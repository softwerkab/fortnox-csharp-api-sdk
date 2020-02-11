using System;
using System.Collections.Generic;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.GeneratedTests
{
    [TestClass]
    public class ContractTests
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
        public void Test_Contract_CRUD()
        {
            #region Arrange
            //Add code to create required resources
            #endregion Arrange

            var connector = new ContractConnector();

            #region CREATE
            var newContract = new Contract()
            {
                //TODO: Populate Entity
            };

            var createdContract = connector.Create(newContract);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("PropertyValue", createdContract.SomeProperty); //TODO: Adapt

            #endregion CREATE

            #region UPDATE

            createdContract.SomeProperty = "UpdatedPropertyValue"; //TODO: Adapt

            var updatedContract = connector.Update(createdContract); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", updatedContract.SomeProperty); //TODO: Adapt

            #endregion UPDATE

            #region READ / GET

            var retrievedContract = connector.Get(createdContract.DocumentNumber); //TODO: Check ID property
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", retrievedContract.SomeProperty); //TODO: Adapt

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdContract.DocumentNumber); //TODO: Check ID property
            MyAssert.HasNoError(connector);

            retrievedContract = connector.Get(createdContract.DocumentNumber); //TODO: Check ID property
            Assert.AreEqual(null, retrievedContract, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }
    }
}
