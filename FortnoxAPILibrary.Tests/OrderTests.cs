using System;
using System.Collections.Generic;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.Tests
{
    [TestClass]
    public class OrderTests
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
        public void Test_Order_CRUD()
        {
            //Arrange
            var tmpCustomer = new CustomerConnector().Create(new Customer() { Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis" });
            var tmpArticle = new ArticleConnector().Create(new Article() { Description = "TmpArticle", Type = ArticleType.STOCK, PurchasePrice = 100 });

            //Act
            var connector = new OrderConnector();

            #region CREATE
            var newOrder = new Order()
            {
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
            MyAssert.HasNoError(connector);
            Assert.AreEqual(createdOrder.CustomerName, "TmpCustomer");
            Assert.AreEqual(3, createdOrder.OrderRows.Count);

            #endregion CREATE

            #region UPDATE

            createdOrder.City = "UpdatedCity";

            var updatedOrder = connector.Update(createdOrder);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedCity", updatedOrder.City);

            #endregion UPDATE

            #region READ / GET

            var retrievedOrder = connector.Get(createdOrder.DocumentNumber);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedCity", retrievedOrder.City);

            #endregion READ / GET

            #region DELETE
            //Order does not provide DELETE method, but can be canceled
            connector.Cancel(createdOrder.DocumentNumber);
            MyAssert.HasNoError(connector);

            retrievedOrder = connector.Get(createdOrder.DocumentNumber);
            Assert.AreEqual(true, retrievedOrder.Cancelled);

            #endregion DELETE

            //Clean
            new CustomerConnector().Delete(tmpCustomer.CustomerNumber);
            new ArticleConnector().Delete(tmpArticle.ArticleNumber);
        }
    }
}
