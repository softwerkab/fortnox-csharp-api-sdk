using System;
using System.Collections.Generic;
using System.Linq;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.Tests.ConnectorTests
{
    [TestClass]
    public class InvoiceTests
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
        public void Test_Invoice_CRUD()
        {
            #region Arrange
            var tmpCustomer = new CustomerConnector().Create(new Customer() { Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis" });
            var tmpArticle = new ArticleConnector().Create(new Article() { Description = "TmpArticle", Type = ArticleType.Stock, PurchasePrice = 100 });
            #endregion Arrange

            IInvoiceConnector connector = new InvoiceConnector();

            #region CREATE
            var newInvoice = new Invoice()
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

            var createdInvoice = connector.Create(newInvoice);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("TestInvoice", createdInvoice.Comments);
            Assert.AreEqual("TmpCustomer", createdInvoice.CustomerName);
            Assert.AreEqual(3, createdInvoice.InvoiceRows.Count);

            #endregion CREATE

            #region UPDATE

            createdInvoice.Comments = "UpdatedInvoice";

            var updatedInvoice = connector.Update(createdInvoice); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedInvoice", updatedInvoice.Comments);

            #endregion UPDATE

            #region READ / GET

            var retrievedInvoice = connector.Get(createdInvoice.DocumentNumber);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedInvoice", retrievedInvoice.Comments);

            #endregion READ / GET

            #region DELETE
            //Not available
            #endregion DELETE

            #region Delete arranged resources
            new CustomerConnector().Delete(tmpCustomer.CustomerNumber);
            new ArticleConnector().Delete(tmpArticle.ArticleNumber);
            #endregion Delete arranged resources
        }

        [TestMethod]
        public void Test_Find()
        {
            #region Arrange
            var tmpCustomer = new CustomerConnector().Create(new Customer() { Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis" });
            var tmpArticle = new ArticleConnector().Create(new Article() { Description = "TmpArticle", Type = ArticleType.Stock, PurchasePrice = 100 });
            #endregion Arrange

            IInvoiceConnector connector = new InvoiceConnector();
            var newInvoice = new Invoice()
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

            //Add entries
            for (var i = 0; i < 5; i++)
            {
                connector.Create(newInvoice);
                MyAssert.HasNoError(connector);
            }

            //Apply base test filter
            connector.CustomerNumber = tmpCustomer.CustomerNumber;
            var fullCollection = connector.Find();
            MyAssert.HasNoError(connector);

            Assert.AreEqual(5, fullCollection.TotalResources);
            Assert.AreEqual(5, fullCollection.Entities.Count);
            Assert.AreEqual(1, fullCollection.TotalPages);
            
            Assert.AreEqual(tmpCustomer.CustomerNumber, fullCollection.Entities.First().CustomerNumber);

            //Apply Limit
            connector.Limit = 2;
            var limitedCollection = connector.Find();
            MyAssert.HasNoError(connector);

            Assert.AreEqual(5, limitedCollection.TotalResources);
            Assert.AreEqual(2, limitedCollection.Entities.Count);
            Assert.AreEqual(3, limitedCollection.TotalPages);

            //Delete entries (DELETE not supported)

            #region Delete arranged resources
            new CustomerConnector().Delete(tmpCustomer.CustomerNumber);
            new ArticleConnector().Delete(tmpArticle.ArticleNumber);
            #endregion Delete arranged resources
        }

        [TestMethod]
        public void Test_DueDate()
        {
            #region Arrange
            var tmpCustomer = new CustomerConnector().Create(new Customer() { Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis" });
            var tmpArticle = new ArticleConnector().Create(new Article() { Description = "TmpArticle", Type = ArticleType.Stock, PurchasePrice = 100 });
            #endregion Arrange

            IInvoiceConnector connector = new InvoiceConnector();
            var newInvoice = new Invoice()
            {
                CustomerNumber = tmpCustomer.CustomerNumber,
                InvoiceDate = new DateTime(2019, 1, 20), //"2019-01-20",
                Comments = "TestInvoice",
                InvoiceRows = new List<InvoiceRow>()
                {
                    new InvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = 10, Price = 100},
                    new InvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = 20, Price = 100},
                    new InvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = 15, Price = 100}
                }
            };

            var createdInvoice = connector.Create(newInvoice);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("2019-01-20", createdInvoice.InvoiceDate?.ToString(APIConstants.DateFormat));
            Assert.AreEqual("2019-02-19", createdInvoice.DueDate?.ToString(APIConstants.DateFormat));

            var newInvoiceDate = new DateTime(2019, 1, 1);
            var dateChange = newInvoiceDate - newInvoice.InvoiceDate.Value;
            var newDueDate = createdInvoice.DueDate?.AddDays(dateChange.Days);

            createdInvoice.InvoiceDate = newInvoiceDate;
            createdInvoice.DueDate = newDueDate;

            var updatedInvoice = connector.Update(createdInvoice);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("2019-01-01", updatedInvoice.InvoiceDate?.ToString(APIConstants.DateFormat));
            Assert.AreEqual("2019-01-31", updatedInvoice.DueDate?.ToString(APIConstants.DateFormat));

            #region Delete arranged resources
            new CustomerConnector().Delete(tmpCustomer.CustomerNumber);
            new ArticleConnector().Delete(tmpArticle.ArticleNumber);
            #endregion Delete arranged resources
        }

        [TestMethod]
        public void Test_Print()
        {
            #region Arrange
            var cc = new CustomerConnector();
            var ac = new ArticleConnector();
            var tmpCustomer = cc.Create(new Customer() { Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis" });
            var tmpArticle = ac.Create(new Article() { Description = "TmpArticle", Type = ArticleType.Stock, PurchasePrice = 100 });
            MyAssert.HasNoError(cc);
            MyAssert.HasNoError(ac);
            #endregion Arrange

            IInvoiceConnector connector = new InvoiceConnector();

            var newInvoice = new Invoice()
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

            var createdInvoice = connector.Create(newInvoice);
            MyAssert.HasNoError(connector);

            var fileData = connector.Print(createdInvoice.DocumentNumber);
            MyAssert.HasNoError(connector);
            MyAssert.IsPDF(fileData);

            #region Delete arranged resources
            new CustomerConnector().Delete(tmpCustomer.CustomerNumber);
            new ArticleConnector().Delete(tmpArticle.ArticleNumber);
            #endregion Delete arranged resources
        }

        [TestMethod]
        public void Test_Email()
        {
            #region Arrange
            var cc = new CustomerConnector();
            var ac = new ArticleConnector();
            var tmpCustomer = cc.Create(new Customer() { Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis", Email = "richard.randak@softwerk.se" });
            var tmpArticle = ac.Create(new Article() { Description = "TmpArticle", Type = ArticleType.Stock, PurchasePrice = 100 });
            MyAssert.HasNoError(cc);
            MyAssert.HasNoError(ac);
            #endregion Arrange

            IInvoiceConnector connector = new InvoiceConnector();

            var newInvoice = new Invoice()
            {
                CustomerNumber = tmpCustomer.CustomerNumber,
                InvoiceDate = new DateTime(2019, 1, 20), //"2019-01-20",
                DueDate = new DateTime(2019, 2, 20), //"2019-02-20",
                InvoiceType = InvoiceType.CashInvoice,
                PaymentWay = PaymentWay.Cash,
                Comments = "Testing invoice email feature",
                InvoiceRows = new List<InvoiceRow>()
                {
                    new InvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = 10, Price = 100},
                    new InvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = 20, Price = 100},
                    new InvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = 15, Price = 100}
                }
            };

            var createdInvoice = connector.Create(newInvoice);
            MyAssert.HasNoError(connector);

            var emailedInvoice = connector.Email(createdInvoice.DocumentNumber);
            MyAssert.HasNoError(connector);
            Assert.AreEqual(emailedInvoice.DocumentNumber, createdInvoice.DocumentNumber);

            #region Delete arranged resources
            new CustomerConnector().Delete(tmpCustomer.CustomerNumber);
            new ArticleConnector().Delete(tmpArticle.ArticleNumber);
            #endregion Delete arranged resources
        }
    }
}
