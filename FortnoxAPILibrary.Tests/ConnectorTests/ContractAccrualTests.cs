using System;
using System.Collections.Generic;
using System.Linq;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.Tests.ConnectorTests
{
    [TestClass]
    public class ContractAccrualTests
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
        public void Test_ContractAccrual_CRUD()
        {
            #region Arrange

            var tmpCustomer = new CustomerConnector().Create(new Customer()
                {Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis"});
            var tmpArticle = new ArticleConnector().Create(new Article()
                {Description = "TmpArticle", Type = ArticleType.Stock, PurchasePrice = 100});
            var tmpContract = new ContractConnector().Create(new Contract()
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

            IContractAccrualConnector connector = new ContractAccrualConnector();

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

            new ContractConnector().Finish(tmpContract.DocumentNumber);
            //new ArticleConnector().Delete(tmpArticle.ArticleNumber); //Can't delete since it is used in contract
            //new CustomerConnector().Delete(tmpCustomer.CustomerNumber); //Can't delete since it is used in contract

            #endregion Delete arranged resources
        }

        [TestMethod]
        public void Test_ContractAccrual_Find()
        {
            #region Arrange

            var tmpCustomer = new CustomerConnector().Create(new Customer() {Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis"});
            var tmpArticle = new ArticleConnector().Create(new Article() {Description = "TmpArticle", Type = ArticleType.Stock, PurchasePrice = 100});

            #endregion Arrange

            IContractAccrualConnector connector = new ContractAccrualConnector();

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
                var createdContract = new ContractConnector().Create(contract);
                newContractAccrual.DocumentNumber = createdContract.DocumentNumber;
                connector.Create(newContractAccrual);
            }

            var contractAccruals = connector.Find(null);
            Assert.AreEqual(5,contractAccruals.Entities.Count(x => x.Description.StartsWith(marks)));

            foreach (var entry in contractAccruals.Entities.Where(x => x.Description.StartsWith(marks)))
            {
                connector.Delete(entry.DocumentNumber);
                new ContractConnector().Finish(entry.DocumentNumber);
            }
            #region Delete arranged resources

            //new ArticleConnector().Delete(tmpArticle.ArticleNumber);
            //new CustomerConnector().Delete(tmpCustomer.CustomerNumber);

            #endregion Delete arranged resources
        }
    }
}
