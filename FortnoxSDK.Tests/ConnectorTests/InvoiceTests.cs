using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task Test_Invoice_CRUD()
        {
            #region Arrange
            var tmpCustomer = await FortnoxClient.CustomerConnector.CreateAsync(new Customer() { Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis" });
            var tmpArticle = await FortnoxClient.ArticleConnector.CreateAsync(new Article() { Description = "TmpArticle", Type = ArticleType.Stock, PurchasePrice = 100 });
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

            var createdInvoice = await connector.CreateAsync(newInvoice);
            Assert.AreEqual("TestInvoice", createdInvoice.Comments);
            Assert.AreEqual("TmpCustomer", createdInvoice.CustomerName);
            Assert.AreEqual(3, createdInvoice.InvoiceRows.Count);

            #endregion CREATE

            #region UPDATE

            createdInvoice.Comments = "UpdatedInvoice";

            var updatedInvoice = await connector.UpdateAsync(createdInvoice);
            Assert.AreEqual("UpdatedInvoice", updatedInvoice.Comments);
            Assert.AreEqual(3, updatedInvoice.InvoiceRows.Count);

            #endregion UPDATE

            #region READ / GET

            var retrievedInvoice = await connector.GetAsync(createdInvoice.DocumentNumber);
            Assert.AreEqual("UpdatedInvoice", retrievedInvoice.Comments);
            Assert.AreEqual(3, retrievedInvoice.InvoiceRows.Count);

            #endregion READ / GET

            #region DELETE
            //Not available, Cancel instead
            await connector.CancelAsync(createdInvoice.DocumentNumber);

            var cancelledInvoice = await connector.GetAsync(createdInvoice.DocumentNumber);
            Assert.AreEqual(true, cancelledInvoice.Cancelled);
            #endregion DELETE

            #region Delete arranged resources
            await FortnoxClient.CustomerConnector.DeleteAsync(tmpCustomer.CustomerNumber);
            //FortnoxClient.ArticleConnector.Delete(tmpArticle.ArticleNumber);
            #endregion Delete arranged resources
        }

        [TestMethod]
        public async Task Test_Find()
        {
            #region Arrange
            var tmpCustomer = await FortnoxClient.CustomerConnector.CreateAsync(new Customer() { Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis" });
            var tmpArticle = await FortnoxClient.ArticleConnector.CreateAsync(new Article() { Description = "TmpArticle", Type = ArticleType.Stock, PurchasePrice = 100 });
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
                await connector.CreateAsync(newInvoice);
            }

            //Apply base test filter
            var searchSettings = new InvoiceSearch();
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
            foreach (var invoice in fullCollection.Entities)
                await connector.CancelAsync(invoice.DocumentNumber);

            #region Delete arranged resources
            await FortnoxClient.CustomerConnector.DeleteAsync(tmpCustomer.CustomerNumber);
            //FortnoxClient.ArticleConnector.Delete(tmpArticle.ArticleNumber);
            #endregion Delete arranged resources
        }

        [TestMethod]
        public async Task Test_DueDate()
        {
            #region Arrange
            var tmpCustomer = await FortnoxClient.CustomerConnector.CreateAsync(new Customer() { Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis" });
            var tmpArticle = await FortnoxClient.ArticleConnector.CreateAsync(new Article() { Description = "TmpArticle", Type = ArticleType.Stock, PurchasePrice = 100 });
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

            var createdInvoice = await connector.CreateAsync(newInvoice);
            Assert.AreEqual("2019-01-20", createdInvoice.InvoiceDate?.ToString(APIConstants.DateFormat));
            Assert.AreEqual("2019-02-19", createdInvoice.DueDate?.ToString(APIConstants.DateFormat));

            var newInvoiceDate = new DateTime(2019, 1, 1);
            var dateChange = newInvoiceDate - newInvoice.InvoiceDate.Value;
            var newDueDate = createdInvoice.DueDate?.AddDays(dateChange.Days);

            createdInvoice.InvoiceDate = newInvoiceDate;
            createdInvoice.DueDate = newDueDate;

            var updatedInvoice = await connector.UpdateAsync(createdInvoice);
            Assert.AreEqual("2019-01-01", updatedInvoice.InvoiceDate?.ToString(APIConstants.DateFormat));
            Assert.AreEqual("2019-01-31", updatedInvoice.DueDate?.ToString(APIConstants.DateFormat));

            await connector.CancelAsync(createdInvoice.DocumentNumber);

            #region Delete arranged resources
            await FortnoxClient.CustomerConnector.DeleteAsync(tmpCustomer.CustomerNumber);
            //FortnoxClient.ArticleConnector.Delete(tmpArticle.ArticleNumber);
            #endregion Delete arranged resources
        }

        [TestMethod]
        public async Task Test_Print()
        {
            #region Arrange
            var cc = FortnoxClient.CustomerConnector;
            var ac = FortnoxClient.ArticleConnector;
            var tmpCustomer = await cc.CreateAsync(new Customer() { Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis" });
            var tmpArticle = await ac.CreateAsync(new Article() { Description = "TmpArticle", Type = ArticleType.Stock, PurchasePrice = 100 });
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

            var createdInvoice = await connector.CreateAsync(newInvoice);

            var fileData = await connector.PrintAsync(createdInvoice.DocumentNumber);
            MyAssert.IsPDF(fileData);

            await connector.CancelAsync(createdInvoice.DocumentNumber);

            #region Delete arranged resources
            await FortnoxClient.CustomerConnector.DeleteAsync(tmpCustomer.CustomerNumber);
            //FortnoxClient.ArticleConnector.Delete(tmpArticle.ArticleNumber);
            #endregion Delete arranged resources
        }

        [TestMethod]
        public async Task Test_Email()
        {
            #region Arrange
            var tmpCustomer = await FortnoxClient.CustomerConnector.CreateAsync(new Customer() { Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis", Email = "richard.randak@softwerk.se" });
            var tmpArticle = await FortnoxClient.ArticleConnector.CreateAsync(new Article() { Description = "TmpArticle", Type = ArticleType.Stock, PurchasePrice = 100 });
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

            var createdInvoice = await connector.CreateAsync(newInvoice);

            var emailedInvoice = await connector.EmailAsync(createdInvoice.DocumentNumber);
            Assert.AreEqual(emailedInvoice.DocumentNumber, createdInvoice.DocumentNumber);

            await connector.CancelAsync(createdInvoice.DocumentNumber);

            #region Delete arranged resources
            await FortnoxClient.CustomerConnector.DeleteAsync(tmpCustomer.CustomerNumber);
            //FortnoxClient.ArticleConnector.Delete(tmpArticle.ArticleNumber);
            #endregion Delete arranged resources
        }

        [TestMethod]
        public async Task Test_Search()
        {
            var connector = FortnoxClient.InvoiceConnector;
            var searchSettings = new InvoiceSearch();
            searchSettings.FromDate = new DateTime(2020, 10, 10);
            searchSettings.ToDate = new DateTime(2020, 10, 15);

            var result = await connector.FindAsync(searchSettings);

            Assert.IsTrue(result.Entities.Count > 0);
            foreach (var invoice in result.Entities)
            {
                Assert.IsTrue(invoice.InvoiceDate >= searchSettings.FromDate);
                Assert.IsTrue(invoice.InvoiceDate <= searchSettings.ToDate);
            }
        }

        [TestMethod]
        public async Task Test_Filter_By_AccountRange()
        {
            #region Arrange
            var tmpCustomer = await FortnoxClient.CustomerConnector.CreateAsync(new Customer() { Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis" });
            var tmpArticle = await FortnoxClient.ArticleConnector.CreateAsync(new Article() { Description = "TmpArticle", Type = ArticleType.Stock, PurchasePrice = 100 });
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

            invoice1 = await connector.CreateAsync(invoice1);
            invoice2 = await connector.CreateAsync(invoice2);
            invoice3 = await connector.CreateAsync(invoice3);

            var filter = new InvoiceSearch()
            {
                CustomerNumber = tmpCustomer.CustomerNumber,
            };

            var invoices = await connector.FindAsync(filter);
            Assert.AreEqual(3, invoices.Entities.Count);

            filter.AccountNumberFrom = "1000";
            filter.AccountNumberTo = "1999";
            invoices = await connector.FindAsync(filter);
            Assert.AreEqual(1, invoices.Entities.Count);
            Assert.AreEqual(invoice1.DocumentNumber, invoices.Entities.First().DocumentNumber);

            filter.AccountNumberFrom = "2000";
            filter.AccountNumberTo = "2999";
            invoices = await connector.FindAsync(filter);
            Assert.AreEqual(1, invoices.Entities.Count);
            Assert.AreEqual(invoice2.DocumentNumber, invoices.Entities.First().DocumentNumber);

            filter.AccountNumberFrom = "3000";
            filter.AccountNumberTo = "3999";
            invoices = await connector.FindAsync(filter);
            Assert.AreEqual(1, invoices.Entities.Count);
            Assert.AreEqual(invoice3.DocumentNumber, invoices.Entities.First().DocumentNumber);

            filter.AccountNumberFrom = "4000";
            filter.AccountNumberTo = "4999";
            invoices = await connector.FindAsync(filter);
            Assert.AreEqual(2, invoices.Entities.Count);
        }

        [TestMethod]
        public async Task Test_InvoiceWithLabels()
        {
            #region Arrange
            var tmpCustomer = await FortnoxClient.CustomerConnector.CreateAsync(new Customer() { Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis" });
            var tmpArticle = await FortnoxClient.ArticleConnector.CreateAsync(new Article() { Description = "TmpArticle", Type = ArticleType.Stock, PurchasePrice = 100 });
            #endregion Arrange

            var labelConnector = FortnoxClient.LabelConnector;
            var label1 = await labelConnector.CreateAsync(new Label() { Description = TestUtils.RandomString() });
            var label2 = await labelConnector.CreateAsync(new Label() { Description = TestUtils.RandomString() });

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

            var createdInvoice = await connector.CreateAsync(invoice);
            Assert.AreEqual(2, createdInvoice.Labels.Count);

            //Clean
            await connector.CancelAsync(createdInvoice.DocumentNumber);
            await labelConnector.DeleteAsync(label1.Id);
            await labelConnector.DeleteAsync(label2.Id);
        }

        [TestMethod]
        public async Task Test_Invoice_FilterByLabel()
        {
            #region Arrange
            var tmpCustomer = await FortnoxClient.CustomerConnector.CreateAsync(new Customer() { Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis" });
            var tmpArticle = await FortnoxClient.ArticleConnector.CreateAsync(new Article() { Description = "TmpArticle", Type = ArticleType.Stock, PurchasePrice = 100 });
            #endregion Arrange

            var labelConnector = FortnoxClient.LabelConnector;
            var label1 = await labelConnector.CreateAsync(new Label() { Description = TestUtils.RandomString() });
            var label2 = await labelConnector.CreateAsync(new Label() { Description = TestUtils.RandomString() });
            var label3 = await labelConnector.CreateAsync(new Label() { Description = TestUtils.RandomString() });

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

            invoice1 = await connector.CreateAsync(invoice1);
            invoice2 = await connector.CreateAsync(invoice2);

            var filter = new InvoiceSearch()
            {
                CustomerNumber = tmpCustomer.CustomerNumber
            };

            var invoices = await connector.FindAsync(filter);
            Assert.AreEqual(2, invoices.Entities.Count);

            filter.LabelReference = label1.Id;
            invoices = await connector.FindAsync(filter);
            Assert.AreEqual(1, invoices.Entities.Count);

            filter.LabelReference = label2.Id;
            invoices = await connector.FindAsync(filter);
            Assert.AreEqual(2, invoices.Entities.Count);

            filter.LabelReference = label3.Id;
            invoices = await connector.FindAsync(filter);
            Assert.AreEqual(1, invoices.Entities.Count);

            //Clean
            await connector.CancelAsync(invoice1.DocumentNumber);
            await connector.CancelAsync(invoice2.DocumentNumber);
            await labelConnector.DeleteAsync(label1.Id);
            await labelConnector.DeleteAsync(label2.Id);
        }

        /// <summary>
        /// Prerequisites: A custom VAT 1.23% was added in the fortnox settings
        /// </summary>
        [TestMethod]
        public async Task Test_Invoice_CustomVAT()
        {
            #region Arrange
            var tmpCustomer = await FortnoxClient.CustomerConnector.CreateAsync(new Customer() { Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis" });
            var tmpArticle = await FortnoxClient.ArticleConnector.CreateAsync(new Article() { Description = "TmpArticle", Type = ArticleType.Stock, PurchasePrice = 100 });
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

            var createdInvoice = await connector.CreateAsync(newInvoice);
            Assert.AreEqual(3, createdInvoice.InvoiceRows.Count);
            Assert.AreEqual(1.23m, createdInvoice.InvoiceRows.First().VAT);

            #region Delete arranged resources
            await FortnoxClient.InvoiceConnector.CancelAsync(createdInvoice.DocumentNumber);
            await FortnoxClient.CustomerConnector.DeleteAsync(tmpCustomer.CustomerNumber);
            //FortnoxClient.ArticleConnector.Delete(tmpArticle.ArticleNumber);
            #endregion Delete arranged resources
        }

        [TestMethod]
        public async Task Test_Invoice_Rows_Update()
        {
            #region Arrange
            var tmpCustomer = await FortnoxClient.CustomerConnector.CreateAsync(new Customer() { Name = "TmpCustomer" });
            var tmpArticle = await FortnoxClient.ArticleConnector.CreateAsync(new Article() { Description = "TmpArticle" });
            #endregion Arrange

            var connector = FortnoxClient.InvoiceConnector;

            var newInvoice = new Invoice()
            {
                CustomerNumber = tmpCustomer.CustomerNumber,
                InvoiceDate = new DateTime(2019, 1, 20),
                Comments = "TestInvoice",
                InvoiceRows = new List<InvoiceRow>()
                {
                    new InvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, Description = "Row1"},
                    new InvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, Description = "Row2"},
                    new InvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, Description = "Row3"}
                }
            };

            var createdInvoice = await connector.CreateAsync(newInvoice);
            Assert.AreEqual(3, createdInvoice.InvoiceRows.Count);

            var updatedInvoiceData = new Invoice()
            {
                DocumentNumber = createdInvoice.DocumentNumber,
                InvoiceRows = new List<InvoiceRow>()
                {
                    new InvoiceRow() { RowId = createdInvoice.InvoiceRows[0].RowId, Description = "Updated"}, // Update existing row
                    new InvoiceRow() { ArticleNumber = tmpArticle.ArticleNumber, Description = "New1" }, // create new row
                    new InvoiceRow() { RowId = createdInvoice.InvoiceRows[1].RowId}, // Keep unchanged
                    new InvoiceRow() { RowId = createdInvoice.InvoiceRows[2].RowId}, // Keep unchanged
                    new InvoiceRow() { ArticleNumber = tmpArticle.ArticleNumber, Description = "New2" } // create new row
                }
            };

            var updatedInvoice = await connector.UpdateAsync(updatedInvoiceData);
            Assert.AreEqual(3 + 2, updatedInvoice.InvoiceRows.Count);
            Assert.AreEqual("Updated", updatedInvoice.InvoiceRows[0].Description);
            Assert.AreEqual("New1", updatedInvoice.InvoiceRows[1].Description);
            Assert.AreEqual("Row2", updatedInvoice.InvoiceRows[2].Description);
            Assert.AreEqual("Row3", updatedInvoice.InvoiceRows[3].Description);
            Assert.AreEqual("New2", updatedInvoice.InvoiceRows[4].Description);

            #region Clean up
            await connector.CancelAsync(createdInvoice.DocumentNumber);
            await FortnoxClient.CustomerConnector.DeleteAsync(tmpCustomer.CustomerNumber);
            //FortnoxClient.ArticleConnector.Delete(tmpArticle.ArticleNumber);
            #endregion Clean up
        }
    }
}
