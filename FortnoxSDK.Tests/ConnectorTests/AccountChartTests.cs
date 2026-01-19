using System.Linq;
using System.Threading.Tasks;
using Fortnox.SDK;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests;

[TestClass]
public class AccountChartTests
{
    private FortnoxClient FortnoxClient;

    [TestInitialize]
    public async Task TestInitialize()
    {
        FortnoxClient ??= await TestClient.GetFortnoxClient();
    }

    [TestMethod]
    public void Test_AccountChart_CRUD()
    {
        //Not supported
    }

    [TestMethod]
    public async Task Test_AccountChart_Find()
    {
        var connector = FortnoxClient.AccountChartConnector;

        var fullCollection = await connector.FindAsync(null);

        Assert.AreEqual(4, fullCollection.Entities.Count);
        Assert.IsNotNull(fullCollection.Entities.First().Name);

        //Limit not supported
    }
}