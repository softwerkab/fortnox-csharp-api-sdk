using System;
using System.Collections.Generic;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.GeneratedTests
{
    [TestClass]
    public class LockedPeriodTests
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
        public void Test_LockedPeriod_CRUD()
        {
            #region Arrange
            //Add code to create required resources
            #endregion Arrange

            var connector = new LockedPeriodConnector();

            #region CREATE
            var newLockedPeriod = new LockedPeriod()
            {
                //TODO: Populate Entity
            };

            var createdLockedPeriod = connector.Create(newLockedPeriod);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("PropertyValue", createdLockedPeriod.SomeProperty); //TODO: Adapt

            #endregion CREATE

            #region UPDATE

            createdLockedPeriod.SomeProperty = "UpdatedPropertyValue"; //TODO: Adapt

            var updatedLockedPeriod = connector.Update(createdLockedPeriod); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", updatedLockedPeriod.SomeProperty); //TODO: Adapt

            #endregion UPDATE

            #region READ / GET

            var retrievedLockedPeriod = connector.Get(createdLockedPeriod.ID); //TODO: Check ID property
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", retrievedLockedPeriod.SomeProperty); //TODO: Adapt

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdLockedPeriod.ID); //TODO: Check ID property
            MyAssert.HasNoError(connector);

            retrievedLockedPeriod = connector.Get(createdLockedPeriod.ID); //TODO: Check ID property
            Assert.AreEqual(null, retrievedLockedPeriod, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }
    }
}
