using System;
using System.Collections.Generic;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.GeneratedTests
{
    [TestClass]
    public class TrustedEmailSendersTests
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
        public void Test_TrustedEmailSenders_CRUD()
        {
            #region Arrange
            //Add code to create required resources
            #endregion Arrange

            var connector = new TrustedEmailSendersConnector();

            #region CREATE
            var newTrustedEmailSenders = new TrustedEmailSenders()
            {
                //TODO: Populate Entity
            };

            var createdTrustedEmailSenders = connector.Create(newTrustedEmailSenders);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("PropertyValue", createdTrustedEmailSenders.SomeProperty); //TODO: Adapt

            #endregion CREATE

            #region UPDATE

            createdTrustedEmailSenders.SomeProperty = "UpdatedPropertyValue"; //TODO: Adapt

            var updatedTrustedEmailSenders = connector.Update(createdTrustedEmailSenders); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", updatedTrustedEmailSenders.SomeProperty); //TODO: Adapt

            #endregion UPDATE

            #region READ / GET

            var retrievedTrustedEmailSenders = connector.Get(createdTrustedEmailSenders.Id); //TODO: Check ID property
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", retrievedTrustedEmailSenders.SomeProperty); //TODO: Adapt

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdTrustedEmailSenders.Id); //TODO: Check ID property
            MyAssert.HasNoError(connector);

            retrievedTrustedEmailSenders = connector.Get(createdTrustedEmailSenders.Id); //TODO: Check ID property
            Assert.AreEqual(null, retrievedTrustedEmailSenders, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }
    }
}
