using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fortnox.SDK;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests;

[TestClass]
public class EmployeeTests
{
    public FortnoxClient FortnoxClient = TestUtils.DefaultFortnoxClient;

    [TestMethod]
    public async Task Test_Employee_CRUD()
    {
        #region Arrange

        var c = FortnoxClient.EmployeeConnector;

        bool alreadyExists;
        try
        {
            alreadyExists = await c.GetAsync("TEST_EMP") != null;
        }
        catch (Exception e)
        {
            alreadyExists = false;
        }

        #endregion Arrange

        var connector = FortnoxClient.EmployeeConnector;

        #region CREATE

        var newEmployee = new Employee
        {
            EmployeeId = "TEST_EMP",
            FirstName = "Test",
            LastName = "Testasson",
            City = "Växjö",
            Country = "Sweden",
            PersonalIdentityNumber = "4504032972",
            Email = "test.testasson@test.test",
            ForaType = ForaType.A74,
            JobTitle = "Woodcutter",
            EmployedTo = new DateTime(2030, 3, 12),
            EmploymentDate = new DateTime(2010, 6, 22),
            DatedWages = new List<DatedWage>
            {
                new()
                {
                    EmployeeId = "TEST_EMP",
                    FirstDay = new DateTime(1970, 1, 1),
                    MonthlySalary = 20000
                }
            }
        };

        var createdEmployee = alreadyExists
            ? await connector.UpdateAsync(newEmployee)
            : await connector.CreateAsync(newEmployee);
        Assert.AreEqual("Test", createdEmployee.FirstName);

        #endregion CREATE

        #region UPDATE

        newEmployee.FirstName = "UpdatedTest";
        var updatedEmployee = await connector.UpdateAsync(newEmployee);
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

    [Ignore("Failing on 'Det finns ingen användare kopplad till den här anställda'. Investigation needed")]
    [TestMethod]
    public async Task Test_Employee_Find()
    {
        var marks = TestUtils.RandomString();

        var connector = FortnoxClient.EmployeeConnector;

        for (var i = 0; i < 5; i++)
            await connector.CreateAsync(new Employee() { City = marks, FirstName = "Test", LastName = "Testsson", Email = "test.testsson@test.com" });

        var searchSettings = new EmployeeSearch
        {
            // LastModified = TestUtils.Recently; //parameter is not accepted by server
            Limit = ApiConstants.Unlimited
        };
        var employees = await connector.FindAsync(searchSettings);

        var newEmployees = employees.Entities.Where(e => e.City == marks).ToList();
        Assert.AreEqual(5, newEmployees.Count);
    }
}