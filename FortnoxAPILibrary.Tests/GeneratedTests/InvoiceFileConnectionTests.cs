using System;
using System.Collections.Generic;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.GeneratedTests
{
    [TestClass]
    public class InvoiceFileConnectionTests
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
        public void Test_InvoiceFileConnection_CRUD()
        {
            #region Arrange
            //Add code to create required resources
            #endregion Arrange

            var connector = new InvoiceFileConnectionConnector();

            #region CREATE
            var newInvoiceFileConnection = new InvoiceFileConnection()
            {
                //TODO: Populate Entity
            };

            var createdInvoiceFileConnection = connector.Create(newInvoiceFileConnection);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("PropertyValue", createdInvoiceFileConnection.SomeProperty); //TODO: Adapt

            #endregion CREATE

            #region UPDATE

            createdInvoiceFileConnection.SomeProperty = "UpdatedPropertyValue"; //TODO: Adapt

            var updatedInvoiceFileConnection = connector.Update(createdInvoiceFileConnection); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", updatedInvoiceFileConnection.SomeProperty); //TODO: Adapt

            #endregion UPDATE

            #region READ / GET

            var retrievedInvoiceFileConnection = connector.Get(createdInvoiceFileConnection.FileId); //TODO: Check ID property
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", retrievedInvoiceFileConnection.SomeProperty); //TODO: Adapt

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdInvoiceFileConnection.FileId); //TODO: Check ID property
            MyAssert.HasNoError(connector);

            retrievedInvoiceFileConnection = connector.Get(createdInvoiceFileConnection.FileId); //TODO: Check ID property
            Assert.AreEqual(null, retrievedInvoiceFileConnection, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }
    }
}
