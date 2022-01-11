using System.Linq;
using System.Threading.Tasks;
using Fortnox.SDK;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Exceptions;
using Fortnox.SDK.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests;

[TestClass]
public class AccountTests
{
    public FortnoxClient FortnoxClient = TestUtils.DefaultFortnoxClient;

    [TestMethod]
    public async Task Test_Account_CRUD()
    {
        var connector = FortnoxClient.AccountConnector;

        #region CREATE
        var newAccount = new Account()
        {
            Description = "Test Account",
            Active = false,
            Number = TestUtils.GetUnusedAccountNumber(),
            CostCenterSettings = CostCenterSettings.Allowed,
            ProjectSettings = ProjectSettings.Allowed,
            SRU = 123
        };

        var createdAccount = await connector.CreateAsync(newAccount);
        Assert.AreEqual("Test Account", createdAccount.Description);

        #endregion CREATE

        #region UPDATE

        createdAccount.Description = "Updated Test Account";

        var updatedAccount = await connector.UpdateAsync(createdAccount);
        Assert.AreEqual("Updated Test Account", updatedAccount.Description);

        #endregion UPDATE

        #region READ / GET

        var retrievedAccount = await connector.GetAsync(createdAccount.Number);
        Assert.AreEqual("Updated Test Account", retrievedAccount.Description);

        #endregion READ / GET

        #region DELETE

        await connector.DeleteAsync(createdAccount.Number);

        await Assert.ThrowsExceptionAsync<FortnoxApiException>(
            async () => await connector.GetAsync(createdAccount.Number),
            "Entity still exists after Delete!");

        #endregion DELETE

        #region Delete arranged resources
        //Add code to delete temporary resources
        #endregion Delete arranged resources
    }

    [TestMethod]
    public async Task Test_Account_CRUD_SpecificFinYear()
    {
        var specificFinYear = (await FortnoxClient.FinancialYearConnector.FindAsync(null)).Entities.First(y => y.FromDate?.Year == 2018); //get fin year 2018

        var connector = FortnoxClient.AccountConnector;

        #region CREATE
        var newAccount = new Account()
        {
            Description = "Test Account",
            Active = false,
            Number = TestUtils.GetUnusedAccountNumber(),
            CostCenterSettings = CostCenterSettings.Allowed,
            ProjectSettings = ProjectSettings.Allowed,
            SRU = 123
        };

        var createdAccount = await connector.CreateAsync(newAccount, specificFinYear.Id);
        Assert.AreEqual(specificFinYear.Id, createdAccount.Year);
        Assert.AreEqual("Test Account", createdAccount.Description);

        #endregion CREATE

        #region UPDATE

        createdAccount.Description = "Updated Test Account";

        var updatedAccount = await connector.UpdateAsync(createdAccount, specificFinYear.Id);
        Assert.AreEqual("Updated Test Account", updatedAccount.Description);
        Assert.AreEqual(specificFinYear.Id, updatedAccount.Year);

        #endregion UPDATE

        #region READ / GET

        var retrievedAccount = await connector.GetAsync(createdAccount.Number, specificFinYear.Id);
        Assert.AreEqual("Updated Test Account", retrievedAccount.Description);
        Assert.AreEqual(specificFinYear.Id, retrievedAccount.Year);

        #endregion READ / GET

        #region DELETE

        await connector.DeleteAsync(createdAccount.Number, specificFinYear.Id);

        await Assert.ThrowsExceptionAsync<FortnoxApiException>(
            async () => await connector.GetAsync(createdAccount.Number, specificFinYear.Id),
            "Entity still exists after Delete!");

        #endregion DELETE

        #region Delete arranged resources
        //Add code to delete temporary resources
        #endregion Delete arranged resources
    }

    [TestMethod]
    public async Task Test_Find()
    {
        #region Arrange
        //Add code to create required resources
        #endregion Arrange

        var testKeyMark = TestUtils.RandomInt();

        var connector = FortnoxClient.AccountConnector;
        var newAccount = new Account()
        {
            Description = "Test Account",
            Active = false,
            CostCenterSettings = CostCenterSettings.Allowed,
            ProjectSettings = ProjectSettings.Allowed,
            SRU = testKeyMark
        };

        //Add entries
        for (var i = 0; i < 5; i++)
        {
            newAccount.Number = TestUtils.GetUnusedAccountNumber();
            await connector.CreateAsync(newAccount);
        }

        //Apply base test filter
        var searchSettings = new AccountSearch();
        searchSettings.SRU = testKeyMark.ToString();

        var fullCollection = await connector.FindAsync(searchSettings);

        Assert.AreEqual(5, fullCollection.TotalResources);
        Assert.AreEqual(5, fullCollection.Entities.Count);
        Assert.AreEqual(1, fullCollection.TotalPages);

        //Apply Limit
        searchSettings.Limit = 2;
        var limitedCollection = await connector.FindAsync(searchSettings);

        Assert.AreEqual(5, limitedCollection.TotalResources);
        Assert.AreEqual(2, limitedCollection.Entities.Count);
        Assert.AreEqual(3, limitedCollection.TotalPages);

        //Delete entries
        foreach (var entry in fullCollection.Entities)
        {
            await connector.DeleteAsync(entry.Number);
        }
        #region Delete arranged resources

        //Add code to delete temporary resources

        #endregion Delete arranged resources
    }
}