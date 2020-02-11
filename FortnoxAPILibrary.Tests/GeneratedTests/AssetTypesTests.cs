using System;
using System.Collections.Generic;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.GeneratedTests
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

            var connector = new AssetTypesConnector();

            #region CREATE
            var newAssetTypes = new AssetTypes()
            {
                //TODO: Populate Entity
            };

            var createdAssetTypes = connector.Create(newAssetTypes);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("PropertyValue", createdAssetTypes.SomeProperty); //TODO: Adapt

            #endregion CREATE

            #region UPDATE

            createdAssetTypes.SomeProperty = "UpdatedPropertyValue"; //TODO: Adapt

            var updatedAssetTypes = connector.Update(createdAssetTypes); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", updatedAssetTypes.SomeProperty); //TODO: Adapt

            #endregion UPDATE

            #region READ / GET

            var retrievedAssetTypes = connector.Get(createdAssetTypes.Id); //TODO: Check ID property
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", retrievedAssetTypes.SomeProperty); //TODO: Adapt

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdAssetTypes.Id); //TODO: Check ID property
            MyAssert.HasNoError(connector);

            retrievedAssetTypes = connector.Get(createdAssetTypes.Id); //TODO: Check ID property
            Assert.AreEqual(null, retrievedAssetTypes, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }
    }
}
