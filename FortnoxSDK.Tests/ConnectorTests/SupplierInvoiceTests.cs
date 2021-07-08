using System;
using System.Collections.Generic;
using System.Linq;
using Fortnox.SDK;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests
{
    [TestClass]
    public class SupplierInvoiceTests
    {
        public FortnoxClient FortnoxClient = TestUtils.DefaultFortnoxClient;

        [TestMethod]
        public void Test_SupplierInvoice_CRUD()
        {
            #region Arrange
            var tmpSupplier = FortnoxClient.SupplierConnector.Create(new Supplier() {Name = "TmpSupplier"});
            var tmpArticle = FortnoxClient.ArticleConnector.Create(new Article(){Description = "TmpArticle", PurchasePrice = 100});
            #endregion Arrange

            var connector = FortnoxClient.SupplierInvoiceConnector;

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
            Assert.AreEqual("InvoiceComments", createdSupplierInvoice.Comments);
            Assert.AreEqual("TmpSupplier", createdSupplierInvoice.SupplierName);
            Assert.AreEqual(3 + 1, createdSupplierInvoice.SupplierInvoiceRows.Count);
            //3 + 1 => A row "Leverant�rsskulder" is created by default

            #endregion CREATE

            #region UPDATE

            createdSupplierInvoice.Comments = "UpdatedInvoiceComments";

            var updatedSupplierInvoice = connector.Update(createdSupplierInvoice); 
            Assert.AreEqual("UpdatedInvoiceComments", updatedSupplierInvoice.Comments);

            #endregion UPDATE

            #region READ / GET

            var retrievedSupplierInvoice = connector.Get(createdSupplierInvoice.GivenNumber);
            Assert.AreEqual("UpdatedInvoiceComments", retrievedSupplierInvoice.Comments);

            #endregion READ / GET

            #region DELETE
            //Not supported
            connector.Cancel(createdSupplierInvoice.GivenNumber);
            var cancelledInvoice = connector.Get(createdSupplierInvoice.GivenNumber);
            Assert.AreEqual(true, cancelledInvoice.Cancelled);
            #endregion DELETE

            #region Delete arranged resources
            FortnoxClient.SupplierConnector.Delete(tmpSupplier.SupplierNumber);
            FortnoxClient.ArticleConnector.Delete(tmpArticle.ArticleNumber);
            #endregion Delete arranged resources
        }

        [TestMethod]
        public void Test_Find()
        {
            #region Arrange
            var tmpSupplier = FortnoxClient.SupplierConnector.Create(new Supplier() { Name = "TmpSupplier" });
            var tmpArticle = FortnoxClient.ArticleConnector.Create(new Article() { Description = "TmpArticle", PurchasePrice = 100 });
            #endregion Arrange

            var connector = FortnoxClient.SupplierInvoiceConnector;
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
            }

            //Apply base test filter
            var searchSettings = new SupplierInvoiceSearch();
            searchSettings.SupplierNumber = tmpSupplier.SupplierNumber;
            var fullCollection = connector.Find(searchSettings);

            Assert.AreEqual(5, fullCollection.TotalResources);
            Assert.AreEqual(5, fullCollection.Entities.Count);
            Assert.AreEqual(1, fullCollection.TotalPages);

            Assert.AreEqual(tmpSupplier.SupplierNumber, fullCollection.Entities.First().SupplierNumber);

            //Apply Limit
            searchSettings.Limit = 2;
            var limitedCollection = connector.Find(searchSettings);

            Assert.AreEqual(5, limitedCollection.TotalResources);
            Assert.AreEqual(2, limitedCollection.Entities.Count);
            Assert.AreEqual(3, limitedCollection.TotalPages);

            //Delete entries (DELETE not supported)
            foreach (var invoice in fullCollection.Entities)
                connector.Cancel(invoice.GivenNumber);

            #region Delete arranged resources
            FortnoxClient.SupplierConnector.Delete(tmpSupplier.SupplierNumber);
            FortnoxClient.ArticleConnector.Delete(tmpArticle.ArticleNumber);
            #endregion Delete arranged resources
        }

        [TestMethod]
        public void Test_Book()
        {
            #region Arrange
            var tmpSupplier = FortnoxClient.SupplierConnector.Create(new Supplier() { Name = "TmpSupplier" });
            var tmpArticle = FortnoxClient.ArticleConnector.Create(new Article() { Description = "TmpArticle", PurchasePrice = 100 });
            #endregion Arrange

            var connector = FortnoxClient.SupplierInvoiceConnector;

            var newSupplierInvoice = new SupplierInvoice()
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
            };

            var createdSupplierInvoice = connector.Create(newSupplierInvoice);

            //Act
            connector.Bookkeep(createdSupplierInvoice.GivenNumber);
            var bookedInvoice = connector.Get(createdSupplierInvoice.GivenNumber);

            //Assert
            Assert.AreEqual(true, bookedInvoice.Booked);
            Assert.AreEqual(1, bookedInvoice.Vouchers.Count);
            Assert.AreEqual(ReferenceType.SupplierInvoice, bookedInvoice.Vouchers.First().ReferenceType);

            #region Delete arranged resources
            //Can not cancel booked invoice
/*            connector.Cancel(createdSupplierInvoice.GivenNumber);
            FortnoxClient.SupplierConnector.Delete(tmpSupplier.SupplierNumber);
            FortnoxClient.ArticleConnector.Delete(tmpArticle.ArticleNumber);*/
            #endregion Delete arranged resources
        }
    }
}
