using System;
using System.Linq;
using Fortnox.SDK;
using Fortnox.SDK.Connectors;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Exceptions;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests
{
    [TestClass]
    public class AbsenceTransactionTests
    {
        public FortnoxClient FortnoxClient = TestUtils.DefaultFortnoxClient;

        [TestMethod]
        public void Test_AbsenceTransaction_CRUD()
        {
            #region Arrange
            var tmpEmployee = new EmployeeConnector().Create(new Employee() { EmployeeId = TestUtils.RandomString() });
            var tmpProject = new ProjectConnector().Create(new Project() { Description = "TmpProject" });
            var tmpCostCenter = new CostCenterConnector().Create(new CostCenter() { Code = "TMP", Description = "TmpCostCenter" });
            #endregion Arrange

            IAbsenceTransactionConnector connector = new AbsenceTransactionConnector();

            #region CREATE
            var newAbsenceTransaction = new AbsenceTransaction()
            {
                EmployeeId = tmpEmployee.EmployeeId,
                CauseCode = AbsenceCauseCode.MIL,
                Date = new DateTime(2018, 01,01),
                Hours = 5.5m,
                CostCenter = tmpCostCenter.Code,
                Project = tmpProject.ProjectNumber
            };

            var createdAbsenceTransaction = connector.Create(newAbsenceTransaction);
            Assert.AreEqual(5.5m, createdAbsenceTransaction.Hours);

            #endregion CREATE

            #region UPDATE

            createdAbsenceTransaction.Hours = 8;

            var updatedAbsenceTransaction = connector.Update(createdAbsenceTransaction); 
            Assert.AreEqual(8, updatedAbsenceTransaction.Hours);

            #endregion UPDATE

            #region READ / GET

            var retrievedAbsenceTransaction = connector.Get(createdAbsenceTransaction.EmployeeId, createdAbsenceTransaction.Date, createdAbsenceTransaction.CauseCode);
            Assert.AreEqual(8, retrievedAbsenceTransaction.Hours);

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdAbsenceTransaction.EmployeeId, createdAbsenceTransaction.Date, createdAbsenceTransaction.CauseCode);

            Assert.ThrowsException<FortnoxApiException>(
                () => connector.Get(createdAbsenceTransaction.EmployeeId, createdAbsenceTransaction.Date, createdAbsenceTransaction.CauseCode),
                "Entity still exists after Delete!");

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

            var tmpEmployee = new EmployeeConnector().Create(new Employee() { EmployeeId = TestUtils.RandomString() });
            var tmpProject = new ProjectConnector().Create(new Project() { Description = "TmpProject" });
            var tmpCostCenter = new CostCenterConnector().Create(new CostCenter() { Code = "TMP", Description = "TmpCostCenter" });
            #endregion Arrange

            IAbsenceTransactionConnector connector = new AbsenceTransactionConnector();

            var newAbsenceTransaction = new AbsenceTransaction()
            {
                EmployeeId = tmpEmployee.EmployeeId,
                CauseCode = AbsenceCauseCode.MIL,
                Date = new DateTime(2018, 01, 01),
                Hours = 1,
                CostCenter = tmpCostCenter.Code,
                Project = tmpProject.ProjectNumber
            };

            //Add entries
            for (var i = 0; i < 5; i++)
            {
                newAbsenceTransaction.Date = new DateTime(2018, 01, 01).AddDays(i);
                connector.Create(newAbsenceTransaction);
            }

            var searchSettings = new AbsenceTransactionSearch();
            searchSettings.EmployeeId = tmpEmployee.EmployeeId;
            var fullCollection = connector.Find(searchSettings);

            Assert.AreEqual(5, fullCollection.TotalResources);
            Assert.AreEqual(5, fullCollection.Entities.Count);
            Assert.AreEqual(1, fullCollection.TotalPages);

            Assert.AreEqual(tmpEmployee.EmployeeId, fullCollection.Entities.First().EmployeeId);

            //Apply Limit
            searchSettings.Limit = 2;
            var limitedCollection = connector.Find(searchSettings);

            Assert.AreEqual(5, limitedCollection.TotalResources);
            Assert.AreEqual(2, limitedCollection.Entities.Count);
            Assert.AreEqual(3, limitedCollection.TotalPages);

            //Delete entries
            foreach (var entry in fullCollection.Entities)
                connector.Delete(entry.EmployeeId, entry.Date, entry.CauseCode);

            #region Delete arranged resources
            new CostCenterConnector().Delete(tmpCostCenter.Code);
            new ProjectConnector().Delete(tmpProject.ProjectNumber);
            #endregion Delete arranged resources
        }
    }
}
