using System;
using System.Collections.Generic;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.GeneratedTests
{
    [TestClass]
    public class FileTests
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
        public void Test_File_CRUD()
        {
            #region Arrange
            //Add code to create required resources
            #endregion Arrange

            var connector = new FileConnector();

            #region CREATE
            var newFile = new File()
            {
                //TODO: Populate Entity
            };

            var createdFile = connector.Create(newFile);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("PropertyValue", createdFile.SomeProperty); //TODO: Adapt

            #endregion CREATE

            #region UPDATE

            createdFile.SomeProperty = "UpdatedPropertyValue"; //TODO: Adapt

            var updatedFile = connector.Update(createdFile); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", updatedFile.SomeProperty); //TODO: Adapt

            #endregion UPDATE

            #region READ / GET

            var retrievedFile = connector.Get(createdFile.Id); //TODO: Check ID property
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", retrievedFile.SomeProperty); //TODO: Adapt

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdFile.Id); //TODO: Check ID property
            MyAssert.HasNoError(connector);

            retrievedFile = connector.Get(createdFile.Id); //TODO: Check ID property
            Assert.AreEqual(null, retrievedFile, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }
    }
}
