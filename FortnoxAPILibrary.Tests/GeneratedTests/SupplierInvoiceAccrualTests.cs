using System;
using System.Collections.Generic;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.GeneratedTests
{
    [TestClass]
    public class SupplierInvoiceAccrualTests
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
        public void Test_SupplierInvoiceAccrual_CRUD()
        {
            #region Arrange
            //Add code to create required resources
            #endregion Arrange

            var connector = new SupplierInvoiceAccrualConnector();

            #region CREATE
            var newSupplierInvoiceAccrual = new SupplierInvoiceAccrual()
            {
                //TODO: Populate Entity
            };

            var createdSupplierInvoiceAccrual = connector.Create(newSupplierInvoiceAccrual);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("PropertyValue", createdSupplierInvoiceAccrual.SomeProperty); //TODO: Adapt

            #endregion CREATE

            #region UPDATE

            createdSupplierInvoiceAccrual.SomeProperty = "UpdatedPropertyValue"; //TODO: Adapt

            var updatedSupplierInvoiceAccrual = connector.Update(createdSupplierInvoiceAccrual); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", updatedSupplierInvoiceAccrual.SomeProperty); //TODO: Adapt

            #endregion UPDATE

            #region READ / GET

            var retrievedSupplierInvoiceAccrual = connector.Get(createdSupplierInvoiceAccrual.ID); //TODO: Check ID property
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", retrievedSupplierInvoiceAccrual.SomeProperty); //TODO: Adapt

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdSupplierInvoiceAccrual.ID); //TODO: Check ID property
            MyAssert.HasNoError(connector);

            retrievedSupplierInvoiceAccrual = connector.Get(createdSupplierInvoiceAccrual.ID); //TODO: Check ID property
            Assert.AreEqual(null, retrievedSupplierInvoiceAccrual, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }
    }
}
