using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fortnox.SDK;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Exceptions;
using Fortnox.SDK.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests
{
    [TestClass]
    public class InvoicePaymentTests
    {
        public FortnoxClient FortnoxClient = TestUtils.DefaultFortnoxClient;

        [TestMethod]
        public async Task Test_InvoicePayment_CRUD()
        {
            #region Arrange

            var tmpCustomer = await FortnoxClient.CustomerConnector.CreateAsync(new Customer()
            { Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis" });
            var tmpArticle = await FortnoxClient.ArticleConnector.CreateAsync(new Article()
            { Description = "TmpArticle", Type = ArticleType.Stock, PurchasePrice = 10 });
            var invoiceConnector = FortnoxClient.InvoiceConnector;
            var tmpInvoice = await invoiceConnector.CreateAsync(new Invoice()
            {
                CustomerNumber = tmpCustomer.CustomerNumber,
                InvoiceDate = new DateTime(2020, 1, 20),
                DueDate = new DateTime(2020, 6, 20),
                InvoiceRows = new List<InvoiceRow>()
                {
                    new InvoiceRow() {ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = 2, Price = 10},
                }
            });
            await invoiceConnector.BookkeepAsync(tmpInvoice.DocumentNumber);
            #endregion Arrange

            var connector = FortnoxClient.InvoicePaymentConnector;

            #region CREATE

            var newInvoicePayment = new InvoicePayment()
            {
                InvoiceNumber = tmpInvoice.DocumentNumber,
                Amount = 10.5m,
                AmountCurrency = 10.5m,
                PaymentDate = new DateTime(2020, 2, 1)
            };

            var createdInvoicePayment = await connector.CreateAsync(newInvoicePayment);
            Assert.AreEqual("2020-02-01", createdInvoicePayment.PaymentDate?.ToString(APIConstants.DateFormat));

            #endregion CREATE

            #region UPDATE

            createdInvoicePayment.PaymentDate = new DateTime(2020, 3, 1);

            var updatedInvoicePayment = await connector.UpdateAsync(createdInvoicePayment);
            Assert.AreEqual("2020-03-01", updatedInvoicePayment.PaymentDate?.ToString(APIConstants.DateFormat));

            #endregion UPDATE

            #region READ / GET

            var retrievedInvoicePayment = await connector.GetAsync(createdInvoicePayment.Number);
            Assert.AreEqual("2020-03-01", retrievedInvoicePayment.PaymentDate?.ToString(APIConstants.DateFormat));

            #endregion READ / GET

            #region DELETE

            await connector.DeleteAsync(createdInvoicePayment.Number);

            Assert.ThrowsException<FortnoxApiException>(
                () => connector.Get(createdInvoicePayment.Number),
                "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            //Can't cancel invoice after it is booked
            //FortnoxClient.InvoiceConnector.Cancel(tmpInvoice.DocumentNumber);
            //FortnoxClient.CustomerConnector.Delete(tmpCustomer.CustomerNumber);
            //FortnoxClient.ArticleConnector.Delete(tmpArticle.ArticleNumber);

            #endregion Delete arranged resources
        }

        [TestMethod]
        public async Task Test_InvoicePayment_Find()
        {
            #region Arrange
            var tmpCustomer = await FortnoxClient.CustomerConnector.CreateAsync(new Customer() { Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis" });
            var tmpArticle = await FortnoxClient.ArticleConnector.CreateAsync(new Article() { Description = "TmpArticle", Type = ArticleType.Stock, PurchasePrice = 10 });
            var invoiceConnector = FortnoxClient.InvoiceConnector;
            var tmpInvoice = await invoiceConnector.CreateAsync(new Invoice()
            {
                CustomerNumber = tmpCustomer.CustomerNumber,
                InvoiceDate = new DateTime(2020, 1, 20),
                DueDate = new DateTime(2020, 6, 20),
                InvoiceRows = new List<InvoiceRow>()
                {
                    new InvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = 2, Price = 10},
                }
            });
            await invoiceConnector.BookkeepAsync(tmpInvoice.DocumentNumber);
            #endregion Arrange

            var connector = FortnoxClient.InvoicePaymentConnector;

            var newInvoicePayment = new InvoicePayment()
            {
                InvoiceNumber = tmpInvoice.DocumentNumber,
                Amount = 10.5m,
                AmountCurrency = 10.5m,
                PaymentDate = new DateTime(2020, 2, 1)
            };

            for (var i = 0; i < 5; i++)
            {
                await connector.CreateAsync(newInvoicePayment);
            }

            var searchSettings = new InvoicePaymentSearch();
            searchSettings.InvoiceNumber = tmpInvoice.DocumentNumber.ToString();
            var payments = await connector.FindAsync(searchSettings);

            Assert.AreEqual(5, payments.Entities.Count);
            Assert.AreEqual(10.5m, payments.Entities.First().Amount);

            foreach (var entity in payments.Entities)
            {
                await connector.DeleteAsync(entity.Number);
            }
        }
    }
}
