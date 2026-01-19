using System;
using System.Threading.Tasks;
using Fortnox.SDK;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests;

[TestClass]
public class SalaryTransactionTests
{
    private FortnoxClient FortnoxClient;

    [TestInitialize]
    public async Task TestInitialize()
    {
        FortnoxClient ??= await TestClient.GetFortnoxClient();
    }

    [TestMethod]
    public async Task Test_SalaryTransaction_CRUD()
    {
        #region Arrange
        var tmpEmployee = await TestUtils.GetBasicTestEmployee();
        #endregion Arrange

        var connector = FortnoxClient.SalaryTransactionConnector;

        #region CREATE
        var newSalaryTransaction = new SalaryTransaction()
        {
            EmployeeId = tmpEmployee.EmployeeId,
            SalaryCode = "11", //Arbetstid
            Date = new DateTime(2020, 1, 1),
            Number = 10,
            TextRow = "TestSalaryRow"
        };

        var createdSalaryTransaction = await connector.CreateAsync(newSalaryTransaction);
        Assert.AreEqual("TestSalaryRow", createdSalaryTransaction.TextRow);

        #endregion CREATE

        #region UPDATE

        createdSalaryTransaction.TextRow = "UpdatedTestSalaryRow";

        var updatedSalaryTransaction = await connector.UpdateAsync(createdSalaryTransaction);
        Assert.AreEqual("UpdatedTestSalaryRow", updatedSalaryTransaction.TextRow);

        #endregion UPDATE

        #region READ / GET

        var retrievedSalaryTransaction = await connector.GetAsync(createdSalaryTransaction.SalaryRow);
        Assert.AreEqual("UpdatedTestSalaryRow", retrievedSalaryTransaction.TextRow);

        #endregion READ / GET

        #region DELETE

        await connector.DeleteAsync(createdSalaryTransaction.SalaryRow);

        await Assert.ThrowsExceptionAsync<FortnoxApiException>(
            async () => await connector.GetAsync(createdSalaryTransaction.SalaryRow),
            "Entity still exists after Delete!");

        #endregion DELETE

        #region Delete arranged resources
        #endregion Delete arranged resources
    }
}