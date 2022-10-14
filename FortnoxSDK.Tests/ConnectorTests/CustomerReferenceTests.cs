using System.Threading.Tasks;
using Fortnox.SDK;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Exceptions;
using Fortnox.SDK.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests;

[TestClass]
public class CustomerReferenceTests
{
    public FortnoxClient FortnoxClient = TestUtils.DefaultFortnoxClient;

    [TestMethod]
    public async Task Test_CustomerReference_CRUD()
    {
        #region Arrange

        var tmpCustomer = await FortnoxClient.CustomerConnector.CreateAsync(new Customer() { Name = "TestCustomer" });

        #endregion Arrange

        var connector = FortnoxClient.CustomerReferenceConnector;

        #region CREATE
        var newCustomerReference = new CustomerReferenceRow()
        {
            Reference = "abc",
            CustomerNumber = tmpCustomer.CustomerNumber
        };

        var createdCustomerReference = await connector.CreateAsync(newCustomerReference);
        Assert.AreEqual("abc", createdCustomerReference.Reference);

        #endregion CREATE

        #region UPDATE

        createdCustomerReference.Reference = "def";
        createdCustomerReference.CustomerNumber = null;

        var updatedCustomerReference = await connector.UpdateAsync(createdCustomerReference);
        Assert.AreEqual("def", updatedCustomerReference.Reference);

        #endregion UPDATE

        #region READ / GET

        var retrievedCustomerReference = await connector.GetAsync(createdCustomerReference.Id);
        Assert.AreEqual("def", retrievedCustomerReference.Reference);

        #endregion READ / GET

        #region DELETE

        await connector.DeleteAsync(createdCustomerReference.Id);

        await Assert.ThrowsExceptionAsync<FortnoxApiException>(
            async () => await connector.GetAsync(createdCustomerReference.Id),
            "Entity still exists after Delete!");

        #endregion DELETE

        #region Delete arranged resources

        await FortnoxClient.CustomerConnector.DeleteAsync(tmpCustomer.CustomerNumber);

        #endregion Delete arranged resources
    }

    [TestMethod]
    public async Task Test_Find()
    {
        #region Arrange
        var tmpCustomer = await FortnoxClient.CustomerConnector.CreateAsync(new Customer() { Name = "TestCustomer" });
        #endregion Arrange

        var connector = FortnoxClient.CustomerReferenceConnector;
        var newCustomerReference = new CustomerReferenceRow()
        {
            CustomerNumber = tmpCustomer.CustomerNumber
        };

        //Add entries
        for (var i = 0; i < 5; i++)
        {
            newCustomerReference.Reference = TestUtils.RandomString();
            await connector.CreateAsync(newCustomerReference);
        }

        //Apply base test filter
        var searchSettings = new CustomerReferenceSearch();
        searchSettings.Customer = tmpCustomer.CustomerNumber;
        var fullCollection = await connector.FindAsync(searchSettings);

        Assert.AreEqual(5, fullCollection.Count);

        //Apply Limit
        searchSettings.Limit = 2;
        var limitedCollection = await connector.FindAsync(searchSettings);

        Assert.AreEqual(2, limitedCollection.Count);

        //Delete entries
        foreach (var entry in fullCollection)
        {
            await connector.DeleteAsync(entry.Id);
        }

        #region Delete arranged resources
        await FortnoxClient.CustomerConnector.DeleteAsync(tmpCustomer.CustomerNumber);
        #endregion Delete arranged resources
    }
}
