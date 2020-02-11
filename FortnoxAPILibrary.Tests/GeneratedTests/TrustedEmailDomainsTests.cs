using System;
using System.Collections.Generic;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.GeneratedTests
{
    [TestClass]
    public class TrustedEmailDomainsTests
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
        public void Test_TrustedEmailDomains_CRUD()
        {
            #region Arrange
            //Add code to create required resources
            #endregion Arrange

            var connector = new TrustedEmailDomainsConnector();

            #region CREATE
            var newTrustedEmailDomains = new TrustedEmailDomains()
            {
                //TODO: Populate Entity
            };

            var createdTrustedEmailDomains = connector.Create(newTrustedEmailDomains);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("PropertyValue", createdTrustedEmailDomains.SomeProperty); //TODO: Adapt

            #endregion CREATE

            #region UPDATE

            createdTrustedEmailDomains.SomeProperty = "UpdatedPropertyValue"; //TODO: Adapt

            var updatedTrustedEmailDomains = connector.Update(createdTrustedEmailDomains); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", updatedTrustedEmailDomains.SomeProperty); //TODO: Adapt

            #endregion UPDATE

            #region READ / GET

            var retrievedTrustedEmailDomains = connector.Get(createdTrustedEmailDomains.Id); //TODO: Check ID property
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", retrievedTrustedEmailDomains.SomeProperty); //TODO: Adapt

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdTrustedEmailDomains.Id); //TODO: Check ID property
            MyAssert.HasNoError(connector);

            retrievedTrustedEmailDomains = connector.Get(createdTrustedEmailDomains.Id); //TODO: Check ID property
            Assert.AreEqual(null, retrievedTrustedEmailDomains, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }
    }
}
