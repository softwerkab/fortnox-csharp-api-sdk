using System;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.Tests.ConnectorTests
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
            var tmpEmployee = new EmployeeConnector().Get("TEST_EMP") ?? new EmployeeConnector().Create(new Employee() { EmployeeId = "TEST_EMP" });
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
            MyAssert.HasNoError(connector);
            Assert.AreEqual("TestSalaryRow", createdSalaryTransaction.TextRow);

            #endregion CREATE

            #region UPDATE

            createdSalaryTransaction.TextRow = "UpdatedTestSalaryRow";

            var updatedSalaryTransaction = connector.Update(createdSalaryTransaction); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedTestSalaryRow", updatedSalaryTransaction.TextRow);

            #endregion UPDATE

            #region READ / GET

            var retrievedSalaryTransaction = connector.Get(createdSalaryTransaction.SalaryRow);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedTestSalaryRow", retrievedSalaryTransaction.TextRow);

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdSalaryTransaction.SalaryRow);
            MyAssert.HasNoError(connector);

            retrievedSalaryTransaction = connector.Get(createdSalaryTransaction.SalaryRow);
            Assert.AreEqual(null, retrievedSalaryTransaction, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            #endregion Delete arranged resources
        }
    }
}
