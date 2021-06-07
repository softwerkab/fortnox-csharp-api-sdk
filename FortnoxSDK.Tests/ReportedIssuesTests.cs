using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Fortnox.SDK;
using Fortnox.SDK.Connectors;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Exceptions;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests
{
    [TestClass]
    public class ReportedIssuesTests
    {
        public FortnoxClient FortnoxClient = TestUtils.DefaultFortnoxClient;
        
        [TestMethod]
        public void Test_Issue_44() // Origins from https://github.com/FortnoxAB/csharp-api-sdk/issues/44
        {
            //Arrange
            var customerConnector = FortnoxClient.CustomerConnector;
            var tmpCustomer = customerConnector.Create(new Customer() { Name = "TmpTestCustomer" });

            IInvoiceConnector connector = FortnoxClient.InvoiceConnector;

            var newInvoce = connector.Create(new Invoice()
            {
                InvoiceDate = new DateTime(2019,1,20), //"2019-01-20",
                DueDate = new DateTime(2019, 2, 20), //"2019-02-20",
                CustomerNumber = tmpCustomer.CustomerNumber,
                InvoiceType = InvoiceType.Invoice,
                InvoiceRows = new List<InvoiceRow>()
                { //Add Empty rows
                    new InvoiceRow(), //Empty Row
                    new InvoiceRow(), //Empty Row
                    new InvoiceRow() { AccountNumber = 0000},
                    new InvoiceRow(), //Empty Row
                }
            });
        }

        [TestMethod]
        public void Test_issue51_fixed() //Origins from https://github.com/FortnoxAB/csharp-api-sdk/issues/51
        {
            //Arrange
            /* Assuming several (at least 5) vouchers exists */

            //Act & Assert
            var connector = FortnoxClient.VoucherConnector;
            var searchSettings = new VoucherSearch();
            searchSettings.FinancialYearID = 1;

            searchSettings.Limit = 2;
            var voucherResult = connector.Find(searchSettings);

            searchSettings.Page = 2;
            var voucherResult2 = connector.Find(searchSettings);

            searchSettings.Page = 3;
            var voucherResult3 = connector.Find(searchSettings);
        }

        [TestMethod]
        public void Test_issue57_fixed() // Origins from https://github.com/FortnoxAB/csharp-api-sdk/issues/57
        {
            var connector = FortnoxClient.CustomerConnector;
            var specificCustomer = connector.Create(new Customer() { Name = "TestCustomer", OrganisationNumber = "123456789" });

            var searchSettings = new CustomerSearch();
            searchSettings.OrganisationNumber = "123456789";
            var customers = connector.Find(searchSettings).Entities;
            var customer = customers.FirstOrDefault(c => c.CustomerNumber == specificCustomer.CustomerNumber);
            Assert.IsNotNull(customer);

            connector.Delete(specificCustomer.CustomerNumber);
        }

        [TestMethod]
        public void Test_issue50_fixed() // Origins from https://github.com/FortnoxAB/csharp-api-sdk/issues/50
        {
            var connector = FortnoxClient.CustomerConnector;
            var newCustomer = connector.Create(new Customer() { Name = "TestCustomer", City = "Växjö", Type = CustomerType.Company });

            var updatedCustomer = connector.Update(new Customer() { CustomerNumber = newCustomer.CustomerNumber, City = "Stockholm" });
            Assert.AreEqual(CustomerType.Company, updatedCustomer.Type);

            connector.Delete(newCustomer.CustomerNumber);
        }

        [TestMethod]
        public void Test_issue61_fixed() // Origins from https://github.com/FortnoxAB/csharp-api-sdk/issues/61
        {
            var connector = FortnoxClient.ArticleConnector;
            var newArticle = connector.Create(new Article() { Description = "TestArticle", FreightCost = 10, OtherCost = 10, CostCalculationMethod = "MANUAL" });

            //NOTE: Server does not create the properties FreightCost, OtherCost and CostCalculationMethod
            //Assert.AreEqual("10", newArticle.FreightCost); //Always fails
            connector.Delete(newArticle.ArticleNumber);
        }

        [TestMethod]
        public void Test_issue73_async_non_blockable()
        {
            var connector = FortnoxClient.CustomerConnector;
            var searchSettings = new CustomerSearch();
            searchSettings.Limit = 2;

            var watch = new Stopwatch();
            watch.Start();

            var runningTasks = new List<Task<EntityCollection<CustomerSubset>>>();
            for (int i = 0;i<40;i++) 
                runningTasks.Add(connector.FindAsync(searchSettings));

            Console.WriteLine(@"Thread free after: "+watch.ElapsedMilliseconds);
            Assert.IsTrue(watch.ElapsedMilliseconds < 1000);

            watch.Start();
            foreach (var runningTask in runningTasks)
            {
                var result = runningTask.GetAwaiter().GetResult();
                Assert.IsNotNull(result);
            }
            watch.Stop();
            Console.WriteLine(@"Total time: "+watch.ElapsedMilliseconds);
        }

        [TestMethod]
        public void Test_issue84_fixed() //Origins from https://github.com/FortnoxAB/csharp-api-sdk/issues/84
        {
            //Arrange
            IArchiveConnector conn = FortnoxClient.ArchiveConnector;
            var testRootFolder = conn.GetFolder("TestArchive") ?? conn.CreateFolder("TestArchive");

            //Act
            IArchiveConnector connector = FortnoxClient.ArchiveConnector;

            var data = Resource.fortnox_image;
            var randomFileName = TestUtils.RandomString() + "åöä.txt";

            var fortnoxFile = connector.UploadFile(randomFileName, data, testRootFolder.Name);

            //Assert
            Assert.AreEqual(randomFileName, fortnoxFile.Name);

            //Clean
            connector.DeleteFile(fortnoxFile.Id);
        }

        [TestMethod]
        public void Test_Issue95_fixed() //Origins from https://github.com/FortnoxAB/csharp-api-sdk/issues/95
        {
            //Arrange
            //Creates a customer with ElectronicInvoice option for deliviery type
            var connector = FortnoxClient.CustomerConnector;
            var tmpCustomer = connector.Create(new Customer()
            {
                Name = "TestCustomer",
                DefaultDeliveryTypes = new DefaultDeliveryTypes()
                {
                    Invoice = DefaultDeliveryType.ElectronicInvoice
                }
            });

            //Act && Assert
            var customer = connector.Get(tmpCustomer.CustomerNumber);
            Assert.AreEqual(DefaultDeliveryType.ElectronicInvoice, customer.DefaultDeliveryTypes.Invoice);

            //Clean
            connector.Delete(tmpCustomer.CustomerNumber);
        }

        [TestMethod]
        public void Test_Issue96_fixed() // Origins from https://github.com/FortnoxAB/csharp-api-sdk/issues/96
        {
            #region Arrange
            var tmpSupplier = FortnoxClient.SupplierConnector.Create(new Supplier() { Name = "TmpSupplier" });
            var tmpArticle = FortnoxClient.ArticleConnector.Create(new Article() { Description = "TmpArticle", PurchasePrice = 100 });
            #endregion Arrange

            var connector = FortnoxClient.SupplierInvoiceConnector;

            var createdInvoice = connector.Create(new SupplierInvoice()
            {
                SupplierNumber = tmpSupplier.SupplierNumber,
                Comments = "InvoiceComments",
                InvoiceDate = new DateTime(2010, 1, 1),
                DueDate = new DateTime(2010, 2, 1),
                SalesType = SalesType.Stock,
                OCR = "123456789",
                Total = 5000,
                SupplierInvoiceRows = new List<SupplierInvoiceRow>()
                {
                    new SupplierInvoiceRow() {ArticleNumber = tmpArticle.ArticleNumber, Quantity = 10, Price = 100},
                    new SupplierInvoiceRow() {ArticleNumber = tmpArticle.ArticleNumber, Quantity = 20, Price = 100},
                    new SupplierInvoiceRow() {ArticleNumber = tmpArticle.ArticleNumber, Quantity = 20, Price = 100}
                }
            });
            Assert.AreEqual(false, createdInvoice.Cancelled);

            var retrievedInvoice = connector.Get(createdInvoice.GivenNumber);
            Assert.AreEqual(false, retrievedInvoice.Cancelled);

            var searchSettings = new SupplierInvoiceSearch();
            searchSettings.LastModified = DateTime.Today;
            var invoiceSubsets = connector.Find(searchSettings).Entities;
            foreach (var supplierInvoiceSubset in invoiceSubsets)
                Assert.IsNotNull(supplierInvoiceSubset.Cancelled);

            #region Delete arranged resources

            FortnoxClient.SupplierInvoiceConnector.Cancel(createdInvoice.GivenNumber);
            FortnoxClient.SupplierConnector.Delete(tmpSupplier.SupplierNumber);
            FortnoxClient.ArticleConnector.Delete(tmpArticle.ArticleNumber);

            #endregion Delete arranged resources
        }

        [TestMethod]
        public void Test_Issue98_fixed() // Origins from https://github.com/FortnoxAB/csharp-api-sdk/issues/98
        {
            #region Arrange

            var tmpCustomer = FortnoxClient.CustomerConnector.Create(new Customer()
                {Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis"});
            var tmpArticle = FortnoxClient.ArticleConnector.Create(new Article()
                {Description = "TmpArticle", PurchasePrice = 100});

            #endregion Arrange

            IInvoiceConnector connector = FortnoxClient.InvoiceConnector;

            var largeId = (long) 2 * int.MaxValue + TestUtils.RandomInt();

            var newInvoice = new Invoice()
            {
                DocumentNumber = largeId,
                CustomerNumber = tmpCustomer.CustomerNumber,
                InvoiceDate = new DateTime(2019, 1, 20),
                DueDate = new DateTime(2019, 2, 20),
                InvoiceType = InvoiceType.CashInvoice,
                PaymentWay = PaymentWay.Cash,
                Comments = "TestInvoice",
                InvoiceRows = new List<InvoiceRow>()
                {
                    new InvoiceRow() {ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = 10, Price = 100},
                    new InvoiceRow() {ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = 20, Price = 100},
                    new InvoiceRow() {ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = 15, Price = 100}
                }
            };

            var createdInvoice = connector.Create(newInvoice);
            Assert.AreEqual(largeId, createdInvoice.DocumentNumber);

            #region Delete arranged resources

            FortnoxClient.InvoiceConnector.Cancel(createdInvoice.DocumentNumber);
            FortnoxClient.CustomerConnector.Delete(tmpCustomer.CustomerNumber);
            //FortnoxClient.ArticleConnector.Delete(tmpArticle.ArticleNumber);

            #endregion Delete arranged resources
        }

        [TestMethod]
        public void Test_Issue99_v1_fixed() // Origins from https://github.com/FortnoxAB/csharp-api-sdk/issues/99
        {
            #region Arrange
            IArchiveConnector ac = FortnoxClient.ArchiveConnector;

            var data = Resource.fortnox_image;
            var randomFileName = TestUtils.RandomString() + ".txt";

            var fortnoxFile = ac.UploadFile(randomFileName, data, StaticFolders.SupplierInvoices);

            #endregion Arrange

            var archiveConnector = FortnoxClient.ArchiveConnector;
            var case1 = archiveConnector.DownloadFile(fortnoxFile.Id, IdType.Id); //no error
            Assert.ThrowsException<FortnoxApiException>(
                () => archiveConnector.DownloadFile(fortnoxFile.Id, IdType.FileId)); //has error
            Assert.ThrowsException<FortnoxApiException>(
                () => archiveConnector.DownloadFile(fortnoxFile.ArchiveFileId, IdType.Id)); //has error
            var case4 = archiveConnector.DownloadFile(fortnoxFile.ArchiveFileId, IdType.FileId); //no error

            Assert.IsNotNull(case1);
            Assert.IsNotNull(case4);

            var inboxConnector = FortnoxClient.InboxConnector;
            var case5 = inboxConnector.DownloadFile(fortnoxFile.Id, IdType.Id); //no error
            var case6 = inboxConnector.DownloadFile(fortnoxFile.Id, IdType.FileId); //no error, why?

            Assert.ThrowsException<FortnoxApiException>(
                () => inboxConnector.DownloadFile(fortnoxFile.ArchiveFileId, IdType.Id)); //has error
            var case8 = inboxConnector.DownloadFile(fortnoxFile.ArchiveFileId, IdType.FileId); //no error

            Assert.IsNotNull(case5);
            Assert.IsNotNull(case6);
            Assert.IsNotNull(case8);
            
            //Clean
            archiveConnector.DeleteFile(fortnoxFile.Id);
        }

        [TestMethod]
        public void Test_Issue99_v2_fixed() // Origins from https://github.com/FortnoxAB/csharp-api-sdk/issues/99
        {
            #region Arrange
            IArchiveConnector ac = FortnoxClient.InboxConnector;

            var data = Resource.fortnox_image;
            var randomFileName = TestUtils.RandomString() + ".txt";

            var fortnoxFile = ac.UploadFile(randomFileName, data, StaticFolders.SupplierInvoices);

            #endregion Arrange

            var archiveConnector = FortnoxClient.ArchiveConnector;
            var case1 = archiveConnector.DownloadFile(fortnoxFile.Id, IdType.Id); //no error
            Assert.ThrowsException<FortnoxApiException>(
                () => archiveConnector.DownloadFile(fortnoxFile.Id, IdType.FileId)); //has error
            Assert.ThrowsException<FortnoxApiException>(
                () => archiveConnector.DownloadFile(fortnoxFile.ArchiveFileId, IdType.Id)); //has error
            var case4 = archiveConnector.DownloadFile(fortnoxFile.ArchiveFileId, IdType.FileId); //no error

            Assert.IsNotNull(case1);
            Assert.IsNotNull(case4);

            var inboxConnector = FortnoxClient.InboxConnector;
            var case5 = inboxConnector.DownloadFile(fortnoxFile.Id, IdType.Id); //no error
            var case6 = inboxConnector.DownloadFile(fortnoxFile.Id, IdType.FileId); //no error, why?
            Assert.ThrowsException<FortnoxApiException>(
                () => inboxConnector.DownloadFile(fortnoxFile.ArchiveFileId, IdType.Id)); //has error
            var case8 = inboxConnector.DownloadFile(fortnoxFile.ArchiveFileId, IdType.FileId); //no error

            Assert.IsNotNull(case5);
            Assert.IsNotNull(case6);
            Assert.IsNotNull(case8);

            //Clean
            inboxConnector.DeleteFile(fortnoxFile.Id);
        }
    }
}
