using System.Linq;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.Tests.ConnectorTests
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
            var tmpPriceList = new PriceListConnector().Get("TST_PR") ?? new PriceListConnector().Create(new PriceList() {Code = "TST_PR", Description = "TmpPriceList"});
            #endregion Arrange

            IPriceConnector connector = new PriceConnector();

            #region CREATE
            var newPrice = new Price()
            {
                ArticleNumber = tmpArticle.ArticleNumber,
                PriceList = tmpPriceList.Code,
                FromQuantity = 1,
                PriceValue = 12.5m
            };

            var createdPrice = connector.Create(newPrice);
            MyAssert.HasNoError(connector);
            Assert.AreEqual(12.5m, createdPrice.PriceValue);

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

        [TestMethod]
        public void Test_Find()
        {
            #region Arrange
            var tmpArticle = new ArticleConnector().Create(new Article() { Description = "TmpArticle", PurchasePrice = 10});
            var tmpPriceList = new PriceListConnector().Get("TST_PR") ?? new PriceListConnector().Create(new PriceList() { Code = "TST_PR", Description = "TmpPriceList" });
            #endregion Arrange
            
            IPriceConnector connector = new PriceConnector();

            var newPrice = new Price()
            {
                ArticleNumber = tmpArticle.ArticleNumber,
                PriceList = tmpPriceList.Code,
                PriceValue = 100,
                FromQuantity = 0
            };
            connector.Create(newPrice);
            
            //Add entries
            for (var i = 0; i < 5; i++)
            {
                connector.Create(newPrice);

                newPrice.PriceValue -= 10;
                newPrice.FromQuantity += 10;
            }

            var fullCollection = connector.Find(tmpPriceList.Code, tmpArticle.ArticleNumber);
            MyAssert.HasNoError(connector);

            Assert.AreEqual(5, fullCollection.TotalResources);
            Assert.AreEqual(5, fullCollection.Entities.Count);
            Assert.AreEqual(1, fullCollection.TotalPages);

            Assert.AreEqual("TST_PR", fullCollection.Entities.First().PriceList);

            //Apply Limit
            connector.Limit = 2;
            var limitedCollection = connector.Find(tmpPriceList.Code, tmpArticle.ArticleNumber);
            MyAssert.HasNoError(connector);

            Assert.AreEqual(5, limitedCollection.TotalResources);
            Assert.AreEqual(2, limitedCollection.Entities.Count);
            Assert.AreEqual(3, limitedCollection.TotalPages);

            //Delete entries
            foreach (var entry in fullCollection.Entities)
            {
                connector.Delete(entry.PriceList, entry.ArticleNumber, entry.FromQuantity);
            }

            #region Delete arranged resources
            new ArticleConnector().Delete(tmpArticle.ArticleNumber);
            #endregion Delete arranged resources
        }
    }
}
