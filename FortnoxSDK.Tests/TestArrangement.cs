using Fortnox.SDK;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace FortnoxSDK.Tests;

[TestClass]
public class TestArrangement
{
    public static FortnoxClient FortnoxClient = TestUtils.DefaultFortnoxClient;

    [AssemblyInitialize]
    public static async Task ArrangeSandbox(TestContext context)
    {
        try
        {
            await FortnoxClient.CostCenterConnector.DeleteAsync("TMP");
        }
        catch
        {
            // ignored
        }

        try
        {
            await FortnoxClient.WayOfDeliveryConnector.DeleteAsync("TST");
        }
        catch
        {
            // Ignore
        }
    }
}
