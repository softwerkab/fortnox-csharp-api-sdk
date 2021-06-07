using System;
using System.Collections.Generic;
using Fortnox.SDK;
using Fortnox.SDK.Connectors;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Exceptions;
using Fortnox.SDK.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests
{
    [TestClass]
    public class VoucherFileConnectionTests
    {
        public FortnoxClient FortnoxClient = TestUtils.DefaultFortnoxClient;

        [TestMethod]
        public void Test_VoucherFileConnection_CRUD()
        {
            #region Arrange

            var tmpVoucher = FortnoxClient.VoucherConnector.Create(new Voucher()
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
            var tmpFile = FortnoxClient.ArchiveConnector.UploadFile("tmpImage.png", Resource.fortnox_image);
            #endregion Arrange

            IVoucherFileConnectionConnector connector = FortnoxClient.VoucherFileConnectionConnector;

            #region CREATE
            var newVoucherFileConnection = new VoucherFileConnection()
            {
                FileId = tmpFile.Id,
                VoucherNumber = tmpVoucher.VoucherNumber.ToString(),
                VoucherSeries = tmpVoucher.VoucherSeries
            };

            var createdVoucherFileConnection = connector.Create(newVoucherFileConnection);
            Assert.AreEqual(tmpVoucher.Description, createdVoucherFileConnection.VoucherDescription);

            #endregion CREATE

            #region UPDATE
            //Not supported
            #endregion UPDATE

            #region READ / GET

            var retrievedVoucherFileConnection = connector.Get(createdVoucherFileConnection.FileId);
            Assert.AreEqual(tmpVoucher.Description, retrievedVoucherFileConnection.VoucherDescription);

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdVoucherFileConnection.FileId);

            Assert.ThrowsException<FortnoxApiException>(
                () => connector.Get(createdVoucherFileConnection.FileId),
                "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            FortnoxClient.ArchiveConnector.DeleteFile(tmpFile.Id);
            #endregion Delete arranged resources
        }
    }
}
