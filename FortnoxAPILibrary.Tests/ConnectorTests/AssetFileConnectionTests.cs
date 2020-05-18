using System;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.Tests.ConnectorTests
{
    [TestClass]
    public class AssetFileConnectionTests
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
        public void Test_AssetFileConnection_CRUD()
        {
            #region Arrange
            var tmpAssetType = new AssetTypesConnector().Create(new AssetType() { Description = "TmpAssetType", Type = "1", Number = TestUtils.RandomString(3), AccountAssetId = 1150, AccountDepreciationId = 7824, AccountValueLossId = 1159 });
            var tmpAsset = new AssetConnector().Create(new Asset()
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
            var tmpFile = new ArchiveConnector().UploadFile("tmpImage.png", Resource.fortnox_image);
            #endregion Arrange

            IAssetFileConnectionConnector connector = new AssetFileConnectionConnector();

            #region CREATE
            var newAssetFileConnection = new AssetFileConnection()
            {
                FileId = tmpFile.Id,
                AssetId = tmpAsset.Id
            };

            var createdAssetFileConnection = connector.Create(newAssetFileConnection);
            MyAssert.HasNoError(connector);
            Assert.AreEqual(tmpAsset.Id, createdAssetFileConnection.AssetId);

            #endregion CREATE

            #region UPDATE
            //Update not supported
            #endregion UPDATE

            #region READ / GET

            var retrievedAssetFileConnection = connector.Get(createdAssetFileConnection.FileId);
            MyAssert.HasNoError(connector);
            Assert.AreEqual(tmpAsset.Id, retrievedAssetFileConnection.AssetId);

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdAssetFileConnection.FileId);
            MyAssert.HasNoError(connector);

            retrievedAssetFileConnection = connector.Get(createdAssetFileConnection.FileId);
            Assert.AreEqual(null, retrievedAssetFileConnection.AssetId, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            new AssetConnector().Delete(tmpAsset.Id);
            new AssetTypesConnector().Delete(tmpAssetType.Id);
            new ArchiveConnector().DeleteFile(tmpFile.Id);
            #endregion Delete arranged resources
        }
    }
}
