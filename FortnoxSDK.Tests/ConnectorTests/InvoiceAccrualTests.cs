using System;
using System.Collections.Generic;
using System.Linq;
using Fortnox.SDK;
using Fortnox.SDK.Connectors;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Exceptions;
using Fortnox.SDK.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests
{
    [TestClass]
    public class InvoiceAccrualTests
    {
        public FortnoxClient FortnoxClient = TestUtils.DefaultFortnoxClient;

        [TestMethod]
        public void Test_InvoiceAccrual_CRUD()
        {
            #region Arrange
            var tmpCustomer = FortnoxClient.CustomerConnector.Create(new Customer() { Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis" });
            var tmpArticle = FortnoxClient.ArticleConnector.Create(new Article() { Description = "TmpArticle", Type = ArticleType.Stock, PurchasePrice = 100 });

            var tmpInvoice = FortnoxClient.InvoiceConnector.Create(new Invoice()
            {
                CustomerNumber = tmpCustomer.CustomerNumber,
                InvoiceDate = new DateTime(2019, 1, 20), //"2019-01-20",
                DueDate = new DateTime(2019, 2, 20), //"2019-02-20",
                Comments = "TestInvoice",
                InvoiceRows = new List<InvoiceRow>()
                {
                    new InvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = 6, Price = 1000},
                }
            });
            #endregion Arrange

            IInvoiceAccrualConnector connector = FortnoxClient.InvoiceAccrualConnector;

            #region CREATE
            var newInvoiceAccrual = new InvoiceAccrual()
            {
                Description = "TestInvoiceAccrual",
                InvoiceNumber = tmpInvoice.DocumentNumber,
                Period = "MONTHLY",
                AccrualAccount = 2990,
                RevenueAccount = 3990,
                StartDate = new DateTime(2020,3,25),
                EndDate = new DateTime(2020, 6, 25),
                Total = 6000,
                InvoiceAccrualRows = new List<InvoiceAccrualRow>()
                {
                    new InvoiceAccrualRow(){ Account = 2990, Credit = 0, Debit = 2000 },
                    new InvoiceAccrualRow(){ Account = 3990, Credit = 2000, Debit = 0 }
                }
            };

            var createdInvoiceAccrual = connector.Create(newInvoiceAccrual);
            Assert.AreEqual("TestInvoiceAccrual", createdInvoiceAccrual.Description);

            #endregion CREATE

            #region UPDATE

            createdInvoiceAccrual.Description = "UpdatedTestInvoiceAccrual";

            var updatedInvoiceAccrual = connector.Update(createdInvoiceAccrual); 
            Assert.AreEqual("UpdatedTestInvoiceAccrual", updatedInvoiceAccrual.Description);

            #endregion UPDATE

            #region READ / GET

            var retrievedInvoiceAccrual = connector.Get(createdInvoiceAccrual.InvoiceNumber);
            Assert.AreEqual("UpdatedTestInvoiceAccrual", retrievedInvoiceAccrual.Description);

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdInvoiceAccrual.InvoiceNumber);

            Assert.ThrowsException<FortnoxApiException>(
                () => connector.Get(createdInvoiceAccrual.InvoiceNumber),
                "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources

            FortnoxClient.InvoiceConnector.Cancel(tmpInvoice.DocumentNumber);
            //FortnoxClient.CustomerConnector.Delete(tmpCustomer.CustomerNumber);
            //FortnoxClient.ArticleConnector.Delete(tmpArticle.ArticleNumber);
            #endregion Delete arranged resources
        }

        [TestMethod]
        public void Test_InvoiceAccrual_Find()
        {
            #region Arrange
            var tmpCustomer = FortnoxClient.CustomerConnector.Create(new Customer() { Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis" });
            var tmpArticle = FortnoxClient.ArticleConnector.Create(new Article() { Description = "TmpArticle", Type = ArticleType.Stock, PurchasePrice = 100 });

            #endregion Arrange

            IInvoiceAccrualConnector connector = FortnoxClient.InvoiceAccrualConnector;

            var invoice = new Invoice()
            {
                CustomerNumber = tmpCustomer.CustomerNumber,
                InvoiceDate = new DateTime(2019, 1, 20), //"2019-01-20",
                DueDate = new DateTime(2019, 2, 20), //"2019-02-20",
                Comments = "TestInvoice",
                InvoiceRows = new List<InvoiceRow>()
                {
                    new InvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = 6, Price = 1000},
                }
            };

            var marks = TestUtils.RandomString();
            var newInvoiceAccrual = new InvoiceAccrual()
            {
                Description = marks,
                Period = "MONTHLY",
                AccrualAccount = 2990,
                RevenueAccount = 3990,
                StartDate = new DateTime(2020, 3, 25),
                EndDate = new DateTime(2020, 6, 25),
                Total = 6000,
                InvoiceAccrualRows = new List<InvoiceAccrualRow>()
                {
                    new InvoiceAccrualRow(){ Account = 2990, Credit = 0, Debit = 2000 },
                    new InvoiceAccrualRow(){ Account = 3990, Credit = 2000, Debit = 0 }
                }
            };

            for (var i = 0; i < 5; i++)
            {
                var createdInvoice = FortnoxClient.InvoiceConnector.Create(invoice);

                newInvoiceAccrual.InvoiceNumber = createdInvoice.DocumentNumber;
                connector.Create(newInvoiceAccrual);
            }

            var contractAccruals = connector.Find(null);
            Assert.AreEqual(5, contractAccruals.Entities.Count(x => x.Description.StartsWith(marks)));

            foreach (var entry in contractAccruals.Entities.Where(x => x.Description.StartsWith(marks)))
            {
                connector.Delete(entry.InvoiceNumber);
                FortnoxClient.InvoiceConnector.Cancel(entry.InvoiceNumber);
            }

            #region Delete arranged resources
            //FortnoxClient.ArticleConnector.Delete(tmpArticle.ArticleNumber);
            FortnoxClient.CustomerConnector.Delete(tmpCustomer.CustomerNumber);
            #endregion Delete arranged resources
        }
    }
}
