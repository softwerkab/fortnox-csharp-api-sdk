using System.Linq;
using System.Threading.Tasks;
using Fortnox.SDK;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests;

[Ignore("Test environment exceeded limit of 250 price lists.")]
[TestClass]
public class PriceListTests
{
    private FortnoxClient FortnoxClient;

    [TestInitialize]
    public async Task TestInitialize()
    {
        FortnoxClient ??= await TestClient.GetFortnoxClient();
    }

    [TestMethod]
    public async Task Test_PriceList_CRUD()
    {
        #region Arrange
        #endregion Arrange

        var connector = FortnoxClient.PriceListConnector;

        #region CREATE
        var newPriceList = new PriceList()
        {
            Code = TestUtils.RandomString().ToUpperInvariant(),
            Description = "TestPriceList",
            Comments = "Some comments"
        };

        var createdPriceList = await connector.CreateAsync(newPriceList);
        Assert.AreEqual("TestPriceList", createdPriceList.Description);

        #endregion CREATE

        #region UPDATE

        createdPriceList.Description = "UpdatedTestPriceList";

        var updatedPriceList = await connector.UpdateAsync(createdPriceList);
        Assert.AreEqual("UpdatedTestPriceList", updatedPriceList.Description);

        #endregion UPDATE

        #region READ / GET

        var retrievedPriceList = await connector.GetAsync(createdPriceList.Code);
        Assert.AreEqual("UpdatedTestPriceList", retrievedPriceList.Description);

        #endregion READ / GET

        #region DELETE
        //Not available
        #endregion DELETE

        #region Delete arranged resources
        //Add code to delete temporary resources
        #endregion Delete arranged resources
    }

    [TestMethod]
    public async Task Test_PriceList_Find()
    {
        var connector = FortnoxClient.PriceListConnector;

        var newPriceList = new PriceList()
        {
            Description = "TestPriceList",
            Comments = "EntryForFindRequest"
        };

        for (var i = 0; i < 5; i++)
        {
            newPriceList.Code = TestUtils.RandomString().ToUpperInvariant();
            await connector.CreateAsync(newPriceList);
        }

        var searchSettings = new PriceListSearch();
        searchSettings.LastModified = TestUtils.Recently;
        var fullCollection = await connector.FindAsync(searchSettings);

        Assert.AreEqual(5, fullCollection.TotalResources);
        Assert.AreEqual(5, fullCollection.Entities.Count);
        Assert.AreEqual(5, fullCollection.Entities.Count(e => e.Comments == "EntryForFindRequest"));

        //Apply Limit
        searchSettings.Limit = 2;
        var limitedCollection = await connector.FindAsync(searchSettings);

        //Assert.AreEqual(5, limitedCollection.TotalResources);
        Assert.AreEqual(2, limitedCollection.Entities.Count);
        //Assert.AreEqual(3, limitedCollection.TotalPages);
    }
}