using System;
using System.Collections.Generic;
using System.Linq;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.Tests
{
    [TestClass]
    public class ReportedIssuesTests
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
        public void Test_Issue_44() // Origins from https://github.com/FortnoxAB/csharp-api-sdk/issues/44
        {
            //Arrange
            var customerConnector = new CustomerConnector();
            var tmpCustomer = customerConnector.Create(new Customer() { Name = "TmpTestCustomer" });

            var connector = new InvoiceConnector();

            var newInvoce = connector.Create(new Invoice()
            {
                InvoiceDate = "2019-01-20",
                DueDate = "2019-02-20",
                CustomerNumber = tmpCustomer.CustomerNumber,
                InvoiceType = InvoiceType.INVOICE,
                InvoiceRows = new List<InvoiceRow>()
                { //Add Empty rows
                    new InvoiceRow(), //Empty Row
                    new InvoiceRow(), //Empty Row
                    new InvoiceRow() { AccountNumber = "0000"},
                    new InvoiceRow(), //Empty Row
                }
            });

            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'.");
        }

        [TestMethod]
        public void Test_issue51_fixed() //Origins from https://github.com/FortnoxAB/csharp-api-sdk/issues/51
        {
            //Arrange
            /* Assuming several (at least 5) vouchers exists */

            //Act & Assert
            var connector = new VoucherConnector();

            connector.Limit = 2;
            var voucherResult = connector.Find();
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'.");

            connector.Page = 2;
            var voucherResult2 = connector.Find();
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'.");

            connector.Page = 3;
            var voucherResult3 = connector.Find();
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'.");
        }

        [TestMethod]
        public void Test_TooManyRequests_fixed()
        {
            var connector = new VoucherConnector();

            for (int i = 0; i < 40; i++)
            {
                connector.Limit = 2;
                connector.Find();
                Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'.");
            }
        }

        [Ignore] //Scenario is not yet fixed
        [TestMethod]
        public void Test_issue57_fixed() // Origins from https://github.com/FortnoxAB/csharp-api-sdk/issues/57
        {
            var connector = new CustomerConnector();
            var specificCustomer = connector.Create(new Customer() { Name = "TestCustomer", OrganisationNumber = "123456789" });
            Assert.IsFalse(connector.HasError);

            connector.OrganisationNumber = "123456789";
            var customers = connector.Find().Entities;
            var customer = customers.FirstOrDefault(c => c.CustomerNumber == specificCustomer.CustomerNumber);
            Assert.IsNotNull(customer);

            connector.Delete(specificCustomer.CustomerNumber);
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'.");
        }

        [TestMethod]
        public void Test_issue50_fixed() // Origins from https://github.com/FortnoxAB/csharp-api-sdk/issues/50
        {
            var connector = new CustomerConnector();
            var newCustomer = connector.Create(new Customer() { Name = "TestCustomer", City = "Växjö", Type = CustomerType.COMPANY });
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'.");

            var updatedCustomer = connector.Update(new Customer() { CustomerNumber = newCustomer.CustomerNumber, City = "Stockholm" });
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'.");
            Assert.AreEqual(CustomerType.COMPANY, updatedCustomer.Type);

            connector.Delete(newCustomer.CustomerNumber);
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'.");
        }

        [TestMethod]
        public void Test_issue61_fixed() // Origins from https://github.com/FortnoxAB/csharp-api-sdk/issues/61
        {
            var connector = new ArticleConnector();
            var newArticle = connector.Create(new Article() { Description = "TestArticle", FreightCost = "10", OtherCost = "10", CostCalculationMethod = "MANUAL" });
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'.");

            //NOTE: Server does not create the properties FreightCost, OtherCost and CostCalculationMethod
            //Assert.AreEqual("10", newArticle.FreightCost); //Always fails
            connector.Delete(newArticle.ArticleNumber);
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'.");
        }

    }
}
