using System;
using System.Linq;
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
			var cc = new CustomerConnector();
            ConnectionCredentials.AccessToken = "";
            ConnectionCredentials.ClientSecret = "";
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
			var customer = connector.Get("0022");
			Assert.IsFalse(connector.HasError);
			Assert.IsTrue(customer.CustomerNumber == "0022");
			
			ConnectionCredentials.AccessToken = at;
			ConnectionCredentials.ClientSecret = cs;
			connector.AccessToken = "";
			connector.ClientSecret = "";

			customer = connector.Get("0022");
			Assert.IsFalse(connector.HasError);
			Assert.IsTrue(customer.CustomerNumber == "0022");
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

			var customer = connector.Get("0022");
			customer.GLN = "123";
			customer.GLNDelivery = "12345";
			customer.Active = "false";
			customer = connector.Update(customer);

			Assert.IsFalse(connector.HasError);
			Assert.IsTrue(customer.Active == "false");

			connector.FilterBy = Filter.Customer.Inactive;
			var customers = connector.Find();

			Assert.IsFalse(connector.HasError);
            Assert.IsTrue(customers.CustomerSubset.Any(c => c.CustomerNumber == "0022"));

			customer.Active = "true";
			connector.Update(customer);

			Assert.IsFalse(connector.HasError);
			Assert.IsTrue(customer.Active == "true");
            customers = connector.Find();
            Assert.IsFalse(customers.CustomerSubset.Any(c => c.CustomerNumber == "0022"));
		}

		[TestMethod]
		public void TestArticle()
		{
			var connector = new ArticleConnector();
			connector.AccessToken = at;
			connector.ClientSecret = cs;

			var article = connector.Get("1");
			article.Active = "false";
			article = connector.Update(article);

			Assert.IsFalse(connector.HasError);
			Assert.IsTrue(article.Active == "false");

			connector.FilterBy = Filter.Article.Inactive;
			var result = connector.Find();

			Assert.IsFalse(connector.HasError);
			Assert.IsTrue(result.TotalResources == "1");

			article.Active = "true";
			article = connector.Update(article);

			Assert.IsFalse(connector.HasError);
			Assert.IsTrue(article.Active == "true");
		}

		[TestMethod]
		public void TestFinicialYear()
		{
			var connector = new FinancialYearConnector();
			connector.AccessToken = at;
			connector.ClientSecret = cs;

			var finicialYear = connector.Get(1);
			Assert.IsFalse(connector.HasError);
			Assert.IsTrue(finicialYear.AccountingMethod == FinancialYearConnector.AccountingMethod.ACCRUAL);
		}

		[TestMethod]
		public void TestOffer()
		{
			var connector = new OfferConnector();
			connector.AccessToken = at;
			connector.ClientSecret = cs;

			connector.FromDate = "2017-01-01";
			connector.ToDate = "2017-01-30";
			var offers = connector.Find();
			Assert.IsFalse(connector.HasError);
			Assert.IsTrue(offers.TotalResources == "1");

			connector.FromDate = "2017-01-31";
			connector.ToDate = "2017-01-31";
			offers = connector.Find();
			Assert.IsFalse(connector.HasError);
			Assert.IsTrue(offers.TotalResources == "1");
		}

		[TestMethod]
		public void TestOrder()
		{
			var connector = new OrderConnector();
			connector.AccessToken = at;
			connector.ClientSecret = cs;

			connector.FromDate = "2017-01-01";
			connector.ToDate = "2017-04-03";
			var orders = connector.Find();
			Assert.IsFalse(connector.HasError);
			Assert.IsTrue(orders.TotalResources == "3");

			connector.FromDate = "2017-06-01";
			connector.ToDate = "2017-06-30";
			orders = connector.Find();
			Assert.IsFalse(connector.HasError);
			Assert.IsTrue(orders.TotalResources == "6");
		}

		[TestMethod]
		public void TestContractAccrural()
		{
			var connector = new ContractAccrualConnector();
			connector.AccessToken = at;
			connector.ClientSecret = cs;

			// test cost account
			var contract = connector.Get("3");
			Assert.IsFalse(connector.HasError);
			Assert.IsTrue(contract.CostAccount == "3990");

			contract.CostAccount = "3991";
			contract = connector.Update(contract);
			Assert.IsFalse(connector.HasError);
			Assert.IsTrue(contract.CostAccount == "3991");

			contract.CostAccount = "3990";
			contract = connector.Update(contract);
			Assert.IsFalse(connector.HasError);
			Assert.IsTrue(contract.CostAccount == "3990");

			// test rows
			var row = new InvoiceAccrualRow();
			row.Account = "2990";
			row.Debit = "100";
			contract.AccrualRows.Add(row);

			row = new InvoiceAccrualRow();
			row.Account = "3990";
			row.Credit = "100";
			contract.AccrualRows.Add(row);

			contract = connector.Update(contract);
			Assert.IsFalse(connector.HasError);
			Assert.IsTrue(contract.AccrualRows.Count == 4);

			contract.AccrualRows[2] = null;
			contract.AccrualRows[3] = null;

			contract = connector.Update(contract);
			Assert.IsFalse(connector.HasError);
			Assert.IsTrue(contract.AccrualRows.Count == 2);
		}

		[TestMethod]
		public void TestInvoice()
		{
			var connector = new InvoiceConnector();
			connector.AccessToken = at;
			connector.ClientSecret = cs;

			var invoice = connector.Get("988");
			invoice.PaymentWay = "CASH";
			invoice = connector.Update(invoice);
			Assert.IsFalse(connector.HasError);
			Assert.IsTrue(invoice.PaymentWay == "CASH");

			invoice.PaymentWay = "AA";
			invoice = connector.Update(invoice);
			Assert.IsFalse(connector.HasError);
			Assert.IsTrue(invoice.PaymentWay == "AA");
		}

		[TestMethod]
		public void TestSupplierInvoice()
		{
			var connector = new SupplierInvoiceConnector();
			connector.AccessToken = at;
			connector.ClientSecret = cs;

			var invoice = connector.Get("5");
			Assert.IsFalse(connector.HasError);
			Assert.IsTrue(invoice.AccountingMethod == "ACCRUAL");

			invoice.PaymentPending = "true";
			invoice.CostCenter = "101";
			invoice.YourReference = "ABC";
			invoice.OurReference = "DEF";
			invoice.Project = "1";			
			invoice = connector.Update(invoice);

			Assert.IsFalse(connector.HasError);
			Assert.IsTrue(invoice.PaymentPending == "true");
			Assert.IsTrue(invoice.CostCenter == "101");
			Assert.IsTrue(invoice.Project == "1");
			Assert.IsTrue(invoice.YourReference == "ABC");
			Assert.IsTrue(invoice.OurReference == "DEF");

			invoice.PaymentPending = "false";
			invoice.CostCenter = "100";
			invoice.Project = "2";
			invoice = connector.Update(invoice);

			Assert.IsFalse(connector.HasError);
			Assert.IsTrue(invoice.PaymentPending == "false");
			Assert.IsTrue(invoice.CostCenter == "100");
			Assert.IsTrue(invoice.Project == "2");
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

        [Ignore]
		[TestMethod]
		public void TestFiles()
		{
			var connector = new ArchiveConnector();
			connector.AccessToken = at;
			connector.ClientSecret = cs;

			connector.DownloadFile("537be280-fc52-4b91-9dab-427be15db4c5", @"C:\temp\abc.txt");
			Assert.IsFalse(connector.HasError);

			var file = new File();
			file.Id = "537be280-fc52-4b91-9dab-427be15db4c5";
			Assert.IsTrue(file.Data == null);
			connector.DownloadFileData(file);
			Assert.IsFalse(connector.HasError);
			Assert.IsTrue(file.Data != null);

			file = connector.UploadFileData(file.Data, "abc545.txt");
			Assert.IsFalse(connector.HasError);
			Assert.IsTrue(file.ContentType == "text/plain");
			Assert.IsTrue(file.Data != null);			

			connector.DeleteFile(file.Id);
			Assert.IsFalse(connector.HasError);
		}
	}
}
