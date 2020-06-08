using System.Collections.Generic;
using System.Linq;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.Tests.ConnectorTests
{
    [TestClass]
    public class WayOfDeliveryTests
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
        public void Test_WayOfDelivery_CRUD()
        {
            #region Arrange
            //Add code to create required resources
            #endregion Arrange

            IWayOfDeliveryConnector connector = new WayOfDeliveryConnector();

            #region CREATE
            var newWayOfDelivery = new WayOfDelivery()
            {
                Code = "TST",
                Description = "TestDeliveryMethod"
            };

            var createdWayOfDelivery = connector.Create(newWayOfDelivery);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("TestDeliveryMethod", createdWayOfDelivery.Description);

            #endregion CREATE

            #region UPDATE

            createdWayOfDelivery.Description = "UpdatedTestDeliveryMethod";

            var updatedWayOfDelivery = connector.Update(createdWayOfDelivery); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedTestDeliveryMethod", updatedWayOfDelivery.Description);

            #endregion UPDATE

            #region READ / GET

            var retrievedWayOfDelivery = connector.Get(createdWayOfDelivery.Code);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedTestDeliveryMethod", retrievedWayOfDelivery.Description);

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdWayOfDelivery.Code);
            MyAssert.HasNoError(connector);

            retrievedWayOfDelivery = connector.Get(createdWayOfDelivery.Code);
            Assert.AreEqual(null, retrievedWayOfDelivery, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }

        [TestMethod]
        public void Test_Find()
        {
            IWayOfDeliveryConnector connector = new WayOfDeliveryConnector();

            var existingCount = connector.Find().Entities.Count;
            var testKeyMark = TestUtils.RandomString();

            var createdEntries = new List<WayOfDelivery>();
            //Add entries
            for (var i = 0; i < 5; i++)
            {
                var createdEntry = connector.Create(new WayOfDelivery() { Code = TestUtils.RandomString(), Description = testKeyMark });
                createdEntries.Add(createdEntry);
            }

            //Filter not supported
            var fullCollection = connector.Find();
            MyAssert.HasNoError(connector);

            Assert.AreEqual(existingCount + 5, fullCollection.Entities.Count);
            Assert.AreEqual(5, fullCollection.Entities.Count(e => e.Description == testKeyMark));

            //Apply Limit
            connector.Limit = 2;
            var limitedCollection = connector.Find();
            MyAssert.HasNoError(connector);

            Assert.AreEqual(existingCount + 5, limitedCollection.TotalResources);
            Assert.AreEqual(2, limitedCollection.Entities.Count);

            //Delete entries
            foreach (var entry in createdEntries)
            {
                connector.Delete(entry.Code);
            }
        }
    }
}
