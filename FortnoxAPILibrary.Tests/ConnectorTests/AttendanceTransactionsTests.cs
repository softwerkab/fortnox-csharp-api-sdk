using System;
using System.Linq;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.Tests.ConnectorTests
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

            IAttendanceTransactionsConnector connector = new AttendanceTransactionsConnector();

            #region CREATE
            var newAttendanceTransaction = new AttendanceTransaction()
            {
                EmployeeId = tmpEmployee.EmployeeId,
                CauseCode = AttendanceCauseCode.TID,
                Date = new DateTime(2018, 01, 01),
                Hours = 5.5m,
                CostCenter = tmpCostCenter.Code,
                Project = tmpProject.ProjectNumber
            };

            var createdAttendanceTransaction = connector.Create(newAttendanceTransaction);
            MyAssert.HasNoError(connector);
            Assert.AreEqual(5.5m, createdAttendanceTransaction.Hours);

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

        [TestMethod]
        public void Test_Find()
        {
            #region Arrange
            var tmpEmployee = new EmployeeConnector().Get("TEST_EMP") ?? new EmployeeConnector().Create(new Employee() { EmployeeId = "TEST_EMP" });
            var tmpProject = new ProjectConnector().Create(new Project() { Description = "TmpProject" });
            var tmpCostCenter = new CostCenterConnector().Get("TMP") ?? new CostCenterConnector().Create(new CostCenter() { Code = "TMP", Description = "TmpCostCenter" });

            for (var i = 0; i < 5; i++)
                new AttendanceTransactionsConnector().Delete(tmpEmployee.EmployeeId, new DateTime(2018, 01, 01).AddDays(i), AttendanceCauseCode.TID);
            #endregion Arrange

            IAttendanceTransactionsConnector connector = new AttendanceTransactionsConnector();

            var newAttendenceTransaction = new AttendanceTransaction()
            {
                EmployeeId = tmpEmployee.EmployeeId,
                CauseCode = AttendanceCauseCode.TID,
                Date = new DateTime(2018, 01, 01),
                Hours = 1,
                CostCenter = tmpCostCenter.Code,
                Project = tmpProject.ProjectNumber
            };

            //Add entries
            for (var i = 0; i < 5; i++)
            {
                newAttendenceTransaction.Date = new DateTime(2018, 01, 01).AddDays(i);
                connector.Create(newAttendenceTransaction);
                MyAssert.HasNoError(connector);
            }

            connector.EmployeeId = tmpEmployee.EmployeeId;
            var fullCollection = connector.Find();
            MyAssert.HasNoError(connector);

            Assert.AreEqual(5, fullCollection.TotalResources);
            Assert.AreEqual(5, fullCollection.Entities.Count);
            Assert.AreEqual(1, fullCollection.TotalPages);

            Assert.AreEqual(tmpEmployee.EmployeeId, fullCollection.Entities.First().EmployeeId);

            //Apply Limit
            connector.Limit = 2;
            var limitedCollection = connector.Find();
            MyAssert.HasNoError(connector);

            Assert.AreEqual(5, limitedCollection.TotalResources);
            Assert.AreEqual(2, limitedCollection.Entities.Count);
            Assert.AreEqual(3, limitedCollection.TotalPages);

            //Delete entries
            foreach (var entry in fullCollection.Entities)
            {
                connector.Delete(entry.EmployeeId, entry.Date, entry.CauseCode);
            }

            #region Delete arranged resources
            new CostCenterConnector().Delete(tmpCostCenter.Code);
            new ProjectConnector().Delete(tmpProject.ProjectNumber);
            #endregion Delete arranged resources
        }
    }
}
