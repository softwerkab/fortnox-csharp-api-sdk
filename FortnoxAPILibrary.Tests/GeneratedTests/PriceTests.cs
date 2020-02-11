using System;
using System.Collections.Generic;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.GeneratedTests
{
    [TestClass]
    public class PriceTests
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
        public void Test_Price_CRUD()
        {
            #region Arrange
            //Add code to create required resources
            #endregion Arrange

            var connector = new PriceConnector();

            #region CREATE
            var newPrice = new Price()
            {
                //TODO: Populate Entity
            };

            var createdPrice = connector.Create(newPrice);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("PropertyValue", createdPrice.SomeProperty); //TODO: Adapt

            #endregion CREATE

            #region UPDATE

            createdPrice.SomeProperty = "UpdatedPropertyValue"; //TODO: Adapt

            var updatedPrice = connector.Update(createdPrice); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", updatedPrice.SomeProperty); //TODO: Adapt

            #endregion UPDATE

            #region READ / GET

            var retrievedPrice = connector.Get(createdPrice.ID); //TODO: Check ID property
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", retrievedPrice.SomeProperty); //TODO: Adapt

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdPrice.ID); //TODO: Check ID property
            MyAssert.HasNoError(connector);

            retrievedPrice = connector.Get(createdPrice.ID); //TODO: Check ID property
            Assert.AreEqual(null, retrievedPrice, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }
    }
}
