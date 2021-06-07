using Fortnox.SDK;
using Fortnox.SDK.Connectors;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Exceptions;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests
{
    [TestClass]
    public class CustomerTests
    {
        public FortnoxClient FortnoxClient = TestUtils.DefaultFortnoxClient;

        [TestMethod]
        public void Test_Customer_CRUD()
        {
            #region Arrange
            //Add code to create required resources
            #endregion Arrange

            ICustomerConnector connector = FortnoxClient.CustomerConnector;

            #region CREATE
            var newCustomer = new Customer()
            {
                Name = "TestCustomer",
                Address1 = "TestStreet 1",
                Address2 = "TestStreet 2",
                ZipCode = "01010",
                City = "Testopolis",
                CountryCode = "SE", //CountryCode needs to be valid
                Email = "testCustomer@test.com",
                Type = CustomerType.Private,
                Active = false
            };

            var createdCustomer = connector.Create(newCustomer);
            Assert.AreEqual("TestCustomer", createdCustomer.Name);

            #endregion CREATE

            #region UPDATE

            createdCustomer.Name = "UpdatedTestCustomer";

            var updatedCustomer = connector.Update(createdCustomer); 
            Assert.AreEqual("UpdatedTestCustomer", updatedCustomer.Name);

            #endregion UPDATE

            #region READ / GET

            var retrievedCustomer = connector.Get(createdCustomer.CustomerNumber);
            Assert.AreEqual("UpdatedTestCustomer", retrievedCustomer.Name);

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdCustomer.CustomerNumber);

            Assert.ThrowsException<FortnoxApiException>(
                () => connector.Get(createdCustomer.CustomerNumber),
                "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }

        [TestMethod]
        public void Test_Find()
        {
            #region Arrange
            //Add code to create required resources
            #endregion Arrange

            var testKeyMark = TestUtils.RandomString();

            ICustomerConnector connector = FortnoxClient.CustomerConnector;
            var newCustomer = new Customer()
            {
                Name = "TestCustomer",
                Address1 = "TestStreet 1",
                Address2 = "TestStreet 2",
                ZipCode = "01010",
                City = testKeyMark,
                CountryCode = "SE", //CountryCode needs to be valid
                Email = "testCustomer@test.com",
                Type = CustomerType.Private,
                Active = false,
                Comments = testKeyMark
            };

            //Add entries
            for (var i = 0; i < 5; i++)
            {
                connector.Create(newCustomer);
            }

            //Apply base test filter
            var searchSettings = new CustomerSearch();
            searchSettings.City = testKeyMark;
            var fullCollection = connector.Find(searchSettings);

            Assert.AreEqual(5, fullCollection.TotalResources);
            Assert.AreEqual(5, fullCollection.Entities.Count);
            Assert.AreEqual(1, fullCollection.TotalPages);

            //Apply Limit
            searchSettings.Limit = 2;
            var limitedCollection = connector.Find(searchSettings);

            Assert.AreEqual(5, limitedCollection.TotalResources);
            Assert.AreEqual(2, limitedCollection.Entities.Count);
            Assert.AreEqual(3, limitedCollection.TotalPages);

            //Delete entries
            foreach (var entry in fullCollection.Entities)
            {
                connector.Delete(entry.CustomerNumber);
            }

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }
    }
}
