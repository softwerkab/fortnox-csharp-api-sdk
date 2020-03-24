using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            Assert.IsTrue(connector.RequestUriString.Contains("name=TestName"));
            Assert.IsTrue(connector.RequestUriString.Contains("city=TestCity"));
            Assert.IsTrue(connector.RequestUriString.Contains("filter=active"));
            Assert.IsTrue(connector.RequestUriString.Contains("sortby=name"));
            Assert.IsTrue(connector.RequestUriString.Contains("sortorder=ascending"));
            Assert.IsTrue(
                connector.RequestUriString.Contains(
                    "lastmodified=2000-01-01+20%3a10%3a05")); //"lastmodified=2000-01-20 20:10:05" in URL encoding
            Assert.IsTrue(connector.RequestUriString.Contains("limit=10"));
            Assert.IsTrue(connector.RequestUriString.Contains("offset=0"));
            Assert.IsTrue(connector.RequestUriString.Contains("page=1"));
        }

        [TestMethod]
        public void Test_Find_ParamsNotAdded()
        {
            var connector = new CustomerConnector();
            connector.Name = "TestName";

            connector.Find();
            MyAssert.HasNoError(connector);
            Assert.IsFalse(connector.RequestUriString.Contains("city="));
            Assert.IsFalse(connector.RequestUriString.Contains("filter="));
            Assert.IsFalse(connector.RequestUriString.Contains("sortby="));
            Assert.IsFalse(connector.RequestUriString.Contains("sortorder="));
            Assert.IsFalse(connector.RequestUriString.Contains("lastmodified="));
            Assert.IsFalse(connector.RequestUriString.Contains("limit="));
            Assert.IsFalse(connector.RequestUriString.Contains("offset="));
            Assert.IsFalse(connector.RequestUriString.Contains("page="));
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
            Assert.IsFalse(connector.RequestUriString.Contains("city="));
            Assert.IsFalse(connector.RequestUriString.Contains("filter="));
            Assert.IsFalse(connector.RequestUriString.Contains("sortby="));
            Assert.IsFalse(connector.RequestUriString.Contains("sortorder="));
            Assert.IsFalse(connector.RequestUriString.Contains("lastmodified="));
            Assert.IsFalse(connector.RequestUriString.Contains("limit="));
            Assert.IsFalse(connector.RequestUriString.Contains("offset="));
            Assert.IsFalse(connector.RequestUriString.Contains("page="));
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
            var connector = new CustomerConnector();

            var createdCustomer = connector.Create(new Customer() {Name = "TestUser", CountryCode = "SE"});
            MyAssert.HasNoError(connector);
            Assert.AreEqual("Sverige", createdCustomer.Country);

            connector.Delete(createdCustomer.CustomerNumber);
            MyAssert.HasNoError(connector);
        }

        [TestMethod]
        public void Test_EmptyNestedObject()
        {
            var connector = new CustomerConnector();

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

        [TestMethod]
        public void Check()
        {
            var tmpCustomer = new CustomerConnector().Create(new Customer()
                {Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis"});
            var tmpArticle = new ArticleConnector().Create(new Article()
                {Description = "TmpArticle", Type = ArticleType.STOCK, PurchasePrice = 100});

            var connector = new ContractConnector();
            var newContract = connector.Create(new Contract()
            {
                CustomerNumber = tmpCustomer.CustomerNumber,
                ContractDate = new DateTime(2019, 1, 20), //"2019-01-20",
                Active = true,
                Comments = "TestContract",
                ContractLength = 4,
                Continuous = true,
                Currency = "SEK",
                Language = Language.EN,
                InvoiceRows = new List<ContractInvoiceRow>()
                {
                    new ContractInvoiceRow() {ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = "10"},
                    new ContractInvoiceRow() {ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = "20"},
                    new ContractInvoiceRow() {ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = "15"}
                },
                PeriodStart = new DateTime(2020, 04, 01),
                PeriodEnd = new DateTime(2020, 10, 01),
            });

            MyAssert.HasNoError(connector);

            connector = new ContractConnector();
            var abc = connector.CreateInvoice(newContract.DocumentNumber);


            var invoiceConnector = new InvoiceConnector();
            invoiceConnector.CustomerNumber = tmpCustomer.CustomerNumber;
            var newInvoices = invoiceConnector.Find();
            var newInvoice = newInvoices.Entities.FirstOrDefault();
        }


        [TestMethod]
        public void Check2()
        {
            var connector = new InvoiceConnector();
            connector.Limit = 500;
            var all = connector.Find();
            var booked = all.Entities.Where(i => i.Booked == true).ToList();
            var unbooked = all.Entities.Where(i => i.Booked == false && i.Cancelled != false).ToList();

            connector.FilterBy = Filter.Invoice.Unbooked;
            var unbookedCollection = connector.Find();
            connector.Limit = 500;

            Assert.AreEqual(unbooked.Count, unbookedCollection.Entities.Count);


            Assert.AreEqual(all.Entities.Count, booked.Count + unbooked.Count);

        }
    }
}
