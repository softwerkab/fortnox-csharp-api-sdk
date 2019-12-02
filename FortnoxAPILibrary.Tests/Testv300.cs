using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FortnoxAPILibrary.Connectors;

namespace FortnoxAPILibrary.Tests
{
    [TestClass]
	public class Testv300
	{
        string at = "08f85b17-4f91-42e4-8f9b-6998205d0975";
        string cs = "4aiLcOuFKx";

        [TestMethod]
		[ExpectedException(typeof(Exception))]
		public void TestConnection1()
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
		public void TestConnection2()
		{
			var connector = new CustomerConnector();
			connector.AccessToken = at;
			connector.ClientSecret = cs;
            var customers = connector.Find();
			Assert.IsFalse(connector.HasError);
            Assert.IsNotNull(customers);

            ConnectionCredentials.AccessToken = at;
			ConnectionCredentials.ClientSecret = cs;
			connector.AccessToken = "";
			connector.ClientSecret = "";

            customers = connector.Find();
            Assert.IsFalse(connector.HasError);
            Assert.IsNotNull(customers);
        }

		[TestMethod]
		public void TestConnection3()
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
			connector.AccessToken = at;
			connector.ClientSecret = cs;

            //Arrange
            connector.FilterBy = Filter.Customer.Inactive;
            var originalInactiveCustomerCount = int.Parse(connector.Find().TotalResources);

            //Act
            var newCustomer = connector.Create(new Customer(){ Name = "TestCustomer", Active = "true" });

            var customers = connector.Find();
            Assert.IsFalse(connector.HasError);
            Assert.AreEqual(originalInactiveCustomerCount, int.Parse(customers.TotalResources));

            newCustomer.Active = "false";
			newCustomer = connector.Update(newCustomer);

            customers = connector.Find();
            Assert.IsFalse(connector.HasError);
            Assert.AreEqual(originalInactiveCustomerCount + 1, int.Parse(customers.TotalResources));
            
            //Restore state
            connector.Delete(newCustomer.CustomerNumber);
            customers = connector.Find();
            Assert.IsFalse(connector.HasError);
            Assert.AreEqual(originalInactiveCustomerCount, int.Parse(customers.TotalResources));
        }

		[TestMethod]
		public void TestArticle()
		{
            var connector = new ArticleConnector();
            connector.AccessToken = at;
            connector.ClientSecret = cs;

            //Arrange
            var originalArticleCount = int.Parse(connector.Find().TotalResources);

            //Act
            var newArticle = connector.Create(new Article { Active = "false", Description = "Test Article", PurchasePrice = "1999.99"});

            var articles = connector.Find();
            Assert.IsFalse(connector.HasError);
            Assert.AreEqual(originalArticleCount + 1, int.Parse(articles.TotalResources));

            connector.Update(new Article() {ArticleNumber = newArticle.ArticleNumber, Description = "Test Article - Updated"});
            Assert.IsFalse(connector.HasError);
            Assert.AreEqual(originalArticleCount + 1, int.Parse(articles.TotalResources));

            var obtainedArticle = connector.Get(newArticle.ArticleNumber);
            Assert.IsFalse(connector.HasError);
            Assert.AreEqual("Test Article - Updated", obtainedArticle.Description);
            Assert.AreEqual("1999.99", obtainedArticle.PurchasePrice);

            //Restore state
            connector.Delete(newArticle.ArticleNumber);
            articles = connector.Find();
            Assert.IsFalse(connector.HasError);
            Assert.AreEqual(originalArticleCount, int.Parse(articles.TotalResources));
        }

		[TestMethod]
		public void TestFinicialYear()
		{
            /* Assumes a financial year exists (Financial year can not be deleted, therefore test should not create one */

            var connector = new FinancialYearConnector();
			connector.AccessToken = at;
			connector.ClientSecret = cs;

            var finicialYear = connector.Get(1);
			Assert.IsFalse(connector.HasError);
        }

