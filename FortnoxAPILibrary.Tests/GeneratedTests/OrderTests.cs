using System;
using System.Collections.Generic;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.GeneratedTests
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
            #region Arrange
            var tmpCustomer = new CustomerConnector().Create(new Customer() { Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis" });
            var tmpArticle = new ArticleConnector().Create(new Article() { Description = "TmpArticle", Type = ArticleType.STOCK, PurchasePrice = 100 });
            #endregion Arrange

            var connector = new OrderConnector();

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
            MyAssert.HasNoError(connector);
            Assert.AreEqual("TestOrder", createdOrder.Comments);
            Assert.AreEqual("TmpCustomer", createdOrder.CustomerName);
            Assert.AreEqual(3, createdOrder.OrderRows.Count);

            #endregion CREATE

            #region UPDATE

            createdOrder.Comments = "UpdatedTestOrder";

            var updatedOrder = connector.Update(createdOrder); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedTestOrder", updatedOrder.Comments);

            #endregion UPDATE

            #region READ / GET

            var retrievedOrder = connector.Get(createdOrder.DocumentNumber);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedTestOrder", retrievedOrder.Comments);

            #endregion READ / GET

            #region DELETE
            //Not allowed
            #endregion DELETE

            #region Delete arranged resources
            new CustomerConnector().Delete(tmpCustomer.CustomerNumber);
            new ArticleConnector().Delete(tmpArticle.ArticleNumber);
            #endregion Delete arranged resources
        }
    }
}
