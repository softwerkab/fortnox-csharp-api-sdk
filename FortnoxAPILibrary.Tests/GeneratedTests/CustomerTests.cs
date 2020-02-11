using System;
using System.Collections.Generic;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.GeneratedTests
{
    [TestClass]
    public class CustomerTests
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
        public void Test_Customer_CRUD()
        {
            #region Arrange
            //Add code to create required resources
            #endregion Arrange

            var connector = new CustomerConnector();

            #region CREATE
            var newCustomer = new Customer()
            {
                //TODO: Populate Entity
            };

            var createdCustomer = connector.Create(newCustomer);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("PropertyValue", createdCustomer.SomeProperty); //TODO: Adapt

            #endregion CREATE

            #region UPDATE

            createdCustomer.SomeProperty = "UpdatedPropertyValue"; //TODO: Adapt

            var updatedCustomer = connector.Update(createdCustomer); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", updatedCustomer.SomeProperty); //TODO: Adapt

            #endregion UPDATE

            #region READ / GET

            var retrievedCustomer = connector.Get(createdCustomer.CustomerNumber); //TODO: Check ID property
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", retrievedCustomer.SomeProperty); //TODO: Adapt

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdCustomer.CustomerNumber); //TODO: Check ID property
            MyAssert.HasNoError(connector);

            retrievedCustomer = connector.Get(createdCustomer.CustomerNumber); //TODO: Check ID property
            Assert.AreEqual(null, retrievedCustomer, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }
    }
}
