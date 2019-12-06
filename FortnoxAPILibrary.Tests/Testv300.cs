using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;

namespace FortnoxAPILibrary.Tests
{
    [TestClass]
    public class Testv300
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
		[ExpectedException(typeof(Exception))]
		public void TestConnection_WithoutCredenials_Error()
		{
            //Arrange
            ConnectionCredentials.AccessToken = "";
            ConnectionCredentials.ClientSecret = "";

            //Act
            var cc = new CustomerConnector();
			cc.AccessToken = "";
			cc.ClientSecret = "";
			cc.Find();
		}

		[TestMethod]
		public void TestConnection_LocalCredentials_Set()
		{
            //Arrange
            ConnectionCredentials.AccessToken = "";
            ConnectionCredentials.ClientSecret = "";

            //Act
            var connector = new CustomerConnector();
			connector.AccessToken = TestCredentials.Access_Token;
            connector.ClientSecret = TestCredentials.Client_Secret;

            var customers = connector.Find();
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'."); 
            Assert.IsNotNull(customers);
        }

        [TestMethod]
        public void TestConnection_GlobalCredentials_Set()
        {
            //Arrange
            ConnectionCredentials.AccessToken = TestCredentials.Access_Token;
            ConnectionCredentials.ClientSecret = TestCredentials.Client_Secret;

            //Act
            var connector = new CustomerConnector();
            connector.AccessToken = "";
            connector.ClientSecret = "";

            var customers = connector.Find();
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'."); 
            Assert.IsNotNull(customers);
        }

		[TestMethod]
		public void TestConnection_MultipleCredentials_Set()
		{
			ConnectionCredentials.AccessToken = "123";
			ConnectionCredentials.ClientSecret = "456";

			var connector1 = new CustomerConnector();
			connector1.AccessToken = "A";
			connector1.ClientSecret = "B";

			var connector2 = new CustomerConnector();
			connector2.AccessToken = "AA";
			connector2.ClientSecret = "BB";

			Assert.IsTrue(connector1.AccessToken == "A" && connector2.AccessToken == "AA");
		}

		[TestMethod]
		public void TestCustomer()
		{
			var connector = new CustomerConnector();

            //Arrange
            connector.FilterBy = Filter.Customer.Inactive;
            var originalInactiveCustomerCount = int.Parse(connector.Find().TotalResources);

            //Act
            var newCustomer = connector.Create(new Customer(){ Name = "TestCustomer", Active = "true" });
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'.");

            var customers = connector.Find();
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'."); 
            Assert.AreEqual(originalInactiveCustomerCount, int.Parse(customers.TotalResources));

            newCustomer.Active = "false";
			newCustomer = connector.Update(newCustomer);
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'.");

            customers = connector.Find();
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'."); 
            Assert.AreEqual(originalInactiveCustomerCount + 1, int.Parse(customers.TotalResources));
            
            //Restore state
            connector.Delete(newCustomer.CustomerNumber);
            customers = connector.Find();
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'."); 
            Assert.AreEqual(originalInactiveCustomerCount, int.Parse(customers.TotalResources));
        }

		[TestMethod]
		public void TestArticle()
		{
            var connector = new ArticleConnector();

            //Arrange
            var originalArticleCount = int.Parse(connector.Find().TotalResources);

            //Act
            var newArticle = connector.Create(new Article { Active = "false", Description = "Test Article", PurchasePrice = "1999.99"});
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'.");

            var articles = connector.Find();
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'."); 
            Assert.AreEqual(originalArticleCount + 1, int.Parse(articles.TotalResources));

            connector.Update(new Article() {ArticleNumber = newArticle.ArticleNumber, Description = "Test Article - Updated"});
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'."); 
            Assert.AreEqual(originalArticleCount + 1, int.Parse(articles.TotalResources));

            var obtainedArticle = connector.Get(newArticle.ArticleNumber);
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'."); 
            Assert.AreEqual("Test Article - Updated", obtainedArticle.Description);
            Assert.AreEqual("1999.99", obtainedArticle.PurchasePrice);

            //Restore state
            connector.Delete(newArticle.ArticleNumber);
            articles = connector.Find();
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'."); 
            Assert.AreEqual(originalArticleCount, int.Parse(articles.TotalResources));
        }

