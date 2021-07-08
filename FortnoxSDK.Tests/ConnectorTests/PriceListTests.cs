using System;
using System.Linq;
using System.Threading;
using Fortnox.SDK;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests
{
    [TestClass]
    public class PriceListTests
    {
        public FortnoxClient FortnoxClient = TestUtils.DefaultFortnoxClient;

        [TestMethod]
        public void Test_PriceList_CRUD()
        {
            #region Arrange
            #endregion Arrange

            var connector = FortnoxClient.PriceListConnector;

            #region CREATE
            var newPriceList = new PriceList()
            {
                Code = TestUtils.RandomString().ToUpperInvariant(),
                Description = "TestPriceList",
                Comments = "Some comments"
            };

            var createdPriceList = connector.Create(newPriceList);
            Assert.AreEqual("TestPriceList", createdPriceList.Description);

            #endregion CREATE

            #region UPDATE

            createdPriceList.Description = "UpdatedTestPriceList";

            var updatedPriceList = connector.Update(createdPriceList); 
            Assert.AreEqual("UpdatedTestPriceList", updatedPriceList.Description);

            #endregion UPDATE

            #region READ / GET

            var retrievedPriceList = connector.Get(createdPriceList.Code);
            Assert.AreEqual("UpdatedTestPriceList", retrievedPriceList.Description);

            #endregion READ / GET

            #region DELETE
            //Not available
            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }

        [TestMethod]
        public void Test_Find()
        {
            Thread.Sleep(1000);
            var timeStamp = DateTime.Now;
            Thread.Sleep(1000);

            var connector = FortnoxClient.PriceListConnector;

            var newPriceList = new PriceList()
            {
                Description = "TestPriceList",
                Comments = "EntryForFindRequest"
            };

            for (var i = 0; i < 5; i++)
            {
                newPriceList.Code = TestUtils.RandomString().ToUpperInvariant();
                connector.Create(newPriceList);
            }

            var searchSettings = new PriceListSearch();
            searchSettings.LastModified = timeStamp;
            var fullCollection = connector.Find(searchSettings);

            Assert.AreEqual(5, fullCollection.TotalResources);
            Assert.AreEqual(5, fullCollection.Entities.Count);
            Assert.AreEqual(5, fullCollection.Entities.Count(e => e.Comments == "EntryForFindRequest"));

            //Apply Limit
            searchSettings.Limit = 2;
            var limitedCollection = connector.Find(searchSettings);

            //Assert.AreEqual(5, limitedCollection.TotalResources);
            Assert.AreEqual(2, limitedCollection.Entities.Count);
            //Assert.AreEqual(3, limitedCollection.TotalPages);
        }
    }
}
