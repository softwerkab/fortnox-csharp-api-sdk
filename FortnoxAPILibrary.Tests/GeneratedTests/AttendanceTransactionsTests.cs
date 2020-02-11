using System;
using System.Collections.Generic;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.GeneratedTests
{
    [TestClass]
    public class AttendanceTransactionsTests
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
        public void Test_AttendanceTransactions_CRUD()
        {
            #region Arrange
            //Add code to create required resources
            #endregion Arrange

            var connector = new AttendanceTransactionsConnector();

            #region CREATE
            var newAttendanceTransactions = new AttendanceTransactions()
            {
                //TODO: Populate Entity
            };

            var createdAttendanceTransactions = connector.Create(newAttendanceTransactions);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("PropertyValue", createdAttendanceTransactions.SomeProperty); //TODO: Adapt

            #endregion CREATE

            #region UPDATE

            createdAttendanceTransactions.SomeProperty = "UpdatedPropertyValue"; //TODO: Adapt

            var updatedAttendanceTransactions = connector.Update(createdAttendanceTransactions); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", updatedAttendanceTransactions.SomeProperty); //TODO: Adapt

            #endregion UPDATE

            #region READ / GET

            var retrievedAttendanceTransactions = connector.Get(createdAttendanceTransactions.ID); //TODO: Check ID property
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", retrievedAttendanceTransactions.SomeProperty); //TODO: Adapt

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdAttendanceTransactions.ID); //TODO: Check ID property
            MyAssert.HasNoError(connector);

            retrievedAttendanceTransactions = connector.Get(createdAttendanceTransactions.ID); //TODO: Check ID property
            Assert.AreEqual(null, retrievedAttendanceTransactions, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }
    }
}
