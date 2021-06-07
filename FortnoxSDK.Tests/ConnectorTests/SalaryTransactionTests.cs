using System;
using Fortnox.SDK;
using Fortnox.SDK.Connectors;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Exceptions;
using Fortnox.SDK.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests
{
    [TestClass]
    public class SalaryTransactionTests
    {
        public FortnoxClient FortnoxClient = TestUtils.DefaultFortnoxClient;

        [TestMethod]
        public void Test_SalaryTransaction_CRUD()
        {
            #region Arrange
            var tmpEmployee = new EmployeeConnector().Create(new Employee() { EmployeeId = TestUtils.RandomString() });
            #endregion Arrange

            ISalaryTransactionConnector connector = new SalaryTransactionConnector();

            #region CREATE
            var newSalaryTransaction = new SalaryTransaction()
            {
                EmployeeId = tmpEmployee.EmployeeId,
                SalaryCode = "11", //Arbetstid
                Date = new DateTime(2020,1,1),
                Number = 10,
                TextRow = "TestSalaryRow"
            };

            var createdSalaryTransaction = connector.Create(newSalaryTransaction);
            Assert.AreEqual("TestSalaryRow", createdSalaryTransaction.TextRow);

            #endregion CREATE

            #region UPDATE

            createdSalaryTransaction.TextRow = "UpdatedTestSalaryRow";

            var updatedSalaryTransaction = connector.Update(createdSalaryTransaction); 
            Assert.AreEqual("UpdatedTestSalaryRow", updatedSalaryTransaction.TextRow);

            #endregion UPDATE

            #region READ / GET

            var retrievedSalaryTransaction = connector.Get(createdSalaryTransaction.SalaryRow);
            Assert.AreEqual("UpdatedTestSalaryRow", retrievedSalaryTransaction.TextRow);

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdSalaryTransaction.SalaryRow);

            Assert.ThrowsException<FortnoxApiException>(
                () => connector.Get(createdSalaryTransaction.SalaryRow),
                "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            #endregion Delete arranged resources
        }
    }
}
