using System;
using System.Linq;
using System.Threading.Tasks;
using Fortnox.SDK;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Exceptions;
using Fortnox.SDK.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests;

[TestClass]
public class AbsenceTransactionTests
{
    public FortnoxClient FortnoxClient = TestUtils.DefaultFortnoxClient;

    [TestMethod]
    public async Task Test_AbsenceTransaction_CRUD()
    {
        #region Arrange
        var tmpEmployee = await FortnoxClient.EmployeeConnector.CreateAsync(new Employee() { EmployeeId = TestUtils.RandomString() });
        var tmpProject = await FortnoxClient.ProjectConnector.CreateAsync(new Project() { Description = "TmpProject" });
        var tmpCostCenter = await FortnoxClient.CostCenterConnector.CreateAsync(new CostCenter() { Code = "TMP", Description = "TmpCostCenter" });
        #endregion Arrange

        var connector = FortnoxClient.AbsenceTransactionConnector;

        #region CREATE
        var newAbsenceTransaction = new AbsenceTransaction()
        {
            EmployeeId = tmpEmployee.EmployeeId,
            CauseCode = AbsenceCauseCode.MIL,
            Date = new DateTime(2018, 01, 01),
            Hours = 5.5m,
            CostCenter = tmpCostCenter.Code,
            Project = tmpProject.ProjectNumber
        };

        var createdAbsenceTransaction = await connector.CreateAsync(newAbsenceTransaction);
        Assert.AreEqual(5.5m, createdAbsenceTransaction.Hours);

        #endregion CREATE

        #region UPDATE

        createdAbsenceTransaction.Hours = 8;

        var updatedAbsenceTransaction = await connector.UpdateAsync(createdAbsenceTransaction);
        Assert.AreEqual(8, updatedAbsenceTransaction.Hours);

        #endregion UPDATE

        #region READ / GET

        var retrievedAbsenceTransaction = await connector.GetAsync(createdAbsenceTransaction.EmployeeId, createdAbsenceTransaction.Date, createdAbsenceTransaction.CauseCode);
        Assert.AreEqual(8, retrievedAbsenceTransaction.Hours);

        #endregion READ / GET

        #region DELETE

        await connector.DeleteAsync(createdAbsenceTransaction.EmployeeId, createdAbsenceTransaction.Date, createdAbsenceTransaction.CauseCode);

        await Assert.ThrowsExceptionAsync<FortnoxApiException>(
            async () => await connector.GetAsync(createdAbsenceTransaction.EmployeeId, createdAbsenceTransaction.Date, createdAbsenceTransaction.CauseCode),
            "Entity still exists after Delete!");

        #endregion DELETE

        #region Delete arranged resources
        await FortnoxClient.CostCenterConnector.DeleteAsync(tmpCostCenter.Code);
        await FortnoxClient.ProjectConnector.DeleteAsync(tmpProject.ProjectNumber);
        #endregion Delete arranged resources
    }

    [TestMethod]
    public async Task Test_Find()
    {
        #region Arrange

        var tmpEmployee = await FortnoxClient.EmployeeConnector.CreateAsync(new Employee() { EmployeeId = TestUtils.RandomString() });
        var tmpProject = await FortnoxClient.ProjectConnector.CreateAsync(new Project() { Description = "TmpProject" });
        var tmpCostCenter = await FortnoxClient.CostCenterConnector.CreateAsync(new CostCenter() { Code = "TMP", Description = "TmpCostCenter" });
        #endregion Arrange

        var connector = FortnoxClient.AbsenceTransactionConnector;

        var newAbsenceTransaction = new AbsenceTransaction()
        {
            EmployeeId = tmpEmployee.EmployeeId,
            CauseCode = AbsenceCauseCode.MIL,
            Date = new DateTime(2018, 01, 01),
            Hours = 1,
            CostCenter = tmpCostCenter.Code,
            Project = tmpProject.ProjectNumber
        };

        //Add entries
        for (var i = 0; i < 5; i++)
        {
            newAbsenceTransaction.Date = new DateTime(2018, 01, 01).AddDays(i);
            await connector.CreateAsync(newAbsenceTransaction);
        }

        var searchSettings = new AbsenceTransactionSearch();
        searchSettings.EmployeeId = tmpEmployee.EmployeeId;
        var fullCollection = await connector.FindAsync(searchSettings);

        Assert.AreEqual(5, fullCollection.TotalResources);
        Assert.AreEqual(5, fullCollection.Entities.Count);
        Assert.AreEqual(1, fullCollection.TotalPages);

        Assert.AreEqual(tmpEmployee.EmployeeId, fullCollection.Entities.First().EmployeeId);

        //Apply Limit
        searchSettings.Limit = 2;
        var limitedCollection = await connector.FindAsync(searchSettings);

        Assert.AreEqual(5, limitedCollection.TotalResources);
        Assert.AreEqual(2, limitedCollection.Entities.Count);
        Assert.AreEqual(3, limitedCollection.TotalPages);

        //Delete entries
        foreach (var entry in fullCollection.Entities)
            await connector.DeleteAsync(entry.EmployeeId, entry.Date, entry.CauseCode);

        #region Delete arranged resources
        await FortnoxClient.CostCenterConnector.DeleteAsync(tmpCostCenter.Code);
        await FortnoxClient.ProjectConnector.DeleteAsync(tmpProject.ProjectNumber);
        #endregion Delete arranged resources
    }
}