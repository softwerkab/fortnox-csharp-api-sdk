using System.Linq;
using System.Threading.Tasks;
using Fortnox.SDK;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests;

[TestClass]
public class AssetTypesTests
{
    public FortnoxClient FortnoxClient = TestUtils.DefaultFortnoxClient;

    [TestMethod]
    public async Task Test_AssetTypes_CRUD()
    {
        #region Arrange

        //Add code to create required resources

        #endregion Arrange

        var connector = FortnoxClient.AssetTypesConnector;
        var entry = (await connector.FindAsync(null)).Entities.FirstOrDefault(at => at.Number == "TST");
        if (entry != null)
            await connector.DeleteAsync(entry.Id);

        #region CREATE

        var newAssetTypes = new AssetType()
        {
            Description = "TestAssetType",
            Notes = "Some notes",
            Number = "TST",
            Type = "1",
            AccountAssetId = 1150,
            AccountDepreciationId = 7824,
            AccountValueLossId = 1159,
        };

        var createdAssetTypes = await connector.CreateAsync(newAssetTypes);
        Assert.AreEqual("TestAssetType",
            createdAssetTypes.Description); //Fails due to response entity is named "Type", not "AssetType"

        #endregion CREATE

        #region UPDATE

        createdAssetTypes.Description = "UpdatedTestAssetType";

        var updatedAssetTypes = await connector.UpdateAsync(createdAssetTypes);
        Assert.AreEqual("UpdatedTestAssetType", updatedAssetTypes.Description);

        #endregion UPDATE

        #region READ / GET

        var retrievedAssetTypes = await connector.GetAsync(createdAssetTypes.Id);
        Assert.AreEqual("UpdatedTestAssetType", retrievedAssetTypes.Description);

        #endregion READ / GET

        #region DELETE

        await connector.DeleteAsync(createdAssetTypes.Id);

        await Assert.ThrowsExceptionAsync<FortnoxApiException>(
            async () => await connector.GetAsync(createdAssetTypes.Id),
            "Entity still exists after Delete!");

        #endregion DELETE

        #region Delete arranged resources

        //Add code to delete temporary resources

        #endregion Delete arranged resources
    }

    [TestMethod]
    public async Task Test_AssetTypes_Find()
    {
        var connector = FortnoxClient.AssetTypesConnector;

        var newAssetType = new AssetType()
        {
            Description = "TestAssetType",
            Notes = "Some notes",
            Type = "1",
            AccountAssetId = 1150,
            AccountDepreciationId = 7824,
            AccountValueLossId = 1159,
        };

        var marks = TestUtils.RandomString(3);
        for (var i = 0; i < 5; i++)
        {
            newAssetType.Number = marks + i;
            await connector.CreateAsync(newAssetType);
        }

        var assetTypes = await connector.FindAsync(null);
        Assert.AreEqual(5, assetTypes.Entities.Count(x => x.Number.StartsWith(marks)));

        //restore
        foreach (var entity in assetTypes.Entities.Where(x => x.Number.StartsWith(marks)))
        {
            await connector.DeleteAsync(entity.Id);
        }
    }
}