		[TestMethod]
		public void TestFinicialYear()
		{
            /* Assumes a financial year exists (Financial year can not be deleted, therefore test should not create one */

            var connector = new FinancialYearConnector();
            var finicialYear = connector.Get(1);
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'."); 
        }

		[TestMethod]
		public void TestOffer()
		{
            var connector = new OfferConnector();

            //Arrange
            connector.FromDate = "2019-01-01";
            connector.ToDate = "2019-03-01";
            var originalOfferCount = int.Parse(connector.Find().TotalResources);

            var customerConnector = new CustomerConnector();
            var tmpCustomer = customerConnector.Create(new Customer() { Name = "CustomerForTestOrders" });
            Assert.IsFalse(customerConnector.HasError, $"Request failed due to '{customerConnector.Error?.Message}'.");

            //Act
            var offer1 = connector.Create(new Offer() { OfferDate = "2019-01-20", CustomerNumber = tmpCustomer.CustomerNumber });
            var offer2 = connector.Create(new Offer() { OfferDate = "2019-02-20", CustomerNumber = tmpCustomer.CustomerNumber });
            var offer3 = connector.Create(new Offer() { OfferDate = "2019-03-20", CustomerNumber = tmpCustomer.CustomerNumber });
            Assert.IsFalse(connector.HasError);

            var offers = connector.Find();
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'."); 
            Assert.AreEqual(originalOfferCount + 2, int.Parse(offers.TotalResources));

            //Restore
            connector.Cancel(offer1.DocumentNumber);
            connector.Cancel(offer2.DocumentNumber);
            connector.Cancel(offer3.DocumentNumber);
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'."); 

            customerConnector.Delete(tmpCustomer.CustomerNumber);
            Assert.IsFalse(customerConnector.HasError, $"Request failed due to '{customerConnector.Error?.Message}'.");
        }

        [TestMethod]
		public void TestOrder()
		{
            var connector = new OrderConnector();

            //Arrange
            connector.FromDate = "2019-01-01";
            connector.ToDate = "2019-03-01";
            var originalOrderCount = int.Parse(connector.Find().TotalResources);

            var customerConnector = new CustomerConnector();
            var tmpCustomer = customerConnector.Create(new Customer(){Name = "CustomerForTestOrders"});
            Assert.IsFalse(customerConnector.HasError, $"Request failed due to '{customerConnector.Error?.Message}'.");

            //Act
            var order1 = connector.Create(new Order() {OrderDate = "2019-01-20", CustomerNumber = tmpCustomer.CustomerNumber});
            var order2 = connector.Create(new Order() {OrderDate = "2019-02-20", CustomerNumber = tmpCustomer.CustomerNumber});
            var order3 = connector.Create(new Order() {OrderDate = "2019-03-20", CustomerNumber = tmpCustomer.CustomerNumber});
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'."); 

            var orders = connector.Find();
			Assert.IsFalse(connector.HasError);
			Assert.AreEqual(originalOrderCount + 2, int.Parse(orders.TotalResources));

            //Restore
            connector.Cancel(order1.DocumentNumber);
            connector.Cancel(order2.DocumentNumber);
            connector.Cancel(order3.DocumentNumber);
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'."); 

            customerConnector.Delete(tmpCustomer.CustomerNumber);
            Assert.IsFalse(customerConnector.HasError, $"Request failed due to '{customerConnector.Error?.Message}'.");
        }

        [TestMethod]
		public void TestInvoice()
		{
            //Arrange
            var customerConnector = new CustomerConnector();
            var tmpCustomer = customerConnector.Create(new Customer() { Name = "CustomerTestContractAccrural" });

            var connector = new InvoiceConnector();

            var newInvoce = connector.Create(new Invoice() {InvoiceDate = "2019-01-20", DueDate = "2019-02-20", CustomerNumber = tmpCustomer.CustomerNumber});
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'."); 

            var updatedInvoice = connector.Update(new Invoice(){ DocumentNumber = newInvoce.DocumentNumber, DueDate = "2019-03-20"});
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'."); 

            var invoice = connector.Get(newInvoce.DocumentNumber);
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'."); 
            Assert.AreEqual(invoice.InvoiceDate, "2019-01-20");
            Assert.AreEqual(invoice.DueDate, "2019-03-20");

            //Restore
            connector.Cancel(newInvoce.DocumentNumber);
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'."); 

            customerConnector.Delete(tmpCustomer.CustomerNumber);
            Assert.IsFalse(customerConnector.HasError, $"Request failed due to '{customerConnector.Error?.Message}'.");
        }

