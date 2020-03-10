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
            var tmpEmployee = new EmployeeConnector().Get("TEST_EMP") ?? new EmployeeConnector().Create(new Employee() { EmployeeId = "TEST_EMP" });
            var tmpProject = new ProjectConnector().Create(new Project() {Description = "TmpProject"});
            var tmpCostCenter = new CostCenterConnector().Get("TMP") ?? new CostCenterConnector().Create(new CostCenter() {Code = "TMP", Description = "TmpCostCenter"});
            #endregion Arrange

            var connector = new AttendanceTransactionsConnector();

            #region CREATE
            var newAttendanceTransaction = new AttendanceTransaction()
            {
                EmployeeId = tmpEmployee.EmployeeId,
                CauseCode = AttendanceCauseCode.TID,
                Date = new DateTime(2018, 01, 01),
                Hours = 5.5,
                CostCenter = tmpCostCenter.Code,
                Project = tmpProject.ProjectNumber
            };

            var createdAttendanceTransaction = connector.Create(newAttendanceTransaction);
            MyAssert.HasNoError(connector);
            Assert.AreEqual(5.5, createdAttendanceTransaction.Hours);

            #endregion CREATE

            #region UPDATE

            createdAttendanceTransaction.Hours = 8;

            var updatedAttendanceTransaction = connector.Update(createdAttendanceTransaction); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual(8, updatedAttendanceTransaction.Hours);

            #endregion UPDATE

            #region READ / GET

            var retrievedAttendanceTransaction = connector.Get(createdAttendanceTransaction.EmployeeId, createdAttendanceTransaction.Date, createdAttendanceTransaction.CauseCode);
            MyAssert.HasNoError(connector);
            Assert.AreEqual(8, retrievedAttendanceTransaction.Hours);

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdAttendanceTransaction.EmployeeId, createdAttendanceTransaction.Date, createdAttendanceTransaction.CauseCode);
            MyAssert.HasNoError(connector);

            retrievedAttendanceTransaction = connector.Get(createdAttendanceTransaction.EmployeeId, createdAttendanceTransaction.Date, createdAttendanceTransaction.CauseCode);
            Assert.AreEqual(null, retrievedAttendanceTransaction, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            new CostCenterConnector().Delete(tmpCostCenter.Code);
            new ProjectConnector().Delete(tmpProject.ProjectNumber);
            #endregion Delete arranged resources
        }
    }
}
