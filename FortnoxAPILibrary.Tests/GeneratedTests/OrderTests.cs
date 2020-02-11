using System;
using System.Collections.Generic;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.GeneratedTests
{
    [TestClass]
    public class OrderTests
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
        public void Test_Order_CRUD()
        {
            #region Arrange
            //Add code to create required resources
            #endregion Arrange

            var connector = new OrderConnector();

            #region CREATE
            var newOrder = new Order()
            {
                //TODO: Populate Entity
            };

            var createdOrder = connector.Create(newOrder);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("PropertyValue", createdOrder.SomeProperty); //TODO: Adapt

            #endregion CREATE

            #region UPDATE

            createdOrder.SomeProperty = "UpdatedPropertyValue"; //TODO: Adapt

            var updatedOrder = connector.Update(createdOrder); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", updatedOrder.SomeProperty); //TODO: Adapt

            #endregion UPDATE

            #region READ / GET

            var retrievedOrder = connector.Get(createdOrder.DocumentNumber); //TODO: Check ID property
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", retrievedOrder.SomeProperty); //TODO: Adapt

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdOrder.DocumentNumber); //TODO: Check ID property
            MyAssert.HasNoError(connector);

            retrievedOrder = connector.Get(createdOrder.DocumentNumber); //TODO: Check ID property
            Assert.AreEqual(null, retrievedOrder, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }
    }
}
