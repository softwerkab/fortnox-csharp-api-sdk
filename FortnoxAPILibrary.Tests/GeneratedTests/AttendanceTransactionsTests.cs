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
            var employeeConnector = new EmployeeConnector();
            var tmpEmployee = employeeConnector.Create(new Employee()
            {
                FirstName = "Test",
                LastName = "Name",
            });
            MyAssert.HasNoError(employeeConnector);
            #endregion Arrange

            var connector = new AttendanceTransactionsConnector();

            #region CREATE
            var newAttendanceTransactions = new AttendanceTransaction()
            {
                EmployeeId = tmpEmployee.EmployeeId,
                CauseCode = AttendanceCauseCode.FLX,
                Date = new DateTime(2018, 01, 01),
                Hours = 5.5
            };

            var createdAttendanceTransactions = connector.Create(newAttendanceTransactions);
            MyAssert.HasNoError(connector);
            Assert.AreEqual(5.5, createdAttendanceTransactions.Hours);

            #endregion CREATE

            #region UPDATE

            createdAttendanceTransactions.Hours = 8;

            var updatedAttendanceTransactions = connector.Update(createdAttendanceTransactions); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual(8, updatedAttendanceTransactions.Hours);

            #endregion UPDATE

            #region READ / GET

            var retrievedAttendanceTransactions = connector.Get(createdAttendanceTransactions.EmployeeId, createdAttendanceTransactions.Date, createdAttendanceTransactions.CauseCode);
            MyAssert.HasNoError(connector);
            Assert.AreEqual(8, retrievedAttendanceTransactions.Hours);

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdAttendanceTransactions.EmployeeId, createdAttendanceTransactions.Date, createdAttendanceTransactions.CauseCode);
            MyAssert.HasNoError(connector);

            retrievedAttendanceTransactions = connector.Get(createdAttendanceTransactions.EmployeeId, createdAttendanceTransactions.Date, createdAttendanceTransactions.CauseCode);
            Assert.AreEqual(null, retrievedAttendanceTransactions, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }
    }
}