		[TestMethod]
		public void TestOffer()
		{
            var connector = new OfferConnector();
            connector.AccessToken = at;
            connector.ClientSecret = cs;

            //Arrange
            connector.FromDate = "2019-01-01";
            connector.ToDate = "2019-03-01";
            var originalOfferCount = int.Parse(connector.Find().TotalResources);

            var customerConnector = new CustomerConnector() { AccessToken = at, ClientSecret = cs };
            var tmpCustomer = customerConnector.Create(new Customer() { Name = "CustomerForTestOrders" });
            Assert.IsFalse(customerConnector.HasError);

            //Act
            var offer1 = connector.Create(new Offer() { OfferDate = "2019-01-20", CustomerNumber = tmpCustomer.CustomerNumber });
            var offer2 = connector.Create(new Offer() { OfferDate = "2019-02-20", CustomerNumber = tmpCustomer.CustomerNumber });
            var offer3 = connector.Create(new Offer() { OfferDate = "2019-03-20", CustomerNumber = tmpCustomer.CustomerNumber });
            Assert.IsFalse(connector.HasError);

            var offers = connector.Find();
            Assert.IsFalse(connector.HasError);
            Assert.AreEqual(originalOfferCount + 2, int.Parse(offers.TotalResources));

            //Restore
            connector.Cancel(offer1.DocumentNumber);
            connector.Cancel(offer2.DocumentNumber);
            connector.Cancel(offer3.DocumentNumber);
            Assert.IsFalse(connector.HasError);

            customerConnector.Delete(tmpCustomer.CustomerNumber);
            Assert.IsFalse(customerConnector.HasError);
        }

        [TestMethod]
		public void TestOrder()
		{
            var connector = new OrderConnector();
			connector.AccessToken = at;
			connector.ClientSecret = cs;

            //Arrange
            connector.FromDate = "2019-01-01";
            connector.ToDate = "2019-03-01";
            var originalOrderCount = int.Parse(connector.Find().TotalResources);

            var customerConnector = new CustomerConnector(){ AccessToken = at, ClientSecret = cs};
            var tmpCustomer = customerConnector.Create(new Customer(){Name = "CustomerForTestOrders"});
            Assert.IsFalse(customerConnector.HasError);

            //Act
            var order1 = connector.Create(new Order() {OrderDate = "2019-01-20", CustomerNumber = tmpCustomer.CustomerNumber});
            var order2 = connector.Create(new Order() {OrderDate = "2019-02-20", CustomerNumber = tmpCustomer.CustomerNumber});
            var order3 = connector.Create(new Order() {OrderDate = "2019-03-20", CustomerNumber = tmpCustomer.CustomerNumber});
            Assert.IsFalse(connector.HasError);

            var orders = connector.Find();
			Assert.IsFalse(connector.HasError);
			Assert.AreEqual(originalOrderCount + 2, int.Parse(orders.TotalResources));

            //Restore
            connector.Cancel(order1.DocumentNumber);
            connector.Cancel(order2.DocumentNumber);
            connector.Cancel(order3.DocumentNumber);
            Assert.IsFalse(connector.HasError);

            customerConnector.Delete(tmpCustomer.CustomerNumber);
            Assert.IsFalse(customerConnector.HasError);
        }

        [Ignore] //Can not create new contract accrual 'Angivet periodiseringskonto måste finnas som konteringsrad med en summa motsvarande periodiseringsbeloppet genom totalt antal.'
        [TestMethod]
		public void TestContractAccrural()
		{
			var connector = new ContractAccrualConnector();
			connector.AccessToken = at;
			connector.ClientSecret = cs;

            //Arrange
            var customerConnector = new CustomerConnector() { AccessToken = at, ClientSecret = cs };
            var tmpCustomer = customerConnector.Create(new Customer() {Name = "CustomerTestContractAccrural"});
            Assert.IsFalse(customerConnector.HasError);

            var articleConnector = new ArticleConnector() { AccessToken = at, ClientSecret = cs };
            var tmpArticle = articleConnector.Create(new Article(){ Description = "TestArticle", PurchasePrice = "1999.99" });
            Assert.IsFalse(articleConnector.HasError);

            var contractConnector = new ContractConnector() { AccessToken = at, ClientSecret = cs };
            var tmpContract = contractConnector.Create(new Contract()
            {
                CustomerNumber = tmpCustomer.CustomerNumber, 
                ContractDate = "2019-01-01", PeriodStart = "2019-05-05", 
                PeriodEnd = "2019-10-10", 
                InvoiceRows = new List<InvoiceRow>()
                {
                    new InvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = "100"}
                }
            });
            Assert.IsFalse(contractConnector.HasError);

