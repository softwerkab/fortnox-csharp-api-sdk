using System;
using System.Linq;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.Tests.Connectors
{
    [TestClass]
    public class EmployeeConnectorTests : ConnectorTestsBase
    {
        readonly IEmployeeConnector _connector;

        static string NewEmployeeId => Guid.NewGuid().ToString().Replace("-", "").Substring(0, 6);

        public EmployeeConnectorTests()
        {
            _connector = new EmployeeConnector
            {
                AccessToken = AccessToken,
                ClientSecret = ClientSecret
            };
        }

        [TestMethod]
        public void TestConnection()
        {
            _connector.Find();

            CheckForError(_connector);
        }

        [TestMethod]
        public void CreateShouldCreateAnEmployee()
        {
            var employedTo = DateTime.UtcNow.AddYears(1).ToString("yyyy-MM-dd");
            var employee = new Employee
            {
                EmployeeId = NewEmployeeId,
                EmployedTo = employedTo,
            };

            var result = _connector.Create(employee);

            CheckForError(_connector);

            Assert.IsNotNull(result.EmployeeId);
            Assert.IsNotNull(result.EmployedTo);
            Assert.AreEqual(employedTo, result.EmployedTo);

            //Cleanup
            _connector.Update(new Employee { EmployeeId = result.EmployeeId, Inactive = true });
        }

        [TestMethod]
        public void UpdateShouldUpdateAnEmployee()
        {
            //Arrange
            var create = new Employee
            {
                EmployeeId = NewEmployeeId
            };

            var createResult = _connector.Create(create);
            CheckForError(_connector);

            //Act
            var update = new Employee
            {
                EmployeeId = createResult.EmployeeId,
                FirstName = "Test",
                LastName = "Case"
            };

            var updateResult = _connector.Update(update);
            CheckForError(_connector);

            //Assert
            Assert.AreEqual(update.FirstName, updateResult.FirstName);
            Assert.AreEqual(update.LastName, updateResult.LastName);
            Assert.AreEqual("Test Case", updateResult.FullName);

            //Cleanup
            _connector.Update(new Employee {EmployeeId = createResult.EmployeeId, Inactive = true});
        }

        [TestMethod]
        public void GetShouldReturnResult()
        {
            var employeeId = GetNewOrExistingEmployeeId();

            var result = _connector.Get(employeeId);

            CheckForError(_connector);

            Assert.AreEqual(employeeId, result.EmployeeId);
        }

        [TestMethod]
        public void FindShouldReturnResults()
        {
            EnsureSomeEmployeeExists();

            var result = _connector.Find();

            CheckForError(_connector);

            Assert.IsTrue(result.EmployeeSubset.Any());
        }

        void EnsureSomeEmployeeExists()
        {
            GetNewOrExistingEmployeeId();
        }

        string GetNewOrExistingEmployeeId()
        {
            var result = _connector.Find();

            CheckForError(_connector);

            if (result.EmployeeSubset.Any())
                return result.EmployeeSubset.First().EmployeeId;

            var employee = _connector.Create(new Employee());

            CheckForError(_connector);

            return employee.EmployeeId;
        }
    }
}