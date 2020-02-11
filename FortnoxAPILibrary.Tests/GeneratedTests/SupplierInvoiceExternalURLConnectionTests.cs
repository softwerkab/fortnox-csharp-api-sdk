using System;
using System.Collections.Generic;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.GeneratedTests
{
    [TestClass]
    public class SupplierInvoiceExternalURLConnectionTests
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
        public void Test_SupplierInvoiceExternalURLConnection_CRUD()
        {
            #region Arrange
            //Add code to create required resources
            #endregion Arrange

            var connector = new SupplierInvoiceExternalURLConnectionConnector();

            #region CREATE
            var newSupplierInvoiceExternalURLConnection = new SupplierInvoiceExternalURLConnection()
            {
                //TODO: Populate Entity
            };

            var createdSupplierInvoiceExternalURLConnection = connector.Create(newSupplierInvoiceExternalURLConnection);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("PropertyValue", createdSupplierInvoiceExternalURLConnection.SomeProperty); //TODO: Adapt

            #endregion CREATE

            #region UPDATE

            createdSupplierInvoiceExternalURLConnection.SomeProperty = "UpdatedPropertyValue"; //TODO: Adapt

            var updatedSupplierInvoiceExternalURLConnection = connector.Update(createdSupplierInvoiceExternalURLConnection); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", updatedSupplierInvoiceExternalURLConnection.SomeProperty); //TODO: Adapt

            #endregion UPDATE

            #region READ / GET

            var retrievedSupplierInvoiceExternalURLConnection = connector.Get(createdSupplierInvoiceExternalURLConnection.Id); //TODO: Check ID property
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", retrievedSupplierInvoiceExternalURLConnection.SomeProperty); //TODO: Adapt

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdSupplierInvoiceExternalURLConnection.Id); //TODO: Check ID property
            MyAssert.HasNoError(connector);

            retrievedSupplierInvoiceExternalURLConnection = connector.Get(createdSupplierInvoiceExternalURLConnection.Id); //TODO: Check ID property
            Assert.AreEqual(null, retrievedSupplierInvoiceExternalURLConnection, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }
    }
}
