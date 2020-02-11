using System;
using System.Collections.Generic;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.GeneratedTests
{
    [TestClass]
    public class CurrencyTests
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
        public void Test_Currency_CRUD()
        {
            #region Arrange
            //Add code to create required resources
            #endregion Arrange

            var connector = new CurrencyConnector();

            #region CREATE
            var newCurrency = new Currency()
            {
                //TODO: Populate Entity
            };

            var createdCurrency = connector.Create(newCurrency);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("PropertyValue", createdCurrency.SomeProperty); //TODO: Adapt

            #endregion CREATE

            #region UPDATE

            createdCurrency.SomeProperty = "UpdatedPropertyValue"; //TODO: Adapt

            var updatedCurrency = connector.Update(createdCurrency); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", updatedCurrency.SomeProperty); //TODO: Adapt

            #endregion UPDATE

            #region READ / GET

            var retrievedCurrency = connector.Get(createdCurrency.Code); //TODO: Check ID property
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", retrievedCurrency.SomeProperty); //TODO: Adapt

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdCurrency.Code); //TODO: Check ID property
            MyAssert.HasNoError(connector);

            retrievedCurrency = connector.Get(createdCurrency.Code); //TODO: Check ID property
            Assert.AreEqual(null, retrievedCurrency, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }
    }
}
