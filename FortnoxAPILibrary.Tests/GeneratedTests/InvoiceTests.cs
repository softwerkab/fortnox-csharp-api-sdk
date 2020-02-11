using System;
using System.Collections.Generic;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.GeneratedTests
{
    [TestClass]
    public class InvoiceTests
    {
        [TestInitialize]
        public void Init()
        {
            //Set global credentials for SDK
            //--- Open 'TestCredentials.resx' to edit the values ---\\
            ConnectionCredentials.AccessToken = TestCredentials.Access_Token;
            ConnectionCredentials.ClientSecret = TestCredentials.Client_Secret;
        }

        [TestMethod]
        public void Test_Invoice_CRUD()
        {
            #region Arrange
            var tmpCustomer = new CustomerConnector().Create(new Customer() { Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis" });
            var tmpArticle = new ArticleConnector().Create(new Article() { Description = "TmpArticle", Type = ArticleType.STOCK, PurchasePrice = 100 });
            #endregion Arrange

            var connector = new InvoiceConnector();

            #region CREATE
            var newInvoice = new Invoice()
            {
                CustomerNumber = tmpCustomer.CustomerNumber,
                InvoiceDate = new DateTime(2019, 1, 20), //"2019-01-20",
                DueDate = new DateTime(2019, 2, 20), //"2019-02-20",
                InvoiceType = InvoiceType.CASHINVOICE,
                PaymentWay = "CASH",
                Comments = "TestInvoice",
                InvoiceRows = new List<InvoiceRow>()
                {
                    new InvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = 10},
                    new InvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = 20},
                    new InvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = 15}
                }
            };

            var createdInvoice = connector.Create(newInvoice);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("TestInvoice", createdInvoice.Comments);
            Assert.AreEqual("TmpCustomer", createdInvoice.CustomerName);
            Assert.AreEqual(3, createdInvoice.InvoiceRows.Count);

            #endregion CREATE

            #region UPDATE

            createdInvoice.Comments = "UpdatedInvoice";

            var updatedInvoice = connector.Update(createdInvoice); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedInvoice", updatedInvoice.Comments);

            #endregion UPDATE

            #region READ / GET

            var retrievedInvoice = connector.Get(createdInvoice.DocumentNumber);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedInvoice", retrievedInvoice.Comments);

            #endregion READ / GET

            #region DELETE
            //Not available
            #endregion DELETE

            #region Delete arranged resources
            new CustomerConnector().Delete(tmpCustomer.CustomerNumber);
            new ArticleConnector().Delete(tmpArticle.ArticleNumber);
            #endregion Delete arranged resources
        }
    }
}
