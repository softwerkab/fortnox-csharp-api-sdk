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
            var tmpAccount = new AccountConnector().Create(new Account(){Description = "TestAccount", Number = 0123});
            #endregion Arrange

            var connector = new ModeOfPaymentConnector();
            connector.Delete("TEST_MODE");
            #region CREATE
            var newModeOfPayment = new ModeOfPayment()
            {
                Description = "TestMode",
                AccountNumber = 0123,
                Code = "TEST_MODE",
            };

            var createdModeOfPayment = connector.Create(newModeOfPayment);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("TestMode", createdModeOfPayment.Description);

            #endregion CREATE

            #region UPDATE

            createdModeOfPayment.Description = "UpdatedMode";

            var updatedModeOfPayment = connector.Update(createdModeOfPayment); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedMode", updatedModeOfPayment.Description);

            #endregion UPDATE

            #region READ / GET

            var retrievedModeOfPayment = connector.Get(createdModeOfPayment.Code);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedMode", retrievedModeOfPayment.Description);

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdModeOfPayment.Code);
            MyAssert.HasNoError(connector);

            retrievedModeOfPayment = connector.Get(createdModeOfPayment.Code);
            Assert.AreEqual(null, retrievedModeOfPayment, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            new AccountConnector().Delete(0123);
            #endregion Delete arranged resources
        }
    }
}
