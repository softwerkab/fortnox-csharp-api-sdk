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
            var tmpEmployee = new EmployeeConnector().Get("TEST_EMP") ?? new EmployeeConnector().Create(new Employee() { EmployeeId = "TEST_EMP" });
            var tmpProject = new ProjectConnector().Create(new Project() { Description = "TmpProject" });
            var tmpCostCenter = new CostCenterConnector().Get("TMP") ??  new CostCenterConnector().Create(new CostCenter() { Code = "TMP", Description = "TmpCostCenter" });
            #endregion Arrange

            var connector = new AbsenceTransactionConnector();

            #region CREATE
            var newAbsenceTransaction = new AbsenceTransaction()
            {
                EmployeeId = tmpEmployee.EmployeeId,
                CauseCode = AbsenceCauseCode.MIL,
                Date = new DateTime(2018, 01,01),
                Hours = 5.5,
                CostCenter = tmpCostCenter.Code,
                Project = tmpProject.ProjectNumber
            };

            var createdAbsenceTransaction = connector.Create(newAbsenceTransaction);
            MyAssert.HasNoError(connector);
            Assert.AreEqual(5.5, createdAbsenceTransaction.Hours);

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
    }
}
