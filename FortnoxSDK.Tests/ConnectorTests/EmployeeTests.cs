using System.Linq;
using System.Threading.Tasks;
using Fortnox.SDK;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests
{
    [TestClass]
    public class EmployeeTests
    {
        public FortnoxClient FortnoxClient = TestUtils.DefaultFortnoxClient;

        [TestMethod]
        public async Task Test_Employee_CRUD()
        {
            #region Arrange
            var c = FortnoxClient.EmployeeConnector;
            var alreadyExists = await c.GetAsync("TEST_EMP") != null;

            #endregion Arrange

            var connector = FortnoxClient.EmployeeConnector;

            #region CREATE

            var newEmployee = new Employee()
            {
                EmployeeId = "TEST_EMP",
                FirstName = "Test",
                LastName = "Testasson",
                City = "Växjö",
                Country = "Sweden",
                ForaType = ForaType.A74,
                JobTitle = "Woodcutter",
                MonthlySalary = 20000
            };

            var createdEmployee = alreadyExists ? await connector.UpdateAsync(newEmployee) : await connector.CreateAsync(newEmployee);
            Assert.AreEqual("Test", createdEmployee.FirstName);

            #endregion CREATE

            #region UPDATE

            createdEmployee.FirstName = "UpdatedTest";

            var updatedEmployee = await connector.UpdateAsync(createdEmployee);
            Assert.AreEqual("UpdatedTest", updatedEmployee.FirstName);

            #endregion UPDATE

            #region READ / GET

            var retrievedEmployee = await connector.GetAsync(createdEmployee.EmployeeId);
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
        public async Task Test_Employee_Find()
        {
            var marks = TestUtils.RandomString();

            var connector = FortnoxClient.EmployeeConnector;

            for (var i = 0; i < 5; i++)
                await connector.CreateAsync(new Employee() { EmployeeId = TestUtils.RandomString(), City = marks });

            var searchSettings = new EmployeeSearch();
            //searchSettings.LastModified = TestUtils.Recently; //parameter is not accepted by server
            searchSettings.Limit = ApiConstants.Unlimited;
            var employees = await connector.FindAsync(searchSettings);

            var newEmployees = employees.Entities.Where(e => e.City == marks).ToList();
            Assert.AreEqual(5, newEmployees.Count);
        }
    }
}
