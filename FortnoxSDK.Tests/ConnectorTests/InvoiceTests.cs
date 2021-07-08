using System;
using System.Collections.Generic;
using System.Linq;
using Fortnox.SDK;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests
{
    [TestClass]
    public class InvoiceTests
    {
        public FortnoxClient FortnoxClient = TestUtils.DefaultFortnoxClient;

        [TestMethod]
        public void Test_Invoice_CRUD()
        {
            #region Arrange
            var tmpCustomer = FortnoxClient.CustomerConnector.Create(new Customer() { Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis" });
            var tmpArticle = FortnoxClient.ArticleConnector.Create(new Article() { Description = "TmpArticle", Type = ArticleType.Stock, PurchasePrice = 100 });
            #endregion Arrange

            var connector = FortnoxClient.InvoiceConnector;

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
            Assert.AreEqual("TestInvoice", createdInvoice.Comments);
            Assert.AreEqual("TmpCustomer", createdInvoice.CustomerName);
            Assert.AreEqual(3, createdInvoice.InvoiceRows.Count);

            #endregion CREATE

            #region UPDATE

            createdInvoice.Comments = "UpdatedInvoice";

            var updatedInvoice = connector.Update(createdInvoice); 
            Assert.AreEqual("UpdatedInvoice", updatedInvoice.Comments);

            #endregion UPDATE

            #region READ / GET

            var retrievedInvoice = connector.Get(createdInvoice.DocumentNumber);
            Assert.AreEqual("UpdatedInvoice", retrievedInvoice.Comments);

            #endregion READ / GET

            #region DELETE
            //Not available, Cancel instead
            connector.Cancel(createdInvoice.DocumentNumber);

            var cancelledInvoice = connector.Get(createdInvoice.DocumentNumber);
            Assert.AreEqual(true, cancelledInvoice.Cancelled);
            #endregion DELETE

            #region Delete arranged resources
            FortnoxClient.CustomerConnector.Delete(tmpCustomer.CustomerNumber);
            //FortnoxClient.ArticleConnector.Delete(tmpArticle.ArticleNumber);
            #endregion Delete arranged resources
        }

        [TestMethod]
        public void Test_Find()
        {
            #region Arrange
            var tmpCustomer = FortnoxClient.CustomerConnector.Create(new Customer() { Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis" });
            var tmpArticle = FortnoxClient.ArticleConnector.Create(new Article() { Description = "TmpArticle", Type = ArticleType.Stock, PurchasePrice = 100 });
            #endregion Arrange

            var connector = FortnoxClient.InvoiceConnector;
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
            }

            //Apply base test filter
            var searchSettings = new InvoiceSearch();
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
            foreach (var invoice in fullCollection.Entities)
                connector.Cancel(invoice.DocumentNumber);

            #region Delete arranged resources
            FortnoxClient.CustomerConnector.Delete(tmpCustomer.CustomerNumber);
            //FortnoxClient.ArticleConnector.Delete(tmpArticle.ArticleNumber);
            #endregion Delete arranged resources
        }

        [TestMethod]
        public void Test_DueDate()
        {
            #region Arrange
            var tmpCustomer = FortnoxClient.CustomerConnector.Create(new Customer() { Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis" });
            var tmpArticle = FortnoxClient.ArticleConnector.Create(new Article() { Description = "TmpArticle", Type = ArticleType.Stock, PurchasePrice = 100 });
            #endregion Arrange

            var connector = FortnoxClient.InvoiceConnector;
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
            Assert.AreEqual("2019-01-20", createdInvoice.InvoiceDate?.ToString(APIConstants.DateFormat));
            Assert.AreEqual("2019-02-19", createdInvoice.DueDate?.ToString(APIConstants.DateFormat));

            var newInvoiceDate = new DateTime(2019, 1, 1);
            var dateChange = newInvoiceDate - newInvoice.InvoiceDate.Value;
            var newDueDate = createdInvoice.DueDate?.AddDays(dateChange.Days);

            createdInvoice.InvoiceDate = newInvoiceDate;
            createdInvoice.DueDate = newDueDate;

            var updatedInvoice = connector.Update(createdInvoice);
            Assert.AreEqual("2019-01-01", updatedInvoice.InvoiceDate?.ToString(APIConstants.DateFormat));
            Assert.AreEqual("2019-01-31", updatedInvoice.DueDate?.ToString(APIConstants.DateFormat));

            connector.Cancel(createdInvoice.DocumentNumber);

            #region Delete arranged resources
            FortnoxClient.CustomerConnector.Delete(tmpCustomer.CustomerNumber);
            //FortnoxClient.ArticleConnector.Delete(tmpArticle.ArticleNumber);
            #endregion Delete arranged resources
        }

        [TestMethod]
        public void Test_Print()
        {
            #region Arrange
            var cc = FortnoxClient.CustomerConnector;
            var ac = FortnoxClient.ArticleConnector;
            var tmpCustomer = cc.Create(new Customer() { Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis" });
            var tmpArticle = ac.Create(new Article() { Description = "TmpArticle", Type = ArticleType.Stock, PurchasePrice = 100 });
            #endregion Arrange

            var connector = FortnoxClient.InvoiceConnector;

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

            var fileData = connector.Print(createdInvoice.DocumentNumber);
            MyAssert.IsPDF(fileData);

            connector.Cancel(createdInvoice.DocumentNumber);

            #region Delete arranged resources
            FortnoxClient.CustomerConnector.Delete(tmpCustomer.CustomerNumber);
            //FortnoxClient.ArticleConnector.Delete(tmpArticle.ArticleNumber);
            #endregion Delete arranged resources
        }

        [TestMethod]
        public void Test_Email()
        {
            #region Arrange
            var tmpCustomer = FortnoxClient.CustomerConnector.Create(new Customer() { Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis", Email = "richard.randak@softwerk.se" });
            var tmpArticle = FortnoxClient.ArticleConnector.Create(new Article() { Description = "TmpArticle", Type = ArticleType.Stock, PurchasePrice = 100 });
            #endregion Arrange

            var connector = FortnoxClient.InvoiceConnector;

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

            var emailedInvoice = connector.Email(createdInvoice.DocumentNumber);
            Assert.AreEqual(emailedInvoice.DocumentNumber, createdInvoice.DocumentNumber);

            connector.Cancel(createdInvoice.DocumentNumber);

            #region Delete arranged resources
            FortnoxClient.CustomerConnector.Delete(tmpCustomer.CustomerNumber);
            //FortnoxClient.ArticleConnector.Delete(tmpArticle.ArticleNumber);
            #endregion Delete arranged resources
        }

        [TestMethod]
        public void Test_Search()
        {
            var connector = FortnoxClient.InvoiceConnector;
            var searchSettings = new InvoiceSearch();
            searchSettings.FromDate = new DateTime(2020,10, 10);
            searchSettings.ToDate = new DateTime(2020, 10, 15);

            var result = connector.Find(searchSettings);

            Assert.IsTrue(result.Entities.Count > 0);
            foreach (var invoice in result.Entities)
            {
                Assert.IsTrue(invoice.InvoiceDate >= searchSettings.FromDate);
                Assert.IsTrue(invoice.InvoiceDate <= searchSettings.ToDate);
            }
        }

        [TestMethod]
        public void Test_Filter_By_AccountRange()
        {
            #region Arrange
            var tmpCustomer = FortnoxClient.CustomerConnector.Create(new Customer() { Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis" });
            var tmpArticle = FortnoxClient.ArticleConnector.Create(new Article() { Description = "TmpArticle", Type = ArticleType.Stock, PurchasePrice = 100 });
            #endregion Arrange

            var connector = FortnoxClient.InvoiceConnector;

            var invoice1 = new Invoice()
            {
                CustomerNumber = tmpCustomer.CustomerNumber,
                InvoiceDate = new DateTime(2019, 1, 20), //"2019-01-20",
                DueDate = new DateTime(2019, 2, 20), //"2019-02-20",
                InvoiceType = InvoiceType.CashInvoice,
                PaymentWay = PaymentWay.Cash,
                Comments = "TestInvoice",
                InvoiceRows = new List<InvoiceRow>()
                {
                    new InvoiceRow(){ AccountNumber = 1010, ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = 20, Price = 100},
                    new InvoiceRow(){ AccountNumber = 4000, ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = 15, Price = 100}
                }
            };

            var invoice2 = new Invoice()
            {
                CustomerNumber = tmpCustomer.CustomerNumber,
                InvoiceDate = new DateTime(2019, 1, 20), //"2019-01-20",
                DueDate = new DateTime(2019, 2, 20), //"2019-02-20",
                InvoiceType = InvoiceType.CashInvoice,
                PaymentWay = PaymentWay.Cash,
                Comments = "TestInvoice",
                InvoiceRows = new List<InvoiceRow>()
                {
                    new InvoiceRow(){ AccountNumber = 2010, ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = 20, Price = 100},
                    new InvoiceRow(){ AccountNumber = 4000, ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = 15, Price = 100}
                }
            };

            var invoice3 = new Invoice()
            {
                CustomerNumber = tmpCustomer.CustomerNumber,
                InvoiceDate = new DateTime(2019, 1, 20), //"2019-01-20",
                DueDate = new DateTime(2019, 2, 20), //"2019-02-20",
                InvoiceType = InvoiceType.CashInvoice,
                PaymentWay = PaymentWay.Cash,
                Comments = "TestInvoice",
                InvoiceRows = new List<InvoiceRow>()
                {
                    new InvoiceRow(){ AccountNumber = 3000, ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = 20, Price = 100},
                    new InvoiceRow(){ AccountNumber = 3000, ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = 15, Price = 100}
                }
            };

            invoice1 = connector.Create(invoice1);
            invoice2 = connector.Create(invoice2);
            invoice3 = connector.Create(invoice3);

            var filter = new InvoiceSearch()
            {
                CustomerNumber = tmpCustomer.CustomerNumber,
            };

            var invoices = connector.Find(filter);
            Assert.AreEqual(3, invoices.Entities.Count);

            filter.AccountNumberFrom = "1000";
            filter.AccountNumberTo = "1999";
            invoices = connector.Find(filter);
            Assert.AreEqual(1, invoices.Entities.Count);
            Assert.AreEqual(invoice1.DocumentNumber, invoices.Entities.First().DocumentNumber);

            filter.AccountNumberFrom = "2000";
            filter.AccountNumberTo = "2999";
            invoices = connector.Find(filter);
            Assert.AreEqual(1, invoices.Entities.Count);
            Assert.AreEqual(invoice2.DocumentNumber, invoices.Entities.First().DocumentNumber);

            filter.AccountNumberFrom = "3000";
            filter.AccountNumberTo = "3999";
            invoices = connector.Find(filter);
            Assert.AreEqual(1, invoices.Entities.Count);
            Assert.AreEqual(invoice3.DocumentNumber, invoices.Entities.First().DocumentNumber);

            filter.AccountNumberFrom = "4000";
            filter.AccountNumberTo = "4999";
            invoices = connector.Find(filter);
            Assert.AreEqual(2, invoices.Entities.Count);
        }

        [TestMethod]
        public void Test_InvoiceWithLabels()
        {
            #region Arrange
            var tmpCustomer = FortnoxClient.CustomerConnector.Create(new Customer() { Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis" });
            var tmpArticle = FortnoxClient.ArticleConnector.Create(new Article() { Description = "TmpArticle", Type = ArticleType.Stock, PurchasePrice = 100 });
            #endregion Arrange

            var labelConnector = FortnoxClient.LabelConnector;
            var label1 = labelConnector.Create(new Label() { Description = TestUtils.RandomString() });
            var label2 = labelConnector.Create(new Label() { Description = TestUtils.RandomString() });

            var connector = FortnoxClient.InvoiceConnector;

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
                    new InvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = 20, Price = 100},
                    new InvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = 15, Price = 100}
                },
                Labels = new List<LabelReference>()
                {
                    new LabelReference(label1.Id),
                    new LabelReference(label2.Id)
                }
            };

            var createdInvoice = connector.Create(invoice);
            Assert.AreEqual(2, createdInvoice.Labels.Count);

            //Clean
            connector.Cancel(createdInvoice.DocumentNumber);
            labelConnector.Delete(label1.Id);
            labelConnector.Delete(label2.Id);
        }

        [TestMethod]
        public void Test_Invoice_FilterByLabel()
        {
            #region Arrange
            var tmpCustomer = FortnoxClient.CustomerConnector.Create(new Customer() { Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis" });
            var tmpArticle = FortnoxClient.ArticleConnector.Create(new Article() { Description = "TmpArticle", Type = ArticleType.Stock, PurchasePrice = 100 });
            #endregion Arrange

            var labelConnector = FortnoxClient.LabelConnector;
            var label1 = labelConnector.Create(new Label() { Description = TestUtils.RandomString() });
            var label2 = labelConnector.Create(new Label() { Description = TestUtils.RandomString() });
            var label3 = labelConnector.Create(new Label() { Description = TestUtils.RandomString() });

            var connector = FortnoxClient.InvoiceConnector;

            var invoice1 = new Invoice()
            {
                CustomerNumber = tmpCustomer.CustomerNumber,
                InvoiceDate = new DateTime(2019, 1, 20), //"2019-01-20",
                DueDate = new DateTime(2019, 2, 20), //"2019-02-20",
                InvoiceType = InvoiceType.CashInvoice,
                PaymentWay = PaymentWay.Cash,
                Comments = "TestInvoice",
                InvoiceRows = new List<InvoiceRow>()
                {
                    new InvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = 20, Price = 100},
                    new InvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = 15, Price = 100}
                },
                Labels = new List<LabelReference>()
                {
                    new LabelReference(label1.Id),
                    new LabelReference(label2.Id),
                }
            };

            var invoice2 = new Invoice()
            {
                CustomerNumber = tmpCustomer.CustomerNumber,
                InvoiceDate = new DateTime(2019, 1, 20), //"2019-01-20",
                DueDate = new DateTime(2019, 2, 20), //"2019-02-20",
                InvoiceType = InvoiceType.CashInvoice,
                PaymentWay = PaymentWay.Cash,
                Comments = "TestInvoice",
                InvoiceRows = new List<InvoiceRow>()
                {
                    new InvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = 20, Price = 100},
                    new InvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = 15, Price = 100}
                },
                Labels = new List<LabelReference>()
                {
                    new LabelReference(label2.Id),
                    new LabelReference(label3.Id),
                }
            };

            invoice1 = connector.Create(invoice1);
            invoice2 = connector.Create(invoice2);

            var filter = new InvoiceSearch()
            {
                CustomerNumber = tmpCustomer.CustomerNumber
            };

            var invoices = connector.Find(filter);
            Assert.AreEqual(2, invoices.Entities.Count);

            filter.LabelReference = label1.Id;
            invoices = connector.Find(filter);
            Assert.AreEqual(1, invoices.Entities.Count);

            filter.LabelReference = label2.Id;
            invoices = connector.Find(filter);
            Assert.AreEqual(2, invoices.Entities.Count);

            filter.LabelReference = label3.Id;
            invoices = connector.Find(filter);
            Assert.AreEqual(1, invoices.Entities.Count);

            //Clean
            connector.Cancel(invoice1.DocumentNumber);
            connector.Cancel(invoice2.DocumentNumber);
            labelConnector.Delete(label1.Id);
            labelConnector.Delete(label2.Id);
        }

        /// <summary>
        /// Prerequisites: A custom VAT 1.23% was added in the fortnox settings
        /// </summary>
        [TestMethod]
        public void Test_Invoice_CustomVAT()
        {
            #region Arrange
            var tmpCustomer = FortnoxClient.CustomerConnector.Create(new Customer() { Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis" });
            var tmpArticle = FortnoxClient.ArticleConnector.Create(new Article() { Description = "TmpArticle", Type = ArticleType.Stock, PurchasePrice = 100 });
            #endregion Arrange

            var connector = FortnoxClient.InvoiceConnector;

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
                    new InvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = 10, Price = 100, VAT = 1.23m},
                    new InvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = 20, Price = 100, VAT = 1.23m},
                    new InvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = 15, Price = 100, VAT = 1.23m}
                }
            };

            var createdInvoice = connector.Create(newInvoice);
            Assert.AreEqual(3, createdInvoice.InvoiceRows.Count);
            Assert.AreEqual(1.23m, createdInvoice.InvoiceRows.First().VAT);

            #region Delete arranged resources
            FortnoxClient.InvoiceConnector.Cancel(createdInvoice.DocumentNumber);
            FortnoxClient.CustomerConnector.Delete(tmpCustomer.CustomerNumber);
            //FortnoxClient.ArticleConnector.Delete(tmpArticle.ArticleNumber);
            #endregion Delete arranged resources
        }
    }
}
