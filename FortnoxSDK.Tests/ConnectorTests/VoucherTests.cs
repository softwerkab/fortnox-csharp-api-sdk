using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Fortnox.SDK;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Exceptions;
using Fortnox.SDK.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests;

[TestClass]
public class VoucherTests
{
    public FortnoxClient FortnoxClient = TestUtils.DefaultFortnoxClient;

    [TestMethod]
    public async Task Test_Voucher_CRUD()
    {
        #region Arrange
        #endregion Arrange

        var connector = FortnoxClient.VoucherConnector;

        #region CREATE
        var newVoucher = new Voucher()
        {
            Description = "TestVoucher",
            Comments = "Some comments",
            VoucherSeries = "A", //predefined series
            TransactionDate = new DateTime(2020, 1, 1),
            VoucherRows = new List<VoucherRow>()
            {
                new VoucherRow(){ Account = 1930, Debit = 1500, Credit = 0 },
                new VoucherRow(){ Account = 1910, Debit = 0, Credit = 1500 }
            }
        };

        var createdVoucher = await connector.CreateAsync(newVoucher);
        Assert.AreEqual("TestVoucher", createdVoucher.Description);

        #endregion CREATE

        #region UPDATE
        //Not supported
        #endregion UPDATE

        #region READ / GET
        var retrievedVoucher = await connector.GetAsync(createdVoucher.VoucherNumber, createdVoucher.VoucherSeries, createdVoucher.Year);
        Assert.AreEqual("TestVoucher", retrievedVoucher.Description);

        #endregion READ / GET

        #region DELETE
        await connector.DeleteAsync(createdVoucher.VoucherNumber, createdVoucher.VoucherSeries, createdVoucher.Year);
        await Assert.ThrowsExceptionAsync<FortnoxApiException>(
            async () => await connector.GetAsync(createdVoucher.VoucherNumber, createdVoucher.VoucherSeries, createdVoucher.Year),
            "Entity still exists after Delete!");
        #endregion DELETE

        #region Delete arranged resources
        //Add code to delete temporary resources
        #endregion Delete arranged resources
    }

    [TestMethod]
    public async Task Test_Vouchers_Find_By_Series()
    {
        //Arrange
        Thread.Sleep(2);

        var voucher1 = new Voucher()
        {
            Description = "TestVoucher",
            Comments = "Some comments",
            VoucherSeries = "TST", //predefined series
            TransactionDate = new DateTime(2020, 1, 1),
            VoucherRows = new List<VoucherRow>()
            {
                new VoucherRow(){ Account = 1930, Debit = 1500, Credit = 0 },
                new VoucherRow(){ Account = 1910, Debit = 0, Credit = 1500 }
            }
        };
        var voucher2 = new Voucher()
        {
            Description = "TestVoucher",
            Comments = "Some comments",
            VoucherSeries = "TST", //predefined series
            TransactionDate = new DateTime(2020, 1, 1),
            VoucherRows = new List<VoucherRow>()
            {
                new VoucherRow(){ Account = 1930, Debit = 1500, Credit = 0 },
                new VoucherRow(){ Account = 1910, Debit = 0, Credit = 1500 }
            }
        };
        var voucher3 = new Voucher()
        {
            Description = "TestVoucher",
            Comments = "Some comments",
            VoucherSeries = "A", //predefined series
            TransactionDate = new DateTime(2020, 1, 1),
            VoucherRows = new List<VoucherRow>()
            {
                new VoucherRow(){ Account = 1930, Debit = 1500, Credit = 0 },
                new VoucherRow(){ Account = 1910, Debit = 0, Credit = 1500 }
            }
        };

        var connector = FortnoxClient.VoucherConnector;
        voucher1 = await connector.CreateAsync(voucher1);
        voucher2 = await connector.CreateAsync(voucher2);
        voucher3 = await connector.CreateAsync(voucher3);

        //Act
        var settings = new VoucherSearch()
        {
            LastModified = TestUtils.Recently,
            VoucherSeries = "TST"
        };

        //Assert
        var vouchers = await connector.FindAsync(settings);
        Assert.AreEqual(2, vouchers.TotalResources);

        //Clean
        await connector.DeleteAsync(voucher3.VoucherNumber, voucher3.VoucherSeries, voucher3.Year);
        await connector.DeleteAsync(voucher2.VoucherNumber, voucher2.VoucherSeries, voucher2.Year);
        await connector.DeleteAsync(voucher1.VoucherNumber, voucher1.VoucherSeries, voucher1.Year);
    }
}