using System;
using System.Collections.Generic;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.GeneratedTests
{
    [TestClass]
    public class EmployeeTests
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
        public void Test_Employee_CRUD()
        {
            #region Arrange
            //Add code to create required resources
            #endregion Arrange

            var connector = new EmployeeConnector();

            #region CREATE
            var newEmployee = new Employee()
            {
                FirstName = "Test",
                LastName = "Testasson",
                City = "Växjö",
                Country = "Sweden",
                ForaType = ForaType.A74,
                JobTitle = "Woodcutter",
                HourlyPay = 123.45
            };

            var createdEmployee = connector.Create(newEmployee);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("Test", createdEmployee.FirstName);

            #endregion CREATE

            #region UPDATE

            createdEmployee.FirstName = "UpdatedTest";
            
            var updatedEmployee = connector.Update(createdEmployee); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedTest", updatedEmployee.FirstName);

            #endregion UPDATE

            #region READ / GET

            var retrievedEmployee = connector.Get(createdEmployee.EmployeeId);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedTest", retrievedEmployee.FirstName);

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdEmployee.EmployeeId);
            MyAssert.HasNoError(connector);

            retrievedEmployee = connector.Get(createdEmployee.EmployeeId);
            Assert.AreEqual(null, retrievedEmployee, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }
    }
}
