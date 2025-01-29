using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fortnox.SDK;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Exceptions;
using Fortnox.SDK.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests;

[TestClass]
public class WayOfDeliveryTests
{
    public FortnoxClient FortnoxClient = TestUtils.DefaultFortnoxClient;

    [TestMethod]
    public async Task Test_WayOfDelivery_CRUD()
    {
        #region Arrange
        //Add code to create required resources
        #endregion Arrange

        var connector = FortnoxClient.WayOfDeliveryConnector;

        #region CREATE
        var newWayOfDelivery = new WayOfDelivery()
        {
            Code = "TST",
            Description = "TestDeliveryMethod"
        };

        var createdWayOfDelivery = await connector.CreateAsync(newWayOfDelivery);
        Assert.AreEqual("TestDeliveryMethod", createdWayOfDelivery.Description);

        #endregion CREATE

        #region UPDATE

        createdWayOfDelivery.Description = "UpdatedTestDeliveryMethod";

        var updatedWayOfDelivery = await connector.UpdateAsync(createdWayOfDelivery);
        Assert.AreEqual("UpdatedTestDeliveryMethod", updatedWayOfDelivery.Description);

        #endregion UPDATE

        #region READ / GET

        var retrievedWayOfDelivery = await connector.GetAsync(createdWayOfDelivery.Code);
        Assert.AreEqual("UpdatedTestDeliveryMethod", retrievedWayOfDelivery.Description);

        #endregion READ / GET

        #region DELETE

        await connector.DeleteAsync(createdWayOfDelivery.Code);

        await Assert.ThrowsExceptionAsync<FortnoxApiException>(
            async () => await connector.GetAsync(createdWayOfDelivery.Code),
            "Entity still exists after Delete!");

        #endregion DELETE

        #region Delete arranged resources
        //Add code to delete temporary resources
        #endregion Delete arranged resources
    }

    [TestMethod]
    public async Task Test_WayOfDelivery_Find()
    {
        var connector = FortnoxClient.WayOfDeliveryConnector;

        var existingCount = (await connector.FindAsync(null)).Entities.Count;
        var testKeyMark = TestUtils.RandomString();

        var createdEntries = new List<WayOfDelivery>();
        //Add entries
        for (var i = 0; i < 5; i++)
        {
            var createdEntry = await connector.CreateAsync(new WayOfDelivery() { Code = TestUtils.RandomString(), Description = testKeyMark });
            createdEntries.Add(createdEntry);
        }

        //Filter not supported
        var fullCollection = await connector.FindAsync(null);

        Assert.AreEqual(existingCount + 5, fullCollection.Entities.Count);
        Assert.AreEqual(5, fullCollection.Entities.Count(e => e.Description == testKeyMark));

        //Apply Limit
        var searchSettings = new WayOfDeliverySearch();
        searchSettings.Limit = 2;
        var limitedCollection = await connector.FindAsync(searchSettings);

        Assert.AreEqual(existingCount + 5, limitedCollection.TotalResources);
        Assert.AreEqual(2, limitedCollection.Entities.Count);

        //Delete entries
        foreach (var entry in createdEntries)
        {
            await connector.DeleteAsync(entry.Code);
        }
    }
}