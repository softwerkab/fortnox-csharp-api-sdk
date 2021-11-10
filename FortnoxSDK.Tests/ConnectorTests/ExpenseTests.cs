using System.Linq;
using System.Threading.Tasks;
using Fortnox.SDK;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests;

[TestClass]
public class ExpenseTests
{
    public FortnoxClient FortnoxClient = TestUtils.DefaultFortnoxClient;

    [TestMethod]
    public async Task Test_Expense_CRUD()
    {
        #region Arrange
        var tmpAccount = await FortnoxClient.AccountConnector.CreateAsync(new Account() { Number = TestUtils.GetUnusedAccountNumber(), Description = "TmpAccount" });
        #endregion Arrange

        var connector = FortnoxClient.ExpenseConnector;

        #region CREATE

        var newExpense = new Expense()
        {
            Text = "TestExpense",
            Code = TestUtils.RandomString(6),
            Account = tmpAccount.Number
        };

        var createdExpense = await connector.CreateAsync(newExpense);
        Assert.AreEqual("TestExpense", createdExpense.Text);

        #endregion CREATE

        #region UPDATE

        //Not supported

        #endregion UPDATE

        #region READ / GET

        var retrievedExpense = await connector.GetAsync(createdExpense.Code);
        Assert.AreEqual("TestExpense", retrievedExpense.Text);

        #endregion READ / GET

        #region DELETE

        //Not supported

        #endregion DELETE

        #region Delete arranged resources
        await FortnoxClient.AccountConnector.DeleteAsync(tmpAccount.Number);
        #endregion Delete arranged resources
    }

    [TestMethod]
    public async Task Test_Expense_Find()
    {
        #region Arrange
        var tmpAccount = await FortnoxClient.AccountConnector.CreateAsync(new Account() { Number = TestUtils.GetUnusedAccountNumber(), Description = "TmpAccount" });
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
            await connector.CreateAsync(newExpense);
        }

        var searchSettings = new ExpenseSearch();
        searchSettings.LastModified = TestUtils.Recently; //does not seem to work
        searchSettings.Limit = ApiConstants.Unlimited;
        var expensesCollection = await connector.FindAsync(searchSettings);

        var newExpenses = expensesCollection.Entities.Where(x => x.Text == remark).ToList();
        Assert.AreEqual(2, newExpenses.Count);
        Assert.IsNotNull(newExpenses.First().Url);

        #region Delete arranged resources
        await FortnoxClient.AccountConnector.DeleteAsync(tmpAccount.Number);
        #endregion Delete arranged resources
    }
}