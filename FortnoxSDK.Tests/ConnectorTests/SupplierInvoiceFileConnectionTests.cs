using System;
using System.Collections.Generic;
using Fortnox.SDK;
using Fortnox.SDK.Connectors;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Exceptions;
using Fortnox.SDK.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests
{
    [TestClass]
    public class SupplierInvoiceFileConnectionTests
    {
        public FortnoxClient FortnoxClient = TestUtils.DefaultFortnoxClient;

        [TestMethod]
        public void Test_SupplierInvoiceFileConnection_CRUD()
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
            var tmpFile = new InboxConnector().UploadFile("tmpImage.png", Resource.fortnox_image, StaticFolders.SupplierInvoices);
            #endregion Arrange

            ISupplierInvoiceFileConnectionConnector connector = new SupplierInvoiceFileConnectionConnector();

            #region CREATE
            var newSupplierInvoiceFileConnection = new SupplierInvoiceFileConnection()
            {
                SupplierInvoiceNumber = tmpSpplierInvoice.GivenNumber.ToString(),
                FileId = tmpFile.Id
            };

            var createdSupplierInvoiceFileConnection = connector.Create(newSupplierInvoiceFileConnection);
            Assert.AreEqual(tmpSupplier.Name, createdSupplierInvoiceFileConnection.SupplierName);

            #endregion CREATE

            #region UPDATE
            //Not supported
            #endregion UPDATE

            #region READ / GET

            var retrievedSupplierInvoiceFileConnection = connector.Get(createdSupplierInvoiceFileConnection.FileId);
            Assert.AreEqual(tmpSupplier.Name, retrievedSupplierInvoiceFileConnection.SupplierName);

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdSupplierInvoiceFileConnection.FileId);

            Assert.ThrowsException<FortnoxApiException>(
                () => connector.Get(createdSupplierInvoiceFileConnection.FileId),
                "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            new SupplierInvoiceConnector().Cancel(tmpSpplierInvoice.GivenNumber);
            new ArticleConnector().Delete(tmpArticle.ArticleNumber);
            new SupplierConnector().Delete(tmpSupplier.SupplierNumber);
            #endregion Delete arranged resources
        }
    }
}
