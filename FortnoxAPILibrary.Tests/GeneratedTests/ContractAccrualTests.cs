using System;
using System.Collections.Generic;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.GeneratedTests
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
            var tmpCustomer = new CustomerConnector().Create(new Customer() { Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis" });
            var tmpArticle = new ArticleConnector().Create(new Article() { Description = "TmpArticle", Type = ArticleType.STOCK, PurchasePrice = 100 });
            var tmpContract = new ContractConnector().Create(new Contract()
            {
                CustomerNumber = tmpCustomer.CustomerNumber,
                ContractDate = new DateTime(2020, 1, 1), 
                Active = false,
                Comments = "TestContract",
                ContractLength = 3,
                Continuous = true,
                Currency = "SEK",
                VATIncluded = false,
                Language = Language.EN,
                InvoiceRows = new List<ContractInvoiceRow>()
                {
                    new ContractInvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = "6", Price = "1000"}
                },
                PeriodStart = new DateTime(2020, 01, 20),
                PeriodEnd = new DateTime(2020, 03, 20)
            });
            #endregion Arrange

            var connector = new ContractAccrualConnector();

            #region CREATE
            var newContractAccrual = new ContractAccrual()
            {
                DocumentNumber = tmpContract.DocumentNumber,
                Description = "TestContractAccrual",
                Total = 6000,
                AccrualAccount = 2990,
                CostAccount = 3990,
                AccrualRows = new List<ContractAccrualRow>()
                {
                    new ContractAccrualRow(){ Account = 2990, Credit = 0, Debit = 2000},
                    new ContractAccrualRow(){ Account = 3990, Credit = 2000, Debit = 0},
                }
            };

            var createdContractAccrual = connector.Create(newContractAccrual);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("TestContractAccrual", createdContractAccrual.Description);

            #endregion CREATE

            #region UPDATE

            createdContractAccrual.Description = "UpdatedTestContractAccrual";

            var updatedContractAccrual = connector.Update(createdContractAccrual); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedTestContractAccrual", updatedContractAccrual.Description);

            #endregion UPDATE

            #region READ / GET

            var retrievedContractAccrual = connector.Get(createdContractAccrual.DocumentNumber);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedTestContractAccrual", retrievedContractAccrual.Description);

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdContractAccrual.DocumentNumber);
            MyAssert.HasNoError(connector);

            retrievedContractAccrual = connector.Get(createdContractAccrual.DocumentNumber);
            Assert.AreEqual(null, retrievedContractAccrual, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }
    }
}
