using System;
using System.Collections.Generic;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.Tests
{
    [TestClass]
    public class SupplierInvoiceTests
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
        public void Test_SupplierInvoice_CRUD()
        {
            //Arrange
            var tmpSupplier = new SupplierConnector().Create(new Supplier() { Name = "TmpSupplier", CountryCode = "SE", City = "Testopolis" });
            var tmpArticle = new ArticleConnector().Create(new Article(){Description = "TmpArticle", Type = ArticleType.STOCK, PurchasePrice = 100});
            
            //Act
            var connector = new SupplierInvoiceConnector();

            #region CREATE
            var newInvoice = new SupplierInvoice()
            {
                SupplierNumber = tmpSupplier.SupplierNumber,
                InvoiceDate = new DateTime(2019, 1, 20).ToString(APIConstants.DateFormat), //"2019-01-20",
                DueDate = new DateTime(2019, 2, 20).ToString(APIConstants.DateFormat), //"2019-02-20",
                SalesType = SalesType.STOCK,
                OCR = "123456789",
                SupplierInvoiceRows = new List<SupplierInvoiceRow>()
                {
                    new SupplierInvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, Quantity = 10},
                    new SupplierInvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, Quantity = 20},
                    new SupplierInvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, Quantity = 15}
                }
            };

            var createdInvoice = connector.Create(newInvoice);
            MyAssert.HasNoError(connector);
            Assert.AreEqual(createdInvoice.SupplierName, "TmpSupplier");
            Assert.AreEqual(3+1,createdInvoice.SupplierInvoiceRows.Count);
            //3 + 1 => A row "Leverantörsskulder" is created by default

            #endregion CREATE

            #region UPDATE

            createdInvoice.OCR = "987654321";
            var updatedInvoice = connector.Update(createdInvoice);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("987654321", updatedInvoice.OCR);

            #endregion UPDATE

            #region READ / GET

            var retrievedInvoice = connector.Get(createdInvoice.GivenNumber);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("987654321", retrievedInvoice.OCR);

            #endregion READ / GET

            #region DELETE
            //Invoice does not provide DELETE method, but can be canceled
            connector.Cancel(createdInvoice.GivenNumber);
            MyAssert.HasNoError(connector);

            retrievedInvoice = connector.Get(createdInvoice.GivenNumber);
            Assert.AreEqual(true, retrievedInvoice.Cancelled);

            #endregion DELETE

            //Clean
            new SupplierConnector().Delete(tmpSupplier.SupplierNumber);
            new ArticleConnector().Delete(tmpArticle.ArticleNumber);
        }
    }
}
