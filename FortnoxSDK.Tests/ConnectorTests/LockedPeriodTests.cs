using System.Threading.Tasks;
using Fortnox.SDK;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests;

[TestClass]
public class LockedPeriodTests
{
    private FortnoxClient FortnoxClient;

    [TestInitialize]
    public async Task TestInitialize()
    {
        FortnoxClient ??= await TestClient.GetFortnoxClient();
    }

    [TestMethod]
    public async Task Test_LockedPeriod_CRUD()
    {
        #region Arrange
        //Add code to create required resources
        #endregion Arrange

        var connector = FortnoxClient.LockedPeriodConnector;

        #region CREATE
        //Not Allowed
        #endregion CREATE

        #region UPDATE
        //Not Allowed
        #endregion UPDATE

        #region READ / GET

        var retrievedLockedPeriod = await connector.GetAsync();
        Assert.IsNotNull(retrievedLockedPeriod);

        Assert.IsNull(retrievedLockedPeriod.EndDate); //No period is locked

        #endregion READ / GET

        #region DELETE
        //Not Allowed
        #endregion DELETE

        #region Delete arranged resources
        //Add code to delete temporary resources
        #endregion Delete arranged resources
    }
}