		[TestMethod]
		public void TestSupplierInvoice()
		{
            //Arrange
            var supplierConnector = new SupplierConnector();
            var tmpSupplier = supplierConnector.Create(new Supplier() { Name = "TestSupplier"});
            Assert.IsFalse(supplierConnector.HasError, $"Request failed due to '{supplierConnector.Error?.Message}'.");

            /* Assumes several currencies exists, at least SEK and EUR */

            //Act
            var connector = new SupplierInvoiceConnector();

            var newInvoice = connector.Create(new SupplierInvoice(){ Currency = "EUR", InvoiceDate = "2019-01-01", SupplierNumber = tmpSupplier.SupplierNumber});
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'."); 

            connector.Update(new SupplierInvoice() { Currency = "SEK", GivenNumber = newInvoice.GivenNumber});
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'."); 


            var invoice = connector.Get(newInvoice.GivenNumber);
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'."); 
            Assert.AreEqual("2019-01-01", invoice.InvoiceDate);
            Assert.AreEqual("SEK", invoice.Currency);


            //Restore
            connector.Cancel(newInvoice.GivenNumber);
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'."); 

            supplierConnector.Delete(tmpSupplier.SupplierNumber);
            Assert.IsFalse(supplierConnector.HasError, $"Request failed due to '{supplierConnector.Error?.Message}'.");

            /* For some reason, deleting currencies ends with Bad Request. Most likely, if they are used in the invoices */
        }

		[TestMethod]
		public void TestFolder()
		{
			var connector = new ArchiveConnector();

			var folder = new Folder();
			folder.Name = "f1";
			folder = connector.CreateFolder(folder);
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'."); 

            connector.DeleteFolder(folder.Id);
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'."); 
        }

		[TestMethod]
		public void TestFiles()
		{
            //Arrange
            var tmpPath = Path.GetTempFileName();

            //Act
            var connector = new ArchiveConnector();

            var uploadedFile = connector.UploadFileData(Resource.fortnox_image, "FortnoxImage.png", "");
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'."); 
            Assert.AreEqual("image/png", uploadedFile.ContentType);


            connector.DownloadFile(uploadedFile.Id, tmpPath);
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'."); 
            Assert.IsTrue(System.IO.File.Exists(tmpPath));

            var reuploadedFile = connector.UploadFile(tmpPath);
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'."); 

            //Restore State
            connector.DeleteFile(uploadedFile.Id);
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'."); 
            connector.DeleteFile(reuploadedFile.Id);
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'."); 

            System.IO.File.Delete(tmpPath);
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
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'."); 

            connector.Page = 2;
            var voucherResult2 = connector.Find();
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'."); 

            connector.Page = 3;
            var voucherResult3 = connector.Find();
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'."); 
        }

        [TestMethod]
        public void Test_TooManyRequests_fixed()
        {
            var connector = new VoucherConnector();

            for (int i = 0; i < 40; i++)
            {
                connector.Limit = 2;
                connector.Find();
                Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'."); 
            }
        }

        [Ignore] //Scenario is not yet fixed
        [TestMethod]
        public void Test_issue57_fixed() // Origins from https://github.com/FortnoxAB/csharp-api-sdk/issues/57
        {
            var connector = new CustomerConnector();
            var specificCustomer = connector.Create(new Customer() {Name = "TestCustomer", OrganisationNumber = "123456789"});
            Assert.IsFalse(connector.HasError);
            
            connector.OrganisationNumber = "123456789";
            var customers = connector.Find().CustomerSubset;
            var customer = customers.FirstOrDefault(c => c.CustomerNumber == specificCustomer.CustomerNumber);
            Assert.IsNotNull(customer);
            
            connector.Delete(specificCustomer.CustomerNumber);
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'."); 
        }

