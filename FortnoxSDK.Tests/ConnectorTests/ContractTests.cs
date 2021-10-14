using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fortnox.SDK;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests
{
    [TestClass]
    public class ContractTests
    {
        public FortnoxClient FortnoxClient = TestUtils.DefaultFortnoxClient;

        [TestMethod]
        public async Task Test_Contract_CRUD()
        {
            #region Arrange
            var tmpCustomer = await FortnoxClient.CustomerConnector.CreateAsync(new Customer() { Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis" });
            var tmpArticle = await FortnoxClient.ArticleConnector.CreateAsync(new Article() { Description = "TmpArticle", Type = ArticleType.Stock, PurchasePrice = 100 });
            #endregion Arrange

            var connector = FortnoxClient.ContractConnector;

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

            var createdContract = await connector.CreateAsync(newContract);
            Assert.AreEqual("TestContract", createdContract.Comments);

            #endregion CREATE

            #region UPDATE

            createdContract.Comments = "UpdatedTestContract";

            var updatedContract = await connector.UpdateAsync(createdContract);
            Assert.AreEqual("UpdatedTestContract", updatedContract.Comments);

            #endregion UPDATE

            #region READ / GET

            var retrievedContract = await connector.GetAsync(createdContract.DocumentNumber);
            Assert.AreEqual("UpdatedTestContract", retrievedContract.Comments);

            #endregion READ / GET

            #region DELETE
            // Not available
            #endregion DELETE

            #region Delete arranged resources
            //FortnoxClient.CustomerConnector.Delete(tmpCustomer.CustomerNumber);
            //FortnoxClient.ArticleConnector.Delete(tmpArticle.ArticleNumber);
            #endregion Delete arranged resources
        }

        [TestMethod]
        public async Task Test_Contract_Find()
        {
            #region Arrange
            var tmpCustomer = await FortnoxClient.CustomerConnector.CreateAsync(new Customer() { Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis" });
            var tmpArticle = await FortnoxClient.ArticleConnector.CreateAsync(new Article() { Description = "TmpArticle", Type = ArticleType.Stock, PurchasePrice = 100 });
            #endregion Arrange

            var connector = FortnoxClient.ContractConnector;

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
                await connector.CreateAsync(newContract);
            }

            var searchSettings = new ContractSearch();
            searchSettings.CustomerNumber = tmpCustomer.CustomerNumber;
            var contracts = await connector.FindAsync(searchSettings);
            Assert.AreEqual(5, contracts.Entities.Count);
            Assert.AreEqual("INACTIVE", contracts.Entities.First().Status);
        }
    }
}
