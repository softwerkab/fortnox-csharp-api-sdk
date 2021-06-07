using System;
using Fortnox.SDK;
using Fortnox.SDK.Connectors;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests
{
    [TestClass]
    public class AssetFileConnectionTests
    {
        public FortnoxClient FortnoxClient = TestUtils.DefaultFortnoxClient;

        [TestMethod]
        public void Test_AssetFileConnection_CRUD()
        {
            #region Arrange
            var tmpAssetType = FortnoxClient.AssetTypesConnector.Create(new AssetType() { Description = "TmpAssetType", Type = "1", Number = TestUtils.RandomString(3), AccountAssetId = 1150, AccountDepreciationId = 7824, AccountValueLossId = 1159 });
            var tmpAsset = FortnoxClient.AssetConnector.Create(new Asset()
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
                TypeId = tmpAssetType.Id.ToString()
            });
            var tmpFile = FortnoxClient.ArchiveConnector.UploadFile("tmpImage.png", Resource.fortnox_image);
            #endregion Arrange

            IAssetFileConnectionConnector connector = FortnoxClient.AssetFileConnectionConnector;

            #region CREATE
            var newAssetFileConnection = new AssetFileConnection()
            {
                FileId = tmpFile.Id,
                AssetId = tmpAsset.Id
            };

            var createdAssetFileConnection = connector.Create(newAssetFileConnection);
            Assert.AreEqual(tmpAsset.Id, createdAssetFileConnection.AssetId);

            #endregion CREATE

            #region UPDATE
            //Update not supported
            #endregion UPDATE

            #region READ / GET

            var retrievedAssetFileConnection = connector.Get(createdAssetFileConnection.FileId);
            Assert.AreEqual(tmpAsset.Id, retrievedAssetFileConnection.AssetId);

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdAssetFileConnection.FileId);

            /*Assert.ThrowsException<FortnoxApiException>(
                () => connector.Get(createdAssetFileConnection.FileId),
                "Entity still exists after Delete!");*/

            //For some reason, connection exists after delete, but with asset id set to null
            retrievedAssetFileConnection = connector.Get(createdAssetFileConnection.FileId);
            Assert.AreEqual(null, retrievedAssetFileConnection.AssetId, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            FortnoxClient.AssetConnector.Delete(tmpAsset.Id);
            FortnoxClient.AssetTypesConnector.Delete(tmpAssetType.Id);
            FortnoxClient.ArchiveConnector.DeleteFile(tmpFile.Id);
            #endregion Delete arranged resources
        }
    }
}
