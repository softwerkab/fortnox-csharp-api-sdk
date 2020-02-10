using System;
using System.Collections.Generic;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.Tests
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
            //Arrange
            var tmpCustomer = new CustomerConnector().Create(new Customer() { Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis" });
            var tmpArticle = new ArticleConnector().Create(new Article() { Description = "TmpArticle", Type = ArticleType.STOCK, PurchasePrice = 100 });

            //Act
            var connector = new OfferConnector();

            #region CREATE
            var newOffer = new Offer()
            {
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
            MyAssert.HasNoError(connector);
            Assert.AreEqual(createdOffer.CustomerName, "TmpCustomer");
            Assert.AreEqual(3, createdOffer.OfferRows.Count);

            #endregion CREATE

            #region UPDATE

            createdOffer.City = "UpdatedCity";

            var updatedOffer = connector.Update(createdOffer);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedCity", updatedOffer.City);

            #endregion UPDATE

            #region READ / GET

            var retrievedOffer = connector.Get(createdOffer.DocumentNumber);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedCity", retrievedOffer.City);

            #endregion READ / GET

            #region DELETE
            //Offer does not provide DELETE method, but can be canceled
            connector.Cancel(createdOffer.DocumentNumber);
            MyAssert.HasNoError(connector);

            retrievedOffer = connector.Get(createdOffer.DocumentNumber);
            Assert.AreEqual(true, retrievedOffer.Cancelled);

            #endregion DELETE

            //Clean
            new CustomerConnector().Delete(tmpCustomer.CustomerNumber);
            new ArticleConnector().Delete(tmpArticle.ArticleNumber);
        }
    }
}
