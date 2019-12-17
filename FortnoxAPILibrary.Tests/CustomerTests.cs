using System;
using System.Collections.Generic;
using System.Text;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.Tests
{
    [TestClass]
    public class CustomerTests
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
        public void Test_Customer_CRUD()
        {
            var connector = new CustomerConnector();

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
                Type = CustomerType.PRIVATE
            };

            var createdCustomer = connector.Create(newCustomer);
            MyAssert.HasNoError(connector);
            Assert.AreEqual(createdCustomer.Name, "TestCustomer");

            #endregion CREATE

            #region UPDATE

            createdCustomer.Name = "UpdatedTestCustomer";

            var updatedCustomer = connector.Update(createdCustomer);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedTestCustomer", updatedCustomer.Name);

            #endregion UPDATE

            #region READ / GET

            var retrievedCustomer = connector.Get(createdCustomer.CustomerNumber);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedTestCustomer", retrievedCustomer.Name);

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdCustomer.CustomerNumber);
            MyAssert.HasNoError(connector);

            retrievedCustomer = connector.Get(createdCustomer.CustomerNumber);
            Assert.AreEqual(null, retrievedCustomer, "Entity still exists after Delete!");

            #endregion DELETE
        }

        [TestMethod]
        public void Test_Customer_Search()
        {
            var testId = Guid.NewGuid().ToString(); //serves to identify entities created in this test

            var connector = new CustomerConnector();

            var newCustomers = new List<Customer>()
            {
                new Customer()
                {
                    Name = testId,
                    Address1 = "TestStreet 1",
                    Address2 = "TestStreet 2",
                    ZipCode = "01010",
                    City = "Testopolis",
                    Email = "testCustomer@test.com",
                    Type = CustomerType.PRIVATE,
                    Active = "true"
                },
                new Customer()
                {
                    Name = testId,
                    Address1 = "TestStreet 1",
                    Address2 = "TestStreet 2",
                    ZipCode = "01010",
                    City = "TestCity",
                    Email = "testCustomer@test.com",
                    Type = CustomerType.PRIVATE,
                    Active = "true"
                },
                new Customer()
                {
                    Name = testId,
                    Address1 = "TestStreet 1",
                    Address2 = "TestStreet 2",
                    ZipCode = "01010",
                    City = "PolisTest",
                    Email = "testCustomer@test.com",
                    Type = CustomerType.PRIVATE,
                    Active = "true"
                },
                new Customer()
                {
                    Name = testId,
                    Address1 = "TestStreet 1",
                    Address2 = "TestStreet 2",
                    ZipCode = "01010",
                    City = "Testopolis",
                    Email = "testCustomer@test.com",
                    Type = CustomerType.PRIVATE,
                    Active = "false"
                }
            };

            for (int i = 0;i < newCustomers.Count;i++)
            {
                newCustomers[i] = connector.Create(newCustomers[i]);
                MyAssert.HasNoError(connector);
            }

            connector.Limit = 10;
            connector.LastModified = DateTime.Today;
            connector.SortBy = Sort.By.Customer.Name;
            connector.Offset = 0;
            connector.Page = 1;

            connector.FilterBy = Filter.Customer.Active; //Matched by customers 1,2,3
            connector.City = "polis"; //Matched by customers 1,3,4
            connector.Name = testId; //Matched by customers 1,2,3,4 (all)

            var retrievedCustomers = connector.Find();
            MyAssert.HasNoError(connector);
            Assert.AreEqual(2, retrievedCustomers.Entities.Count); //Final matched customers: 1,3

            foreach (var customer in newCustomers)
            {
                connector.Delete(customer.CustomerNumber);
                MyAssert.HasNoError(connector);
            }
        }

        [TestMethod]
        public void Test_Customer_Update_UndefinedProperties()
        {
            var connector = new CustomerConnector();

            //Arrange - Create customer
            var existingCustomer = connector.Create(new Customer()
            {
                Name = "TestCustomer",
                Address1 = "TestStreet 1",
                Type = CustomerType.PRIVATE,
                VATType = VATType.EUVAT
            });
            MyAssert.HasNoError(connector);

            //Act - Update customer
            var updatedCustomerData = new Customer()
            {
                CustomerNumber = existingCustomer.CustomerNumber,
                Address1 = "Updated Address"
            };

            var updatedCustomer = connector.Update(updatedCustomerData);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("Updated Address", updatedCustomer.Address1);
            Assert.AreEqual("TestCustomer", updatedCustomer.Name);
            Assert.AreEqual(CustomerType.PRIVATE, updatedCustomer.Type);
            Assert.AreEqual(VATType.EUVAT, updatedCustomer.VATType);

            //Clean
            connector.Delete(existingCustomer.CustomerNumber);
            MyAssert.HasNoError(connector);
        }
    }
}
