using System.Threading.Tasks;
using Fortnox.SDK;
using Fortnox.SDK.Authorization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests;

[TestClass]
public class ProfileTests
{
    [Ignore("Does not work with old auth")]
    [TestMethod]
    public async Task Get_OldAuth()
    {
        var fortnoxClient = TestUtils.DefaultFortnoxClient;

        var connector = fortnoxClient.ProfileConnector;
        var profile = await connector.GetAsync();

        Assert.AreEqual("Richard Randak", profile.Name);
    }

    [Ignore("Requires valid access token")]
    [TestMethod]
    public async Task Get()
    {
        var token = "placeholder";
        var auth = new StandardAuth(token);
        var fortnoxClient = new FortnoxClient(auth);

        var connector = fortnoxClient.ProfileConnector;
        var profile = await connector.GetAsync();

        Assert.AreEqual("Richard Randak", profile.Name);
    }
}
