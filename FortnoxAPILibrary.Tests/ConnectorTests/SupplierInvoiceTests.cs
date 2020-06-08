using System;
using System.Collections.Generic;
using System.Linq;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.Tests.ConnectorTests
{
    [TestClass]
    public class SupplierInvoiceTests
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
        public void Test_SupplierInvoice_CRUD()
        {
            #region Arrange
            var tmpSupplier = new SupplierConnector().Create(new Supplier() {Name = "TmpSupplier"});
            var tmpArticle = new ArticleConnector().Create(new Article(){Description = "TmpArticle", PurchasePrice = 100});
            #endregion Arrange

            ISupplierInvoiceConnector connector = new SupplierInvoiceConnector();

            #region CREATE
            var newSupplierInvoice = new SupplierInvoice()
            {
                SupplierNumber = tmpSupplier.SupplierNumber,
                Comments = "InvoiceComments",
                InvoiceDate = new DateTime(2010,1,1),
                DueDate = new DateTime(2010,2,1),
                SalesType = SalesType.Stock,
                OCR = "123456789",
                Total = 5000,
                SupplierInvoiceRows = new List<SupplierInvoiceRow>()
                {
                    new SupplierInvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, Quantity = 10, Price = 100},
                    new SupplierInvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, Quantity = 20, Price = 100},
                    new SupplierInvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, Quantity = 20, Price = 100}
                }
            };

            var createdSupplierInvoice = connector.Create(newSupplierInvoice);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("InvoiceComments", createdSupplierInvoice.Comments);
            Assert.AreEqual("TmpSupplier", createdSupplierInvoice.SupplierName);
            Assert.AreEqual(3 + 1, createdSupplierInvoice.SupplierInvoiceRows.Count);
            //3 + 1 => A row "Leverant�rsskulder" is created by default

            #endregion CREATE

            #region UPDATE

            createdSupplierInvoice.Comments = "UpdatedInvoiceComments";

            var updatedSupplierInvoice = connector.Update(createdSupplierInvoice); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedInvoiceComments", updatedSupplierInvoice.Comments);

            #endregion UPDATE

            #region READ / GET

            var retrievedSupplierInvoice = connector.Get(createdSupplierInvoice.GivenNumber);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedInvoiceComments", retrievedSupplierInvoice.Comments);

            #endregion READ / GET

            #region DELETE
            //Not supported
            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }

        [TestMethod]
        public void Test_Find()
        {
            #region Arrange
            var tmpSupplier = new SupplierConnector().Create(new Supplier() { Name = "TmpSupplier" });
            var tmpArticle = new ArticleConnector().Create(new Article() { Description = "TmpArticle", PurchasePrice = 100 });
            #endregion Arrange

            ISupplierInvoiceConnector connector = new SupplierInvoiceConnector();
            var newSupplierInvoice = new SupplierInvoice()
            {
                SupplierNumber = tmpSupplier.SupplierNumber,
                Comments = "InvoiceComments",
                InvoiceDate = new DateTime(2010, 1, 1),
                DueDate = new DateTime(2010, 2, 1),
                SalesType = SalesType.Stock,
                OCR = "123456789",
                Total = 5000,
                SupplierInvoiceRows = new List<SupplierInvoiceRow>()
                {
                    new SupplierInvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, Quantity = 10, Price = 100},
                    new SupplierInvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, Quantity = 20, Price = 100},
                    new SupplierInvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, Quantity = 20, Price = 100}
                }
            };

            //Add entries
            for (var i = 0; i < 5; i++)
            {
                connector.Create(newSupplierInvoice);
                MyAssert.HasNoError(connector);
            }

            //Apply base test filter
            connector.SupplierNumber = tmpSupplier.SupplierNumber;
            var fullCollection = connector.Find();
            MyAssert.HasNoError(connector);

            Assert.AreEqual(5, fullCollection.TotalResources);
            Assert.AreEqual(5, fullCollection.Entities.Count);
            Assert.AreEqual(1, fullCollection.TotalPages);

            Assert.AreEqual(tmpSupplier.SupplierNumber, fullCollection.Entities.First().SupplierNumber);

            //Apply Limit
            connector.Limit = 2;
            var limitedCollection = connector.Find();
            MyAssert.HasNoError(connector);

            Assert.AreEqual(5, limitedCollection.TotalResources);
            Assert.AreEqual(2, limitedCollection.Entities.Count);
            Assert.AreEqual(3, limitedCollection.TotalPages);

            //Delete entries (DELETE not supported)

            #region Delete arranged resources
            new CustomerConnector().Delete(tmpSupplier.SupplierNumber);
            new ArticleConnector().Delete(tmpArticle.ArticleNumber);
            #endregion Delete arranged resources
        }
    }
}