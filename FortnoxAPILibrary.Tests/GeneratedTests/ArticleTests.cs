using System;
using System.Collections.Generic;
using System.Net;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.GeneratedTests
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
            #region Arrange
            //Add code to create required resources
            #endregion Arrange

            var connector = new ArticleConnector();

            #region CREATE
            var newArticle = new Article()
            {
                Description = "Test Article",
                Height = 60,
                Width = 150,
                Type = ArticleType.STOCK,
                PurchasePrice = 2499.50,
                FreightCost = 200,
                OtherCost = 210,
                Note = "Definitely not worth the price."
            };

            var createdArticle = connector.Create(newArticle);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("Test Article", createdArticle.Description);
            #endregion CREATE

            #region UPDATE

            createdArticle.Description = "Updated Test Article";

            var updatedArticle = connector.Update(createdArticle); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual("Updated Test Article", updatedArticle.Description);

            #endregion UPDATE

            #region READ / GET

            var retrievedArticle = connector.Get(createdArticle.ArticleNumber);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("Updated Test Article", retrievedArticle.Description);

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdArticle.ArticleNumber);
            MyAssert.HasNoError(connector);

            retrievedArticle = connector.Get(createdArticle.ArticleNumber);
            Assert.AreEqual(null, retrievedArticle, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }

        [TestMethod]
        public void Test_Find()
        {
            #region Arrange
            //Add code to create required resources
            #endregion Arrange

            var testKeyMark = TestUtils.RandomString();

            var connector = new ArticleConnector();
            var newArticle = new Article
            {
                Description = testKeyMark,
                Height = 60,
                Width = 150,
                Type = ArticleType.STOCK,
                PurchasePrice = 2499.50,
                FreightCost = 200,
                OtherCost = 210,
                Note = "Definitely not worth the price."
            };

            //Add entries
            for (var i = 0; i < 5; i++)
            {
                connector.Create(newArticle);
            }

            //Apply base test filter
            connector.Description = testKeyMark;
            var fullCollection = connector.Find();
            MyAssert.HasNoError(connector);

            Assert.AreEqual(5, fullCollection.TotalResources);
            Assert.AreEqual(5, fullCollection.Entities.Count);
            Assert.AreEqual(1, fullCollection.TotalPages);

            //Apply Limit
            connector.Limit = 2;
            var limitedCollection = connector.Find();
            MyAssert.HasNoError(connector);

            Assert.AreEqual(5, limitedCollection.TotalResources);
            Assert.AreEqual(2, limitedCollection.Entities.Count);
            Assert.AreEqual(3, limitedCollection.TotalPages);

            //Delete entries
            foreach (var entry in fullCollection.Entities)
            {
                connector.Delete(entry.ArticleNumber);
            }

            #region Delete arranged resources

            //Add code to delete temporary resources

            #endregion Delete arranged resources
        }
    }
}
