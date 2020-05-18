using System;
using System.Linq;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.Tests.ConnectorTests
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
            var tmpEmployee = new EmployeeConnector().Get("TEST_EMP") ?? new EmployeeConnector().Create(new Employee() { EmployeeId = "TEST_EMP" });
            var tmpProject = new ProjectConnector().Create(new Project() { Description = "TmpProject" });
            var tmpCostCenter = new CostCenterConnector().Get("TMP") ??  new CostCenterConnector().Create(new CostCenter() { Code = "TMP", Description = "TmpCostCenter" });
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
            MyAssert.HasNoError(connector);
            Assert.AreEqual(5.5m, createdAbsenceTransaction.Hours);

            #endregion CREATE

            #region UPDATE

            createdAbsenceTransaction.Hours = 8;

            var updatedAbsenceTransaction = connector.Update(createdAbsenceTransaction); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual(8, updatedAbsenceTransaction.Hours);

            #endregion UPDATE

            #region READ / GET

            var retrievedAbsenceTransaction = connector.Get(createdAbsenceTransaction.EmployeeId, createdAbsenceTransaction.Date, createdAbsenceTransaction.CauseCode);
            MyAssert.HasNoError(connector);
            Assert.AreEqual(8, retrievedAbsenceTransaction.Hours);

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdAbsenceTransaction.EmployeeId, createdAbsenceTransaction.Date, createdAbsenceTransaction.CauseCode);
            MyAssert.HasNoError(connector);

            retrievedAbsenceTransaction = connector.Get(createdAbsenceTransaction.EmployeeId, createdAbsenceTransaction.Date, createdAbsenceTransaction.CauseCode);
            Assert.AreEqual(null, retrievedAbsenceTransaction, "Entity still exists after Delete!");

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
                new AbsenceTransactionConnector().Delete(tmpEmployee.EmployeeId, new DateTime(2018, 01, 01).AddDays(i), AbsenceCauseCode.MIL);
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
