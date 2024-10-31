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
public class AttendanceTransactionsTests
{
    public FortnoxClient FortnoxClient = TestUtils.DefaultFortnoxClient;

    [TestMethod]
    public async Task Test_AttendanceTransactions_CRUD()
    {
        #region Arrange
        var tmpEmployee = await TestUtils.GetBasicTestEmployee();
        var tmpProject = await FortnoxClient.ProjectConnector.CreateAsync(new Project() { Description = "TmpProject" });
        var tmpCostCenter = await FortnoxClient.CostCenterConnector.CreateAsync(new CostCenter() { Code = "TMPCC", Description = "TempCostCenter" });
        #endregion Arrange

        var connector = FortnoxClient.AttendanceTransactionsConnector;

        #region CREATE
        var newAttendanceTransaction = new AttendanceTransaction()
        {
            EmployeeId = tmpEmployee.EmployeeId,
            CauseCode = AttendanceCauseCode.TID,
            Date = new DateTime(2018, 01, 01),
            Hours = 5.5m,
            CostCenter = tmpCostCenter.Code,
            Project = tmpProject.ProjectNumber
        };

        var createdAttendanceTransaction = await connector.CreateAsync(newAttendanceTransaction);
        Assert.AreEqual(5.5m, createdAttendanceTransaction.Hours);

        #endregion CREATE

        #region UPDATE

        createdAttendanceTransaction.Hours = 8;

        var updatedAttendanceTransaction = await connector.UpdateAsync(createdAttendanceTransaction);
        Assert.AreEqual(8, updatedAttendanceTransaction.Hours);

        #endregion UPDATE

        #region READ / GET

        var retrievedAttendanceTransaction = await connector.GetAsync(createdAttendanceTransaction.Id);
        Assert.AreEqual(8, retrievedAttendanceTransaction.Hours);
        Assert.IsNotNull(retrievedAttendanceTransaction.Url);

        #endregion READ / GET

        #region DELETE

        await connector.DeleteAsync(createdAttendanceTransaction.Id);

        await Assert.ThrowsExceptionAsync<FortnoxApiException>(
            async () => await connector.GetAsync(createdAttendanceTransaction.Id),
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
        var tmpEmployee = await TestUtils.GetBasicTestEmployee();
        var tmpProject = await FortnoxClient.ProjectConnector.CreateAsync(new Project() { Description = "TmpProject" });
        var tmpCostCenter = await FortnoxClient.CostCenterConnector.CreateAsync(new CostCenter() { Code = "TMPCC", Description = "TempCostCenter" });
        #endregion Arrange

        var connector = FortnoxClient.AttendanceTransactionsConnector;

        var newAttendenceTransaction = new AttendanceTransaction()
        {
            EmployeeId = tmpEmployee.EmployeeId,
            CauseCode = AttendanceCauseCode.TID,
            Date = new DateTime(2018, 01, 01),
            Hours = 1,
            CostCenter = tmpCostCenter.Code,
            Project = tmpProject.ProjectNumber
        };

        //Add entries
        for (var i = 0; i < 5; i++)
        {
            newAttendenceTransaction.Date = new DateTime(2018, 01, 01).AddDays(i);
            await connector.CreateAsync(newAttendenceTransaction);
        }

        var searchSettings = new AttendanceTransactionsSearch();
        searchSettings.EmployeeId = tmpEmployee.EmployeeId;
        var fullCollection = await connector.FindAsync(searchSettings);

        Assert.AreEqual(5, fullCollection.TotalResources);
        Assert.AreEqual(5, fullCollection.Entities.Count);
        Assert.AreEqual(1, fullCollection.TotalPages);

        Assert.AreEqual(tmpEmployee.EmployeeId, fullCollection.Entities.First().EmployeeId);
        Assert.IsNotNull(fullCollection.Entities.First().Url);

        //Apply Limit
        searchSettings.Limit = 2;
        var limitedCollection = await connector.FindAsync(searchSettings);

        Assert.AreEqual(5, limitedCollection.TotalResources);
        Assert.AreEqual(2, limitedCollection.Entities.Count);
        Assert.AreEqual(3, limitedCollection.TotalPages);

        //Delete entries
        foreach (var entry in fullCollection.Entities)
            await connector.DeleteAsync(entry.Id);

        #region Delete arranged resources
        await FortnoxClient.CostCenterConnector.DeleteAsync(tmpCostCenter.Code);
        await FortnoxClient.ProjectConnector.DeleteAsync(tmpProject.ProjectNumber);
        #endregion Delete arranged resources
    }
}