using System;
using System.Collections.Generic;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.GeneratedTests
{
    [TestClass]
    public class SupplierInvoiceFileConnectionTests
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
        public void Test_SupplierInvoiceFileConnection_CRUD()
        {
            #region Arrange
            //Add code to create required resources
            #endregion Arrange

            var connector = new SupplierInvoiceFileConnectionConnector();

            #region CREATE
            var newSupplierInvoiceFileConnection = new SupplierInvoiceFileConnection()
            {
                //TODO: Populate Entity
            };

            var createdSupplierInvoiceFileConnection = connector.Create(newSupplierInvoiceFileConnection);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("PropertyValue", createdSupplierInvoiceFileConnection.SomeProperty); //TODO: Adapt

            #endregion CREATE

            #region UPDATE

            createdSupplierInvoiceFileConnection.SomeProperty = "UpdatedPropertyValue"; //TODO: Adapt

            var updatedSupplierInvoiceFileConnection = connector.Update(createdSupplierInvoiceFileConnection); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", updatedSupplierInvoiceFileConnection.SomeProperty); //TODO: Adapt

            #endregion UPDATE

            #region READ / GET

            var retrievedSupplierInvoiceFileConnection = connector.Get(createdSupplierInvoiceFileConnection.FileId); //TODO: Check ID property
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", retrievedSupplierInvoiceFileConnection.SomeProperty); //TODO: Adapt

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdSupplierInvoiceFileConnection.FileId); //TODO: Check ID property
            MyAssert.HasNoError(connector);

            retrievedSupplierInvoiceFileConnection = connector.Get(createdSupplierInvoiceFileConnection.FileId); //TODO: Check ID property
            Assert.AreEqual(null, retrievedSupplierInvoiceFileConnection, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }
    }
}
