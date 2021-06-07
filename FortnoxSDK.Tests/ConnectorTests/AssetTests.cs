using System;
using Fortnox.SDK;
using Fortnox.SDK.Connectors;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Exceptions;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests
{
    [TestClass]
    public class AssetTests
    {
        public FortnoxClient FortnoxClient = TestUtils.DefaultFortnoxClient;

        [TestMethod]
        public void Test_Asset_CRUD()
        {
            #region Arrange
            var tmpCostCenter = FortnoxClient.CostCenterConnector.Create(new CostCenter(){ Code = "TMP", Description = "TmpCostCenter"});
            var tmpAssetType = FortnoxClient.AssetTypesConnector.Create(new AssetType() {Description = "TmpAssetType", Type = "1", Number = TestUtils.RandomString(3), AccountAssetId = 1150, AccountDepreciationId = 7824, AccountValueLossId = 1159 });
            #endregion Arrange

            IAssetConnector connector = FortnoxClient.AssetConnector;

            #region CREATE
            var newAsset = new Asset()
            {
                Description = "TestAsset",
                Number = TestUtils.RandomString(),
                AcquisitionDate = new DateTime(2011, 1, 1),
                AcquisitionStart = new DateTime(2011,2,1),
                AcquisitionValue = 500,
                DepreciationFinal = new DateTime(2012,1,1),
                Department = "Some Department",
                Notes = "Some notes",
                Group = "Some Group",
                Room = "Some room",
                Placement = "Right here",
                CostCenter = tmpCostCenter.Code,
                TypeId = tmpAssetType.Id.ToString()
            };

            var createdAsset = connector.Create(newAsset);
            Assert.AreEqual("TestAsset", createdAsset.Description); //returns entity named "Assets" instead of "asset"

            #endregion CREATE

            #region UPDATE

            createdAsset.Description = "UpdatedTestAsset";

            var updatedAsset = connector.Update(createdAsset); 
            Assert.AreEqual("UpdatedTestAsset", updatedAsset.Description);

            #endregion UPDATE

            #region READ / GET

            var retrievedAsset = connector.Get(createdAsset.Id);
            Assert.AreEqual("UpdatedTestAsset", retrievedAsset.Description);

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdAsset.Id);

            Assert.ThrowsException<FortnoxApiException>(
                () => connector.Get(createdAsset.Id),
                "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            FortnoxClient.CostCenterConnector.Delete(tmpCostCenter.Code);
            FortnoxClient.AssetTypesConnector.Delete(tmpAssetType.Id);
            #endregion Delete arranged resources
        }

        [TestMethod]
        public void Test_Find()
        {
            #region Arrange
            var tmpCostCenter = FortnoxClient.CostCenterConnector.Create(new CostCenter() { Code = "TMP", Description = "TmpCostCenter" });
            var tmpAssetType = FortnoxClient.AssetTypesConnector.Create(new AssetType() { Description = "TmpAssetType", Type = "1", Number = TestUtils.RandomString(3), AccountAssetId = 1150, AccountDepreciationId = 7824, AccountValueLossId = 1159 });
            #endregion Arrange

            var testKeyMark = TestUtils.RandomString();

            IAssetConnector connector = FortnoxClient.AssetConnector;
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
                TypeId = tmpAssetType.Id.ToString()
            };

            //Add entries
            for (var i = 0; i < 5; i++)
            {
                newAsset.Number = TestUtils.RandomString();
                connector.Create(newAsset);
            }

            //Apply base test filter
            var searchSettings = new AssetSearch();
            searchSettings.Description = testKeyMark;
            var fullCollection = connector.Find(searchSettings);

            Assert.AreEqual(5, fullCollection.TotalResources);
            Assert.AreEqual(5, fullCollection.Entities.Count);
            Assert.AreEqual(1, fullCollection.TotalPages);

            //Apply Limit
            searchSettings.Limit = 2;
            var limitedCollection = connector.Find(searchSettings);

            Assert.AreEqual(5, limitedCollection.TotalResources);
            Assert.AreEqual(2, limitedCollection.Entities.Count);
            Assert.AreEqual(3, limitedCollection.TotalPages);

            //Delete entries
            foreach (var entry in fullCollection.Entities)
                connector.Delete(entry.Id);

            #region Delete arranged resources
            FortnoxClient.CostCenterConnector.Delete(tmpCostCenter.Code);
            FortnoxClient.AssetTypesConnector.Delete(tmpAssetType.Id);
            #endregion Delete arranged resources
        }
    }
}
