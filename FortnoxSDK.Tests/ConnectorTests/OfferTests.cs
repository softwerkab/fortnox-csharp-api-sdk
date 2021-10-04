using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fortnox.SDK;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests
{
    [TestClass]
    public class OfferTests
    {
        public FortnoxClient FortnoxClient = TestUtils.DefaultFortnoxClient;

        [TestMethod]
        public async Task Test_Offer_CRUD()
        {
            #region Arrange
            var tmpCustomer = await FortnoxClient.CustomerConnector.CreateAsync(new Customer() { Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis" });
            var tmpArticle = await FortnoxClient.ArticleConnector.CreateAsync(new Article() { Description = "TmpArticle", Type = ArticleType.Stock, PurchasePrice = 100 });
            #endregion Arrange

            var connector = FortnoxClient.OfferConnector;

            #region CREATE
            var newOffer = new Offer()
            {
                Comments = "TestOrder",
                CustomerNumber = tmpCustomer.CustomerNumber,
                OfferDate = new DateTime(2019, 1, 20), //"2019-01-20",
                OfferRows = new List<OfferRow>()
                {
                    new OfferRow(){ ArticleNumber = tmpArticle.ArticleNumber, Quantity = 10},
                    new OfferRow(){ ArticleNumber = tmpArticle.ArticleNumber, Quantity = 20},
                    new OfferRow(){ ArticleNumber = tmpArticle.ArticleNumber, Quantity = 15}
                }
            };

            var createdOffer = await connector.CreateAsync(newOffer);
            Assert.AreEqual("TestOrder", createdOffer.Comments);
            Assert.AreEqual("TmpCustomer", createdOffer.CustomerName);
            Assert.AreEqual(3, createdOffer.OfferRows.Count);

            #endregion CREATE

            #region UPDATE

            createdOffer.Comments = "UpdatedTestOrder";

            var updatedOffer = await connector.UpdateAsync(createdOffer); 
            Assert.AreEqual("UpdatedTestOrder", updatedOffer.Comments);

            #endregion UPDATE

            #region READ / GET

            var retrievedOffer = await connector.GetAsync(createdOffer.DocumentNumber);
            Assert.AreEqual("UpdatedTestOrder", retrievedOffer.Comments);

            #endregion READ / GET

            #region DELETE
            //Not allowed
            await connector.CancelAsync(createdOffer.DocumentNumber);

            var cancelledOffer = await connector.GetAsync(createdOffer.DocumentNumber);
            Assert.AreEqual(true, cancelledOffer.Cancelled);
            #endregion DELETE

            #region Delete arranged resources
            await FortnoxClient.CustomerConnector.DeleteAsync(tmpCustomer.CustomerNumber);
            //FortnoxClient.ArticleConnector.Delete(tmpArticle.ArticleNumber);
            #endregion Delete arranged resources
        }

        [TestMethod]
        public async Task Test_Find()
        {
            #region Arrange
            var tmpCustomer = await FortnoxClient.CustomerConnector.CreateAsync(new Customer() { Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis" });
            var tmpArticle = await FortnoxClient.ArticleConnector.CreateAsync(new Article() { Description = "TmpArticle", Type = ArticleType.Stock, PurchasePrice = 100 });
            #endregion Arrange

            var connector = FortnoxClient.OfferConnector;
            var newOffer = new Offer()
            {
                Comments = "TestOrder",
                CustomerNumber = tmpCustomer.CustomerNumber,
                OfferDate = new DateTime(2019, 1, 20), //"2019-01-20",
                OfferRows = new List<OfferRow>()
                {
                    new OfferRow(){ ArticleNumber = tmpArticle.ArticleNumber, Quantity = 10},
                    new OfferRow(){ ArticleNumber = tmpArticle.ArticleNumber, Quantity = 20},
                    new OfferRow(){ ArticleNumber = tmpArticle.ArticleNumber, Quantity = 15}
                }
            };

            //Add entries
            for (var i = 0; i < 5; i++)
            {
                await connector.CreateAsync(newOffer);
            }

            //Apply base test filter
            var searchSettings = new OfferSearch();
            searchSettings.CustomerNumber = tmpCustomer.CustomerNumber;
            var fullCollection = await connector.FindAsync(searchSettings);

            Assert.AreEqual(5, fullCollection.TotalResources);
            Assert.AreEqual(5, fullCollection.Entities.Count);
            Assert.AreEqual(1, fullCollection.TotalPages);

            Assert.AreEqual(tmpCustomer.CustomerNumber, fullCollection.Entities.First().CustomerNumber);

            //Apply Limit
            searchSettings.Limit = 2;
            var limitedCollection = await connector.FindAsync(searchSettings);

            Assert.AreEqual(5, limitedCollection.TotalResources);
            Assert.AreEqual(2, limitedCollection.Entities.Count);
            Assert.AreEqual(3, limitedCollection.TotalPages);

            //Delete entries (DELETE not supported)
            foreach (var offer in fullCollection.Entities)
                await connector.CancelAsync(offer.DocumentNumber);

            #region Delete arranged resources
            await FortnoxClient.CustomerConnector.DeleteAsync(tmpCustomer.CustomerNumber);
            //FortnoxClient.ArticleConnector.Delete(tmpArticle.ArticleNumber);
            #endregion Delete arranged resources
        }

        [TestMethod]
        public async Task Test_Print()
        {
            #region Arrange
            var tmpCustomer = await FortnoxClient.CustomerConnector.CreateAsync(new Customer() { Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis" });
            var tmpArticle = await FortnoxClient.ArticleConnector.CreateAsync(new Article() { Description = "TmpArticle", Type = ArticleType.Stock, PurchasePrice = 100 });
            #endregion Arrange

            var connector = FortnoxClient.OfferConnector;
            var newOffer = new Offer()
            {
                Comments = "TestOrder",
                CustomerNumber = tmpCustomer.CustomerNumber,
                OfferDate = new DateTime(2019, 1, 20), //"2019-01-20",
                OfferRows = new List<OfferRow>()
                {
                    new OfferRow(){ ArticleNumber = tmpArticle.ArticleNumber, Quantity = 10},
                    new OfferRow(){ ArticleNumber = tmpArticle.ArticleNumber, Quantity = 20},
                    new OfferRow(){ ArticleNumber = tmpArticle.ArticleNumber, Quantity = 15}
                }
            };

            var createdOffer = await connector.CreateAsync(newOffer);

            var fileData = await connector.PrintAsync(createdOffer.DocumentNumber);
            MyAssert.IsPDF(fileData);

            await connector.CancelAsync(createdOffer.DocumentNumber);

            #region Delete arranged resources
            await FortnoxClient.CustomerConnector.DeleteAsync(tmpCustomer.CustomerNumber);
            //FortnoxClient.ArticleConnector.Delete(tmpArticle.ArticleNumber);
            #endregion Delete arranged resources
        }

        [TestMethod]
        public async Task Test_Email()
        {
            #region Arrange
            var tmpCustomer = await FortnoxClient.CustomerConnector.CreateAsync(new Customer() { Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis", Email = "richard.randak@softwerk.se"});
            var tmpArticle = await FortnoxClient.ArticleConnector.CreateAsync(new Article() { Description = "TmpArticle", Type = ArticleType.Stock, PurchasePrice = 100 });
            #endregion Arrange

            var connector = FortnoxClient.OfferConnector;
            var newOffer = new Offer()
            {
                Comments = "TestOrder",
                CustomerNumber = tmpCustomer.CustomerNumber,
                OfferDate = new DateTime(2019, 1, 20), //"2019-01-20",
                OfferRows = new List<OfferRow>()
                {
                    new OfferRow(){ ArticleNumber = tmpArticle.ArticleNumber, Quantity = 10},
                    new OfferRow(){ ArticleNumber = tmpArticle.ArticleNumber, Quantity = 20},
                    new OfferRow(){ ArticleNumber = tmpArticle.ArticleNumber, Quantity = 15}
                }
            };

            var createdOffer = await connector.CreateAsync(newOffer);

            var emailedInvoice = await connector.EmailAsync(createdOffer.DocumentNumber);
            Assert.AreEqual(emailedInvoice.DocumentNumber, createdOffer.DocumentNumber);

            await connector.CancelAsync(createdOffer.DocumentNumber);

            #region Delete arranged resources
            await FortnoxClient.CustomerConnector.DeleteAsync(tmpCustomer.CustomerNumber);
            //FortnoxClient.ArticleConnector.Delete(tmpArticle.ArticleNumber);
            #endregion Delete arranged resources
        }
    }
}
