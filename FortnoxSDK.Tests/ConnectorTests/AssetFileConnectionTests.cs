using System;
using System.Threading.Tasks;
using Fortnox.SDK;
using Fortnox.SDK.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests;

[TestClass]
public class AssetFileConnectionTests
{
    private FortnoxClient FortnoxClient;

    [TestInitialize]
    public async Task TestInitialize()
    {
        FortnoxClient ??= await TestClient.GetFortnoxClient();
    }

    [TestMethod]
    public async Task Test_AssetFileConnection_CRUD()
    {
        #region Arrange
        var tmpAssetType = await FortnoxClient.AssetTypesConnector.CreateAsync(new AssetType() { Description = "TmpAssetType", Type = "1", Number = TestUtils.RandomString(3), AccountAssetId = 1150, AccountDepreciationId = 7824, AccountValueLossId = 1159 });
        var tmpAsset = await FortnoxClient.AssetConnector.CreateAsync(new Asset()
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
            TypeId = tmpAssetType.Id
        });
        var tmpFile = await FortnoxClient.ArchiveConnector.UploadFileAsync("tmpImage.png", Resource.fortnox_image);
        #endregion Arrange

        var connector = FortnoxClient.AssetFileConnectionConnector;

        #region CREATE
        var newAssetFileConnection = new AssetFileConnection()
        {
            FileId = tmpFile.Id,
            AssetId = tmpAsset.Id
        };

        var createdAssetFileConnection = await connector.CreateAsync(newAssetFileConnection);
        Assert.AreEqual(tmpAsset.Id, createdAssetFileConnection.AssetId);

        #endregion CREATE

        #region UPDATE
        //Update not supported
        #endregion UPDATE

        #region READ / GET

        var retrievedAssetFileConnection = await connector.GetAsync(createdAssetFileConnection.FileId);
        Assert.AreEqual(tmpAsset.Id, retrievedAssetFileConnection.AssetId);

        #endregion READ / GET

        #region DELETE

        await connector.DeleteAsync(createdAssetFileConnection.FileId);

        /*Assert.ThrowsException<FortnoxApiException>(
            () => connector.Get(createdAssetFileConnection.FileId),
            "Entity still exists after Delete!");*/

        //For some reason, connection exists after delete, but with asset id set to null
        retrievedAssetFileConnection = await connector.GetAsync(createdAssetFileConnection.FileId);
        Assert.AreEqual(null, retrievedAssetFileConnection.AssetId, "Entity still exists after Delete!");

        #endregion DELETE

        #region Delete arranged resources
        await FortnoxClient.AssetConnector.DeleteAsync(tmpAsset.Id);
        await FortnoxClient.AssetTypesConnector.DeleteAsync(tmpAssetType.Id);
        await FortnoxClient.ArchiveConnector.DeleteFileAsync(tmpFile.Id);
        #endregion Delete arranged resources
    }
}