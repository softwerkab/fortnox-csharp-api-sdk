using System.Collections.Generic;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.Tests
{
    [TestClass]
    public class InvoiceTests
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
        public void Test_Invoice_CRUD()
        {
            //Arrange
            var tmpCustomer = new CustomerConnector().Create(new Customer(){ Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis"});
            var tmpArticle = new ArticleConnector().Create(new Article(){Description = "TmpArticle", Type = ArticleType.STOCK, PurchasePrice = "100"});
            
            //Act
            var connector = new InvoiceConnector();

            #region CREATE
            var newInvoice = new Invoice()
            {
                CustomerNumber = tmpCustomer.CustomerNumber,
                InvoiceDate = "2019-01-20",
                DueDate = "2019-02-20",
                InvoiceType = InvoiceType.CASHINVOICE,
                PaymentWay = "CASH",
                InvoiceRows = new List<InvoiceRow>()
                {
                    new InvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = "10"},
                    new InvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = "20"},
                    new InvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = "15"}
                }
            };

            var createdInvoice = connector.Create(newInvoice);
            MyAssert.HasNoError(connector);
            Assert.AreEqual(createdInvoice.CustomerName, "TmpCustomer");
            Assert.AreEqual(3,createdInvoice.InvoiceRows.Count);

            #endregion CREATE

            #region UPDATE

            createdInvoice.City = "UpdatedCity";

            var updatedInvoice = connector.Update(createdInvoice);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedCity", updatedInvoice.City);

            #endregion UPDATE

            #region READ / GET

            var retrievedInvoice = connector.Get(createdInvoice.DocumentNumber);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedCity", retrievedInvoice.City);

            #endregion READ / GET

            #region DELETE
            //Invoice does not provide DELETE method, but can be canceled
            connector.Cancel(createdInvoice.DocumentNumber);
            MyAssert.HasNoError(connector);

            retrievedInvoice = connector.Get(createdInvoice.DocumentNumber);
            Assert.AreEqual("true", retrievedInvoice.Cancelled);

            #endregion DELETE

            //Clean
            new CustomerConnector().Delete(tmpCustomer.CustomerNumber);
            new ArticleConnector().Delete(tmpArticle.ArticleNumber);
        }
    }
}