            var accountConnector = new AccountConnector() { AccessToken = at, ClientSecret = cs };
            if (accountConnector.Get("1414") != null) 
                accountConnector.Delete("1414"); //Delete if exists
            var tmpAccount = accountConnector.Create(new Account() { Description = "TestAccount", Number = "1414"});
            Assert.IsFalse(accountConnector.HasError);

            //Act
            connector.AccessToken = at;
            connector.ClientSecret = cs;
            var rows = new List<InvoiceAccrualRow>()
            {
                new InvoiceAccrualRow() { Account = tmpAccount.Number, Credit = "0"},
                new InvoiceAccrualRow() { Account = tmpAccount.Number, Credit = "0"},
                new InvoiceAccrualRow() { Account = tmpAccount.Number, Credit = "0"}
            };

            var newContractAccrual = connector.Create(new ContractAccrual() {Description = "TestContractAccrual", Period = "Monthly", DocumentNumber = tmpContract.DocumentNumber, AccrualRows = rows});
            Assert.IsFalse(connector.HasError);

            var newRows = new List<InvoiceAccrualRow>()
            {
                new InvoiceAccrualRow() { Account = tmpAccount.Number, Credit = "300"},
                new InvoiceAccrualRow() { Account = tmpAccount.Number, Credit = "200"}
            };

            connector.Update(connector.Update(new ContractAccrual() {Period = "Yearly", DocumentNumber = newContractAccrual.DocumentNumber, AccrualRows = newRows}));
            Assert.IsFalse(connector.HasError);

            var contract = connector.Get(newContractAccrual.DocumentNumber);
            Assert.IsFalse(connector.HasError);
            Assert.AreEqual("TestContract", contract.Description);
            Assert.AreEqual("Yearly", contract.Period);
            Assert.AreEqual(2, contract.AccrualRows.Count);


            //Restore
            customerConnector.Delete(tmpCustomer.CustomerNumber);
            Assert.IsFalse(connector.HasError);

            connector.Delete(newContractAccrual.DocumentNumber);
			Assert.IsFalse(connector.HasError);

            articleConnector.Delete(tmpArticle.ArticleNumber);
            Assert.IsFalse(connector.HasError);

