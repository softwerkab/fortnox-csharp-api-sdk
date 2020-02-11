using System;
using System.Collections.Generic;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.GeneratedTests
{
    [TestClass]
    public class InvoicePaymentTests
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
        public void Test_InvoicePayment_CRUD()
        {
            #region Arrange
            //Add code to create required resources
            #endregion Arrange

            var connector = new InvoicePaymentConnector();

            #region CREATE
            var newInvoicePayment = new InvoicePayment()
            {
                //TODO: Populate Entity
            };

            var createdInvoicePayment = connector.Create(newInvoicePayment);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("PropertyValue", createdInvoicePayment.SomeProperty); //TODO: Adapt

            #endregion CREATE

            #region UPDATE

            createdInvoicePayment.SomeProperty = "UpdatedPropertyValue"; //TODO: Adapt

            var updatedInvoicePayment = connector.Update(createdInvoicePayment); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", updatedInvoicePayment.SomeProperty); //TODO: Adapt

            #endregion UPDATE

            #region READ / GET

            var retrievedInvoicePayment = connector.Get(createdInvoicePayment.Number); //TODO: Check ID property
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", retrievedInvoicePayment.SomeProperty); //TODO: Adapt

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdInvoicePayment.Number); //TODO: Check ID property
            MyAssert.HasNoError(connector);

            retrievedInvoicePayment = connector.Get(createdInvoicePayment.Number); //TODO: Check ID property
            Assert.AreEqual(null, retrievedInvoicePayment, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }
    }
}
