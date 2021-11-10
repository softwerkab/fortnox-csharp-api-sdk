using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fortnox.SDK;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Exceptions;
using Fortnox.SDK.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests;

[TestClass]
public class TaxReductionTests
{
    public FortnoxClient FortnoxClient = TestUtils.DefaultFortnoxClient;

    [TestMethod]
    public async Task Test_TaxReduction_CRUD()
    {
        #region Arrange
        var tmpCustomer = await FortnoxClient.CustomerConnector.CreateAsync(new Customer() { Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis" });
        var tmpArticle = await FortnoxClient.ArticleConnector.CreateAsync(new Article() { Description = "TmpArticle", Type = ArticleType.Service, PurchasePrice = 1000 });
        var tmpInvoice = await FortnoxClient.InvoiceConnector.CreateAsync(new Invoice()
        {
            CustomerNumber = tmpCustomer.CustomerNumber,
            InvoiceDate = new DateTime(2019, 1, 20), //"2019-01-20",
            DueDate = new DateTime(2019, 2, 20), //"2019-02-20",
            Comments = "TestInvoice",
            TaxReductionType = TaxReductionType.RUT,
            InvoiceRows = new List<InvoiceRow>()
            {
                new InvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = 10, HouseWorkHoursToReport = 10, Price = 1000, HouseWorkType = HouseworkType.Gardening, HouseWork = true},
                new InvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = 20, HouseWorkHoursToReport = 20, Price = 1000, HouseWorkType = HouseworkType.Gardening, HouseWork = true},
                new InvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = 15, HouseWorkHoursToReport = 15, Price = 1000, HouseWorkType = HouseworkType.Gardening, HouseWork = true}
            }
        });
        #endregion Arrange

        var connector = FortnoxClient.TaxReductionConnector;

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

        var createdTaxReduction = await connector.CreateAsync(newTaxReduction);
        Assert.AreEqual(100, createdTaxReduction.AskedAmount);

        #endregion CREATE

        #region UPDATE

        createdTaxReduction.AskedAmount = 200;

        var updatedTaxReduction = await connector.UpdateAsync(createdTaxReduction);
        Assert.AreEqual(200, updatedTaxReduction.AskedAmount);

        #endregion UPDATE

        #region READ / GET

        var retrievedTaxReduction = await connector.GetAsync(createdTaxReduction.Id);
        Assert.AreEqual(200, retrievedTaxReduction.AskedAmount);

        #endregion READ / GET

        #region DELETE
        //Can not delete tax redution if there is only one, therefore one more is created
        await connector.CreateAsync(new TaxReduction()
        {
            //TypeOfReduction = TypeOfReduction.RUT,
            CustomerName = "TmpCustomer",
            AskedAmount = 200,
            SocialSecurityNumber = "880515-2033",
            ReferenceNumber = tmpInvoice.DocumentNumber,
            ReferenceDocumentType = ReferenceDocumentType.Invoice
        });

        await connector.DeleteAsync(createdTaxReduction.Id);

        Assert.ThrowsException<FortnoxApiException>(
            () => connector.Get(createdTaxReduction.Id),
            "Entity still exists after Delete!");

        #endregion DELETE

