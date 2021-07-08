using System;
using Fortnox.SDK;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Exceptions;
using Fortnox.SDK.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests
{
    [TestClass]
    public class TermsOfPaymentTests
    {
        public FortnoxClient FortnoxClient = TestUtils.DefaultFortnoxClient;

        [TestMethod]
        public void Test_TermsOfPayment_CRUD()
        {
            #region Arrange
            //Add code to create required resources
            #endregion Arrange

            var connector = FortnoxClient.TermsOfPaymentConnector;

            #region CREATE
            var newTermsOfPayment = new TermsOfPayment()
            {
                Code = TestUtils.RandomString(5),
                Description = "TestPaymentTerms"
            };

            var createdTermsOfPayment = connector.Create(newTermsOfPayment);
            Assert.AreEqual("TestPaymentTerms", createdTermsOfPayment.Description);

            #endregion CREATE

            #region UPDATE

            createdTermsOfPayment.Description = "UpdatedTestPaymentTerms";

            var updatedTermsOfPayment = connector.Update(createdTermsOfPayment); 
            Assert.AreEqual("UpdatedTestPaymentTerms", updatedTermsOfPayment.Description);

            #endregion UPDATE

            #region READ / GET

            var retrievedTermsOfPayment = connector.Get(createdTermsOfPayment.Code);
            Assert.AreEqual("UpdatedTestPaymentTerms", retrievedTermsOfPayment.Description);

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdTermsOfPayment.Code);

            Assert.ThrowsException<FortnoxApiException>(
                () => connector.Get(createdTermsOfPayment.Code),
                "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }

        [TestMethod]
        public void Test_Find()
        {
            var connector = FortnoxClient.TermsOfPaymentConnector;

            var newTermsOfPayment = new TermsOfPayment()
            {
                Description = "TestPaymentTerms"
            };

            //Add entries
            for (var i = 0; i < 5; i++)
            {
                newTermsOfPayment.Code = TestUtils.RandomString();
                connector.Create(newTermsOfPayment);
            }

            //Filter not supported
            var searchSettings = new TermsOfPaymentSearch();
            searchSettings.LastModified = DateTime.Now.AddMinutes(-5);
            var fullCollection = connector.Find(searchSettings);

            Assert.AreEqual(5, fullCollection.Entities.Count);
            Assert.AreEqual("TestPaymentTerms", fullCollection.Entities[0].Description);

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
