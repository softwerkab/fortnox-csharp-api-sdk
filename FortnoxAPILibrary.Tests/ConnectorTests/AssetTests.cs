using System;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.Tests.ConnectorTests
{
    [TestClass]
    public class AssetTests
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
        public void Test_Asset_CRUD()
        {
            #region Arrange
            var tmpCostCenter = new CostCenterConnector().Get("TMP") ?? new CostCenterConnector().Create(new CostCenter(){ Code = "TMP", Description = "TmpCostCenter"});
            var tmpAssetType = new AssetTypesConnector().Create(new AssetType() {Description = "TmpAssetType", Type = "1", Number = TestUtils.RandomString(3), AccountAssetId = 1150, AccountDepreciationId = 7824, AccountValueLossId = 1159 });
            #endregion Arrange

            IAssetConnector connector = new AssetConnector();

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
            MyAssert.HasNoError(connector);
            Assert.AreEqual("TestAsset", createdAsset.Description); //returns entity named "Assets" instead of "asset"

            #endregion CREATE

            #region UPDATE

            createdAsset.Description = "UpdatedTestAsset";

            var updatedAsset = connector.Update(createdAsset); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedTestAsset", updatedAsset.Description);

            #endregion UPDATE

            #region READ / GET

            var retrievedAsset = connector.Get(createdAsset.Id);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedTestAsset", retrievedAsset.Description);

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdAsset.Id);
            MyAssert.HasNoError(connector);

            retrievedAsset = connector.Get(createdAsset.Id);
            Assert.AreEqual(null, retrievedAsset, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            new CostCenterConnector().Delete(tmpCostCenter.Code);
            new AssetTypesConnector().Delete(tmpAssetType.Id);
            #endregion Delete arranged resources
        }

        [TestMethod]
        public void Test_Find()
        {
            #region Arrange
            var tmpCostCenter = new CostCenterConnector().Get("TMP") ?? new CostCenterConnector().Create(new CostCenter() { Code = "TMP", Description = "TmpCostCenter" });
            var tmpAssetType = new AssetTypesConnector().Create(new AssetType() { Description = "TmpAssetType", Type = "1", Number = TestUtils.RandomString(3), AccountAssetId = 1150, AccountDepreciationId = 7824, AccountValueLossId = 1159 });
            #endregion Arrange

            var testKeyMark = TestUtils.RandomString();

            IAssetConnector connector = new AssetConnector();
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
            connector.Description = testKeyMark;
            var fullCollection = connector.Find();
            MyAssert.HasNoError(connector);

            Assert.AreEqual(5, fullCollection.TotalResources);
            Assert.AreEqual(5, fullCollection.Entities.Count);
            Assert.AreEqual(1, fullCollection.TotalPages);

            //Apply Limit
            connector.Limit = 2;
            var limitedCollection = connector.Find();
            MyAssert.HasNoError(connector);

            Assert.AreEqual(5, limitedCollection.TotalResources);
            Assert.AreEqual(2, limitedCollection.Entities.Count);
            Assert.AreEqual(3, limitedCollection.TotalPages);

            //Delete entries
            foreach (var entry in fullCollection.Entities)
            {
                connector.Delete(entry.Id);
            }

            #region Delete arranged resources
            new CostCenterConnector().Delete(tmpCostCenter.Code);
            new AssetTypesConnector().Delete(tmpAssetType.Id);
            #endregion Delete arranged resources
        }
    }
}