        #region Delete arranged resources
        await FortnoxClient.InvoiceConnector.CancelAsync(tmpInvoice.DocumentNumber);
        await FortnoxClient.CustomerConnector.DeleteAsync(tmpCustomer.CustomerNumber);
        //FortnoxClient.ArticleConnector.Delete(tmpArticle.ArticleNumber);
        #endregion Delete arranged resources
    }

    [TestMethod]
    public async Task Test_Find()
    {
        #region Arrange
        var tmpCustomer = await FortnoxClient.CustomerConnector.CreateAsync(new Customer() { Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis" });
        var tmpArticle = await FortnoxClient.ArticleConnector.CreateAsync(new Article() { Description = "TmpArticle", Type = ArticleType.Service, PurchasePrice = 1000 });
        var tmpInvoice = await FortnoxClient.InvoiceConnector.CreateAsync(new Invoice()
        {
            CustomerNumber = tmpCustomer.CustomerNumber,
            InvoiceDate = new DateTime(2019, 1, 20), //"2019-01-20",
            DueDate = new DateTime(2019, 2, 20), //"2019-02-20",
            Comments = "TestInvoice",
            TaxReductionType = TaxReductionType.RUT,
            InvoiceRows = new List<InvoiceRow>()
            {
                new InvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = 10, HouseWorkHoursToReport = 10, Price = 1000, HouseWorkType = HouseworkType.Gardening, HouseWork = true},
                new InvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = 20, HouseWorkHoursToReport = 20, Price = 1000, HouseWorkType = HouseworkType.Gardening, HouseWork = true},
                new InvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = 15, HouseWorkHoursToReport = 15, Price = 1000, HouseWorkType = HouseworkType.Gardening, HouseWork = true}
            }
        });
        #endregion Arrange

        //var testKeyMark = TestUtils.RandomString();

        var connector = FortnoxClient.TaxReductionConnector;
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
            await connector.CreateAsync(newTaxReduction);
        }

        //Apply base test filter
        var searchSettings = new TaxReductionSearch();
        searchSettings.ReferenceNumber = tmpInvoice.DocumentNumber.ToString();
        var fullCollection = await connector.FindAsync(searchSettings);

        Assert.AreEqual(5, fullCollection.TotalResources);
        Assert.AreEqual(5, fullCollection.Entities.Count);
        Assert.AreEqual(1, fullCollection.TotalPages);

        //Apply Limit
        searchSettings.Limit = 2;
        var limitedCollection = await connector.FindAsync(searchSettings);

        Assert.AreEqual(5, limitedCollection.TotalResources);
        Assert.AreEqual(2, limitedCollection.Entities.Count);
        Assert.AreEqual(3, limitedCollection.TotalPages);


        #region Delete arranged resources
        await FortnoxClient.InvoiceConnector.CancelAsync(tmpInvoice.DocumentNumber);
        await FortnoxClient.CustomerConnector.DeleteAsync(tmpCustomer.CustomerNumber);
        //FortnoxClient.ArticleConnector.Delete(tmpArticle.ArticleNumber);
        #endregion Delete arranged resources
    }

    [TestMethod]
    public async Task Test_TaxReductionChanges_2021()
    {
        var tmpCustomer = await FortnoxClient.CustomerConnector.CreateAsync(new Customer()
        {
            Name = "TmpCustomer",
            CountryCode = "SE",
            City = "Testopolis"
        });

        var houseworkArticle = await FortnoxClient.ArticleConnector.CreateAsync(new Article()
        {
            Description = "TmpArticle",
            Type = ArticleType.Service,
            HouseworkType = HouseworkType.SolarCells,
            Housework = true
        });

        var houseworkInvoice = await FortnoxClient.InvoiceConnector.CreateAsync(new Invoice()
        {
            CustomerNumber = tmpCustomer.CustomerNumber,
            InvoiceDate = new DateTime(2021, 1, 20), //"2019-01-20",
            DueDate = new DateTime(2021, 2, 20), //"2019-02-20",
            Comments = "TestInvoice",
            TaxReductionType = TaxReductionType.Green,
            InvoiceRows = new List<InvoiceRow>()
            {
                new InvoiceRow(){ ArticleNumber = houseworkArticle.ArticleNumber, DeliveredQuantity = 10, HouseWorkHoursToReport = 10, Price = 1000 },
                new InvoiceRow(){ ArticleNumber = houseworkArticle.ArticleNumber, DeliveredQuantity = 20, HouseWorkHoursToReport = 20, Price = 1000 },
                new InvoiceRow(){ ArticleNumber = houseworkArticle.ArticleNumber, DeliveredQuantity = 15, HouseWorkHoursToReport = 15, Price = 1000 }
            }
        });

        Assert.AreEqual(true, houseworkInvoice.HouseWork);
        Assert.AreEqual(TaxReductionType.Green, houseworkInvoice.TaxReductionType);

        var createdTaxReduction = await FortnoxClient.TaxReductionConnector.CreateAsync(new TaxReduction()
        {
            CustomerName = "TmpCustomer",
            AskedAmount = 100,
            SocialSecurityNumber = "760412-0852",
            ReferenceNumber = houseworkInvoice.DocumentNumber,
            ReferenceDocumentType = ReferenceDocumentType.Invoice
        });

        Assert.AreEqual(100, createdTaxReduction.AskedAmount);

        //Check if invoice is still the same
        var retrievedInvoice = await FortnoxClient.InvoiceConnector.GetAsync(houseworkInvoice.DocumentNumber);
        Assert.AreEqual(true, retrievedInvoice.HouseWork);
        Assert.AreEqual(TaxReductionType.Green, retrievedInvoice.TaxReductionType);
    }
}