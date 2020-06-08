using System;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.Tests.ConnectorTests
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

            ITermsOfDeliveryConnector connector = new TermsOfDeliveryConnector();

            #region CREATE
            var newTermsOfDelivery = new TermsOfDelivery()
            {
                Code = TestUtils.RandomString(5),
                Description = "TestDeliveryTerms"
            };

            var createdTermsOfDelivery = connector.Create(newTermsOfDelivery);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("TestDeliveryTerms", createdTermsOfDelivery.Description);

            #endregion CREATE

            #region UPDATE

            createdTermsOfDelivery.Description = "UpdatedTestDeliveryTerms";

            var updatedTermsOfDelivery = connector.Update(createdTermsOfDelivery); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedTestDeliveryTerms", updatedTermsOfDelivery.Description);

            #endregion UPDATE

            #region READ / GET

            var retrievedTermsOfDelivery = connector.Get(createdTermsOfDelivery.Code);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedTestDeliveryTerms", retrievedTermsOfDelivery.Description);

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdTermsOfDelivery.Code);
            MyAssert.HasNoError(connector);

            retrievedTermsOfDelivery = connector.Get(createdTermsOfDelivery.Code);
            Assert.AreEqual(null, retrievedTermsOfDelivery, "Entity still exists after Delete!");

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
                MyAssert.HasNoError(connector);
            }

            //Filter not supported
            connector.LastModified = DateTime.Now.AddMinutes(-5);
            var fullCollection = connector.Find();
            MyAssert.HasNoError(connector);

            Assert.AreEqual(5, fullCollection.Entities.Count);
            Assert.AreEqual("TestDeliveryTerms", fullCollection.Entities[0].Description);

            //Apply Limit
            connector.Limit = 2;
            var limitedCollection = connector.Find();
            MyAssert.HasNoError(connector);

            Assert.AreEqual(2, limitedCollection.Entities.Count);

            //Delete entries
            foreach (var entry in fullCollection.Entities)
            {
                connector.Delete(entry.Code);
            }
        }
    }
}
