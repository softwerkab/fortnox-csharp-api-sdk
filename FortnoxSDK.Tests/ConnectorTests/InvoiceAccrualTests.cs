using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fortnox.SDK;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests;

[TestClass]
public class InvoiceAccrualTests
{
    public FortnoxClient FortnoxClient = TestUtils.DefaultFortnoxClient;

    [TestMethod]
    public async Task Test_InvoiceAccrual_CRUD()
    {
        #region Arrange
        var tmpCustomer = await FortnoxClient.CustomerConnector.CreateAsync(new Customer() { Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis" });
        var tmpArticle = await FortnoxClient.ArticleConnector.CreateAsync(new Article() { Description = "TmpArticle", Type = ArticleType.Stock, PurchasePrice = 100 });

        var tmpInvoice = await FortnoxClient.InvoiceConnector.CreateAsync(new Invoice()
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

        var connector = FortnoxClient.InvoiceAccrualConnector;

        #region CREATE
        var newInvoiceAccrual = new InvoiceAccrual()
        {
            Description = "TestInvoiceAccrual",
            InvoiceNumber = tmpInvoice.DocumentNumber,
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

        var createdInvoiceAccrual = await connector.CreateAsync(newInvoiceAccrual);
        Assert.AreEqual("TestInvoiceAccrual", createdInvoiceAccrual.Description);

        #endregion CREATE

        #region UPDATE

        createdInvoiceAccrual.Description = "UpdatedTestInvoiceAccrual";

        var updatedInvoiceAccrual = await connector.UpdateAsync(createdInvoiceAccrual);
        Assert.AreEqual("UpdatedTestInvoiceAccrual", updatedInvoiceAccrual.Description);

        #endregion UPDATE

        #region READ / GET

        var retrievedInvoiceAccrual = await connector.GetAsync(createdInvoiceAccrual.InvoiceNumber);
        Assert.AreEqual("UpdatedTestInvoiceAccrual", retrievedInvoiceAccrual.Description);

        #endregion READ / GET

        #region DELETE

        await connector.DeleteAsync(createdInvoiceAccrual.InvoiceNumber);

        Assert.ThrowsException<FortnoxApiException>(
            () => connector.Get(createdInvoiceAccrual.InvoiceNumber),
            "Entity still exists after Delete!");

        #endregion DELETE

        #region Delete arranged resources

        await FortnoxClient.InvoiceConnector.CancelAsync(tmpInvoice.DocumentNumber);
        //FortnoxClient.CustomerConnector.Delete(tmpCustomer.CustomerNumber);
        //FortnoxClient.ArticleConnector.Delete(tmpArticle.ArticleNumber);
        #endregion Delete arranged resources
    }

    [TestMethod]
    public async Task Test_InvoiceAccrual_Find()
    {
        #region Arrange
        var tmpCustomer = await FortnoxClient.CustomerConnector.CreateAsync(new Customer() { Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis" });
        var tmpArticle = await FortnoxClient.ArticleConnector.CreateAsync(new Article() { Description = "TmpArticle", Type = ArticleType.Stock, PurchasePrice = 100 });

        #endregion Arrange

        var connector = FortnoxClient.InvoiceAccrualConnector;

        var invoice = new Invoice()
        {
            CustomerNumber = tmpCustomer.CustomerNumber,
            InvoiceDate = new DateTime(2019, 1, 20), //"2019-01-20",
            DueDate = new DateTime(2019, 2, 20), //"2019-02-20",
            Comments = "TestInvoice",
            InvoiceRows = new List<InvoiceRow>()
            {
                new InvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = 6, Price = 1000},
            }
        };

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
            var createdInvoice = await FortnoxClient.InvoiceConnector.CreateAsync(invoice);

            newInvoiceAccrual.InvoiceNumber = createdInvoice.DocumentNumber;
            await connector.CreateAsync(newInvoiceAccrual);
        }

        var contractAccruals = await connector.FindAsync(null);
        Assert.AreEqual(5, contractAccruals.Entities.Count(x => x.Description.StartsWith(marks)));

        foreach (var entry in contractAccruals.Entities.Where(x => x.Description.StartsWith(marks)))
        {
            await connector.DeleteAsync(entry.InvoiceNumber);
            await FortnoxClient.InvoiceConnector.CancelAsync(entry.InvoiceNumber);
        }

        #region Delete arranged resources
        //FortnoxClient.ArticleConnector.Delete(tmpArticle.ArticleNumber);
        await FortnoxClient.CustomerConnector.DeleteAsync(tmpCustomer.CustomerNumber);
        #endregion Delete arranged resources
    }
}