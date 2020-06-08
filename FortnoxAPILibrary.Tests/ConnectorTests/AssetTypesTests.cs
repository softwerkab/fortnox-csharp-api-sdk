using System.Linq;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.Tests.ConnectorTests
{
    [TestClass]
    public class AssetTypesTests
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
        public void Test_AssetTypes_CRUD()
        {
            #region Arrange

            //Add code to create required resources

            #endregion Arrange

            IAssetTypesConnector connector = new AssetTypesConnector();
            var entry = connector.Find().Entities.FirstOrDefault(at => at.Number == "TST");
            if (entry != null)
                connector.Delete(entry.Id);

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

            var createdAssetTypes = connector.Create(newAssetTypes);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("TestAssetType",
                createdAssetTypes.Description); //Fails due to response entity is named "Type", not "AssetType"

            #endregion CREATE

            #region UPDATE

            createdAssetTypes.Description = "UpdatedTestAssetType";

            var updatedAssetTypes = connector.Update(createdAssetTypes);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedTestAssetType", updatedAssetTypes.Description);

            #endregion UPDATE

            #region READ / GET

            var retrievedAssetTypes = connector.Get(createdAssetTypes.Id);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedTestAssetType", retrievedAssetTypes.Description);

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdAssetTypes.Id);
            MyAssert.HasNoError(connector);

            retrievedAssetTypes = connector.Get(createdAssetTypes.Id);
            Assert.AreEqual(null, retrievedAssetTypes, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources

            //Add code to delete temporary resources

            #endregion Delete arranged resources
        }

        [TestMethod]
        public void Test_AssetTypes_Find()
        {
            IAssetTypesConnector connector = new AssetTypesConnector();

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
                connector.Create(newAssetType);
                MyAssert.HasNoError(connector);
            }

            var assetTypes = connector.Find();
            Assert.AreEqual(5, assetTypes.Entities.Count(x => x.Number.StartsWith(marks)));

            //restore
            foreach (var entity in assetTypes.Entities.Where(x => x.Number.StartsWith(marks)))
            {
                connector.Delete(entity.Id);
                MyAssert.HasNoError(connector);
            }
        }
    }
}
