using System;
using Fortnox.SDK;
using Fortnox.SDK.Connectors;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Exceptions;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests
{
    [TestClass]
    public class TermsOfDeliveryTests
    {
        public FortnoxClient FortnoxClient = TestUtils.DefaultFortnoxClient;

        [TestMethod]
        public void Test_TermsOfDelivery_CRUD()
        {
            #region Arrange
            //Add code to create required resources
            #endregion Arrange

            ITermsOfDeliveryConnector connector = new TermsOfDeliveryConnector();

            #region CREATE
            var newTermsOfDelivery = new TermsOfDelivery()
            {
                Code = TestUtils.RandomString(5),
                Description = "TestDeliveryTerms"
            };

            var createdTermsOfDelivery = connector.Create(newTermsOfDelivery);
            Assert.AreEqual("TestDeliveryTerms", createdTermsOfDelivery.Description);

            #endregion CREATE

            #region UPDATE

            createdTermsOfDelivery.Description = "UpdatedTestDeliveryTerms";

            var updatedTermsOfDelivery = connector.Update(createdTermsOfDelivery); 
            Assert.AreEqual("UpdatedTestDeliveryTerms", updatedTermsOfDelivery.Description);

            #endregion UPDATE

            #region READ / GET

            var retrievedTermsOfDelivery = connector.Get(createdTermsOfDelivery.Code);
            Assert.AreEqual("UpdatedTestDeliveryTerms", retrievedTermsOfDelivery.Description);

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdTermsOfDelivery.Code);

            Assert.ThrowsException<FortnoxApiException>(
                () => connector.Get(createdTermsOfDelivery.Code),
                "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }

        [TestMethod]
        public void Test_Find()
        {
            ITermsOfDeliveryConnector connector = new TermsOfDeliveryConnector();

            var newTermsOfDelivery = new TermsOfDelivery()
            {
                Description = "TestDeliveryTerms"
            };

            //Add entries
            for (var i = 0; i < 5; i++)
            {
                newTermsOfDelivery.Code = TestUtils.RandomString();
                connector.Create(newTermsOfDelivery);
            }

            //Filter not supported
            var searchSettings = new TermsOfDeliverySearch();
            searchSettings.LastModified = DateTime.Now.AddMinutes(-5);
            var fullCollection = connector.Find(searchSettings);

            Assert.AreEqual(5, fullCollection.Entities.Count);
            Assert.AreEqual("TestDeliveryTerms", fullCollection.Entities[0].Description);

            //Apply Limit
            searchSettings.Limit = 2;
            var limitedCollection = connector.Find(searchSettings);

            Assert.AreEqual(2, limitedCollection.Entities.Count);

            //Delete entries
            foreach (var entry in fullCollection.Entities)
            {
                connector.Delete(entry.Code);
            }
        }
    }
}
