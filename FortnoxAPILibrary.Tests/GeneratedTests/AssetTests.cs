using System;
using System.Collections.Generic;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.GeneratedTests
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
            //Add code to create required resources
            #endregion Arrange

            var connector = new AssetConnector();

            #region CREATE
            var newAsset = new Asset()
            {
                //TODO: Populate Entity
            };

            var createdAsset = connector.Create(newAsset);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("PropertyValue", createdAsset.SomeProperty); //TODO: Adapt

            #endregion CREATE

            #region UPDATE

            createdAsset.SomeProperty = "UpdatedPropertyValue"; //TODO: Adapt

            var updatedAsset = connector.Update(createdAsset); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", updatedAsset.SomeProperty); //TODO: Adapt

            #endregion UPDATE

            #region READ / GET

            var retrievedAsset = connector.Get(createdAsset.Id); //TODO: Check ID property
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", retrievedAsset.SomeProperty); //TODO: Adapt

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdAsset.Id); //TODO: Check ID property
            MyAssert.HasNoError(connector);

            retrievedAsset = connector.Get(createdAsset.Id); //TODO: Check ID property
            Assert.AreEqual(null, retrievedAsset, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }
    }
}
