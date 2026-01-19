using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fortnox.SDK;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Exceptions;
using Fortnox.SDK.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests;

[TestClass]
public class VoucherFileConnectionTests
{
    private FortnoxClient FortnoxClient;

    [TestInitialize]
    public async Task TestInitialize()
    {
        FortnoxClient ??= await TestClient.GetFortnoxClient();
    }

    [TestMethod]
    public async Task Test_VoucherFileConnection_CRUD()
    {
        #region Arrange

        var tmpVoucher = await FortnoxClient.VoucherConnector.CreateAsync(new Voucher()
        {
            Description = "TestVoucher CRUD",
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
        Assert.AreEqual(tmpVoucher.VoucherNumber, createdVoucherFileConnection.VoucherNumber);

        #endregion CREATE

        #region UPDATE
        //Not supported
        #endregion UPDATE

        #region READ / GET

        var retrievedVoucherFileConnection = await connector.GetAsync(createdVoucherFileConnection.FileId);
        Assert.AreEqual(tmpVoucher.VoucherNumber, retrievedVoucherFileConnection.VoucherNumber);

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
    public async Task Create_VoucherFileConnection_NonDefaultYear()
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

    [Ignore("Fails because the Voucher File Connection's VoucherDescription no longer shows the description from the Voucher, but instead a description of the type. Re-enable when the API endpoint is fixed.")]
    [TestMethod]
    public async Task Test_VoucherFileConnection_Find()
    {
        #region Arrange

        var tmpVoucher = await FortnoxClient.VoucherConnector.CreateAsync(new Voucher()
        {
            Description = "TestVoucher FIND",
            Comments = "Comment",
            VoucherSeries = "A",
            TransactionDate = new DateTime(2020, 1, 1),
            VoucherRows =
            [
                new VoucherRow() {Account = 1930, Debit = 1500, Credit = 0},
                new VoucherRow() {Account = 1910, Debit = 0, Credit = 1500}
            ]
        });

        List<ArchiveFile> createdFiles = [];
        //Add entries
        for (var i = 0; i < 5; i++)
        {
            createdFiles.Add(await FortnoxClient.ArchiveConnector.UploadFileAsync("tmpImage_find.png", Resource.fortnox_image));
        }

        #endregion Arrange

        var connector = FortnoxClient.VoucherFileConnectionConnector;

        #region CREATE

        //Add entries
        for (var i = 0; i < 5; i++)
        {
            var newVoucherFileConnection = new VoucherFileConnection()
            {
                FileId = createdFiles[i].Id,
                VoucherNumber = tmpVoucher.VoucherNumber,
                VoucherSeries = tmpVoucher.VoucherSeries
            };
            await connector.CreateAsync(newVoucherFileConnection);
        }

        #endregion CREATE

        #region READ / GET

        var searchSettings = new VoucherFileConnectionSearch
        {
            VoucherDescription = tmpVoucher.Description,
            VoucherYear = tmpVoucher.Year,
            VoucherSeries = tmpVoucher.VoucherSeries
        };
        var retrievedVoucherFileConnections = await connector.FindAsync(searchSettings);
        Assert.AreEqual(5, retrievedVoucherFileConnections.Entities.Count);
        Assert.AreEqual(1, retrievedVoucherFileConnections.TotalPages);

        Assert.AreEqual(tmpVoucher.Description, retrievedVoucherFileConnections.Entities.First().VoucherDescription);

        #endregion READ / GET

        #region DELETE

        //Delete entries
        foreach (var item in retrievedVoucherFileConnections.Entities)
        {
            await connector.DeleteAsync(item.FileId);
        }

        #endregion DELETE

        #region Delete arranged resources
        await FortnoxClient.VoucherConnector.DeleteAsync(tmpVoucher.VoucherNumber, tmpVoucher.VoucherSeries, tmpVoucher.Year);
        foreach (var item in createdFiles)
        {
            await FortnoxClient.ArchiveConnector.DeleteFileAsync(item.Id);
        }
        #endregion Delete arranged resources
    }
}