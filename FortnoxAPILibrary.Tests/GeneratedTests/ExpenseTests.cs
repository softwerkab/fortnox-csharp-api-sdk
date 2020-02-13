using System;
using System.Collections.Generic;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.GeneratedTests
{
    [TestClass]
    public class ExpenseTests
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
        public void Test_Expense_CRUD()
        {
            #region Arrange
            new AccountConnector().Create(new Account() {Number = 0123, Description = "TmpAccount"});
            #endregion Arrange

            var connector = new ExpenseConnector();

            #region CREATE
            var newExpense = new Expense()
            {
                Text = "TestExpense",
                Code = "TST",
                Account = 0123
            };

            var createdExpense = connector.Create(newExpense);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("TestExpense", createdExpense.Text);

            #endregion CREATE

            #region UPDATE

            createdExpense.Text = "UpdatedTestExpense";

            var updatedExpense = connector.Update(createdExpense); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedTestExpense", updatedExpense.Text);

            #endregion UPDATE

            #region READ / GET

            var retrievedExpense = connector.Get(createdExpense.Code);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedTestExpense", retrievedExpense.Text);

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdExpense.Code);
            MyAssert.HasNoError(connector);

            retrievedExpense = connector.Get(createdExpense.Code);
            Assert.AreEqual(null, retrievedExpense, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            new AccountConnector().Delete(0123);
            #endregion Delete arranged resources
        }
    }
}