            accountConnector.Delete(tmpAccount.Number);
            Assert.IsFalse(accountConnector.HasError);
        }

		[TestMethod]
		public void TestInvoice()
		{
            //Arrange
            var customerConnector = new CustomerConnector() { AccessToken = at, ClientSecret = cs };
            var tmpCustomer = customerConnector.Create(new Customer() { Name = "CustomerTestContractAccrural" });

            var connector = new InvoiceConnector();
			connector.AccessToken = at;
			connector.ClientSecret = cs;

            var newInvoce = connector.Create(new Invoice() {InvoiceDate = "2019-01-20", DueDate = "2019-02-20", CustomerNumber = tmpCustomer.CustomerNumber});
            Assert.IsFalse(connector.HasError);

			var updatedInvoice = connector.Update(new Invoice(){ DocumentNumber = newInvoce.DocumentNumber, DueDate = "2019-03-20"});
			Assert.IsFalse(connector.HasError);

            var invoice = connector.Get(newInvoce.DocumentNumber);
            Assert.IsFalse(connector.HasError);
            Assert.AreEqual(invoice.InvoiceDate, "2019-01-20");
            Assert.AreEqual(invoice.DueDate, "2019-03-20");

            //Restore
            connector.Cancel(newInvoce.DocumentNumber);
            Assert.IsFalse(connector.HasError);

            customerConnector.Delete(tmpCustomer.CustomerNumber);
            Assert.IsFalse(customerConnector.HasError);
        }

		[TestMethod]
		public void TestSupplierInvoice()
		{
            //Arrange
            var supplierConnector = new SupplierConnector() { AccessToken = at, ClientSecret = cs };
            var tmpSupplier = supplierConnector.Create(new Supplier() { Name = "TestSupplier"});
            Assert.IsFalse(supplierConnector.HasError);

            /* Assumes several currencies exists, at least SEK and EUR */

            //Act
            var connector = new SupplierInvoiceConnector();
			connector.AccessToken = at;
			connector.ClientSecret = cs;

            var newInvoice = connector.Create(new SupplierInvoice(){ Currency = "EUR", InvoiceDate = "2019-01-01", SupplierNumber = tmpSupplier.SupplierNumber});
            Assert.IsFalse(connector.HasError);

            connector.Update(new SupplierInvoice() { Currency = "SEK", GivenNumber = newInvoice.GivenNumber});
            Assert.IsFalse(supplierConnector.HasError);


            var invoice = connector.Get(newInvoice.GivenNumber);
			Assert.IsFalse(connector.HasError);
            Assert.AreEqual("2019-01-01", invoice.InvoiceDate);
            Assert.AreEqual("SEK", invoice.Currency);


            //Restore
            connector.Cancel(newInvoice.GivenNumber);
            Assert.IsFalse(connector.HasError);

            supplierConnector.Delete(tmpSupplier.SupplierNumber);
            Assert.IsFalse(connector.HasError);

            /* For some reason, deleting currencies ends with Bad Request. Most likely, if they are used in the invoices */
        }

		[TestMethod]
		public void TestFolder()
		{
			var connector = new ArchiveConnector();
			connector.AccessToken = at;
			connector.ClientSecret = cs;

			var folder = new Folder();
			folder.Name = "f1";
			folder = connector.CreateFolder(folder);
			Assert.IsFalse(connector.HasError);

			connector.DeleteFolder(folder.Id);
			Assert.IsFalse(connector.HasError);
		}

		[TestMethod]
		public void TestFiles()
		{
            //Arrange
            var tmpPath = @"C:\temp\fortnoxImage.png";
            if (System.IO.File.Exists(tmpPath))
                System.IO.File.Delete(tmpPath);

            if (!Directory.Exists(@"C:\temp\"))
                Directory.CreateDirectory(@"C:\temp\");

            //Act
            var connector = new ArchiveConnector();
			connector.AccessToken = at;
			connector.ClientSecret = cs;

            var uploadedFile = connector.UploadFileData(Resource.fortnox_image, "FortnoxImage.png", "");
            Assert.IsFalse(connector.HasError, $"Error: '{connector.Error?.Message}'");
            Assert.AreEqual("image/png", uploadedFile.ContentType);


            connector.DownloadFile(uploadedFile.Id, tmpPath);
            Assert.IsFalse(connector.HasError);
            Assert.IsTrue(System.IO.File.Exists(tmpPath));

            var reuploadedFile = connector.UploadFile(tmpPath);
            Assert.IsFalse(connector.HasError);

            //Restore State
            connector.DeleteFile(uploadedFile.Id);
			Assert.IsFalse(connector.HasError);
            connector.DeleteFile(reuploadedFile.Id);
            Assert.IsFalse(connector.HasError);

            System.IO.File.Delete(tmpPath);
        }

        [TestMethod]
        public void Test_issue51_fixed() //Origins from https://github.com/FortnoxAB/csharp-api-sdk/issues/51
        {
            //Arrange
            /* Assuming several (at least 5) vouchers exists */ 

            //Act & Assert
            var connector = new VoucherConnector();
            connector.AccessToken = at;
            connector.ClientSecret = cs;

            connector.Limit = 2;
            var voucherResult = connector.Find();
            Assert.IsFalse(connector.HasError);

            connector.Page = 2;
            var voucherResult2 = connector.Find();
            Assert.IsFalse(connector.HasError);

            connector.Page = 3;
            var voucherResult3 = connector.Find();
            Assert.IsFalse(connector.HasError);
        }
    }
}
