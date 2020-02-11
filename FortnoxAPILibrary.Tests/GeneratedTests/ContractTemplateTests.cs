using System;
using System.Collections.Generic;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.GeneratedTests
{
    [TestClass]
    public class ContractTemplateTests
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
        public void Test_ContractTemplate_CRUD()
        {
            #region Arrange
            //Add code to create required resources
            #endregion Arrange

            var connector = new ContractTemplateConnector();

            #region CREATE
            var newContractTemplate = new ContractTemplate()
            {
                //TODO: Populate Entity
            };

            var createdContractTemplate = connector.Create(newContractTemplate);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("PropertyValue", createdContractTemplate.SomeProperty); //TODO: Adapt

            #endregion CREATE

            #region UPDATE

            createdContractTemplate.SomeProperty = "UpdatedPropertyValue"; //TODO: Adapt

            var updatedContractTemplate = connector.Update(createdContractTemplate); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", updatedContractTemplate.SomeProperty); //TODO: Adapt

            #endregion UPDATE

            #region READ / GET

            var retrievedContractTemplate = connector.Get(createdContractTemplate.ID); //TODO: Check ID property
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", retrievedContractTemplate.SomeProperty); //TODO: Adapt

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdContractTemplate.ID); //TODO: Check ID property
            MyAssert.HasNoError(connector);

            retrievedContractTemplate = connector.Get(createdContractTemplate.ID); //TODO: Check ID property
            Assert.AreEqual(null, retrievedContractTemplate, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }
    }
}
