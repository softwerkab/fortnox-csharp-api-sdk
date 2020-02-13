using System;
using System.Collections.Generic;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.GeneratedTests
{
    [TestClass]
    public class PriceTests
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
        public void Test_Price_CRUD()
        {
            #region Arrange
            var tmpArticle = new ArticleConnector().Create(new Article() {Description = "TmpArticle"});
            var tmpPriceList = new PriceListConnector().Get("TST_PR") ?? new PriceListConnector().Create(new PriceList() {Code = "TST_PR"});
            #endregion Arrange

            var connector = new PriceConnector();

            #region CREATE
            var newPrice = new Price()
            {
                ArticleNumber = tmpArticle.ArticleNumber,
                PriceList = tmpPriceList.Code,
                FromQuantity = 10,
                PriceValue = 12.5
            };

            var createdPrice = connector.Create(newPrice);
            MyAssert.HasNoError(connector);
            Assert.AreEqual(12.5, createdPrice.PriceValue);

            #endregion CREATE

            #region UPDATE

            createdPrice.PriceValue = 15;

            var updatedPrice = connector.Update(createdPrice); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual(15, updatedPrice.PriceValue);

            #endregion UPDATE

            #region READ / GET

            var retrievedPrice = connector.Get(createdPrice.PriceList, createdPrice.ArticleNumber, createdPrice.FromQuantity);
            MyAssert.HasNoError(connector);
            Assert.AreEqual(15, retrievedPrice.PriceValue);

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdPrice.PriceList, createdPrice.ArticleNumber, createdPrice.FromQuantity);
            MyAssert.HasNoError(connector);

            retrievedPrice = connector.Get(createdPrice.PriceList, createdPrice.ArticleNumber, createdPrice.FromQuantity);
            Assert.AreEqual(null, retrievedPrice, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            new ArticleConnector().Delete(tmpArticle.ArticleNumber);
            #endregion Delete arranged resources
        }
    }
}
