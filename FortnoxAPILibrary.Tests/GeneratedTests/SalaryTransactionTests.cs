using System;
using System.Collections.Generic;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.GeneratedTests
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
            var tmpEmployee = new EmployeeConnector().Create(new Employee() {FirstName = "Test", LastName = "Testasson"});
            #endregion Arrange

            var connector = new SalaryTransactionConnector();

            #region CREATE
            var newSalaryTransaction = new SalaryTransaction()
            {
                EmployeeId = tmpEmployee.EmployeeId,
                SalaryCode = "123",
                Date = new DateTime(2020,1,1),
                Amount = 1250.50,
            };

            var createdSalaryTransaction = connector.Create(newSalaryTransaction);
            MyAssert.HasNoError(connector);
            Assert.AreEqual(1250.5, createdSalaryTransaction.Amount);

            #endregion CREATE

            #region UPDATE

            createdSalaryTransaction.Amount = 1500;

            var updatedSalaryTransaction = connector.Update(createdSalaryTransaction); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual(1500, updatedSalaryTransaction.Amount);

            #endregion UPDATE

            #region READ / GET

            var retrievedSalaryTransaction = connector.Get(createdSalaryTransaction.SalaryRow);
            MyAssert.HasNoError(connector);
            Assert.AreEqual(1500, retrievedSalaryTransaction.Amount);

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdSalaryTransaction.SalaryRow);
            MyAssert.HasNoError(connector);

            retrievedSalaryTransaction = connector.Get(createdSalaryTransaction.SalaryRow);
            Assert.AreEqual(null, retrievedSalaryTransaction, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            new EmployeeConnector().Delete(tmpEmployee.EmployeeId);
            #endregion Delete arranged resources
        }
    }
}
