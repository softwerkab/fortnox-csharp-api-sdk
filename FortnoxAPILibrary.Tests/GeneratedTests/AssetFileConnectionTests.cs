using System;
using System.Collections.Generic;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.GeneratedTests
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
            //Add code to create required resources
            #endregion Arrange

            var connector = new AssetFileConnectionConnector();

            #region CREATE
            var newAssetFileConnection = new AssetFileConnection()
            {
                //TODO: Populate Entity
            };

            var createdAssetFileConnection = connector.Create(newAssetFileConnection);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("PropertyValue", createdAssetFileConnection.SomeProperty); //TODO: Adapt

            #endregion CREATE

            #region UPDATE

            createdAssetFileConnection.SomeProperty = "UpdatedPropertyValue"; //TODO: Adapt

            var updatedAssetFileConnection = connector.Update(createdAssetFileConnection); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", updatedAssetFileConnection.SomeProperty); //TODO: Adapt

            #endregion UPDATE

            #region READ / GET

            var retrievedAssetFileConnection = connector.Get(createdAssetFileConnection.Id); //TODO: Check ID property
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", retrievedAssetFileConnection.SomeProperty); //TODO: Adapt

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdAssetFileConnection.Id); //TODO: Check ID property
            MyAssert.HasNoError(connector);

            retrievedAssetFileConnection = connector.Get(createdAssetFileConnection.Id); //TODO: Check ID property
            Assert.AreEqual(null, retrievedAssetFileConnection, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }
    }
}
