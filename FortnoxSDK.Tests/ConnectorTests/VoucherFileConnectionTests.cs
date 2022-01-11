using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fortnox.SDK;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests;

[TestClass]
public class VoucherFileConnectionTests
{
    public FortnoxClient FortnoxClient = TestUtils.DefaultFortnoxClient;

    [TestMethod]
    public async Task Test_VoucherFileConnection_CRUD()
    {
        #region Arrange

        var tmpVoucher = await FortnoxClient.VoucherConnector.CreateAsync(new Voucher()
        {
            Description = "TestVoucher",
            Comments = "Some comments",
            VoucherSeries = "A", //predefined series
            TransactionDate = new DateTime(2020, 1, 1),
            VoucherRows = new List<VoucherRow>()
            {
                new VoucherRow() {Account = 1930, Debit = 1500, Credit = 0},
                new VoucherRow() {Account = 1910, Debit = 0, Credit = 1500}
            }
        });
        var tmpFile = await FortnoxClient.ArchiveConnector.UploadFileAsync("tmpImage.png", Resource.fortnox_image);
        #endregion Arrange

        var connector = FortnoxClient.VoucherFileConnectionConnector;

        #region CREATE
        var newVoucherFileConnection = new VoucherFileConnection()
        {
            FileId = tmpFile.Id,
            VoucherNumber = tmpVoucher.VoucherNumber,
            VoucherSeries = tmpVoucher.VoucherSeries
        };

        var createdVoucherFileConnection = await connector.CreateAsync(newVoucherFileConnection);
        Assert.AreEqual(tmpVoucher.Description, createdVoucherFileConnection.VoucherDescription);
        Assert.AreEqual(tmpVoucher.Year, createdVoucherFileConnection.VoucherYear);

        #endregion CREATE

        #region UPDATE
        //Not supported
        #endregion UPDATE

        #region READ / GET

        var retrievedVoucherFileConnection = await connector.GetAsync(createdVoucherFileConnection.FileId);
        Assert.AreEqual(tmpVoucher.Description, retrievedVoucherFileConnection.VoucherDescription);

        #endregion READ / GET

        #region DELETE

        await connector.DeleteAsync(createdVoucherFileConnection.FileId);

        await Assert.ThrowsExceptionAsync<FortnoxApiException>(
            async () => await connector.GetAsync(createdVoucherFileConnection.FileId),
            "Entity still exists after Delete!");

        #endregion DELETE

        #region Delete arranged resources
        await FortnoxClient.VoucherConnector.DeleteAsync(tmpVoucher.VoucherNumber, tmpVoucher.VoucherSeries, tmpVoucher.Year);
        await FortnoxClient.ArchiveConnector.DeleteFileAsync(tmpFile.Id);
        #endregion Delete arranged resources
    }

    [TestMethod]
    public async Task Create_NonDefaultYear()
    {
        #region Arrange

        var tmpVoucher = await FortnoxClient.VoucherConnector.CreateAsync(new Voucher()
        {
            Description = "TestVoucher",
            Comments = "Some comments",
            VoucherSeries = "A", //predefined series
            TransactionDate = new DateTime(2018, 1, 1),
            VoucherRows = new List<VoucherRow>()
            {
                new VoucherRow() {Account = 1930, Debit = 1500, Credit = 0},
                new VoucherRow() {Account = 1910, Debit = 0, Credit = 1500}
            }
        });
        var tmpFile = await FortnoxClient.ArchiveConnector.UploadFileAsync("tmpImage.png", Resource.fortnox_image);
        #endregion Arrange

        var connector = FortnoxClient.VoucherFileConnectionConnector;

        var newVoucherFileConnection = new VoucherFileConnection()
        {
            FileId = tmpFile.Id,
            VoucherNumber = tmpVoucher.VoucherNumber,
            VoucherSeries = tmpVoucher.VoucherSeries
        };

        var createdVoucherFileConnection = await connector.CreateAsync(newVoucherFileConnection, tmpVoucher.Year);

        Assert.AreEqual(tmpVoucher.Description, createdVoucherFileConnection.VoucherDescription);
        Assert.AreEqual(tmpVoucher.Year, createdVoucherFileConnection.VoucherYear);

        #region Clean up
        await connector.DeleteAsync(createdVoucherFileConnection.FileId);
        await FortnoxClient.VoucherConnector.DeleteAsync(tmpVoucher.VoucherNumber, tmpVoucher.VoucherSeries, tmpVoucher.Year);
        await FortnoxClient.ArchiveConnector.DeleteFileAsync(tmpFile.Id);
        #endregion Clean up
    }
}