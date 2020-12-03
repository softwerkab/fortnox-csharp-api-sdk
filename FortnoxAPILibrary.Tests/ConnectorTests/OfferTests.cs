using System;
using System.Collections.Generic;
using System.Linq;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.Tests.ConnectorTests
{
    [TestClass]
    public class OfferTests
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
        public void Test_Offer_CRUD()
        {
            #region Arrange
            var tmpCustomer = new CustomerConnector().Create(new Customer() { Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis" });
            var tmpArticle = new ArticleConnector().Create(new Article() { Description = "TmpArticle", Type = ArticleType.Stock, PurchasePrice = 100 });
            #endregion Arrange

            IOfferConnector connector = new OfferConnector();

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

            var createdOffer = connector.Create(newOffer);
            Assert.AreEqual("TestOrder", createdOffer.Comments);
            Assert.AreEqual("TmpCustomer", createdOffer.CustomerName);
            Assert.AreEqual(3, createdOffer.OfferRows.Count);

            #endregion CREATE

            #region UPDATE

            createdOffer.Comments = "UpdatedTestOrder";

            var updatedOffer = connector.Update(createdOffer); 
            Assert.AreEqual("UpdatedTestOrder", updatedOffer.Comments);

            #endregion UPDATE

            #region READ / GET

            var retrievedOffer = connector.Get(createdOffer.DocumentNumber);
            Assert.AreEqual("UpdatedTestOrder", retrievedOffer.Comments);

            #endregion READ / GET

            #region DELETE
            //Not allowed
            connector.Cancel(createdOffer.DocumentNumber);

            var cancelledOffer = connector.Get(createdOffer.DocumentNumber);
            Assert.AreEqual(true, cancelledOffer.Cancelled);
            #endregion DELETE

            #region Delete arranged resources
            new CustomerConnector().Delete(tmpCustomer.CustomerNumber);
            //new ArticleConnector().Delete(tmpArticle.ArticleNumber);
            #endregion Delete arranged resources
        }

        [TestMethod]
        public void Test_Find()
        {
            #region Arrange
            var tmpCustomer = new CustomerConnector().Create(new Customer() { Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis" });
            var tmpArticle = new ArticleConnector().Create(new Article() { Description = "TmpArticle", Type = ArticleType.Stock, PurchasePrice = 100 });
            #endregion Arrange

            IOfferConnector connector = new OfferConnector();
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
                connector.Create(newOffer);
            }

            //Apply base test filter
            var searchSettings = new OfferSearch();
            searchSettings.CustomerNumber = tmpCustomer.CustomerNumber;
            var fullCollection = connector.Find(searchSettings);

            Assert.AreEqual(5, fullCollection.TotalResources);
            Assert.AreEqual(5, fullCollection.Entities.Count);
            Assert.AreEqual(1, fullCollection.TotalPages);

            Assert.AreEqual(tmpCustomer.CustomerNumber, fullCollection.Entities.First().CustomerNumber);

            //Apply Limit
            searchSettings.Limit = 2;
            var limitedCollection = connector.Find(searchSettings);

            Assert.AreEqual(5, limitedCollection.TotalResources);
            Assert.AreEqual(2, limitedCollection.Entities.Count);
            Assert.AreEqual(3, limitedCollection.TotalPages);

            //Delete entries (DELETE not supported)
            foreach (var offer in fullCollection.Entities)
                connector.Cancel(offer.DocumentNumber);

            #region Delete arranged resources
            new CustomerConnector().Delete(tmpCustomer.CustomerNumber);
            //new ArticleConnector().Delete(tmpArticle.ArticleNumber);
            #endregion Delete arranged resources
        }

        [TestMethod]
        public void Test_Print()
        {
            #region Arrange
            var tmpCustomer = new CustomerConnector().Create(new Customer() { Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis" });
            var tmpArticle = new ArticleConnector().Create(new Article() { Description = "TmpArticle", Type = ArticleType.Stock, PurchasePrice = 100 });
            #endregion Arrange

            IOfferConnector connector = new OfferConnector();
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

            var createdOffer = connector.Create(newOffer);

            var fileData = connector.Print(createdOffer.DocumentNumber);
            MyAssert.IsPDF(fileData);

            connector.Cancel(createdOffer.DocumentNumber);

            #region Delete arranged resources
            new CustomerConnector().Delete(tmpCustomer.CustomerNumber);
            //new ArticleConnector().Delete(tmpArticle.ArticleNumber);
            #endregion Delete arranged resources
        }

        [TestMethod]
        public void Test_Email()
        {
            #region Arrange
            var tmpCustomer = new CustomerConnector().Create(new Customer() { Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis", Email = "richard.randak@softwerk.se"});
            var tmpArticle = new ArticleConnector().Create(new Article() { Description = "TmpArticle", Type = ArticleType.Stock, PurchasePrice = 100 });
            #endregion Arrange

            IOfferConnector connector = new OfferConnector();
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

            var createdOffer = connector.Create(newOffer);

            var emailedInvoice = connector.Email(createdOffer.DocumentNumber);
            Assert.AreEqual(emailedInvoice.DocumentNumber, createdOffer.DocumentNumber);

            connector.Cancel(createdOffer.DocumentNumber);

            #region Delete arranged resources
            new CustomerConnector().Delete(tmpCustomer.CustomerNumber);
            //new ArticleConnector().Delete(tmpArticle.ArticleNumber);
            #endregion Delete arranged resources
        }
    }
}
