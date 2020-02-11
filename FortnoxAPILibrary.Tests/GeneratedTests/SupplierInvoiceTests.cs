using System;
using System.Collections.Generic;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.GeneratedTests
{
    [TestClass]
    public class SupplierInvoiceTests
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
        public void Test_SupplierInvoice_CRUD()
        {
            #region Arrange
            //Add code to create required resources
            #endregion Arrange

            var connector = new SupplierInvoiceConnector();

            #region CREATE
            var newSupplierInvoice = new SupplierInvoice()
            {
                //TODO: Populate Entity
            };

            var createdSupplierInvoice = connector.Create(newSupplierInvoice);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("PropertyValue", createdSupplierInvoice.SomeProperty); //TODO: Adapt

            #endregion CREATE

            #region UPDATE

            createdSupplierInvoice.SomeProperty = "UpdatedPropertyValue"; //TODO: Adapt

            var updatedSupplierInvoice = connector.Update(createdSupplierInvoice); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", updatedSupplierInvoice.SomeProperty); //TODO: Adapt

            #endregion UPDATE

            #region READ / GET

            var retrievedSupplierInvoice = connector.Get(createdSupplierInvoice.GivenNumber); //TODO: Check ID property
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", retrievedSupplierInvoice.SomeProperty); //TODO: Adapt

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdSupplierInvoice.GivenNumber); //TODO: Check ID property
            MyAssert.HasNoError(connector);

            retrievedSupplierInvoice = connector.Get(createdSupplierInvoice.GivenNumber); //TODO: Check ID property
            Assert.AreEqual(null, retrievedSupplierInvoice, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }
    }
}
