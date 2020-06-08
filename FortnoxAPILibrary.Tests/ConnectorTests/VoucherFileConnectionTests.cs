using System;
using System.Collections.Generic;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.Tests.ConnectorTests
{
    [TestClass]
    public class VoucherFileConnectionTests
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
        public void Test_VoucherFileConnection_CRUD()
        {
            #region Arrange

            var tmpVoucher = new VoucherConnector().Create(new Voucher()
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
            var tmpFile = new ArchiveConnector().UploadFile("tmpImage.png", Resource.fortnox_image);
            #endregion Arrange

            IVoucherFileConnectionConnector connector = new VoucherFileConnectionConnector();

            #region CREATE
            var newVoucherFileConnection = new VoucherFileConnection()
            {
                FileId = tmpFile.Id,
                VoucherNumber = tmpVoucher.VoucherNumber.ToString(),
                VoucherSeries = tmpVoucher.VoucherSeries
            };

            var createdVoucherFileConnection = connector.Create(newVoucherFileConnection);
            MyAssert.HasNoError(connector);
            Assert.AreEqual(tmpVoucher.Description, createdVoucherFileConnection.VoucherDescription);

            #endregion CREATE

            #region UPDATE
            //Not supported
            #endregion UPDATE

            #region READ / GET

            var retrievedVoucherFileConnection = connector.Get(createdVoucherFileConnection.FileId);
            MyAssert.HasNoError(connector);
            Assert.AreEqual(tmpVoucher.Description, retrievedVoucherFileConnection.VoucherDescription);

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdVoucherFileConnection.FileId);
            MyAssert.HasNoError(connector);

            retrievedVoucherFileConnection = connector.Get(createdVoucherFileConnection.FileId);
            Assert.AreEqual(null, retrievedVoucherFileConnection, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            new ArchiveConnector().DeleteFile(tmpFile.Id);
            #endregion Delete arranged resources
        }
    }
}
