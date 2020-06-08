using System;
using System.Collections.Generic;
using System.Linq;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.Tests.ConnectorTests
{
    [TestClass]
    public class ContractTests
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
                ContractDate = new DateTime(2019, 1, 20), //"2019-01-20",
                Active = false,
                Comments = "TestContract",
                ContractLength = 4,
                Continuous = true,
                Currency = "SEK",
                Language = Language.English,
                InvoiceRows = new List<ContractInvoiceRow>()
                {
                    new ContractInvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = "10"},
                    new ContractInvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = "20"},
                    new ContractInvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = "15"}
                },
                PeriodStart = new DateTime(2020, 01, 01),
                PeriodEnd = new DateTime(2020, 03, 01)
            };

            var createdContract = connector.Create(newContract);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("TestContract", createdContract.Comments);

            #endregion CREATE

            #region UPDATE

            createdContract.Comments = "UpdatedTestContract";

            var updatedContract = connector.Update(createdContract); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedTestContract", updatedContract.Comments);

            #endregion UPDATE

            #region READ / GET

            var retrievedContract = connector.Get(createdContract.DocumentNumber);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedTestContract", retrievedContract.Comments);

            #endregion READ / GET

            #region DELETE
            // Not available
            #endregion DELETE

            #region Delete arranged resources
            new CustomerConnector().Delete(tmpCustomer.CustomerNumber);
            new ArticleConnector().Delete(tmpArticle.ArticleNumber);
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
                    new ContractInvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = "10"},
                    new ContractInvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = "20"},
                    new ContractInvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = "15"}
                },
                PeriodStart = new DateTime(2020, 01, 01),
                PeriodEnd = new DateTime(2020, 03, 01)
            };

            for (var i = 0; i < 5; i++)
            {
                connector.Create(newContract);
                MyAssert.HasNoError(connector);
            }

            connector.CustomerNumber = tmpCustomer.CustomerNumber;
            var contracts = connector.Find();
            Assert.AreEqual(5, contracts.Entities.Count);
            Assert.AreEqual("INACTIVE", contracts.Entities.First().Status);
        }
    }
}
