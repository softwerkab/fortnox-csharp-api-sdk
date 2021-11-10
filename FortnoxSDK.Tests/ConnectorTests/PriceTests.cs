using System.Linq;
using System.Threading.Tasks;
using Fortnox.SDK;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Exceptions;
using Fortnox.SDK.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests;

[TestClass]
public class PriceTests
{
    public FortnoxClient FortnoxClient = TestUtils.DefaultFortnoxClient;

    [TestMethod]
    public async Task Test_Price_CRUD()
    {
        #region Arrange
        var tmpArticle = await FortnoxClient.ArticleConnector.CreateAsync(new Article() { Description = "TmpArticle" });
        var tmpPriceList = await FortnoxClient.PriceListConnector.GetAsync("TST_PR");
        #endregion Arrange

        var connector = FortnoxClient.PriceConnector;

        #region CREATE
        var newPrice = new Price()
        {
            ArticleNumber = tmpArticle.ArticleNumber,
            PriceList = tmpPriceList.Code,
            FromQuantity = 1,
            PriceValue = 12.5m
        };

        var createdPrice = await connector.CreateAsync(newPrice);
        Assert.AreEqual(12.5m, createdPrice.PriceValue);

        #endregion CREATE

        #region UPDATE

        createdPrice.PriceValue = 15;

        var updatedPrice = await connector.UpdateAsync(createdPrice);
        Assert.AreEqual(15, updatedPrice.PriceValue);

        #endregion UPDATE

        #region READ / GET

        var retrievedPrice = await connector.GetAsync(createdPrice.PriceList, createdPrice.ArticleNumber, createdPrice.FromQuantity);
        Assert.AreEqual(15, retrievedPrice.PriceValue);

        #endregion READ / GET

        #region DELETE

        await connector.DeleteAsync(createdPrice.PriceList, createdPrice.ArticleNumber, createdPrice.FromQuantity);

        Assert.ThrowsException<FortnoxApiException>(
            () => connector.Get(createdPrice.PriceList, createdPrice.ArticleNumber, createdPrice.FromQuantity),
            "Entity still exists after Delete!");

        #endregion DELETE

        #region Delete arranged resources
        await FortnoxClient.ArticleConnector.DeleteAsync(tmpArticle.ArticleNumber);
        #endregion Delete arranged resources
    }

    [TestMethod]
    public async Task Test_Find()
    {
        #region Arrange
        var tmpArticle = await FortnoxClient.ArticleConnector.CreateAsync(new Article() { Description = "TmpArticle", PurchasePrice = 10 });
        var tmpPriceList = await FortnoxClient.PriceListConnector.GetAsync("TST_PR");
        #endregion Arrange

        var connector = FortnoxClient.PriceConnector;

        var newPrice = new Price()
        {
            ArticleNumber = tmpArticle.ArticleNumber,
            PriceList = tmpPriceList.Code,
            PriceValue = 100,
            FromQuantity = 0
        };

        //Add entries
        for (var i = 0; i < 5; i++)
        {
            newPrice.PriceValue -= 10;
            newPrice.FromQuantity += 10;
            await connector.CreateAsync(newPrice);
        }

        var searchSettings = new PriceSearch();
        searchSettings.LastModified = TestUtils.Recently;
        var fullCollection = await connector.FindAsync(tmpPriceList.Code, tmpArticle.ArticleNumber, searchSettings);

        Assert.AreEqual(5 + 1, fullCollection.TotalResources);
        Assert.AreEqual(5 + 1, fullCollection.Entities.Count);
        Assert.AreEqual(1, fullCollection.TotalPages);

        Assert.AreEqual("TST_PR", fullCollection.Entities.First().PriceList);

        //Apply Limit
        searchSettings.Limit = 2;
        var limitedCollection = await connector.FindAsync(tmpPriceList.Code, tmpArticle.ArticleNumber, searchSettings);

        Assert.AreEqual(5 + 1, limitedCollection.TotalResources);
        Assert.AreEqual(2, limitedCollection.Entities.Count);
        Assert.AreEqual(3, limitedCollection.TotalPages);

        //Delete entries
        foreach (var entry in fullCollection.Entities)
        {
            if (entry.FromQuantity == 0)
                continue; //base price
            await connector.DeleteAsync(entry.PriceList, entry.ArticleNumber, entry.FromQuantity);
        }

        #region Delete arranged resources
        await FortnoxClient.ArticleConnector.DeleteAsync(tmpArticle.ArticleNumber);
        #endregion Delete arranged resources
    }
}