using System;
using System.Collections.Generic;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.GeneratedTests
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
            //Add code to create required resources
            #endregion Arrange

            var connector = new VoucherConnector();

            #region CREATE
            var newVoucher = new Voucher()
            {
                //TODO: Populate Entity
            };

            var createdVoucher = connector.Create(newVoucher);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("PropertyValue", createdVoucher.SomeProperty); //TODO: Adapt

            #endregion CREATE

            #region UPDATE

            createdVoucher.SomeProperty = "UpdatedPropertyValue"; //TODO: Adapt

            var updatedVoucher = connector.Update(createdVoucher); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", updatedVoucher.SomeProperty); //TODO: Adapt

            #endregion UPDATE

            #region READ / GET

            var retrievedVoucher = connector.Get(createdVoucher.VoucherNumber); //TODO: Check ID property
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", retrievedVoucher.SomeProperty); //TODO: Adapt

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdVoucher.VoucherNumber); //TODO: Check ID property
            MyAssert.HasNoError(connector);

            retrievedVoucher = connector.Get(createdVoucher.VoucherNumber); //TODO: Check ID property
            Assert.AreEqual(null, retrievedVoucher, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }
    }
}
