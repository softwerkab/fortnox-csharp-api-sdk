using System.Threading.Tasks;
using Fortnox.SDK;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests;

[TestClass]
public class TrustedEmailDomainsTests
{
    public FortnoxClient FortnoxClient = TestUtils.DefaultFortnoxClient;

    [TestMethod]
    public async Task Test_TrustedEmailDomains_CRUD()
    {
        #region Arrange
        //Add code to create required resources
        #endregion Arrange

        var connector = FortnoxClient.TrustedEmailDomainsConnector;
        const string domainName = "newtestdomain.tst";
        
        #region CREATE
        var newTrustedEmailDomains = new TrustedEmailDomain()
        {
            Domain = domainName,
        };

        var createdTrustedEmailDomains = await connector.CreateAsync(newTrustedEmailDomains);
        Assert.AreEqual(domainName, createdTrustedEmailDomains.Domain);

        #endregion CREATE

        #region UPDATE
        //Not supported
        #endregion UPDATE

        #region READ / GET

        var retrievedTrustedEmailDomains = await connector.GetAsync(createdTrustedEmailDomains.Id);
        Assert.AreEqual(domainName, retrievedTrustedEmailDomains.Domain);

        #endregion READ / GET

        #region DELETE

        await connector.DeleteAsync(createdTrustedEmailDomains.Id);

        await Assert.ThrowsExceptionAsync<FortnoxApiException>(
            async () => await connector.GetAsync(createdTrustedEmailDomains.Id),
            "Entity still exists after Delete!");

        #endregion DELETE

        #region Delete arranged resources
        //Add code to delete temporary resources
        #endregion Delete arranged resources
    }
}