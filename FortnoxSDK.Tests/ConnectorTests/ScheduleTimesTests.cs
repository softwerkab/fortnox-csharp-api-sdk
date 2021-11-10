using System;
using System.Threading.Tasks;
using Fortnox.SDK;
using Fortnox.SDK.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests;

[TestClass]
public class ScheduleTimesTests
{
    public FortnoxClient FortnoxClient = TestUtils.DefaultFortnoxClient;

    [TestMethod]
    public async Task Test_ScheduleTimes_CRUD()
    {
        #region Arrange
        var tmpEmployee = await FortnoxClient.EmployeeConnector.GetAsync("TEST_EMP") ?? await FortnoxClient.EmployeeConnector.CreateAsync(new Employee() { EmployeeId = "TEST_EMP" });
        #endregion Arrange

        var connector = FortnoxClient.ScheduleTimesConnector;

        #region CREATE

        //Create method is not supported
        var newScheduleTimes = new ScheduleTimes()
        {
            Hours = 6.5m,
            EmployeeId = tmpEmployee.EmployeeId,
            Date = new DateTime(2050, 10, 10)
        };

        var createdScheduleTimes = await connector.UpdateAsync(newScheduleTimes);
        Assert.AreEqual(6.5m, createdScheduleTimes.Hours);

        #endregion CREATE

        #region UPDATE

        createdScheduleTimes.Hours = 7;

        var updatedScheduleTimes = await connector.UpdateAsync(createdScheduleTimes);
        Assert.AreEqual(7, updatedScheduleTimes.Hours);

        #endregion UPDATE

        #region READ / GET

        var retrievedScheduleTimes = await connector.GetAsync(createdScheduleTimes.EmployeeId, createdScheduleTimes.Date);
        Assert.AreEqual(7, retrievedScheduleTimes.Hours);

        #endregion READ / GET

        #region DELETE
        //Not available
        #endregion DELETE

        #region Delete arranged resources
        #endregion Delete arranged resources
    }
}