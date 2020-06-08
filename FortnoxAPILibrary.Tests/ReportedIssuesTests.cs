using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.Tests
{
    [TestClass]
    public class ReportedIssuesTests
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
        public void Test_Issue_44() // Origins from https://github.com/FortnoxAB/csharp-api-sdk/issues/44
        {
            //Arrange
            var customerConnector = new CustomerConnector();
            var tmpCustomer = customerConnector.Create(new Customer() { Name = "TmpTestCustomer" });

            IInvoiceConnector connector = new InvoiceConnector();

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

            MyAssert.HasNoError(connector);
        }

        [TestMethod]
        public void Test_issue51_fixed() //Origins from https://github.com/FortnoxAB/csharp-api-sdk/issues/51
        {
            //Arrange
            /* Assuming several (at least 5) vouchers exists */

            //Act & Assert
            var connector = new VoucherConnector();

            connector.Limit = 2;
            var voucherResult = connector.Find();
            MyAssert.HasNoError(connector);

            connector.Page = 2;
            var voucherResult2 = connector.Find();
            MyAssert.HasNoError(connector);

            connector.Page = 3;
            var voucherResult3 = connector.Find();
            MyAssert.HasNoError(connector);
        }

        [TestMethod]
        public void Test_TooManyRequests_fixed()
        {
            var connector = new VoucherConnector();
            connector.Limit = 2;

            var watch = new Stopwatch();
            watch.Start();
            for (int i = 0; i < 40; i++)
            {
                connector.Find();
                MyAssert.HasNoError(connector);
            }

            watch.Stop();
            Console.WriteLine(@"Total time: "+watch.ElapsedMilliseconds);
        }

        [Ignore] //Scenario is not yet fixed
        [TestMethod]
        public void Test_issue57_fixed() // Origins from https://github.com/FortnoxAB/csharp-api-sdk/issues/57
        {
            var connector = new CustomerConnector();
            var specificCustomer = connector.Create(new Customer() { Name = "TestCustomer", OrganisationNumber = "123456789" });
            Assert.IsFalse(connector.HasError);

            connector.OrganisationNumber = "123456789";
            var customers = connector.Find().Entities;
            var customer = customers.FirstOrDefault(c => c.CustomerNumber == specificCustomer.CustomerNumber);
            Assert.IsNotNull(customer);

            connector.Delete(specificCustomer.CustomerNumber);
            MyAssert.HasNoError(connector);
        }

        [TestMethod]
        public void Test_issue50_fixed() // Origins from https://github.com/FortnoxAB/csharp-api-sdk/issues/50
        {
            var connector = new CustomerConnector();
            var newCustomer = connector.Create(new Customer() { Name = "TestCustomer", City = "Växjö", Type = CustomerType.Company });
            MyAssert.HasNoError(connector);

            var updatedCustomer = connector.Update(new Customer() { CustomerNumber = newCustomer.CustomerNumber, City = "Stockholm" });
            MyAssert.HasNoError(connector);
            Assert.AreEqual(CustomerType.Company, updatedCustomer.Type);

            connector.Delete(newCustomer.CustomerNumber);
            MyAssert.HasNoError(connector);
        }

        [TestMethod]
        public void Test_issue61_fixed() // Origins from https://github.com/FortnoxAB/csharp-api-sdk/issues/61
        {
            var connector = new ArticleConnector();
            var newArticle = connector.Create(new Article() { Description = "TestArticle", FreightCost = 10, OtherCost = 10, CostCalculationMethod = "MANUAL" });
            MyAssert.HasNoError(connector);

            //NOTE: Server does not create the properties FreightCost, OtherCost and CostCalculationMethod
            //Assert.AreEqual("10", newArticle.FreightCost); //Always fails
            connector.Delete(newArticle.ArticleNumber);
            MyAssert.HasNoError(connector);
        }

        [TestMethod]
        public void Test_issue73_async_non_blockable()
        {
            var connector = new CustomerConnector();
            connector.Limit = 2;
            var watch = new Stopwatch();
            watch.Start();

            var runningTasks = new List<Task<EntityCollection<CustomerSubset>>>();
            for (int i = 0;i<40;i++) 
                runningTasks.Add(connector.FindAsync());

            Console.WriteLine(@"Thread free after: "+watch.ElapsedMilliseconds);
            Assert.IsTrue(watch.ElapsedMilliseconds < 1000);

            watch.Start();
            foreach (var runningTask in runningTasks)
            {
                var result = runningTask.Result;
                MyAssert.HasNoError(connector);
                Assert.IsNotNull(result);
            }
            watch.Stop();
            Console.WriteLine(@"Total time: "+watch.ElapsedMilliseconds);
        }

        [TestMethod]
        public void Test_issue84_fixed() //Origins from https://github.com/FortnoxAB/csharp-api-sdk/issues/84
        {
            //Arrange
            IArchiveConnector conn = new ArchiveConnector();
            var testRootFolder = conn.GetFolder("TestArchive") ?? conn.CreateFolder("TestArchive");

            //Act
            IArchiveConnector connector = new ArchiveConnector();

            var data = Resource.fortnox_image;
            var randomFileName = TestUtils.RandomString() + "åöä.txt";

            var fortnoxFile = connector.UploadFile(randomFileName, data, testRootFolder.Name);
            MyAssert.HasNoError(connector);

            //Assert
            Assert.AreEqual(randomFileName, fortnoxFile.Name);

            //Clean
            connector.DeleteFile(fortnoxFile.Id);
            MyAssert.HasNoError(connector);
        }
    }
}
