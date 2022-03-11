using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fortnox.SDK;
using Fortnox.SDK.Authorization;
using Fortnox.SDK.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests;

[TestClass]
public class WarehouseTests
{
    public FortnoxClient FortnoxClient = new FortnoxClient(new StaticTokenAuth("006738d2-3698-44af-b6d2-3103f3bf5b89", TestCredentials.Client_Secret)) { WarehouseEnabled = true };

    [TestMethod]
    public async Task Test_Order_WarehouseReady()
    {
        #region Arrange
        var tmpCustomer = await FortnoxClient.CustomerConnector.CreateAsync(new Customer() { Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis", Email = "richard.randak@softwerk.se" });
        var tmpArticle = await FortnoxClient.ArticleConnector.CreateAsync(new Article() { Description = "TmpArticle", Type = ArticleType.Stock, PurchasePrice = 100 });
        #endregion Arrange

        var order = new Order()
        {
            Comments = "TestOrder",
            CustomerNumber = tmpCustomer.CustomerNumber,
            OrderDate = new DateTime(2019, 1, 20), //"2019-01-20",
            OrderRows = new List<OrderRow>()
            {
                new OrderRow(){ ArticleNumber = tmpArticle.ArticleNumber, OrderedQuantity = 20, DeliveredQuantity = 10},
                new OrderRow(){ ArticleNumber = tmpArticle.ArticleNumber, OrderedQuantity = 20, DeliveredQuantity = 20},
                new OrderRow(){ ArticleNumber = tmpArticle.ArticleNumber, OrderedQuantity = 20, DeliveredQuantity = 15}
            }
        };

        order.DeliveryState = DeliveryState.Delivery;

        order = await FortnoxClient.OrderConnector.CreateAsync(order);
        Assert.AreEqual(false, order.WarehouseReady);

        order = await FortnoxClient.OrderConnector.WarehouseReady(order.DocumentNumber);
        Assert.AreEqual(true, order.WarehouseReady);

        #region Delete arranged resources
        await FortnoxClient.OrderConnector.CancelAsync(order.DocumentNumber);
        await FortnoxClient.CustomerConnector.DeleteAsync(tmpCustomer.CustomerNumber);
        //client.ArticleConnector.Delete(tmpArticle.ArticleNumber);
        #endregion Delete arranged resources
    }

    [TestMethod]
    public async Task Test_Invoice_WarehouseReady()
    {
        #region Arrange
        var tmpCustomer = await FortnoxClient.CustomerConnector.CreateAsync(new Customer() { Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis" });
        var tmpArticle = await FortnoxClient.ArticleConnector.CreateAsync(new Article() { Description = "TmpArticle", Type = ArticleType.Stock, PurchasePrice = 100 });
        #endregion Arrange

        var invoice = new Invoice()
        {
            CustomerNumber = tmpCustomer.CustomerNumber,
            InvoiceDate = new DateTime(2019, 1, 20), //"2019-01-20",
            DueDate = new DateTime(2019, 2, 20), //"2019-02-20",
            InvoiceType = InvoiceType.CashInvoice,
            PaymentWay = PaymentWay.Cash,
            Comments = "TestInvoice",
            InvoiceRows = new List<InvoiceRow>()
            {
                new InvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = 10, Price = 100},
                new InvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = 20, Price = 100},
                new InvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = 15, Price = 100}
            }
        };

        invoice = await FortnoxClient.InvoiceConnector.CreateAsync(invoice);
        Assert.AreEqual(false, invoice.WarehouseReady);

        invoice = await FortnoxClient.InvoiceConnector.WarehouseReady(invoice.DocumentNumber);
        Assert.AreEqual(true, invoice.WarehouseReady);

        #region Delete arranged resources
        await FortnoxClient.InvoiceConnector.CancelAsync(invoice.DocumentNumber);
        await FortnoxClient.CustomerConnector.DeleteAsync(tmpCustomer.CustomerNumber);
        //client.ArticleConnector.Delete(tmpArticle.ArticleNumber);
        #endregion Delete arranged resources
    }

    [TestMethod]
    public async Task Test_Order_DeliveryState_Update()
    {
        #region Arrange
        var tmpCustomer = await FortnoxClient.CustomerConnector.CreateAsync(new Customer() { Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis", Email = "richard.randak@softwerk.se" });
        var tmpArticle = await FortnoxClient.ArticleConnector.CreateAsync(new Article() { Description = "TmpArticle", Type = ArticleType.Stock, PurchasePrice = 100 });
        #endregion Arrange

        var order = new Order()
        {
            Comments = "TestOrder",
            CustomerNumber = tmpCustomer.CustomerNumber,
            OrderDate = new DateTime(2019, 1, 20), //"2019-01-20",
            OrderRows = new List<OrderRow>()
            {
                new OrderRow(){ ArticleNumber = tmpArticle.ArticleNumber, OrderedQuantity = 20, DeliveredQuantity = 10},
                new OrderRow(){ ArticleNumber = tmpArticle.ArticleNumber, OrderedQuantity = 20, DeliveredQuantity = 20},
                new OrderRow(){ ArticleNumber = tmpArticle.ArticleNumber, OrderedQuantity = 20, DeliveredQuantity = 15}
            },
            DeliveryState = DeliveryState.Reservation
        };

        order = await FortnoxClient.OrderConnector.CreateAsync(order);
        Assert.AreEqual(DeliveryState.Reservation, order.DeliveryState);

        order.DeliveryState = DeliveryState.Delivery;

        order = await FortnoxClient.OrderConnector.UpdateAsync(order);
        Assert.AreEqual(DeliveryState.Delivery, order.DeliveryState);

        #region Delete arranged resources
        await FortnoxClient.OrderConnector.CancelAsync(order.DocumentNumber);
        await FortnoxClient.CustomerConnector.DeleteAsync(tmpCustomer.CustomerNumber);
        //client.ArticleConnector.Delete(tmpArticle.ArticleNumber);
        #endregion Delete arranged resources
    }

    [TestMethod]
    public async Task Test_Tenant_WarehouseActivated_Get()
    {
        var tenant = await FortnoxClient.TenantConnector.GetAsync();

        Assert.AreEqual(true, tenant.WarehouseActivated);
        Assert.AreEqual(1212851, tenant.TenantId);
    }

    [TestMethod]
    public async Task Test_Tenant_WarehouseDisabled_Get()
    {
        var tenant = await TestUtils.DefaultFortnoxClient.TenantConnector.GetAsync();

        Assert.AreEqual(false, tenant.WarehouseActivated);
        Assert.AreEqual(1018318, tenant.TenantId);
    }
}
