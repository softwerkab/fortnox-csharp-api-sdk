using System;
using Fortnox.SDK;
using Fortnox.SDK.Connectors;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests
{
    [TestClass]
    public class ScheduleTimesTests
    {
        public FortnoxClient FortnoxClient = TestUtils.DefaultFortnoxClient;

        [TestMethod]
        public void Test_ScheduleTimes_CRUD()
        {
            #region Arrange
            var tmpEmployee = FortnoxClient.EmployeeConnector.Get("TEST_EMP") ?? FortnoxClient.EmployeeConnector.Create(new Employee() { EmployeeId = "TEST_EMP" });
            #endregion Arrange

            IScheduleTimesConnector connector = FortnoxClient.ScheduleTimesConnector;

            #region CREATE

            //Create method is not supported
            var newScheduleTimes = new ScheduleTimes()
            {
                Hours = 6.5m,
                EmployeeId = tmpEmployee.EmployeeId,
                Date = new DateTime(2050,10,10)
            };

            var createdScheduleTimes = connector.Update(newScheduleTimes);
            Assert.AreEqual(6.5m, createdScheduleTimes.Hours);

            #endregion CREATE

            #region UPDATE

            createdScheduleTimes.Hours = 7;

            var updatedScheduleTimes = connector.Update(createdScheduleTimes); 
            Assert.AreEqual(7, updatedScheduleTimes.Hours);

            #endregion UPDATE

            #region READ / GET

            var retrievedScheduleTimes = connector.Get(createdScheduleTimes.EmployeeId, createdScheduleTimes.Date);
            Assert.AreEqual(7, retrievedScheduleTimes.Hours);

            #endregion READ / GET

            #region DELETE
            //Not available
            #endregion DELETE

            #region Delete arranged resources
            #endregion Delete arranged resources
        }
    }
}
