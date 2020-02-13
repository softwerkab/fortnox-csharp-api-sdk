using System;
using System.Collections.Generic;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.GeneratedTests
{
    [TestClass]
    public class ScheduleTimesTests
    {
        [TestInitialize]
        public void Init()
        {
            //Set global credentials for SDK
            //--- Open 'TestCredentials.resx' to edit the values ---\\
            ConnectionCredentials.AccessToken = TestCredentials.Access_Token;
            ConnectionCredentials.ClientSecret = TestCredentials.Client_Secret;
        }

        [TestMethod]
        public void Test_ScheduleTimes_CRUD()
        {
            #region Arrange
            var tmpEmployee = new EmployeeConnector().Create(new Employee() {FirstName = "Test", LastName = "Testasson"});
            #endregion Arrange

            var connector = new ScheduleTimesConnector();

            #region CREATE
            //Not available

            var newScheduleTimes = new ScheduleTimes()
            {
                Hours = 6.5,
                EmployeeId = tmpEmployee.EmployeeId,
                Date = new DateTime(2020,10,10)
            };

            var createdScheduleTimes = connector.Update(newScheduleTimes);
            MyAssert.HasNoError(connector);
            Assert.AreEqual(6.5, createdScheduleTimes.Hours);

            #endregion CREATE

            #region UPDATE

            createdScheduleTimes.Hours = 7;

            var updatedScheduleTimes = connector.Update(createdScheduleTimes); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual(7, updatedScheduleTimes.Hours);

            #endregion UPDATE

            #region READ / GET

            var retrievedScheduleTimes = connector.Get(createdScheduleTimes.EmployeeId, createdScheduleTimes.Date);
            MyAssert.HasNoError(connector);
            Assert.AreEqual(7, retrievedScheduleTimes.Hours);

            #endregion READ / GET

            #region DELETE
            //Not available
            #endregion DELETE

            #region Delete arranged resources
            new EmployeeConnector().Delete(tmpEmployee.EmployeeId);
            #endregion Delete arranged resources
        }
    }
}
