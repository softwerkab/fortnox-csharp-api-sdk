using System;
using System.Collections.Generic;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.GeneratedTests
{
    [TestClass]
    public class InvoiceTests
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
        public void Test_Invoice_CRUD()
        {
            #region Arrange
            //Add code to create required resources
            #endregion Arrange

            var connector = new InvoiceConnector();

            #region CREATE
            var newInvoice = new Invoice()
            {
                //TODO: Populate Entity
            };

            var createdInvoice = connector.Create(newInvoice);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("PropertyValue", createdInvoice.SomeProperty); //TODO: Adapt

            #endregion CREATE

            #region UPDATE

            createdInvoice.SomeProperty = "UpdatedPropertyValue"; //TODO: Adapt

            var updatedInvoice = connector.Update(createdInvoice); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", updatedInvoice.SomeProperty); //TODO: Adapt

            #endregion UPDATE

            #region READ / GET

            var retrievedInvoice = connector.Get(createdInvoice.DocumentNumber); //TODO: Check ID property
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", retrievedInvoice.SomeProperty); //TODO: Adapt

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdInvoice.DocumentNumber); //TODO: Check ID property
            MyAssert.HasNoError(connector);

            retrievedInvoice = connector.Get(createdInvoice.DocumentNumber); //TODO: Check ID property
            Assert.AreEqual(null, retrievedInvoice, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }
    }
}
