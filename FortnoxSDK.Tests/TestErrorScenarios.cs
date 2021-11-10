using System.Threading.Tasks;
using Fortnox.SDK;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests;

[TestClass]
public class TestErrorScenarios
{
    public FortnoxClient FortnoxClient = TestUtils.DefaultFortnoxClient;

    [TestMethod]
    [ExpectedException(typeof(FortnoxApiException))]
    public async Task Test_FailedCreate_NoEntity()
    {
        var connector = FortnoxClient.CustomerConnector;

        var createdCustomer = await connector.CreateAsync(new Customer() { Name = "TestCustomer", CountryCode = "InvalidCountryCode" });
        Assert.IsNull(createdCustomer);
    }

    [TestMethod]
    [ExpectedException(typeof(FortnoxApiException))]
    public async Task Test_FailedUpdate_NoEntity()
    {
        var connector = FortnoxClient.CustomerConnector;

        var createdCustomer = await connector.UpdateAsync(new Customer() { Name = "TestCustomer", CustomerNumber = "NotExistingCustomerNumber" });
        Assert.IsNull(createdCustomer);
    }
}