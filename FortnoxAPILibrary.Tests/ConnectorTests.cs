using System;
using System.Collections.Generic;
using System.Runtime;
using System.Runtime.InteropServices.WindowsRuntime;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.Tests
{
    [TestClass]
    public class ConnectorTests
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
            var connector = new CustomerConnector();
            connector.Name = "TestName";
            connector.City = "TestCity";
            connector.FilterBy = Filter.Customer.Active;
            connector.SortBy = Sort.By.Customer.Name;
            connector.SortOrder = Sort.Order.Ascending;
            connector.LastModified = new DateTime(2000,01,01);

            connector.Find();
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'.");
            Assert.IsTrue(connector.RequestUriString.Contains("name=TestName"));
            Assert.IsTrue(connector.RequestUriString.Contains("city=TestCity"));
            Assert.IsTrue(connector.RequestUriString.Contains("filter=active"));
            Assert.IsTrue(connector.RequestUriString.Contains("sortby=name"));
            Assert.IsTrue(connector.RequestUriString.Contains("sortorder=ascending"));
            Assert.IsTrue(connector.RequestUriString.Contains("lastmodified=2000-01-01"));
        }

        [TestMethod]
        public void Test_Find_ParamsNotAdded()
        {
            var connector = new CustomerConnector();
            connector.Name = "TestName";

            connector.Find();
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'.");
            Assert.IsFalse(connector.RequestUriString.Contains("city="));
            Assert.IsFalse(connector.RequestUriString.Contains("filter="));
            Assert.IsFalse(connector.RequestUriString.Contains("sortby="));
            Assert.IsFalse(connector.RequestUriString.Contains("sortorder="));
            Assert.IsFalse(connector.RequestUriString.Contains("lastmodified="));
        }

        [TestMethod]
        public void Test_Find_ParamsNullable()
        {
            var connector = new CustomerConnector();
            connector.Name = "TestName";
            connector.City = null;
            connector.FilterBy = null;
            connector.SortBy = null;
            connector.SortOrder = null;
            connector.LastModified = null;

            connector.Find();
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'.");
            Assert.IsFalse(connector.RequestUriString.Contains("city="));
            Assert.IsFalse(connector.RequestUriString.Contains("filter="));
            Assert.IsFalse(connector.RequestUriString.Contains("sortby="));
            Assert.IsFalse(connector.RequestUriString.Contains("sortorder="));
            Assert.IsFalse(connector.RequestUriString.Contains("lastmodified="));
        }

        [TestMethod]
        public void Test_ReadOnlyProperty_NotSerialized()
        {
            var connector = new CustomerConnector();

            var createdCustomer = connector.Create(new Customer() { Name = "TestCustomer", CountryCode = "SE" });
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'.");

            connector.Update(createdCustomer);
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'.");
            Assert.IsFalse(connector.RequestContent.Contains("\"Country\":"), "Read-only property exists in Update request!");
            //Country is read-only, should not be send in update request even if its unchanged

            connector.Delete(createdCustomer.CustomerNumber);
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'.");
        }

        [TestMethod]
        public void Test_ReadOnlyProperty_Deserialized()
        {
            var connector = new CustomerConnector();

            var createdCustomer = connector.Create(new Customer() { Name = "TestUser", CountryCode = "SE" });
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'.");
            Assert.AreEqual("Sverige", createdCustomer.Country);

            connector.Delete(createdCustomer.CustomerNumber);
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'.");
        }

        [TestMethod]
        public void Test_EmptyNestedObject()
        {
            var connector = new CustomerConnector();

            var createdCustomer = connector.Create(new Customer()
            {
                Name = "TestUser", 
                DefaultDeliveryTypes = new InvoiceDefaultDeliveryTypes() //Empty Object
            });
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'.");

            connector.Delete(createdCustomer.CustomerNumber);
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'.");
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
            var totalCustomers = int.Parse(largeCustomerCollection.TotalResources);

            var neededPages = GetNeededPages(Math.Min(totalCustomers, large), small);
            var mergedCollection = new List<CustomerSubset>();

            for (int i = 0; i < neededPages; i++)
            {
                connector.Limit = small;
                connector.Page = i + 1;
                var smallCustomerCollection = connector.Find();
                mergedCollection.AddRange(smallCustomerCollection.Entities);
            }
            
            for(int i = 0;i<largeCustomerCollection.Entities.Count;i++)
                Assert.AreEqual(largeCustomerCollection.Entities[i].CustomerNumber, mergedCollection[i].CustomerNumber);
        }

        private static int GetNeededPages(int totalSize, int pageSize)
        {
            return (int) Math.Ceiling(totalSize / (float) pageSize);

            /*var pages =  totalSize / (double) pageSize;
            if (totalSize % pageSize != 0)
                pages++;
            return pages;*/
        }
    }
}
