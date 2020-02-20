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

        [Ignore("CAN NOT UPDATE OR DELETE")]
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
            //Not supported
            #endregion UPDATE

            #region READ / GET

            var retrievedExpense = connector.Get(createdExpense.Code);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("TestExpense", retrievedExpense.Text);

            #endregion READ / GET

            #region DELETE
            //Not supported
            #endregion DELETE

            #region Delete arranged resources
            var accConnector = new AccountConnector();
            accConnector.Delete(0123);
            MyAssert.HasNoError(accConnector);
            #endregion Delete arranged resources
        }
    }
}
