using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fortnox.SDK;
using Fortnox.SDK.Authorization;
using Fortnox.SDK.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests;

[TestClass]
public class ConnectionTests
{
    [TestMethod]
    [ExpectedException(typeof(FortnoxApiException))]
    public async Task TestConnection_NoCredenials_Error()
    {
        //Arrange
        var auth = new StaticTokenAuth(null, null);
        var fortnoxClient = new FortnoxClient(auth);

        //Act
        var cc = fortnoxClient.CustomerConnector;
        await cc.FindAsync(null);
    }

    [TestMethod]
    [ExpectedException(typeof(FortnoxApiException))]
    public async Task TestConnection_EmptyCredenials_Error()
    {
        //Arrange
        var auth = new StaticTokenAuth("", "");
        var fortnoxClient = new FortnoxClient(auth);

        //Act
        var cc = fortnoxClient.CustomerConnector;
        await cc.FindAsync(null);
    }

    [TestMethod]
    [ExpectedException(typeof(FortnoxApiException))]
    public async Task TestConnection_WrongCredenials_Error()
    {
        //Arrange
        var auth = new StaticTokenAuth("ABC", "DEF");
        var fortnoxClient = new FortnoxClient(auth);

        //Act
        var cc = fortnoxClient.CustomerConnector;
        await cc.FindAsync(null);
    }

    [TestMethod]
    public async Task TestConnection_Credentials_Correct()
    {
        //Arrange
        var auth = new StaticTokenAuth(TestCredentials.Access_Token, TestCredentials.Client_Secret);
        var fortnoxClient = new FortnoxClient(auth);

        //Act
        var connector = fortnoxClient.CustomerConnector;
        var customers = await connector.FindAsync(null);

        //Assert
        Assert.IsNotNull(customers);
    }

    [TestMethod]
    public async Task TestConnection_MultipleCredentials_Set()
    {
        var auth1 = new StaticTokenAuth("AT1", "CS1");
        var fortnoxClient1 = new FortnoxClient(auth1);

        var auth2 = new StaticTokenAuth("AT2", "CS2");
        var fortnoxClient2 = new FortnoxClient(auth2);

        var connector1 = fortnoxClient1.CustomerConnector;
        var connector2 = fortnoxClient2.CustomerConnector;

        Assert.AreEqual(auth1, connector1.Authorization);
        Assert.AreEqual(auth2, connector2.Authorization);
    }

    [TestMethod]
    public async Task TestConnection_Config_Set()
    {
        var auth = new StaticTokenAuth("AccToken", "Secret");
        var httpClient = new HttpClient() { Timeout = TimeSpan.FromSeconds(10) };
        var fortnoxClient = new FortnoxClient(auth, httpClient, false);

        var connector = fortnoxClient.CustomerConnector;

        Assert.AreEqual(auth, connector.Authorization);
        Assert.AreEqual(false, connector.UseRateLimiter);
        Assert.AreEqual(10, connector.HttpClient.Timeout.Seconds);
    }
}