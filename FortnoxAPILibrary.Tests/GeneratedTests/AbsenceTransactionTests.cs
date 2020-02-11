using System;
using System.Collections.Generic;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.GeneratedTests
{
    [TestClass]
    public class AbsenceTransactionTests
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
        public void Test_AbsenceTransaction_CRUD()
        {
            #region Arrange
            //Add code to create required resources
            #endregion Arrange

            var connector = new AbsenceTransactionConnector();

            #region CREATE
            var newAbsenceTransaction = new AbsenceTransaction()
            {
                //TODO: Populate Entity
            };

            var createdAbsenceTransaction = connector.Create(newAbsenceTransaction);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("PropertyValue", createdAbsenceTransaction.SomeProperty); //TODO: Adapt

            #endregion CREATE

            #region UPDATE

            createdAbsenceTransaction.SomeProperty = "UpdatedPropertyValue"; //TODO: Adapt

            var updatedAbsenceTransaction = connector.Update(createdAbsenceTransaction); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", updatedAbsenceTransaction.SomeProperty); //TODO: Adapt

            #endregion UPDATE

            #region READ / GET

            var retrievedAbsenceTransaction = connector.Get(createdAbsenceTransaction.ID); //TODO: Check ID property
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", retrievedAbsenceTransaction.SomeProperty); //TODO: Adapt

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdAbsenceTransaction.ID); //TODO: Check ID property
            MyAssert.HasNoError(connector);

            retrievedAbsenceTransaction = connector.Get(createdAbsenceTransaction.ID); //TODO: Check ID property
            Assert.AreEqual(null, retrievedAbsenceTransaction, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }
    }
}
