using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;

namespace FortnoxAPILibrary.Tests
{
    [TestClass]
    public class ArticleTests
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
        public void Test_Article_CRUD()
        {
            var connector = new ArticleConnector();

            #region CREATE
            var newArticle = new Article
            {
                Description = "Test Article",
                Height = "60",
                Width = "150",
                Type = ArticleType.STOCK,
                PurchasePrice = "2499.50",
                FreightCost = "200",
                OtherCost = "210",
                Note = "Definitely not worth the price."
            };

            //Act
            var createdArticle = connector.Create(newArticle);
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'.");
            Assert.AreEqual("Test Article", createdArticle.Description);

            #endregion CREATE

            #region UPDATE

            createdArticle.Description = "Updated Test Article";

            var updatedArticle = connector.Update(createdArticle);
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'.");
            Assert.AreEqual("Updated Test Article", updatedArticle.Description);

            #endregion UPDATE

            #region READ / GET

            var retrievedArticle = connector.Get(createdArticle.ArticleNumber);
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'.");
            Assert.AreEqual("Updated Test Article", retrievedArticle.Description);

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdArticle.ArticleNumber);
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'.");

            retrievedArticle = connector.Get(createdArticle.ArticleNumber);
            Assert.AreEqual(null, retrievedArticle, "Entity still exists after Delete!");

            #endregion DELETE
        }
    }
}
