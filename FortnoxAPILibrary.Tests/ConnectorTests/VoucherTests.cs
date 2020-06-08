using System;
using System.Collections.Generic;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.Tests.ConnectorTests
{
    [TestClass]
    public class VoucherTests
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
        public void Test_Voucher_CRUD()
        {
            #region Arrange
            #endregion Arrange

            IVoucherConnector connector = new VoucherConnector();

            #region CREATE
            var newVoucher = new Voucher()
            {
                Description = "TestVoucher",
                Comments = "Some comments",
                VoucherSeries = "A", //predefined series
                TransactionDate = new DateTime(2020, 1,1),
                VoucherRows = new List<VoucherRow>()
                {
                    new VoucherRow(){ Account = 1930, Debit = 1500, Credit = 0 },
                    new VoucherRow(){ Account = 1910, Debit = 0, Credit = 1500 }
                }
            };

            var createdVoucher = connector.Create(newVoucher);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("TestVoucher", createdVoucher.Description);

            #endregion CREATE

            #region UPDATE
            //Not supported
            #endregion UPDATE

            #region READ / GET
            var retrievedVoucher = connector.Get(createdVoucher.VoucherNumber, createdVoucher.VoucherSeries, createdVoucher.Year);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("TestVoucher", retrievedVoucher.Description);

            #endregion READ / GET

            #region DELETE
            //Not supported
            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }
    }
}
