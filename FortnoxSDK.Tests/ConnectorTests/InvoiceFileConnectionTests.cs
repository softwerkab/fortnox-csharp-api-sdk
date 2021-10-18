using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fortnox.SDK;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests
{
    [TestClass]
    public class InvoiceFileConnectionTests
    {
        public FortnoxClient FortnoxClient = TestUtils.DefaultFortnoxClient;

        [TestMethod]
        public async Task Test_InvoiceFileConnection_CRUD()
        {
            #region Arrange
            var tmpCustomer = await FortnoxClient.CustomerConnector.CreateAsync(new Customer() { Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis" });
            var tmpArticle = await FortnoxClient.ArticleConnector.CreateAsync(new Article() { Description = "TmpArticle", Type = ArticleType.Stock, PurchasePrice = 10 });
            var invoiceConnector = FortnoxClient.InvoiceConnector;
            var tmpInvoice = await invoiceConnector.CreateAsync(new Invoice()
            {
                CustomerNumber = tmpCustomer.CustomerNumber,
                InvoiceDate = new DateTime(2020, 1, 20),
                DueDate = new DateTime(2020, 6, 20),
                InvoiceRows = new List<InvoiceRow>()
                {
                    new InvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = 2, Price = 10},
                }
            });
            var inboxConnector = FortnoxClient.InboxConnector;
            var tmpFile = await inboxConnector.UploadFileAsync("tmpInvoiceFile.pdf", Resource.invoice_example, StaticFolders.CustomerInvoices);
            #endregion Arrange

            var connector = FortnoxClient.InvoiceFileConnectionConnector;

            #region CREATE
            var newInvoiceFileConnection = new InvoiceFileConnection()
            {
                EntityId = tmpInvoice.DocumentNumber,
                FileId = tmpFile.ArchiveFileId,
                IncludeOnSend = false,
                EntityType = EntityType.Invoice
            };

            var createdInvoiceFileConnection = await connector.CreateAsync(newInvoiceFileConnection);
            Assert.AreEqual(false, createdInvoiceFileConnection.IncludeOnSend);

            #endregion CREATE

            #region UPDATE

            createdInvoiceFileConnection.IncludeOnSend = true;

            var updatedInvoiceFileConnection = await connector.UpdateAsync(createdInvoiceFileConnection);
            Assert.AreEqual(true, updatedInvoiceFileConnection.IncludeOnSend);

            #endregion UPDATE

            #region READ / GET

            var retrievedInvoiceFileConnection = (await connector.GetConnectionsAsync(createdInvoiceFileConnection.EntityId, createdInvoiceFileConnection.EntityType))?.FirstOrDefault();
            Assert.AreEqual(true, retrievedInvoiceFileConnection?.IncludeOnSend);

            #endregion READ / GET

            #region DELETE

            await connector.DeleteAsync(createdInvoiceFileConnection.Id);

            retrievedInvoiceFileConnection = (await connector.GetConnectionsAsync(createdInvoiceFileConnection.EntityId, createdInvoiceFileConnection.EntityType))?.FirstOrDefault();
            Assert.AreEqual(null, retrievedInvoiceFileConnection, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            await FortnoxClient.InvoiceConnector.CancelAsync(tmpInvoice.DocumentNumber);
            await FortnoxClient.CustomerConnector.DeleteAsync(tmpCustomer.CustomerNumber);
            //FortnoxClient.ArticleConnector.Delete(tmpArticle.ArticleNumber);
            await FortnoxClient.InboxConnector.DeleteFileAsync(tmpFile.Id);
            #endregion Delete arranged resources
        }
    }
}
