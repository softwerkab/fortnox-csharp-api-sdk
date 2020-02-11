using System;
using System.Collections.Generic;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.GeneratedTests
{
    [TestClass]
    public class AccountTests
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
        public void Test_Account_CRUD()
        {
            #region Arrange
            //Add code to create required resources
            #endregion Arrange

            var connector = new AccountConnector();

            #region CREATE
            var newAccount = new Account()
            {
                //TODO: Populate Entity
            };

            var createdAccount = connector.Create(newAccount);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("PropertyValue", createdAccount.SomeProperty); //TODO: Adapt

            #endregion CREATE

            #region UPDATE

            createdAccount.SomeProperty = "UpdatedPropertyValue"; //TODO: Adapt

            var updatedAccount = connector.Update(createdAccount); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", updatedAccount.SomeProperty); //TODO: Adapt

            #endregion UPDATE

            #region READ / GET

            var retrievedAccount = connector.Get(createdAccount.Number); //TODO: Check ID property
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", retrievedAccount.SomeProperty); //TODO: Adapt

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdAccount.Number); //TODO: Check ID property
            MyAssert.HasNoError(connector);

            retrievedAccount = connector.Get(createdAccount.Number); //TODO: Check ID property
            Assert.AreEqual(null, retrievedAccount, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }
    }
}
