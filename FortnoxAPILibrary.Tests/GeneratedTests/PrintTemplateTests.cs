using System;
using System.Collections.Generic;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.GeneratedTests
{
    [TestClass]
    public class PrintTemplateTests
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
        public void Test_PrintTemplate_CRUD()
        {
            #region Arrange
            //Add code to create required resources
            #endregion Arrange

            var connector = new PrintTemplateConnector();

            #region CREATE
            var newPrintTemplate = new PrintTemplate()
            {
                //TODO: Populate Entity
            };

            var createdPrintTemplate = connector.Create(newPrintTemplate);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("PropertyValue", createdPrintTemplate.SomeProperty); //TODO: Adapt

            #endregion CREATE

            #region UPDATE

            createdPrintTemplate.SomeProperty = "UpdatedPropertyValue"; //TODO: Adapt

            var updatedPrintTemplate = connector.Update(createdPrintTemplate); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", updatedPrintTemplate.SomeProperty); //TODO: Adapt

            #endregion UPDATE

            #region READ / GET

            var retrievedPrintTemplate = connector.Get(createdPrintTemplate.ID); //TODO: Check ID property
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", retrievedPrintTemplate.SomeProperty); //TODO: Adapt

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdPrintTemplate.ID); //TODO: Check ID property
            MyAssert.HasNoError(connector);

            retrievedPrintTemplate = connector.Get(createdPrintTemplate.ID); //TODO: Check ID property
            Assert.AreEqual(null, retrievedPrintTemplate, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }
    }
}
