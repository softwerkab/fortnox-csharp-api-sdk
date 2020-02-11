using System;
using System.Collections.Generic;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.GeneratedTests
{
    [TestClass]
    public class TermsOfPaymentTests
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
        public void Test_TermsOfPayment_CRUD()
        {
            #region Arrange
            //Add code to create required resources
            #endregion Arrange

            var connector = new TermsOfPaymentConnector();

            #region CREATE
            var newTermsOfPayment = new TermsOfPayment()
            {
                //TODO: Populate Entity
            };

            var createdTermsOfPayment = connector.Create(newTermsOfPayment);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("PropertyValue", createdTermsOfPayment.SomeProperty); //TODO: Adapt

            #endregion CREATE

            #region UPDATE

            createdTermsOfPayment.SomeProperty = "UpdatedPropertyValue"; //TODO: Adapt

            var updatedTermsOfPayment = connector.Update(createdTermsOfPayment); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", updatedTermsOfPayment.SomeProperty); //TODO: Adapt

            #endregion UPDATE

            #region READ / GET

            var retrievedTermsOfPayment = connector.Get(createdTermsOfPayment.Code); //TODO: Check ID property
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", retrievedTermsOfPayment.SomeProperty); //TODO: Adapt

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdTermsOfPayment.Code); //TODO: Check ID property
            MyAssert.HasNoError(connector);

            retrievedTermsOfPayment = connector.Get(createdTermsOfPayment.Code); //TODO: Check ID property
            Assert.AreEqual(null, retrievedTermsOfPayment, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }
    }
}
