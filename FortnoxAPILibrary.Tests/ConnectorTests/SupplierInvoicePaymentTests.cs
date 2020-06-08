using System;
using System.Collections.Generic;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.Tests.ConnectorTests
{
    [TestClass]
    public class SupplierInvoicePaymentTests
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
        public void Test_SupplierInvoicePayment_CRUD()
        {
            #region Arrange
            var tmpSupplier = new SupplierConnector().Create(new Supplier() { Name = "TmpSupplier" });
            var tmpArticle = new ArticleConnector().Create(new Article() { Description = "TmpArticle", PurchasePrice = 100 });
            var tmpSpplierInvoice = new SupplierInvoiceConnector().Create(new SupplierInvoice()
            {
                SupplierNumber = tmpSupplier.SupplierNumber,
                Comments = "InvoiceComments",
                InvoiceDate = new DateTime(2020, 1, 1),
                DueDate = new DateTime(2020, 2, 1),
                SalesType = SalesType.Stock,
                OCR = "123456789",
                Total = 5000,
                SupplierInvoiceRows = new List<SupplierInvoiceRow>()
                {
                    new SupplierInvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, Quantity = 10, Price = 100},
                    new SupplierInvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, Quantity = 20, Price = 100},
                    new SupplierInvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, Quantity = 20, Price = 100}
                }
            });
            var bookedInvoice = new SupplierInvoiceConnector().Bookkeep(tmpSpplierInvoice.GivenNumber);
            #endregion Arrange

            ISupplierInvoicePaymentConnector connector = new SupplierInvoicePaymentConnector();

            #region CREATE
            var newSupplierInvoicePayment = new SupplierInvoicePayment()
            {
                InvoiceNumber = (int?) tmpSpplierInvoice.GivenNumber,
                Amount = 1000,
                AmountCurrency = 1000,
                PaymentDate = new DateTime(2020, 1, 20)
            };

            var createdSupplierInvoicePayment = connector.Create(newSupplierInvoicePayment);
            MyAssert.HasNoError(connector);
            Assert.AreEqual(1000, createdSupplierInvoicePayment.Amount);

            #endregion CREATE

            #region UPDATE

            createdSupplierInvoicePayment.Amount = 2000; 

            var updatedSupplierInvoicePayment = connector.Update(createdSupplierInvoicePayment); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual(2000, updatedSupplierInvoicePayment.Amount);

            #endregion UPDATE

            #region READ / GET

            var retrievedSupplierInvoicePayment = connector.Get(createdSupplierInvoicePayment.Number);
            MyAssert.HasNoError(connector);
            Assert.AreEqual(2000, retrievedSupplierInvoicePayment.Amount);

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdSupplierInvoicePayment.Number);
            MyAssert.HasNoError(connector);

            retrievedSupplierInvoicePayment = connector.Get(createdSupplierInvoicePayment.Number);
            Assert.AreEqual(null, retrievedSupplierInvoicePayment, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            new ArticleConnector().Delete(tmpArticle.ArticleNumber);
            new SupplierConnector().Delete(tmpSupplier.SupplierNumber);
            #endregion Delete arranged resources
        }
    }
}
