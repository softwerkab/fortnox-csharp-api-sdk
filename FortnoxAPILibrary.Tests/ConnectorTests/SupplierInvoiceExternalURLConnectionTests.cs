using System;
using System.Collections.Generic;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.Tests.ConnectorTests
{
    [TestClass]
    public class SupplierInvoiceExternalURLConnectionTests
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
        public void Test_SupplierInvoiceExternalURLConnection_CRUD()
        {
            #region Arrange
            var tmpSupplier = new SupplierConnector().Create(new Supplier() { Name = "TmpSupplier" });
            var tmpArticle = new ArticleConnector().Create(new Article() { Description = "TmpArticle", PurchasePrice = 100 });
            var tmpSpplierInvoice = new SupplierInvoiceConnector().Create(new SupplierInvoice()
            {
                SupplierNumber = tmpSupplier.SupplierNumber,
                Comments = "InvoiceComments",
                InvoiceDate = new DateTime(2020, 1, 1),
                DueDate = new DateTime(2020, 2, 1),
                SalesType = SalesType.Stock,
                OCR = "123456789",
                Total = 5000,
                SupplierInvoiceRows = new List<SupplierInvoiceRow>()
                {
                    new SupplierInvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, Quantity = 10, Price = 100},
                    new SupplierInvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, Quantity = 20, Price = 100},
                    new SupplierInvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, Quantity = 20, Price = 100}
                }
            });
            #endregion Arrange

            ISupplierInvoiceExternalURLConnectionConnector connector = new SupplierInvoiceExternalURLConnectionConnector();

            #region CREATE
            var newSupplierInvoiceExternalURLConnection = new SupplierInvoiceExternalURLConnection()
            {
                SupplierInvoiceNumber = (int?) tmpSpplierInvoice.GivenNumber,
                ExternalURLConnection = @"http://example.com/image.jpg"
            };

            var createdSupplierInvoiceExternalURLConnection = connector.Create(newSupplierInvoiceExternalURLConnection);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("http://example.com/image.jpg", createdSupplierInvoiceExternalURLConnection.ExternalURLConnection);

            #endregion CREATE

            #region UPDATE

            createdSupplierInvoiceExternalURLConnection.ExternalURLConnection = "http://example.com/image.png";

            var updatedSupplierInvoiceExternalURLConnection = connector.Update(createdSupplierInvoiceExternalURLConnection); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual("http://example.com/image.png", updatedSupplierInvoiceExternalURLConnection.ExternalURLConnection);

            #endregion UPDATE

            #region READ / GET

            var retrievedSupplierInvoiceExternalURLConnection = connector.Get(createdSupplierInvoiceExternalURLConnection.Id);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("http://example.com/image.png", retrievedSupplierInvoiceExternalURLConnection.ExternalURLConnection);

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdSupplierInvoiceExternalURLConnection.Id);
            MyAssert.HasNoError(connector);

            retrievedSupplierInvoiceExternalURLConnection = connector.Get(createdSupplierInvoiceExternalURLConnection.Id);
            Assert.AreEqual(null, retrievedSupplierInvoiceExternalURLConnection, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            new ArticleConnector().Delete(tmpArticle.ArticleNumber);
            new SupplierConnector().Delete(tmpSupplier.SupplierNumber);
            #endregion Delete arranged resources
        }
    }
}
