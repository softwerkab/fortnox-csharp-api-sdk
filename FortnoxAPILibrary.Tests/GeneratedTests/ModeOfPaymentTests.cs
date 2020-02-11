using System;
using System.Collections.Generic;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.GeneratedTests
{
    [TestClass]
    public class ModeOfPaymentTests
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
        public void Test_ModeOfPayment_CRUD()
        {
            #region Arrange
            //Add code to create required resources
            #endregion Arrange

            var connector = new ModeOfPaymentConnector();

            #region CREATE
            var newModeOfPayment = new ModeOfPayment()
            {
                //TODO: Populate Entity
            };

            var createdModeOfPayment = connector.Create(newModeOfPayment);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("PropertyValue", createdModeOfPayment.SomeProperty); //TODO: Adapt

            #endregion CREATE

            #region UPDATE

            createdModeOfPayment.SomeProperty = "UpdatedPropertyValue"; //TODO: Adapt

            var updatedModeOfPayment = connector.Update(createdModeOfPayment); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", updatedModeOfPayment.SomeProperty); //TODO: Adapt

            #endregion UPDATE

            #region READ / GET

            var retrievedModeOfPayment = connector.Get(createdModeOfPayment.Code); //TODO: Check ID property
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", retrievedModeOfPayment.SomeProperty); //TODO: Adapt

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdModeOfPayment.Code); //TODO: Check ID property
            MyAssert.HasNoError(connector);

            retrievedModeOfPayment = connector.Get(createdModeOfPayment.Code); //TODO: Check ID property
            Assert.AreEqual(null, retrievedModeOfPayment, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }
    }
}
