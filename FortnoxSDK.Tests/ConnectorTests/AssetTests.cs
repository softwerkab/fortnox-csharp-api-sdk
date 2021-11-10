using System;
using System.Threading.Tasks;
using Fortnox.SDK;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Exceptions;
using Fortnox.SDK.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests;

[TestClass]
public class AssetTests
{
    public FortnoxClient FortnoxClient = TestUtils.DefaultFortnoxClient;

    [TestMethod]
    public async Task Test_Asset_CRUD()
    {
        #region Arrange
        var tmpCostCenter = await FortnoxClient.CostCenterConnector.CreateAsync(new CostCenter() { Code = "TMP", Description = "TmpCostCenter" });
        var tmpAssetType = await FortnoxClient.AssetTypesConnector.CreateAsync(new AssetType() { Description = "TmpAssetType", Type = "1", Number = TestUtils.RandomString(3), AccountAssetId = 1150, AccountDepreciationId = 7824, AccountValueLossId = 1159 });
        #endregion Arrange

        var connector = FortnoxClient.AssetConnector;

        #region CREATE
        var newAsset = new Asset()
        {
            Description = "TestAsset",
            Number = TestUtils.RandomString(),
            AcquisitionDate = new DateTime(2011, 1, 1),
            AcquisitionStart = new DateTime(2011, 2, 1),
            AcquisitionValue = 500,
            DepreciationFinal = new DateTime(2012, 1, 1),
            Department = "Some Department",
            Notes = "Some notes",
            Group = "Some Group",
            Room = "Some room",
            Placement = "Right here",
            CostCenter = tmpCostCenter.Code,
            TypeId = tmpAssetType.Id
        };

        var createdAsset = await connector.CreateAsync(newAsset);
        Assert.AreEqual("TestAsset", createdAsset.Description); //returns entity named "Assets" instead of "asset"

        #endregion CREATE

        #region UPDATE

        createdAsset.Description = "UpdatedTestAsset";

        var updatedAsset = await connector.UpdateAsync(createdAsset);
        Assert.AreEqual("UpdatedTestAsset", updatedAsset.Description);

        #endregion UPDATE

        #region READ / GET

        var retrievedAsset = await connector.GetAsync(createdAsset.Id);
        Assert.AreEqual("UpdatedTestAsset", retrievedAsset.Description);

        #endregion READ / GET

        #region DELETE

        await connector.DeleteAsync(createdAsset.Id);

        Assert.ThrowsException<FortnoxApiException>(
            () => connector.Get(createdAsset.Id),
            "Entity still exists after Delete!");

        #endregion DELETE

        #region Delete arranged resources
        await FortnoxClient.CostCenterConnector.DeleteAsync(tmpCostCenter.Code);
        await FortnoxClient.AssetTypesConnector.DeleteAsync(tmpAssetType.Id);
        #endregion Delete arranged resources
    }

    [TestMethod]
    public async Task Test_Find()
    {
        #region Arrange
        var tmpCostCenter = await FortnoxClient.CostCenterConnector.CreateAsync(new CostCenter() { Code = "TMP", Description = "TmpCostCenter" });
        var tmpAssetType = await FortnoxClient.AssetTypesConnector.CreateAsync(new AssetType() { Description = "TmpAssetType", Type = "1", Number = TestUtils.RandomString(3), AccountAssetId = 1150, AccountDepreciationId = 7824, AccountValueLossId = 1159 });
        #endregion Arrange

        var testKeyMark = TestUtils.RandomString();

        var connector = FortnoxClient.AssetConnector;
        var newAsset = new Asset()
        {
            Description = testKeyMark,
            AcquisitionDate = new DateTime(2011, 1, 1),
            AcquisitionStart = new DateTime(2011, 2, 1),
            AcquisitionValue = 500,
            DepreciationFinal = new DateTime(2012, 1, 1),
            Department = "Some Department",
            Notes = "Some notes",
            Group = "Some Group",
            Room = "Some room",
            Placement = "Right here",
            CostCenter = tmpCostCenter.Code,
            TypeId = tmpAssetType.Id
        };

        //Add entries
        for (var i = 0; i < 5; i++)
        {
            newAsset.Number = TestUtils.RandomString();
            await connector.CreateAsync(newAsset);
        }

        //Apply base test filter
        var searchSettings = new AssetSearch();
        searchSettings.Description = testKeyMark;
        var fullCollection = await connector.FindAsync(searchSettings);

        Assert.AreEqual(5, fullCollection.TotalResources);
        Assert.AreEqual(5, fullCollection.Entities.Count);
        Assert.AreEqual(1, fullCollection.TotalPages);

        //Apply Limit
        searchSettings.Limit = 2;
        var limitedCollection = await connector.FindAsync(searchSettings);

        Assert.AreEqual(5, limitedCollection.TotalResources);
        Assert.AreEqual(2, limitedCollection.Entities.Count);
        Assert.AreEqual(3, limitedCollection.TotalPages);

        //Delete entries
        foreach (var entry in fullCollection.Entities)
            await connector.DeleteAsync(entry.Id);

        #region Delete arranged resources
        await FortnoxClient.CostCenterConnector.DeleteAsync(tmpCostCenter.Code);
        await FortnoxClient.AssetTypesConnector.DeleteAsync(tmpAssetType.Id);
        #endregion Delete arranged resources
    }
}