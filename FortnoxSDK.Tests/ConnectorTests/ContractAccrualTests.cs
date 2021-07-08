using System;
using System.Collections.Generic;
using System.Linq;
using Fortnox.SDK;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests
{
    [TestClass]
    public class ContractAccrualTests
    {
        public FortnoxClient FortnoxClient = TestUtils.DefaultFortnoxClient;

        [TestMethod]
        public void Test_ContractAccrual_CRUD()
        {
            #region Arrange

            var tmpCustomer = FortnoxClient.CustomerConnector.Create(new Customer()
                {Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis"});
            var tmpArticle = FortnoxClient.ArticleConnector.Create(new Article()
                {Description = "TmpArticle", Type = ArticleType.Stock, PurchasePrice = 100});
            var tmpContract = FortnoxClient.ContractConnector.Create(new Contract()
            {
                CustomerNumber = tmpCustomer.CustomerNumber,
                ContractDate = new DateTime(2020, 1, 1),
                ContractLength = 3,
                InvoiceInterval = 3,
                Comments = "TestContract",
                Continuous = true,
                Currency = "SEK",
                VATIncluded = false,
                Language = Language.English,
                InvoiceRows = new List<ContractInvoiceRow>()
                {
                    new ContractInvoiceRow()
                        {ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = 6, Price = 1000, VAT = 0}
                },
                PeriodStart = new DateTime(2020, 01, 1),
                PeriodEnd = new DateTime(2020, 03, 20)
            });

            #endregion Arrange

            var connector = FortnoxClient.ContractAccrualConnector;

            #region CREATE

            var newContractAccrual = new ContractAccrual()
            {
                DocumentNumber = tmpContract.DocumentNumber,
                Description = "TestContractAccrual",
                Total = 6000,
                AccrualAccount = 2990,
                CostAccount = 3990,
                VATIncluded = false,
                AccrualRows = new List<ContractAccrualRow>()
                {
                    new ContractAccrualRow() {Account = 2990, Credit = 0, Debit = 2000},
                    new ContractAccrualRow() {Account = 3990, Credit = 2000, Debit = 0},
                }
            };

            var createdContractAccrual = connector.Create(newContractAccrual);
            Assert.AreEqual("TestContractAccrual", createdContractAccrual.Description);

            #endregion CREATE

            #region UPDATE

            createdContractAccrual.Description = "UpdatedTestContractAccrual";

            var updatedContractAccrual = connector.Update(createdContractAccrual);
            Assert.AreEqual("UpdatedTestContractAccrual", updatedContractAccrual.Description);

            #endregion UPDATE

            #region READ / GET

            var retrievedContractAccrual = connector.Get(createdContractAccrual.DocumentNumber);
            Assert.AreEqual("UpdatedTestContractAccrual", retrievedContractAccrual.Description);

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdContractAccrual.DocumentNumber);

            Assert.ThrowsException<FortnoxApiException>(
                () => connector.Get(createdContractAccrual.DocumentNumber),
                "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources

            FortnoxClient.ContractConnector.Finish(tmpContract.DocumentNumber);
            //FortnoxClient.ArticleConnector.Delete(tmpArticle.ArticleNumber); //Can't delete since it is used in contract
            //FortnoxClient.CustomerConnector.Delete(tmpCustomer.CustomerNumber); //Can't delete since it is used in contract

            #endregion Delete arranged resources
        }

        [TestMethod]
        public void Test_ContractAccrual_Find()
        {
            #region Arrange

            var tmpCustomer = FortnoxClient.CustomerConnector.Create(new Customer() {Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis"});
            var tmpArticle = FortnoxClient.ArticleConnector.Create(new Article() {Description = "TmpArticle", Type = ArticleType.Stock, PurchasePrice = 100});

            #endregion Arrange

            var connector = FortnoxClient.ContractAccrualConnector;

            var contract = new Contract()
            {
                CustomerNumber = tmpCustomer.CustomerNumber,
                ContractDate = new DateTime(2020, 1, 1),
                ContractLength = 3,
                InvoiceInterval = 3,
                Comments = "TestContract",
                Continuous = true,
                Currency = "SEK",
                VATIncluded = false,
                Language = Language.English,
                InvoiceRows = new List<ContractInvoiceRow>()
                {
                    new ContractInvoiceRow()
                        {ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = 6, Price = 1000, VAT = 0}
                },
                PeriodStart = new DateTime(2020, 01, 1),
                PeriodEnd = new DateTime(2020, 03, 20)
            };

            var marks = TestUtils.RandomString();
            var newContractAccrual = new ContractAccrual()
            {
                Description = marks,
                Total = 6000,
                AccrualAccount = 2990,
                CostAccount = 3990,
                VATIncluded = false,
                AccrualRows = new List<ContractAccrualRow>()
                {
                    new ContractAccrualRow() {Account = 2990, Credit = 0, Debit = 2000},
                    new ContractAccrualRow() {Account = 3990, Credit = 2000, Debit = 0},
                }
            };

            for (var i = 0; i < 5; i++)
            {
                var createdContract = FortnoxClient.ContractConnector.Create(contract);
                newContractAccrual.DocumentNumber = createdContract.DocumentNumber;
                connector.Create(newContractAccrual);
            }

            var contractAccruals = connector.Find(null);
            Assert.AreEqual(5,contractAccruals.Entities.Count(x => x.Description.StartsWith(marks)));

            foreach (var entry in contractAccruals.Entities.Where(x => x.Description.StartsWith(marks)))
            {
                connector.Delete(entry.DocumentNumber);
                FortnoxClient.ContractConnector.Finish(entry.DocumentNumber);
            }
            #region Delete arranged resources

            //FortnoxClient.ArticleConnector.Delete(tmpArticle.ArticleNumber);
            //FortnoxClient.CustomerConnector.Delete(tmpCustomer.CustomerNumber);

            #endregion Delete arranged resources
        }
    }
}
