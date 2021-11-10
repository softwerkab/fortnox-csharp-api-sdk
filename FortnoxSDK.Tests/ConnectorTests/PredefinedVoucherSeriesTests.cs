using System.Linq;
using System.Threading.Tasks;
using Fortnox.SDK;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests;

[TestClass]
public class PredefinedVoucherSeriesTests
{
    public FortnoxClient FortnoxClient = TestUtils.DefaultFortnoxClient;

    [TestMethod]
    public async Task Test_PredefinedVoucherSeries_CRUD()
    {
        var connector = FortnoxClient.PredefinedVoucherSeriesConnector;

        //Get
        var predefinedVoucherSeries = await connector.GetAsync("INVOICE");
        Assert.AreEqual("B", predefinedVoucherSeries.VoucherSeries);

        //Update
        predefinedVoucherSeries.VoucherSeries = "L"; //Lon -> "SALARY"
        await connector.UpdateAsync(predefinedVoucherSeries);
        Assert.AreEqual("L", predefinedVoucherSeries.VoucherSeries);

        //Reset
        predefinedVoucherSeries.VoucherSeries = "B";
        await connector.UpdateAsync(predefinedVoucherSeries);
        Assert.AreEqual("B", predefinedVoucherSeries.VoucherSeries);
    }

    [TestMethod]
    public async Task Test_Find()
    {
        var connector = FortnoxClient.PredefinedVoucherSeriesConnector;

        var fullCollection = await connector.FindAsync(null);

        Assert.AreEqual(13, fullCollection.Entities.Count);
        Assert.IsNotNull(fullCollection.Entities.First().Name);

        //Limit not supported
    }
}