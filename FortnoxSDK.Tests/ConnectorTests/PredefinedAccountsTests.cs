using Fortnox.SDK;
using Fortnox.SDK.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace FortnoxSDK.Tests.ConnectorTests;

[TestClass]
public class PredefinedAccountsTests
{
    private FortnoxClient FortnoxClient;

    [TestInitialize]
    public async Task TestInitialize()
    {
        FortnoxClient ??= await TestClient.GetFortnoxClient();
    }

    [TestMethod]
    public async Task Test_PredefinedAccounts_CRUD()
    {
        var connector = FortnoxClient.PredefinedAccountsConnector;

        //Get
        var bygAccount = await connector.GetAsync(PredefinedAccountName.ReverseChargeSEDebit);
        Assert.AreEqual(2647, bygAccount.Account);

        var patentAccount = await connector.GetAsync(PredefinedAccountName.ReverseChargeGoodsEUDebit);
        Assert.AreEqual(2645, patentAccount.Account);

        //Update
        patentAccount.Account = bygAccount.Account;
        await connector.UpdateAsync(patentAccount);
        Assert.AreEqual(2647, patentAccount.Account);

        //Revert
        patentAccount.Account = 2645;
        await connector.UpdateAsync(patentAccount);
        Assert.AreEqual(2645, patentAccount.Account);
    }

    [TestMethod]
    public async Task Test_PredefinedAccounts_Find()
    {
        var connector = FortnoxClient.PredefinedAccountsConnector;

        var fullCollection = await connector.FindAsync(null);

        Assert.AreEqual(48, fullCollection.Entities.Count);
        Assert.IsNotNull(fullCollection.Entities.First().Name);

        /* Limit not supported
        var searchSettings = new PredefinedAccountsSearch();
        searchSettings.Limit = 2;
        var limitedCollection = connector.Find(searchSettings);

        Assert.AreEqual(2, limitedCollection.Entities.Count);
        Assert.AreEqual(42, limitedCollection.TotalResources);
        */
    }

    /// <summary>
    /// It looks like that not all the Fortnox account have all accounts
    /// so this test may fail. Further investigations are needed in this regard.
    /// </summary>
    /// <returns></returns>
    //[TestMethod]
    //public async Task Test_FindAllAccounts()
    //{
    //    var connector = FortnoxClient.PredefinedAccountsConnector;

    //    var fields = typeof(PredefinedAccountName)
    //        .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
    //        .Where(fi => fi.IsLiteral && !fi.IsInitOnly);

    //    foreach (var field in fields)
    //    {
    //        var predefineradAccount = await connector.GetAsync((string?)field.GetValue(null));
    //        Assert.IsNotNull(predefineradAccount);
    //    }
    //}
}