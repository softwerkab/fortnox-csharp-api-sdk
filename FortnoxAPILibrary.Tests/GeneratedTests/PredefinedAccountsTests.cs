using System;
using System.Collections.Generic;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.GeneratedTests
{
    [TestClass]
    public class PredefinedAccountsTests
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
        public void Test_PredefinedAccounts_CRUD()
        {
            #region Arrange
            //Add code to create required resources
            #endregion Arrange

            var connector = new PredefinedAccountsConnector();

            #region CREATE
            var newPredefinedAccounts = new PredefinedAccounts()
            {
                //TODO: Populate Entity
            };

            var createdPredefinedAccounts = connector.Create(newPredefinedAccounts);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("PropertyValue", createdPredefinedAccounts.SomeProperty); //TODO: Adapt

            #endregion CREATE

            #region UPDATE

            createdPredefinedAccounts.SomeProperty = "UpdatedPropertyValue"; //TODO: Adapt

            var updatedPredefinedAccounts = connector.Update(createdPredefinedAccounts); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", updatedPredefinedAccounts.SomeProperty); //TODO: Adapt

            #endregion UPDATE

            #region READ / GET

            var retrievedPredefinedAccounts = connector.Get(createdPredefinedAccounts.ID); //TODO: Check ID property
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", retrievedPredefinedAccounts.SomeProperty); //TODO: Adapt

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdPredefinedAccounts.ID); //TODO: Check ID property
            MyAssert.HasNoError(connector);

            retrievedPredefinedAccounts = connector.Get(createdPredefinedAccounts.ID); //TODO: Check ID property
            Assert.AreEqual(null, retrievedPredefinedAccounts, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }
    }
}
