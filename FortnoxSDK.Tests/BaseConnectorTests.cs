using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fortnox.SDK;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests
{
    [TestClass]
    public class BaseConnectorTests
    {
        public FortnoxClient FortnoxClient => TestUtils.DefaultFortnoxClient;

        [TestInitialize]
        public void Init()
        {
        }

        /*[TestMethod]
        public async Task Test_Find_ParamsAdded()
        {
            var connector = new CustomerConnector
            {
                Search = new CustomerSearch()
                {
                    Name = "TestName",
                    City = "TestCity",
                    LastModified = new DateTime(2000, 01, 01, 20, 10, 05), //2000-01-20 20:10:05
                    FilterBy = Filter.Customer.Active,
                    SortBy = Sort.By.Customer.Name,
                    SortOrder = Sort.Order.Ascending,
                    Limit = 10,
                    Offset = 0,
                    Page = 1
                }
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
        public async Task Test_Find_ParamsNotAdded()
        {
            var connector = FortnoxClient.CustomerConnector;
            searchSettings.Name = "TestName";

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
        public async Task Test_Find_ParamsNullable()
        {
            var connector = FortnoxClient.CustomerConnector
            {
                Search = new CustomerSearch()
                {
                    Name = "TestName",
                    City = null,
                    LastModified = null,
                    FilterBy = null,
                    SortBy = null,
                    SortOrder = null,
                    Limit = null,
                    Offset = null,
                    Page = null
                },
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
        }*/

        /*[TestMethod]
        public async Task Test_ReadOnlyProperty_NotSerialized()
        {
            var connector = FortnoxClient.CustomerConnector;

            var createdCustomer = connector.Create(new Customer() {Name = "TestCustomer", CountryCode = "SE"});
            MyAssert.HasNoError(connector);

            connector.Update(createdCustomer);
            MyAssert.HasNoError(connector);
            Assert.IsFalse(connector.Request.Content.Contains("\"Country\":"),
                "Read-only property exists in Update request!");
            //Country is read-only, should not be send in update request even if its unchanged

            connector.Delete(createdCustomer.CustomerNumber);
            MyAssert.HasNoError(connector);
        }*/

        [TestMethod]
        public async Task Test_ReadOnlyProperty_Deserialized()
        {
            var connector = FortnoxClient.CustomerConnector;

            var createdCustomer = await connector.CreateAsync(new Customer() { Name = "TestUser", CountryCode = "SE" });
            Assert.AreEqual("Sverige", createdCustomer.Country);

            await connector.DeleteAsync(createdCustomer.CustomerNumber);
        }

        [TestMethod]
        public async Task Test_EmptyNestedObject()
        {
            var connector = FortnoxClient.CustomerConnector;

            var createdCustomer = await connector.CreateAsync(new Customer()
            {
                Name = "TestUser",
                DefaultDeliveryTypes = new DefaultDeliveryTypes() //Empty Object
            });

            await connector.DeleteAsync(createdCustomer.CustomerNumber);
        }

        [TestMethod]
        public async Task Test_Paging()
        {
            const int large = 20;
            const int small = 5;

            var connector = FortnoxClient.CustomerConnector;
            var searchSettings = new CustomerSearch();
            searchSettings.Limit = large;
            searchSettings.SortBy = Sort.By.Customer.CustomerNumber;
            searchSettings.SortOrder = Sort.Order.Ascending;

            var largeCustomerCollection = await connector.FindAsync(searchSettings); //get up to 'large' number of entities
            var totalCustomers = largeCustomerCollection.TotalResources;

            var neededPages = GetNeededPages(Math.Min(totalCustomers, large), small);
            var mergedCollection = new List<CustomerSubset>();

            for (var i = 0; i < neededPages; i++)
            {
                searchSettings.Limit = small;
                searchSettings.Page = i + 1;
                var smallCustomerCollection = await connector.FindAsync(searchSettings);
                mergedCollection.AddRange(smallCustomerCollection.Entities);
            }

            for (var i = 0; i < largeCustomerCollection.Entities.Count; i++)
                Assert.AreEqual(largeCustomerCollection.Entities[i].CustomerNumber, mergedCollection[i].CustomerNumber);
        }

        [TestMethod]
        public async Task Test_AllInOnePage()
        {
            //To make this test make sense, over 100 customers must exist, ideally over 500

            var connector = FortnoxClient.CustomerConnector;
            var result = await connector.FindAsync(null);
            Assert.IsTrue(result.TotalPages > 1);

            var searchSettings = new CustomerSearch();
            searchSettings.Limit = ApiConstants.Unlimited;
            var allInOneResult = await connector.FindAsync(searchSettings);

            Assert.AreEqual(1, allInOneResult.TotalPages);
            Assert.AreEqual(result.TotalResources, allInOneResult.Entities.Count);
        }

        [TestMethod]
        public async Task Test_Uri_Escaping_Special_Characters()
        {
            var article = await FortnoxClient.ArticleConnector.CreateAsync(new Article()
            {
                ArticleNumber = "TestArticle_+-",
                Description = "X + Y != Z && X - Y == Z"
            });

            var retrievedArticle = await FortnoxClient.ArticleConnector.GetAsync(article.ArticleNumber);
            Assert.AreEqual("TestArticle_+-", retrievedArticle.ArticleNumber);


            var query = new ArticleSearch()
            {
                Description = "X + Y != Z && X - Y == Z" // some characters like '<' or '>' in query are not accepted by the server even if escaped
            };
            var matches = await FortnoxClient.ArticleConnector.FindAsync(query);
            Assert.AreEqual(1, matches.Entities.Count);
            Assert.AreEqual(article.ArticleNumber, matches.Entities.First().ArticleNumber);

            await FortnoxClient.ArticleConnector.DeleteAsync(article.ArticleNumber);
        }

        private static int GetNeededPages(int totalSize, int pageSize)
        {
            return (int)Math.Ceiling(totalSize / (float)pageSize);
        }
    }
}
