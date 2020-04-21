using System;
using System.Collections.Generic;
using System.Linq;
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

            var alreadyExists = new EmployeeConnector().Get("TEST_EMP") != null;

            #endregion Arrange

            IEmployeeConnector connector = new EmployeeConnector();

            #region CREATE

            var newEmployee = new Employee()
            {
                EmployeeId = "TEST_EMP",
                FirstName = "Test",
                LastName = "Testasson",
                City = "V�xj�",
                Country = "Sweden",
                ForaType = ForaType.A74,
                JobTitle = "Woodcutter",
                MonthlySalary = 20000
            };

            var createdEmployee = alreadyExists ? connector.Update(newEmployee) : connector.Create(newEmployee);
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

            //Not supported

            #endregion DELETE

            #region Delete arranged resources

            //Add code to delete temporary resources

            #endregion Delete arranged resources
        }

        [TestMethod]
        public void Test_Employee_Find()
        {
            IEmployeeConnector connector = new EmployeeConnector();

            var employees = connector.Find();
            
            Assert.AreEqual(1, employees.Entities.Count);
            Assert.IsNotNull(employees.Entities.First().Url);
        }
    }
}
