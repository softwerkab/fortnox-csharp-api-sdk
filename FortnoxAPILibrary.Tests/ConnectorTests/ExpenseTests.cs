using System;
using System.Linq;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.Tests.ConnectorTests
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
            var ac = new AccountConnector();
            if (ac.Get(0123) == null) //account 123 does not exist
                ac.Create(new Account() {Number = 0123, Description = "TmpAccount"});
            #endregion Arrange

            IExpenseConnector connector = new ExpenseConnector();

            #region CREATE

            var newExpense = new Expense()
            {
                Text = "TestExpense",
                Code = TestUtils.RandomString(6),
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
            ac.Delete(0123);
            MyAssert.HasNoError(ac);

            #endregion Delete arranged resources
        }

        [TestMethod]
        public void Test_Expense_Find()
        {
            #region Arrange
            var ac = new AccountConnector();
            if (ac.Get(0123) == null) //account 123 does not exist
                ac.Create(new Account() { Number = 0123, Description = "TmpAccount" });
            #endregion Arrange

            var timeStamp = DateTime.Now;
            var remark = TestUtils.RandomString();

            var newExpense = new Expense()
            {
                Text = remark,
                Account = 0123
            };

            IExpenseConnector connector = new ExpenseConnector();
            for (var i = 0; i < 2; i++)
            {
                newExpense.Code = TestUtils.RandomString(6);
                connector.Create(newExpense);
                MyAssert.HasNoError(connector);
            }

            connector.LastModified = timeStamp; //does not seem to work
            var expensesCollection = connector.Find();

            var filteredExpenses = expensesCollection.Entities.Where(x => x.Text == remark).ToList();
            MyAssert.HasNoError(connector);
            Assert.AreEqual(2, filteredExpenses.Count);
            Assert.IsNotNull(filteredExpenses.First().Url);

            #region Delete arranged resources
            ac.Delete(0123);
            MyAssert.HasNoError(ac);
            #endregion Delete arranged resources
        }
    }
}
