using System;
using System.Collections.Generic;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.Tests
{
    [TestClass]
    public class BaseConnectorTests
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
        public void Test_Find_ParamsAdded()
        {
            var connector = new CustomerConnector
            {
                Name = "TestName",
                City = "TestCity",
                FilterBy = Filter.Customer.Active,
                SortBy = Sort.By.Customer.Name,
                SortOrder = Sort.Order.Ascending,
                LastModified = new DateTime(2000, 01, 01, 20, 10, 05), //2000-01-20 20:10:05
                Limit = 10,
                Offset = 0,
                Page = 1
            };

            connector.Find();
            MyAssert.HasNoError(connector);
            Assert.IsTrue(connector.RequestInfo.AbsoluteUrl.Contains("name=TestName"));
            Assert.IsTrue(connector.RequestInfo.AbsoluteUrl.Contains("city=TestCity"));
            Assert.IsTrue(connector.RequestInfo.AbsoluteUrl.Contains("filter=active"));
            Assert.IsTrue(connector.RequestInfo.AbsoluteUrl.Contains("sortby=name"));
            Assert.IsTrue(connector.RequestInfo.AbsoluteUrl.Contains("sortorder=ascending"));
            Assert.IsTrue(
                connector.RequestInfo.AbsoluteUrl.Contains(
                    "lastmodified=2000-01-01+20%3a10%3a05")); //"lastmodified=2000-01-20 20:10:05" in URL encoding
            Assert.IsTrue(connector.RequestInfo.AbsoluteUrl.Contains("limit=10"));
            Assert.IsTrue(connector.RequestInfo.AbsoluteUrl.Contains("offset=0"));
            Assert.IsTrue(connector.RequestInfo.AbsoluteUrl.Contains("page=1"));
        }

        [TestMethod]
        public void Test_Find_ParamsNotAdded()
        {
            var connector = new CustomerConnector();
            connector.Name = "TestName";

            connector.Find();
            MyAssert.HasNoError(connector);
            Assert.IsFalse(connector.RequestInfo.AbsoluteUrl.Contains("city="));
            Assert.IsFalse(connector.RequestInfo.AbsoluteUrl.Contains("filter="));
            Assert.IsFalse(connector.RequestInfo.AbsoluteUrl.Contains("sortby="));
            Assert.IsFalse(connector.RequestInfo.AbsoluteUrl.Contains("sortorder="));
            Assert.IsFalse(connector.RequestInfo.AbsoluteUrl.Contains("lastmodified="));
            Assert.IsFalse(connector.RequestInfo.AbsoluteUrl.Contains("limit="));
            Assert.IsFalse(connector.RequestInfo.AbsoluteUrl.Contains("offset="));
            Assert.IsFalse(connector.RequestInfo.AbsoluteUrl.Contains("page="));
        }

        [TestMethod]
        public void Test_Find_ParamsNullable()
        {
            var connector = new CustomerConnector()
            {
                Name = "TestName",
                City = null,
                FilterBy = null,
                SortBy = null,
                SortOrder = null,
                LastModified = null,
                Limit = null,
                Offset = null,
                Page = null
            };

            connector.Find();
            MyAssert.HasNoError(connector);
            Assert.IsFalse(connector.RequestInfo.AbsoluteUrl.Contains("city="));
            Assert.IsFalse(connector.RequestInfo.AbsoluteUrl.Contains("filter="));
            Assert.IsFalse(connector.RequestInfo.AbsoluteUrl.Contains("sortby="));
            Assert.IsFalse(connector.RequestInfo.AbsoluteUrl.Contains("sortorder="));
            Assert.IsFalse(connector.RequestInfo.AbsoluteUrl.Contains("lastmodified="));
            Assert.IsFalse(connector.RequestInfo.AbsoluteUrl.Contains("limit="));
            Assert.IsFalse(connector.RequestInfo.AbsoluteUrl.Contains("offset="));
            Assert.IsFalse(connector.RequestInfo.AbsoluteUrl.Contains("page="));
        }

        [TestMethod]
        public void Test_ReadOnlyProperty_NotSerialized()
        {
            var connector = new CustomerConnector();

            var createdCustomer = connector.Create(new Customer() {Name = "TestCustomer", CountryCode = "SE"});
            MyAssert.HasNoError(connector);

            connector.Update(createdCustomer);
            MyAssert.HasNoError(connector);
            Assert.IsFalse(connector.RequestContent.Contains("\"Country\":"),
                "Read-only property exists in Update request!");
            //Country is read-only, should not be send in update request even if its unchanged

            connector.Delete(createdCustomer.CustomerNumber);
            MyAssert.HasNoError(connector);
        }

        [TestMethod]
        public void Test_ReadOnlyProperty_Deserialized()
        {
            ICustomerConnector connector = new CustomerConnector();

            var createdCustomer = connector.Create(new Customer() {Name = "TestUser", CountryCode = "SE"});
            MyAssert.HasNoError(connector);
            Assert.AreEqual("Sverige", createdCustomer.Country);

            connector.Delete(createdCustomer.CustomerNumber);
            MyAssert.HasNoError(connector);
        }

        [TestMethod]
        public void Test_EmptyNestedObject()
        {
            ICustomerConnector connector = new CustomerConnector();

            var createdCustomer = connector.Create(new Customer()
            {
                Name = "TestUser",
                DefaultDeliveryTypes = new DefaultDeliveryTypes() //Empty Object
            });
            MyAssert.HasNoError(connector);

            connector.Delete(createdCustomer.CustomerNumber);
            MyAssert.HasNoError(connector);
        }

        [TestMethod]
        public void Test_Paging()
        {
            const int large = 20;
            const int small = 5;

            var connector = new CustomerConnector();
            connector.Limit = large;
            connector.SortBy = Sort.By.Customer.CustomerNumber;
            connector.SortOrder = Sort.Order.Ascending;

            var largeCustomerCollection = connector.Find(); //get up to 'large' number of entities
            var totalCustomers = largeCustomerCollection.TotalResources;

            var neededPages = GetNeededPages(Math.Min(totalCustomers, large), small);
            var mergedCollection = new List<CustomerSubset>();

            for (int i = 0; i < neededPages; i++)
            {
                connector.Limit = small;
                connector.Page = i + 1;
                var smallCustomerCollection = connector.Find();
                mergedCollection.AddRange(smallCustomerCollection.Entities);
            }

            for (int i = 0; i < largeCustomerCollection.Entities.Count; i++)
                Assert.AreEqual(largeCustomerCollection.Entities[i].CustomerNumber, mergedCollection[i].CustomerNumber);
        }

        private static int GetNeededPages(int totalSize, int pageSize)
        {
            return (int) Math.Ceiling(totalSize / (float) pageSize);
        }
    }
}
