using System;
using System.Linq;
using Fortnox.SDK;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests
{
    [TestClass]
    public class ExpenseTests
    {
        public FortnoxClient FortnoxClient = TestUtils.DefaultFortnoxClient;

        [TestMethod]
        public void Test_Expense_CRUD()
        {
            #region Arrange
            var tmpAccount = FortnoxClient.AccountConnector.Create(new Account() { Number = TestUtils.GetUnusedAccountNumber(), Description = "TmpAccount" });
            #endregion Arrange

            var connector = FortnoxClient.ExpenseConnector;

            #region CREATE

            var newExpense = new Expense()
            {
                Text = "TestExpense",
                Code = TestUtils.RandomString(6),
                Account = tmpAccount.Number
            };

            var createdExpense = connector.Create(newExpense);
            Assert.AreEqual("TestExpense", createdExpense.Text);

            #endregion CREATE

            #region UPDATE

            //Not supported

            #endregion UPDATE

            #region READ / GET

            var retrievedExpense = connector.Get(createdExpense.Code);
            Assert.AreEqual("TestExpense", retrievedExpense.Text);

            #endregion READ / GET

            #region DELETE

            //Not supported

            #endregion DELETE

            #region Delete arranged resources
            FortnoxClient.AccountConnector.Delete(tmpAccount.Number);
            #endregion Delete arranged resources
        }

        [TestMethod]
        public void Test_Expense_Find()
        {
            #region Arrange
            var tmpAccount = FortnoxClient.AccountConnector.Create(new Account() { Number = TestUtils.GetUnusedAccountNumber(), Description = "TmpAccount" });
            #endregion Arrange

            var remark = TestUtils.RandomString();

            var newExpense = new Expense()
            {
                Text = remark,
                Account = tmpAccount.Number
            };

            var connector = FortnoxClient.ExpenseConnector;
            for (var i = 0; i < 2; i++)
            {
                newExpense.Code = TestUtils.RandomString(6);
                connector.Create(newExpense);
            }

            var searchSettings = new ExpenseSearch();
            searchSettings.LastModified = TestUtils.Recently; //does not seem to work
            searchSettings.Limit = APIConstants.Unlimited;
            var expensesCollection = connector.Find(searchSettings);

            var newExpenses = expensesCollection.Entities.Where(x => x.Text == remark).ToList();
            Assert.AreEqual(2, newExpenses.Count);
            Assert.IsNotNull(newExpenses.First().Url);

            #region Delete arranged resources
            FortnoxClient.AccountConnector.Delete(tmpAccount.Number);
            #endregion Delete arranged resources
        }
    }
}
