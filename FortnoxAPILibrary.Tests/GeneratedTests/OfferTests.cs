using System;
using System.Collections.Generic;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.GeneratedTests
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
            var tmpArticle = new ArticleConnector().Create(new Article() { Description = "TmpArticle", Type = ArticleType.STOCK, PurchasePrice = 100 });
            #endregion Arrange

            var connector = new OfferConnector();

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
            MyAssert.HasNoError(connector);
            Assert.AreEqual("TestOrder", createdOffer.Comments);
            Assert.AreEqual("TmpCustomer", createdOffer.CustomerName);
            Assert.AreEqual(3, createdOffer.OfferRows.Count);

            #endregion CREATE

            #region UPDATE

            createdOffer.Comments = "UpdatedTestOrder";

            var updatedOffer = connector.Update(createdOffer); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedTestOrder", updatedOffer.Comments);

            #endregion UPDATE

            #region READ / GET

            var retrievedOffer = connector.Get(createdOffer.DocumentNumber);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedTestOrder", retrievedOffer.Comments);

            #endregion READ / GET

            #region DELETE
            //Not allowed
            #endregion DELETE

            #region Delete arranged resources
            new CustomerConnector().Delete(tmpCustomer.CustomerNumber);
            new ArticleConnector().Delete(tmpArticle.ArticleNumber);
            #endregion Delete arranged resources
        }
    }
}
