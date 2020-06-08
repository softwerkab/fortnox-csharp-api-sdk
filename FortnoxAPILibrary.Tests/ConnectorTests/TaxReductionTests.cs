using System;
using System.Collections.Generic;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.Tests.ConnectorTests
{
    [TestClass]
    public class TaxReductionTests
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
        public void Test_TaxReduction_CRUD()
        {
            #region Arrange
            var tmpCustomer = new CustomerConnector().Create(new Customer() { Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis" });
            var tmpArticle = new ArticleConnector().Create(new Article() { Description = "TmpArticle", Type = ArticleType.Service, PurchasePrice = 1000 });
            var tmpInvoice = new InvoiceConnector().Create(new Invoice()
            {
                CustomerNumber = tmpCustomer.CustomerNumber,
                InvoiceDate = new DateTime(2019, 1, 20), //"2019-01-20",
                DueDate = new DateTime(2019, 2, 20), //"2019-02-20",
                Comments = "TestInvoice",
                InvoiceRows = new List<InvoiceRow>()
                {
                    new InvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = 10, HouseWorkHoursToReport = 10, Price = 1000, HouseWorkType = HouseworkType.Gardening, HouseWork = true},
                    new InvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = 20, HouseWorkHoursToReport = 20, Price = 1000, HouseWorkType = HouseworkType.Gardening, HouseWork = true},
                    new InvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = 15, HouseWorkHoursToReport = 15, Price = 1000, HouseWorkType = HouseworkType.Gardening, HouseWork = true}
                }
            });
            #endregion Arrange

            ITaxReductionConnector connector = new TaxReductionConnector();

            #region CREATE

            var newTaxReduction = new TaxReduction()
            {
                //TypeOfReduction = TypeOfReduction.RUT,
                CustomerName = "TmpCustomer",
                AskedAmount = 100,
                SocialSecurityNumber = "760412-0852",
                ReferenceNumber = tmpInvoice.DocumentNumber,
                ReferenceDocumentType = ReferenceDocumentType.Invoice
            };

            var createdTaxReduction = connector.Create(newTaxReduction);
            MyAssert.HasNoError(connector);
            Assert.AreEqual(100, createdTaxReduction.AskedAmount);

            #endregion CREATE

            #region UPDATE

            createdTaxReduction.AskedAmount = 200;

            var updatedTaxReduction = connector.Update(createdTaxReduction); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual(200, updatedTaxReduction.AskedAmount);

            #endregion UPDATE

            #region READ / GET

            var retrievedTaxReduction = connector.Get(createdTaxReduction.Id);
            MyAssert.HasNoError(connector);
            Assert.AreEqual(200, retrievedTaxReduction.AskedAmount);

            #endregion READ / GET

            #region DELETE
            //Can not delete tax redution if there is only one, therefore one more is created
            connector.Create(new TaxReduction()
            {
                //TypeOfReduction = TypeOfReduction.RUT,
                CustomerName = "TmpCustomer",
                AskedAmount = 200,
                SocialSecurityNumber = "880515-2033",
                ReferenceNumber = tmpInvoice.DocumentNumber,
                ReferenceDocumentType = ReferenceDocumentType.Invoice
            });

            connector.Delete(createdTaxReduction.Id);
            MyAssert.HasNoError(connector);

            retrievedTaxReduction = connector.Get(createdTaxReduction.Id);
            Assert.AreEqual(null, retrievedTaxReduction, "Entity still exists after Delete!");

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
            var tmpArticle = new ArticleConnector().Create(new Article() { Description = "TmpArticle", Type = ArticleType.Service, PurchasePrice = 1000 });
            var tmpInvoice = new InvoiceConnector().Create(new Invoice()
            {
                CustomerNumber = tmpCustomer.CustomerNumber,
                InvoiceDate = new DateTime(2019, 1, 20), //"2019-01-20",
                DueDate = new DateTime(2019, 2, 20), //"2019-02-20",
                Comments = "TestInvoice",
                InvoiceRows = new List<InvoiceRow>()
                {
                    new InvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = 10, HouseWorkHoursToReport = 10, Price = 1000, HouseWorkType = HouseworkType.Gardening, HouseWork = true},
                    new InvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = 20, HouseWorkHoursToReport = 20, Price = 1000, HouseWorkType = HouseworkType.Gardening, HouseWork = true},
                    new InvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = 15, HouseWorkHoursToReport = 15, Price = 1000, HouseWorkType = HouseworkType.Gardening, HouseWork = true}
                }
            });
            #endregion Arrange

            //var testKeyMark = TestUtils.RandomString();

            ITaxReductionConnector connector = new TaxReductionConnector();
            var newTaxReduction = new TaxReduction()
            {
                CustomerName = "TmpCustomer",
                AskedAmount = 200,
                ReferenceNumber = tmpInvoice.DocumentNumber,
                ReferenceDocumentType = ReferenceDocumentType.Invoice
            };

            //Add entries
            for (var i = 0; i < 5; i++)
            {
                newTaxReduction.SocialSecurityNumber = TestUtils.RandomPersonalNumber();
                connector.Create(newTaxReduction);
                MyAssert.HasNoError(connector);
            }

            //Apply base test filter
            connector.ReferenceNumber = tmpInvoice.DocumentNumber.ToString();
            var fullCollection = connector.Find();
            MyAssert.HasNoError(connector);

            Assert.AreEqual(5, fullCollection.TotalResources);
            Assert.AreEqual(5, fullCollection.Entities.Count);
            Assert.AreEqual(1, fullCollection.TotalPages);

            //Apply Limit
            connector.Limit = 2;
            var limitedCollection = connector.Find();
            MyAssert.HasNoError(connector);

            Assert.AreEqual(5, limitedCollection.TotalResources);
            Assert.AreEqual(2, limitedCollection.Entities.Count);
            Assert.AreEqual(3, limitedCollection.TotalPages);

            //Delete entries
            foreach (var entry in fullCollection.Entities)
            {
                connector.Delete(entry.Id);
            }

            #region Delete arranged resources
            new CustomerConnector().Delete(tmpCustomer.CustomerNumber);
            new ArticleConnector().Delete(tmpArticle.ArticleNumber);
            #endregion Delete arranged resources
        }
    }
}
