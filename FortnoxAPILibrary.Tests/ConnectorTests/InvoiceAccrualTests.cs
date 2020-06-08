using System;
using System.Collections.Generic;
using System.Linq;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.Tests.ConnectorTests
{
    [TestClass]
    public class InvoiceAccrualTests
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
        public void Test_InvoiceAccrual_CRUD()
        {
            #region Arrange
            var tmpCustomer = new CustomerConnector().Create(new Customer() { Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis" });
            var tmpArticle = new ArticleConnector().Create(new Article() { Description = "TmpArticle", Type = ArticleType.Stock, PurchasePrice = 100 });

            var tmpInvoice = new InvoiceConnector().Create(new Invoice()
            {
                CustomerNumber = tmpCustomer.CustomerNumber,
                InvoiceDate = new DateTime(2019, 1, 20), //"2019-01-20",
                DueDate = new DateTime(2019, 2, 20), //"2019-02-20",
                Comments = "TestInvoice",
                InvoiceRows = new List<InvoiceRow>()
                {
                    new InvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = 6, Price = 1000},
                }
            });
            #endregion Arrange

            IInvoiceAccrualConnector connector = new InvoiceAccrualConnector();

            #region CREATE
            var newInvoiceAccrual = new InvoiceAccrual()
            {
                Description = "TestInvoiceAccrual",
                InvoiceNumber = tmpInvoice.DocumentNumber,
                Period = "MONTHLY",
                AccrualAccount = 2990,
                RevenueAccount = 3990,
                StartDate = new DateTime(2020,3,25),
                EndDate = new DateTime(2020, 6, 25),
                Total = 6000,
                InvoiceAccrualRows = new List<InvoiceAccrualRow>()
                {
                    new InvoiceAccrualRow(){ Account = 2990, Credit = 0, Debit = 2000 },
                    new InvoiceAccrualRow(){ Account = 3990, Credit = 2000, Debit = 0 }
                }
            };

            var createdInvoiceAccrual = connector.Create(newInvoiceAccrual);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("TestInvoiceAccrual", createdInvoiceAccrual.Description);

            #endregion CREATE

            #region UPDATE

            createdInvoiceAccrual.Description = "UpdatedTestInvoiceAccrual";

            var updatedInvoiceAccrual = connector.Update(createdInvoiceAccrual); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedTestInvoiceAccrual", updatedInvoiceAccrual.Description);

            #endregion UPDATE

            #region READ / GET

            var retrievedInvoiceAccrual = connector.Get(createdInvoiceAccrual.InvoiceNumber);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedTestInvoiceAccrual", retrievedInvoiceAccrual.Description);

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdInvoiceAccrual.InvoiceNumber);
            MyAssert.HasNoError(connector);

            retrievedInvoiceAccrual = connector.Get(createdInvoiceAccrual.InvoiceNumber);
            Assert.AreEqual(null, retrievedInvoiceAccrual, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            new CustomerConnector().Delete(tmpCustomer.CustomerNumber);
            new ArticleConnector().Delete(tmpArticle.ArticleNumber);
            #endregion Delete arranged resources
        }

        [TestMethod]
        public void Test_ContractAccrual_Find()
        {
            #region Arrange
            var tmpCustomer = new CustomerConnector().Create(new Customer() { Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis" });
            var tmpArticle = new ArticleConnector().Create(new Article() { Description = "TmpArticle", Type = ArticleType.Stock, PurchasePrice = 100 });

            var tmpInvoice = new InvoiceConnector().Create(new Invoice()
            {
                CustomerNumber = tmpCustomer.CustomerNumber,
                InvoiceDate = new DateTime(2019, 1, 20), //"2019-01-20",
                DueDate = new DateTime(2019, 2, 20), //"2019-02-20",
                Comments = "TestInvoice",
                InvoiceRows = new List<InvoiceRow>()
                {
                    new InvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = 6, Price = 1000},
                }
            });
            #endregion Arrange

            IInvoiceAccrualConnector connector = new InvoiceAccrualConnector();

            var marks = TestUtils.RandomString();
            var newInvoiceAccrual = new InvoiceAccrual()
            {
                Description = marks,
                Period = "MONTHLY",
                AccrualAccount = 2990,
                RevenueAccount = 3990,
                StartDate = new DateTime(2020, 3, 25),
                EndDate = new DateTime(2020, 6, 25),
                Total = 6000,
                InvoiceAccrualRows = new List<InvoiceAccrualRow>()
                {
                    new InvoiceAccrualRow(){ Account = 2990, Credit = 0, Debit = 2000 },
                    new InvoiceAccrualRow(){ Account = 3990, Credit = 2000, Debit = 0 }
                }
            };

            for (var i = 0; i < 5; i++)
            {
                newInvoiceAccrual.InvoiceNumber = tmpInvoice.DocumentNumber;
                connector.Create(newInvoiceAccrual);
                MyAssert.HasNoError(connector);

                var contractConnector = new InvoiceConnector();
                tmpInvoice.DocumentNumber = null;
                tmpInvoice = contractConnector.Create(tmpInvoice);
                MyAssert.HasNoError(contractConnector);
            }

            var contractAccruals = connector.Find();
            Assert.AreEqual(5, contractAccruals.Entities.Count(x => x.Description.StartsWith(marks)));

            foreach (var entry in contractAccruals.Entities.Where(x => x.Description.StartsWith(marks)))
            {
                connector.Delete(entry.InvoiceNumber);
                MyAssert.HasNoError(connector);
            }

            #region Delete arranged resources

            new ArticleConnector().Delete(tmpArticle.ArticleNumber);
            new CustomerConnector().Delete(tmpCustomer.CustomerNumber);

            #endregion Delete arranged resources
        }
    }
}
