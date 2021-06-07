using System;
using System.Collections.Generic;
using System.Linq;
using Fortnox.SDK;
using Fortnox.SDK.Connectors;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests
{
    [TestClass]
    public class OrderTests
    {
        public FortnoxClient FortnoxClient = TestUtils.DefaultFortnoxClient;

        [TestMethod]
        public void Test_Order_CRUD()
        {
            #region Arrange
            var tmpCustomer = new CustomerConnector().Create(new Customer() { Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis" });
            var tmpArticle = new ArticleConnector().Create(new Article() { Description = "TmpArticle", Type = ArticleType.Stock, PurchasePrice = 100 });
            #endregion Arrange

            IOrderConnector connector = new OrderConnector();

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

            var createdOrder = connector.Create(newOrder);
            Assert.AreEqual("TestOrder", createdOrder.Comments);
            Assert.AreEqual("TmpCustomer", createdOrder.CustomerName);
            Assert.AreEqual(3, createdOrder.OrderRows.Count);

            #endregion CREATE

            #region UPDATE

            createdOrder.Comments = "UpdatedTestOrder";

            var updatedOrder = connector.Update(createdOrder); 
            Assert.AreEqual("UpdatedTestOrder", updatedOrder.Comments);

            #endregion UPDATE

            #region READ / GET

            var retrievedOrder = connector.Get(createdOrder.DocumentNumber);
            Assert.AreEqual("UpdatedTestOrder", retrievedOrder.Comments);

            #endregion READ / GET

            #region DELETE
            //Not allowed
            connector.Cancel(createdOrder.DocumentNumber);
            #endregion DELETE

            #region Delete arranged resources
            new CustomerConnector().Delete(tmpCustomer.CustomerNumber);
            //new ArticleConnector().Delete(tmpArticle.ArticleNumber);
            #endregion Delete arranged resources
        }

        [TestMethod]
        public void Test_Find()
        {
            #region Arrange
            var tmpCustomer = new CustomerConnector().Create(new Customer() { Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis" });
            var tmpArticle = new ArticleConnector().Create(new Article() { Description = "TmpArticle", Type = ArticleType.Stock, PurchasePrice = 100 });
            #endregion Arrange

            IOrderConnector connector = new OrderConnector();
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
                connector.Create(newOrder);
            }

            //Apply base test filter
            var searchSettings = new OrderSearch();
            searchSettings.CustomerNumber = tmpCustomer.CustomerNumber;
            var fullCollection = connector.Find(searchSettings);

            Assert.AreEqual(5, fullCollection.TotalResources);
            Assert.AreEqual(5, fullCollection.Entities.Count);
            Assert.AreEqual(1, fullCollection.TotalPages);

            Assert.AreEqual(tmpCustomer.CustomerNumber, fullCollection.Entities.First().CustomerNumber);

            //Apply Limit
            searchSettings.Limit = 2;
            var limitedCollection = connector.Find(searchSettings);

            Assert.AreEqual(5, limitedCollection.TotalResources);
            Assert.AreEqual(2, limitedCollection.Entities.Count);
            Assert.AreEqual(3, limitedCollection.TotalPages);

            //Delete entries (DELETE not supported)
            foreach (var order in fullCollection.Entities)
                connector.Cancel(order.DocumentNumber);

            #region Delete arranged resources
            new CustomerConnector().Delete(tmpCustomer.CustomerNumber);
            //new ArticleConnector().Delete(tmpArticle.ArticleNumber);
            #endregion Delete arranged resources
        }

        [TestMethod]
        public void Test_Print()
        {
            #region Arrange
            var tmpCustomer = new CustomerConnector().Create(new Customer() { Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis" });
            var tmpArticle = new ArticleConnector().Create(new Article() { Description = "TmpArticle", Type = ArticleType.Stock, PurchasePrice = 100 });
            #endregion Arrange

            IOrderConnector connector = new OrderConnector();
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

            var createdOrder = connector.Create(newOrder);

            var fileData = connector.Print(createdOrder.DocumentNumber);
            MyAssert.IsPDF(fileData);

            connector.Cancel(createdOrder.DocumentNumber);

            #region Delete arranged resources
            new CustomerConnector().Delete(tmpCustomer.CustomerNumber);
            //new ArticleConnector().Delete(tmpArticle.ArticleNumber);
            #endregion Delete arranged resources
        }

        [TestMethod]
        public void Test_Email()
        {
            #region Arrange
            var tmpCustomer = new CustomerConnector().Create(new Customer() { Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis", Email = "richard.randak@softwerk.se" });
            var tmpArticle = new ArticleConnector().Create(new Article() { Description = "TmpArticle", Type = ArticleType.Stock, PurchasePrice = 100 });
            #endregion Arrange

            IOrderConnector connector = new OrderConnector();
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

            var createdOrder = connector.Create(newOrder);

            var emailedInvoice = connector.Email(createdOrder.DocumentNumber);
            Assert.AreEqual(emailedInvoice.DocumentNumber, createdOrder.DocumentNumber);

            connector.Cancel(createdOrder.DocumentNumber);

            #region Delete arranged resources
            new CustomerConnector().Delete(tmpCustomer.CustomerNumber);
            //new ArticleConnector().Delete(tmpArticle.ArticleNumber);
            #endregion Delete arranged resources
        }
    }
}
