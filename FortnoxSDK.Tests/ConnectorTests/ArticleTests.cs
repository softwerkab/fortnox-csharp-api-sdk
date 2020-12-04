using System;
using System.Linq;
using Fortnox.SDK;
using Fortnox.SDK.Connectors;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Exceptions;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests
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

            IArticleConnector connector = new ArticleConnector();

            #region CREATE
            var newArticle = new Article()
            {
                Description = "Test Article",
                Height = 60,
                Width = 150,
                Type = ArticleType.Stock,
                PurchasePrice = 2499.50m,
                FreightCost = 200,
                OtherCost = 210,
                Note = "Definitely not worth the price."
            };

            var createdArticle = connector.Create(newArticle);
            Assert.AreEqual("Test Article", createdArticle.Description);
            #endregion CREATE

            #region UPDATE

            createdArticle.Description = "Updated Test Article";

            var updatedArticle = connector.Update(createdArticle); 
            Assert.AreEqual("Updated Test Article", updatedArticle.Description);

            #endregion UPDATE

            #region READ / GET

            var retrievedArticle = connector.Get(createdArticle.ArticleNumber);
            Assert.AreEqual("Updated Test Article", retrievedArticle.Description);

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdArticle.ArticleNumber);

            Assert.ThrowsException<FortnoxApiException>(
                () => connector.Get(createdArticle.ArticleNumber),
                "Entity still exists after Delete!");

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

            IArticleConnector connector = new ArticleConnector();

            var newArticle = new Article
            {
                Description = testKeyMark,
                Height = 60,
                Width = 150,
                Type = ArticleType.Stock,
                PurchasePrice = 2499.50m,
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
            var searchSettings = new ArticleSearch();
            searchSettings.Description = testKeyMark;
            var fullCollection = connector.Find(searchSettings);

            Assert.AreEqual(5, fullCollection.TotalResources);
            Assert.AreEqual(5, fullCollection.Entities.Count);
            Assert.AreEqual(1, fullCollection.TotalPages);

            //Apply Limit
            searchSettings.Limit = 2;
            var limitedCollection = connector.Find(searchSettings);

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

        [TestMethod]
        public void HouseWorkArticle_AllTypes()
        {
            var values = Enum.GetValues(typeof(HouseworkType)).Cast<HouseworkType>().ToList();
            Assert.AreEqual(20,values.Count);

            var connector = new ArticleConnector();
            var article = connector.Create(new Article(){ Description = "HouseworkArticleTest", Housework = true });

            foreach (var houseworkType in values)
            {
                if (houseworkType == HouseworkType.Empty) 
                    continue;
                if (houseworkType == HouseworkType.Cooking || houseworkType == HouseworkType.Tutoring)
                    continue;

                article.HouseworkType = houseworkType;
                article = connector.Update(article);

                Assert.AreEqual(houseworkType, article.HouseworkType);
            }

            connector.Delete(article.ArticleNumber);
        }

        [TestMethod]
        public void HouseWorkArticle_Empty()
        {
            var connector = new ArticleConnector();
            var article = connector.Create(new Article()
            {
                Description = "HouseworkArticleTest", 
                Housework = true,
                HouseworkType = HouseworkType.Cleaning
            });
            Assert.AreEqual(HouseworkType.Cleaning, article.HouseworkType);

            article.HouseworkType = HouseworkType.Empty;
            var updatedArticle = connector.Update(article);
            Assert.AreEqual(null, updatedArticle.HouseworkType);

            connector.Delete(article.ArticleNumber);
        }
    }
}
