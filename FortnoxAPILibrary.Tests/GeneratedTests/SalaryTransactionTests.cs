using System;
using System.Collections.Generic;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.GeneratedTests
{
    [TestClass]
    public class SalaryTransactionTests
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
        public void Test_SalaryTransaction_CRUD()
        {
            #region Arrange
            //Add code to create required resources
            #endregion Arrange

            var connector = new SalaryTransactionConnector();

            #region CREATE
            var newSalaryTransaction = new SalaryTransaction()
            {
                //TODO: Populate Entity
            };

            var createdSalaryTransaction = connector.Create(newSalaryTransaction);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("PropertyValue", createdSalaryTransaction.SomeProperty); //TODO: Adapt

            #endregion CREATE

            #region UPDATE

            createdSalaryTransaction.SomeProperty = "UpdatedPropertyValue"; //TODO: Adapt

            var updatedSalaryTransaction = connector.Update(createdSalaryTransaction); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", updatedSalaryTransaction.SomeProperty); //TODO: Adapt

            #endregion UPDATE

            #region READ / GET

            var retrievedSalaryTransaction = connector.Get(createdSalaryTransaction.Number); //TODO: Check ID property
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", retrievedSalaryTransaction.SomeProperty); //TODO: Adapt

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdSalaryTransaction.Number); //TODO: Check ID property
            MyAssert.HasNoError(connector);

            retrievedSalaryTransaction = connector.Get(createdSalaryTransaction.Number); //TODO: Check ID property
            Assert.AreEqual(null, retrievedSalaryTransaction, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }
    }
}
