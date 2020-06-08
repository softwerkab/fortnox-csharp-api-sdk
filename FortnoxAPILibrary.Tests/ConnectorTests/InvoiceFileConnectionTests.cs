using System;
using System.Collections.Generic;
using System.Linq;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.Tests.ConnectorTests
{
    [TestClass]
    public class InvoiceFileConnectionTests
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
        public void Test_InvoiceFileConnection_CRUD()
        {
            #region Arrange
            var tmpCustomer = new CustomerConnector().Create(new Customer() { Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis" });
            var tmpArticle = new ArticleConnector().Create(new Article() { Description = "TmpArticle", Type = ArticleType.Stock, PurchasePrice = 10 });
            var invoiceConnector = new InvoiceConnector();
            var tmpInvoice = invoiceConnector.Create(new Invoice()
            {
                CustomerNumber = tmpCustomer.CustomerNumber,
                InvoiceDate = new DateTime(2020, 1, 20),
                DueDate = new DateTime(2020, 6, 20),
                InvoiceRows = new List<InvoiceRow>()
                {
                    new InvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = 2, Price = 10},
                }
            });
            var c = new InboxConnector();
            var tmpFile = c.UploadFile("tmpInvoiceFile.pdf", Resource.invoice_example, StaticFolders.CustomerInvoices);
            #endregion Arrange

            /*IInvoiceFileConnectionConnector*/ var connector = new InvoiceFileConnectionConnector();

            #region CREATE
            var newInvoiceFileConnection = new InvoiceFileConnection()
            {
                EntityId = tmpInvoice.DocumentNumber,
                FileId = tmpFile.ArchiveFileId,
                IncludeOnSend = false,
                EntityType = EntityType.Invoice
            };

            var createdInvoiceFileConnection = connector.Create(newInvoiceFileConnection);
            MyAssert.HasNoError(connector);
            Assert.AreEqual(false, createdInvoiceFileConnection.IncludeOnSend);

            #endregion CREATE

            #region UPDATE

            createdInvoiceFileConnection.IncludeOnSend = true;

            var updatedInvoiceFileConnection = connector.Update(createdInvoiceFileConnection); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual(true, updatedInvoiceFileConnection.IncludeOnSend);

            #endregion UPDATE

            #region READ / GET

            var retrievedInvoiceFileConnection = connector.GetConnections(createdInvoiceFileConnection.EntityId, createdInvoiceFileConnection.EntityType)?.FirstOrDefault();
            MyAssert.HasNoError(connector);
            Assert.AreEqual(true, retrievedInvoiceFileConnection?.IncludeOnSend);

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdInvoiceFileConnection.Id);
            MyAssert.HasNoError(connector);

            retrievedInvoiceFileConnection = connector.GetConnections(createdInvoiceFileConnection.EntityId, createdInvoiceFileConnection.EntityType)?.FirstOrDefault();
            Assert.AreEqual(null, retrievedInvoiceFileConnection, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            new CustomerConnector().Delete(tmpCustomer.CustomerNumber);
            new ArticleConnector().Delete(tmpArticle.ArticleNumber);
            new InboxConnector().DeleteFile(tmpFile.Id);
            #endregion Delete arranged resources
        }
    }
}
