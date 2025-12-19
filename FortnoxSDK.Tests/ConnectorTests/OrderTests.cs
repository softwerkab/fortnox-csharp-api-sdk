using Fortnox.SDK;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FortnoxSDK.Tests.ConnectorTests;

[TestClass]
public class OrderTests
{
    public FortnoxClient FortnoxClient = TestUtils.DefaultFortnoxClient;

    [TestMethod]
    public async Task Test_Order_CRUD()
    {
        #region Arrange
        var tmpCustomer = await FortnoxClient.CustomerConnector.CreateAsync(new Customer() { Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis" });
        var tmpArticle = await FortnoxClient.ArticleConnector.CreateAsync(new Article() { Description = "TmpArticle", Type = ArticleType.Stock, PurchasePrice = 100 });
        #endregion Arrange

        var connector = FortnoxClient.OrderConnector;

        #region CREATE
        var newOrder = new Order()
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

        var createdOrder = await connector.CreateAsync(newOrder);
        Assert.AreEqual("TestOrder", createdOrder.Comments);
        Assert.AreEqual("TmpCustomer", createdOrder.CustomerName);
        Assert.AreEqual(3, createdOrder.OrderRows.Count);

        #endregion CREATE

        #region UPDATE

        createdOrder.Comments = "UpdatedTestOrder";

        var updatedOrder = await connector.UpdateAsync(createdOrder);
        Assert.AreEqual("UpdatedTestOrder", updatedOrder.Comments);

        #endregion UPDATE

        #region READ / GET

        var retrievedOrder = await connector.GetAsync(createdOrder.DocumentNumber);
        Assert.AreEqual("UpdatedTestOrder", retrievedOrder.Comments);

        #endregion READ / GET

        #region DELETE
        //Not allowed
        await connector.CancelAsync(createdOrder.DocumentNumber);
        #endregion DELETE

        #region Delete arranged resources
        await FortnoxClient.CustomerConnector.DeleteAsync(tmpCustomer.CustomerNumber);
        //FortnoxClient.ArticleConnector.Delete(tmpArticle.ArticleNumber);
        #endregion Delete arranged resources
    }

    [TestMethod]
    public async Task Test_Order_Find()
    {
        #region Arrange
        var tmpCustomer = await FortnoxClient.CustomerConnector.CreateAsync(new Customer() { Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis" });
        var tmpArticle = await FortnoxClient.ArticleConnector.CreateAsync(new Article() { Description = "TmpArticle", Type = ArticleType.Stock, PurchasePrice = 100 });
        #endregion Arrange

        var connector = FortnoxClient.OrderConnector;
        var newOrder = new Order()
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

        //Add entries
        for (var i = 0; i < 5; i++)
        {
            await connector.CreateAsync(newOrder);
        }

        //Apply base test filter
        var searchSettings = new OrderSearch();
        searchSettings.CustomerNumber = tmpCustomer.CustomerNumber;
        var fullCollection = await connector.FindAsync(searchSettings);

        Assert.AreEqual(5, fullCollection.TotalResources);
        Assert.AreEqual(5, fullCollection.Entities.Count);
        Assert.AreEqual(1, fullCollection.TotalPages);

        Assert.AreEqual(tmpCustomer.CustomerNumber, fullCollection.Entities.First().CustomerNumber);

        //Apply Limit
        searchSettings.Limit = 2;
        var limitedCollection = await connector.FindAsync(searchSettings);

        Assert.AreEqual(5, limitedCollection.TotalResources);
        Assert.AreEqual(2, limitedCollection.Entities.Count);
        Assert.AreEqual(3, limitedCollection.TotalPages);

        //Delete entries (DELETE not supported)
        foreach (var order in fullCollection.Entities)
            await connector.CancelAsync(order.DocumentNumber);

        #region Delete arranged resources
        await FortnoxClient.CustomerConnector.DeleteAsync(tmpCustomer.CustomerNumber);
        //FortnoxClient.ArticleConnector.Delete(tmpArticle.ArticleNumber);
        #endregion Delete arranged resources
    }

    [TestMethod]
    public async Task Test_Order_Print()
    {
        #region Arrange
        var tmpCustomer = await FortnoxClient.CustomerConnector.CreateAsync(new Customer() { Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis" });
        var tmpArticle = await FortnoxClient.ArticleConnector.CreateAsync(new Article() { Description = "TmpArticle", Type = ArticleType.Stock, PurchasePrice = 100 });
        #endregion Arrange

        var connector = FortnoxClient.OrderConnector;
        var newOrder = new Order()
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

        var createdOrder = await connector.CreateAsync(newOrder);

        var fileData = await connector.PrintAsync(createdOrder.DocumentNumber);
        MyAssert.IsPDF(fileData);

        await connector.CancelAsync(createdOrder.DocumentNumber);

        #region Delete arranged resources
        await FortnoxClient.CustomerConnector.DeleteAsync(tmpCustomer.CustomerNumber);
        //FortnoxClient.ArticleConnector.Delete(tmpArticle.ArticleNumber);
        #endregion Delete arranged resources
    }

    [TestMethod]
    public async Task Test_Order_Email()
    {
        #region Arrange
        var tmpCustomer = await FortnoxClient.CustomerConnector.CreateAsync(new Customer() { Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis", Email = "richard.randak@softwerk.se" });
        var tmpArticle = await FortnoxClient.ArticleConnector.CreateAsync(new Article() { Description = "TmpArticle", Type = ArticleType.Stock, PurchasePrice = 100 });
        #endregion Arrange

        var connector = FortnoxClient.OrderConnector;
        var newOrder = new Order()
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

        var createdOrder = await connector.CreateAsync(newOrder);

        var emailedInvoice = await connector.EmailAsync(createdOrder.DocumentNumber);
        Assert.AreEqual(emailedInvoice.DocumentNumber, createdOrder.DocumentNumber);

        await connector.CancelAsync(createdOrder.DocumentNumber);

        #region Delete arranged resources
        await FortnoxClient.CustomerConnector.DeleteAsync(tmpCustomer.CustomerNumber);
        //FortnoxClient.ArticleConnector.Delete(tmpArticle.ArticleNumber);
        #endregion Delete arranged resources
    }

    [TestMethod]
    [DataRow(HouseworkType.Cleaning, TaxReductionType.RUT)]
    [DataRow(HouseworkType.Construction, TaxReductionType.ROT)]
    [DataRow(HouseworkType.SolarCells, TaxReductionType.Green)]
    public async Task Test_Order_OrderRow_HouseWorkType(HouseworkType houseWorkType, TaxReductionType taxReductionType)
    {
        #region Arrange
        var tmpCustomer = await FortnoxClient.CustomerConnector.CreateAsync(new Customer() { Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis" });
        var tmpArticle = await FortnoxClient.ArticleConnector.CreateAsync(new Article() { Description = "TmpArticle", Type = ArticleType.Stock, PurchasePrice = 100 });
        #endregion Arrange

        var connector = FortnoxClient.OrderConnector;

        var order = new Order()
        {
            Comments = "Test Order with Order Rows specifying House Work types",
            CustomerNumber = tmpCustomer.CustomerNumber,
            OrderDate = new DateTime(2019, 1, 20),
            TaxReductionType = taxReductionType,
            OrderRows = [new OrderRow() { ArticleNumber = tmpArticle.ArticleNumber, OrderedQuantity = 20, DeliveredQuantity = 10, HouseWork = true, HouseWorkType = houseWorkType }]
        };

        order = await connector.CreateAsync(order);

        Assert.AreEqual(1, order.OrderRows.Count);
        Assert.AreEqual(houseWorkType, order.OrderRows.First().HouseWorkType);

        await connector.CancelAsync(order.DocumentNumber);

        #region Delete arranged resources
        await FortnoxClient.CustomerConnector.DeleteAsync(tmpCustomer.CustomerNumber);
        //FortnoxClient.ArticleConnector.Delete(tmpArticle.ArticleNumber);
        #endregion Delete arranged resources
    }
}