using System;
using System.Collections.Generic;
using System.Linq;
using Fortnox.SDK;
using Fortnox.SDK.Connectors;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests
{
    [TestClass]
    public class ContractTests
    {
        public FortnoxClient FortnoxClient = TestUtils.DefaultFortnoxClient;

        [TestMethod]
        public void Test_Contract_CRUD()
        {
            #region Arrange
            var tmpCustomer = new CustomerConnector().Create(new Customer() { Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis" });
            var tmpArticle = new ArticleConnector().Create(new Article() { Description = "TmpArticle", Type = ArticleType.Stock, PurchasePrice = 100 });
            #endregion Arrange

            IContractConnector connector = new ContractConnector();

            #region CREATE
            var newContract = new Contract()
            {
                CustomerNumber = tmpCustomer.CustomerNumber,
                ContractDate = new DateTime(2020, 1, 20), //"2019-01-20",
                Active = false,
                Comments = "TestContract",
                ContractLength = 4,
                Continuous = true,
                Currency = "SEK",
                Language = Language.English,
                YourReference = "SDK Test",
                InvoiceRows = new List<ContractInvoiceRow>()
                {
                    new ContractInvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = 10},
                    new ContractInvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = 20},
                    new ContractInvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = 15}
                },
                PeriodStart = new DateTime(2020, 05, 01),
                PeriodEnd = new DateTime(2020, 08, 01)
            };

            var createdContract = connector.Create(newContract);
            Assert.AreEqual("TestContract", createdContract.Comments);

            #endregion CREATE

            #region UPDATE

            createdContract.Comments = "UpdatedTestContract";

            var updatedContract = connector.Update(createdContract); 
            Assert.AreEqual("UpdatedTestContract", updatedContract.Comments);

            #endregion UPDATE

            #region READ / GET

            var retrievedContract = connector.Get(createdContract.DocumentNumber);
            Assert.AreEqual("UpdatedTestContract", retrievedContract.Comments);

            #endregion READ / GET

            #region DELETE
            // Not available
            #endregion DELETE

            #region Delete arranged resources
            //new CustomerConnector().Delete(tmpCustomer.CustomerNumber);
            //new ArticleConnector().Delete(tmpArticle.ArticleNumber);
            #endregion Delete arranged resources
        }

        [TestMethod]
        public void Test_Contract_Find()
        {
            #region Arrange
            var tmpCustomer = new CustomerConnector().Create(new Customer() { Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis" });
            var tmpArticle = new ArticleConnector().Create(new Article() { Description = "TmpArticle", Type = ArticleType.Stock, PurchasePrice = 100 });
            #endregion Arrange

            IContractConnector connector = new ContractConnector();

            var newContract = new Contract()
            {
                CustomerNumber = tmpCustomer.CustomerNumber,
                ContractDate = new DateTime(2019, 1, 20), //"2019-01-20",
                Active = false,
                Comments = "TestContract",
                ContractLength = 4,
                Continuous = true,
                Currency = "SEK",
                Language = Language.English,
                InvoiceRows = new List<ContractInvoiceRow>()
                {
                    new ContractInvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = 10},
                    new ContractInvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = 20},
                    new ContractInvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = 15}
                },
                PeriodStart = new DateTime(2020, 01, 01),
                PeriodEnd = new DateTime(2020, 03, 01)
            };

            for (var i = 0; i < 5; i++)
            {
                connector.Create(newContract);
            }

            var searchSettings = new ContractSearch();
            searchSettings.CustomerNumber = tmpCustomer.CustomerNumber;
            var contracts = connector.Find(searchSettings);
            Assert.AreEqual(5, contracts.Entities.Count);
            Assert.AreEqual("INACTIVE", contracts.Entities.First().Status);
        }
    }
}
