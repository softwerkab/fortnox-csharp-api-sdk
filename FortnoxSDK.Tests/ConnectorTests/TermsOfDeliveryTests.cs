using System.Threading.Tasks;
using Fortnox.SDK;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Exceptions;
using Fortnox.SDK.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests;

[TestClass]
public class TermsOfDeliveryTests
{
    public FortnoxClient FortnoxClient = TestUtils.DefaultFortnoxClient;

    [TestMethod]
    public async Task Test_TermsOfDelivery_CRUD()
    {
        #region Arrange
        //Add code to create required resources
        #endregion Arrange

        var connector = FortnoxClient.TermsOfDeliveryConnector;

        #region CREATE
        var newTermsOfDelivery = new TermsOfDelivery()
        {
            Code = TestUtils.RandomString(5),
            Description = "TestDeliveryTerms"
        };

        var createdTermsOfDelivery = await connector.CreateAsync(newTermsOfDelivery);
        Assert.AreEqual("TestDeliveryTerms", createdTermsOfDelivery.Description);

        #endregion CREATE

        #region UPDATE

        createdTermsOfDelivery.Description = "UpdatedTestDeliveryTerms";

        var updatedTermsOfDelivery = await connector.UpdateAsync(createdTermsOfDelivery);
        Assert.AreEqual("UpdatedTestDeliveryTerms", updatedTermsOfDelivery.Description);

        #endregion UPDATE

        #region READ / GET

        var retrievedTermsOfDelivery = await connector.GetAsync(createdTermsOfDelivery.Code);
        Assert.AreEqual("UpdatedTestDeliveryTerms", retrievedTermsOfDelivery.Description);

        #endregion READ / GET

        #region DELETE

        await connector.DeleteAsync(createdTermsOfDelivery.Code);

        Assert.ThrowsException<FortnoxApiException>(
            () => connector.Get(createdTermsOfDelivery.Code),
            "Entity still exists after Delete!");

        #endregion DELETE

        #region Delete arranged resources
        //Add code to delete temporary resources
        #endregion Delete arranged resources
    }

    [TestMethod]
    public async Task Test_Find()
    {
        var connector = FortnoxClient.TermsOfDeliveryConnector;

        var newTermsOfDelivery = new TermsOfDelivery()
        {
            Description = "TestDeliveryTerms"
        };

        //Add entries
        for (var i = 0; i < 5; i++)
        {
            newTermsOfDelivery.Code = TestUtils.RandomString();
            await connector.CreateAsync(newTermsOfDelivery);
        }

        //Filter not supported
        var searchSettings = new TermsOfDeliverySearch();
        searchSettings.LastModified = TestUtils.Recently;
        var fullCollection = await connector.FindAsync(searchSettings);

        Assert.AreEqual(5, fullCollection.Entities.Count);
        Assert.AreEqual("TestDeliveryTerms", fullCollection.Entities[0].Description);

        //Apply Limit
        searchSettings.Limit = 2;
        var limitedCollection = await connector.FindAsync(searchSettings);

        Assert.AreEqual(2, limitedCollection.Entities.Count);

        //Delete entries
        foreach (var entry in fullCollection.Entities)
        {
            await connector.DeleteAsync(entry.Code);
        }
    }
}