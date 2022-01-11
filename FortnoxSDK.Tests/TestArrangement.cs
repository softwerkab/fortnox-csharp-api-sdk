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
            // Delete hanging entities from failed execution
            await FortnoxClient.CostCenterConnector.DeleteAsync("TMP");
        }
        catch
        {
            // Ignore
        }
    }
}
