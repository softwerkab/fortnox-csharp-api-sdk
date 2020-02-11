using System;
using System.Collections.Generic;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.GeneratedTests
{
    [TestClass]
    public class WayOfDeliveryTests
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
        public void Test_WayOfDelivery_CRUD()
        {
            #region Arrange
            //Add code to create required resources
            #endregion Arrange

            var connector = new WayOfDeliveryConnector();

            #region CREATE
            var newWayOfDelivery = new WayOfDelivery()
            {
                Code = "TST",
                Description = "TestDeliveryMethod"
            };

            var createdWayOfDelivery = connector.Create(newWayOfDelivery);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("TestDeliveryMethod", createdWayOfDelivery.Description);

            #endregion CREATE

            #region UPDATE

            createdWayOfDelivery.Description = "UpdatedTestDeliveryMethod";

            var updatedWayOfDelivery = connector.Update(createdWayOfDelivery); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedTestDeliveryMethod", updatedWayOfDelivery.Description);

            #endregion UPDATE

            #region READ / GET

            var retrievedWayOfDelivery = connector.Get(createdWayOfDelivery.Code);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedTestDeliveryMethod", retrievedWayOfDelivery.Description);

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdWayOfDelivery.Code);
            MyAssert.HasNoError(connector);

            retrievedWayOfDelivery = connector.Get(createdWayOfDelivery.Code);
            Assert.AreEqual(null, retrievedWayOfDelivery, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }
    }
}
