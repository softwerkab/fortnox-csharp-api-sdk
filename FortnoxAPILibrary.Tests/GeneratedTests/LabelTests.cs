using System;
using System.Collections.Generic;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.GeneratedTests
{
    [TestClass]
    public class LabelTests
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
        public void Test_Label_CRUD()
        {
            #region Arrange
            //Add code to create required resources
            #endregion Arrange

            var connector = new LabelConnector();

            #region CREATE
            var newLabel = new Label()
            {
                //TODO: Populate Entity
            };

            var createdLabel = connector.Create(newLabel);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("PropertyValue", createdLabel.SomeProperty); //TODO: Adapt

            #endregion CREATE

            #region UPDATE

            createdLabel.SomeProperty = "UpdatedPropertyValue"; //TODO: Adapt

            var updatedLabel = connector.Update(createdLabel); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", updatedLabel.SomeProperty); //TODO: Adapt

            #endregion UPDATE

            #region READ / GET

            var retrievedLabel = connector.Get(createdLabel.Id); //TODO: Check ID property
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", retrievedLabel.SomeProperty); //TODO: Adapt

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdLabel.Id); //TODO: Check ID property
            MyAssert.HasNoError(connector);

            retrievedLabel = connector.Get(createdLabel.Id); //TODO: Check ID property
            Assert.AreEqual(null, retrievedLabel, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }
    }
}
