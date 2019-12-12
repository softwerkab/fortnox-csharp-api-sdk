using System;
using FortnoxAPILibrary.Connectors;
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
            Assert.IsTrue(connector.RequestUriString.Contains("lastmodified="));
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
        }
    }
}
