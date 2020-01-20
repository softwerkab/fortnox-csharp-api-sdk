using System;
using System.Collections.Generic;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.Tests
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
            //Arrange
            var tmpCustomer = new CustomerConnector().Create(new Customer() { Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis" });
            var tmpArticle = new ArticleConnector().Create(new Article() { Description = "TmpArticle", Type = ArticleType.STOCK, PurchasePrice = 100 });

            //Act
            var connector = new ContractConnector();

            #region CREATE
            var newContract = new Contract()
            {
                CustomerNumber = tmpCustomer.CustomerNumber,
                ContractDate = new DateTime(2019, 1, 20).ToString(APIConstants.DateFormat), //"2019-01-20",
                Active = false,
                Comments = "Contract used in tests",
                ContractLength = 4,
                Continuous = true,
                Currency = "SEK",
                Language = "EN",
                InvoiceRows = new List<InvoiceRow>()
                {
                    new InvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = 10},
                    new InvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = 20},
                    new InvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = 15}
                },
                PeriodStart = "2020-01-01",
                PeriodEnd = "2020-03-01"
            };

            var createdContract = connector.Create(newContract);
            MyAssert.HasNoError(connector);
            Assert.AreEqual(createdContract.CustomerName, "TmpCustomer");
            Assert.AreEqual(3, createdContract.InvoiceRows.Count);

            #endregion CREATE

            #region UPDATE

            createdContract.Comments = "Updated Comments";

            var updatedContract = connector.Update(createdContract);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("Updated Comments", updatedContract.Comments);

            #endregion UPDATE

            #region READ / GET

            var retrievedContract = connector.Get(createdContract.DocumentNumber);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("Updated Comments", retrievedContract.Comments);

            #endregion READ / GET

            #region DELETE
            //Contract does not provide DELETE method, but can be canceled
            connector.Finish(createdContract.DocumentNumber);
            MyAssert.HasNoError(connector);

            retrievedContract = connector.Get(createdContract.DocumentNumber);
            //Assert.AreEqual(true, retrievedContract.Finished);

            #endregion DELETE

            //Clean
            new CustomerConnector().Delete(tmpCustomer.CustomerNumber);
            new ArticleConnector().Delete(tmpArticle.ArticleNumber);
        }
    }
}