        [TestMethod]
        public void Test_issue50_fixed() // Origins from https://github.com/FortnoxAB/csharp-api-sdk/issues/50
        {
            var connector = new CustomerConnector();
            var newCustomer = connector.Create(new Customer() { Name = "TestCustomer", City = "Växjö", Type = CustomerConnector.Type.COMPANY });
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'."); 

            var updatedCustomer = connector.Update(new Customer() {CustomerNumber = newCustomer.CustomerNumber, City = "Stockholm"});
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'."); 
            Assert.AreEqual(CustomerConnector.Type.COMPANY, updatedCustomer.Type);

            connector.Delete(newCustomer.CustomerNumber);
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'."); 
        }

        [TestMethod]
        public void Test_issue61_fixed() // Origins from https://github.com/FortnoxAB/csharp-api-sdk/issues/61
        {
            var connector = new ArticleConnector();
            var newArticle = connector.Create(new Article() { Description = "TestArticle", FreightCost = "10", OtherCost = "10", CostCalculationMethod = "MANUAL"});
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'.");

            //NOTE: Server does not create the properties FreightCost, OtherCost and CostCalculationMethod
            //Assert.AreEqual("10", newArticle.FreightCost); //Always fails
            connector.Delete(newArticle.ArticleNumber);
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'.");
        }

        /*[TestMethod]
        public void Test_Customers_ReadOnly_Properties_Reset()
        {
            //Read-only properties are reset before sending to the server. Therefore, request should pass without error.
            var connector = new CustomerConnector();
            connector.FilterBy = Filter.Customer.Active;
            var tmpCustomer = connector.Create(new Customer
            {
                Name = "TestCustomer",
                Country = "Sweden" //ReadOnly
            });

            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'.");

            connector.Delete(tmpCustomer.CustomerNumber);
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'.");
        }*/

        [TestMethod]
        public void Test_Customers_FilterBy()
        {
            var connector = new CustomerConnector();
            connector.FilterBy = Filter.Customer.Active;

            var orig = int.Parse(connector.Find().TotalResources);

            var tmpCustomer1 = connector.Create(new Customer
            {
                Name = "TestCustomer",
                Active = "true"
            });
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'.");

            var tmpCustomer2 = connector.Create(new Customer
            {
                Name = "TestCustomer",
                Active = "false"
            });

            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'.");


            Assert.AreEqual(orig + 1, int.Parse(connector.Find().TotalResources));

            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'.");

            connector.Delete(tmpCustomer1.CustomerNumber);
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'.");
            connector.Delete(tmpCustomer2.CustomerNumber);
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'.");
        }

        [TestMethod]
        public void Test_Customers_SortBy_Nullable()
        {
            var connector = new CustomerConnector();
            connector.SortBy = Sort.By.Customer.Name;

            connector.SortBy = null;

            connector.Find();
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'.");
        }

        [Ignore] //Fails because the server does not accept empty XML element <InvoiceRow/> 
        [TestMethod]
        public void Test_Issue_44() // Origins from https://github.com/FortnoxAB/csharp-api-sdk/issues/44
        {
            //Arrange
            var customerConnector = new CustomerConnector();
            var tmpCustomer = customerConnector.Create(new Customer() { Name = "TmpTestCustomer" });

            var connector = new InvoiceConnector();

            var newInvoce = connector.Create(new Invoice()
            {
                InvoiceDate = "2019-01-20", 
                DueDate = "2019-02-20", 
                CustomerNumber = tmpCustomer.CustomerNumber,
                InvoiceType = InvoiceConnector.InvoiceType.INVOICE,
                InvoiceRows = new List<InvoiceRow>()
                { //Add Empty rows
                    new InvoiceRow(), //Empty Row
                    new InvoiceRow(), //Empty Row
                    new InvoiceRow() { AccountNumber = "0000"},
                    new InvoiceRow(), //Empty Row
                }
            });

            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'.");
        }
    }
}
