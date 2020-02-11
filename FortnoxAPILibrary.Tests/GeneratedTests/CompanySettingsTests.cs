using System;
using System.Collections.Generic;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.GeneratedTests
{
    [TestClass]
    public class CompanySettingsTests
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
        public void Test_CompanySettings_CRUD()
        {
            #region Arrange
            //Add code to create required resources
            #endregion Arrange

            var connector = new CompanySettingsConnector();

            #region CREATE
            var newCompanySettings = new CompanySettings()
            {
                //TODO: Populate Entity
            };

            var createdCompanySettings = connector.Create(newCompanySettings);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("PropertyValue", createdCompanySettings.SomeProperty); //TODO: Adapt

            #endregion CREATE

            #region UPDATE

            createdCompanySettings.SomeProperty = "UpdatedPropertyValue"; //TODO: Adapt

            var updatedCompanySettings = connector.Update(createdCompanySettings); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", updatedCompanySettings.SomeProperty); //TODO: Adapt

            #endregion UPDATE

            #region READ / GET

            var retrievedCompanySettings = connector.Get(createdCompanySettings.ID); //TODO: Check ID property
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", retrievedCompanySettings.SomeProperty); //TODO: Adapt

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdCompanySettings.ID); //TODO: Check ID property
            MyAssert.HasNoError(connector);

            retrievedCompanySettings = connector.Get(createdCompanySettings.ID); //TODO: Check ID property
            Assert.AreEqual(null, retrievedCompanySettings, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }
    }
}
