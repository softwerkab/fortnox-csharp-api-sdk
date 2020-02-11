using System;
using System.Collections.Generic;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.GeneratedTests
{
    [TestClass]
    public class TermsOfDeliveryTests
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
        public void Test_TermsOfDelivery_CRUD()
        {
            #region Arrange
            //Add code to create required resources
            #endregion Arrange

            var connector = new TermsOfDeliveryConnector();

            #region CREATE
            var newTermsOfDelivery = new TermsOfDelivery()
            {
                //TODO: Populate Entity
            };

            var createdTermsOfDelivery = connector.Create(newTermsOfDelivery);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("PropertyValue", createdTermsOfDelivery.SomeProperty); //TODO: Adapt

            #endregion CREATE

            #region UPDATE

            createdTermsOfDelivery.SomeProperty = "UpdatedPropertyValue"; //TODO: Adapt

            var updatedTermsOfDelivery = connector.Update(createdTermsOfDelivery); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", updatedTermsOfDelivery.SomeProperty); //TODO: Adapt

            #endregion UPDATE

            #region READ / GET

            var retrievedTermsOfDelivery = connector.Get(createdTermsOfDelivery.Code); //TODO: Check ID property
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", retrievedTermsOfDelivery.SomeProperty); //TODO: Adapt

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdTermsOfDelivery.Code); //TODO: Check ID property
            MyAssert.HasNoError(connector);

            retrievedTermsOfDelivery = connector.Get(createdTermsOfDelivery.Code); //TODO: Check ID property
            Assert.AreEqual(null, retrievedTermsOfDelivery, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }
    }
}
