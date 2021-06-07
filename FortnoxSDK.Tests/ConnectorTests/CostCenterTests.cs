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
    public class CostCenterTests
    {
        public FortnoxClient FortnoxClient = TestUtils.DefaultFortnoxClient;

        [TestMethod]
        public void Test_CostCenter_CRUD()
        {
            #region Arrange
            //Add code to create required resources
            #endregion Arrange

            ICostCenterConnector connector = FortnoxClient.CostCenterConnector;

            #region CREATE
            var newCostCenter = new CostCenter()
            {
                Code = TestUtils.RandomString(5),
                Description = "TestCostCenter",
                Active = true,
                Note = "Some notes"
            };

            var createdCostCenter = connector.Create(newCostCenter);
            Assert.AreEqual("TestCostCenter", createdCostCenter.Description);

            #endregion CREATE

            #region UPDATE

            createdCostCenter.Description = "UpdatedTestCostCenter";

            var updatedCostCenter = connector.Update(createdCostCenter); 
            Assert.AreEqual("UpdatedTestCostCenter", updatedCostCenter.Description);

            #endregion UPDATE

            #region READ / GET

            var retrievedCostCenter = connector.Get(createdCostCenter.Code);
            Assert.AreEqual("UpdatedTestCostCenter", retrievedCostCenter.Description);

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdCostCenter.Code);

            Assert.ThrowsException<FortnoxApiException>(
                () => connector.Get(createdCostCenter.Code),
                "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }

        [TestMethod]
        public void Test_Find()
        {
            #region Arrange
            //Add code to create required resources
            #endregion Arrange

            ICostCenterConnector connector = FortnoxClient.CostCenterConnector;
            var newCostCenter = new CostCenter()
            {
                Code = TestUtils.RandomString(),
                Description = "TestCostCenter",
                Active = true,
                Note = "Some notes"
            };

            //Add entries
            for (var i = 0; i < 5; i++)
            {
                newCostCenter.Code = TestUtils.RandomString(5);
                connector.Create(newCostCenter);
            }

            //Apply base test filter
            var searchSettings = new CostCenterSearch();
            searchSettings.LastModified = DateTime.Now.AddMinutes(-5);
            var fullCollection = connector.Find(searchSettings);

            Assert.AreEqual(5, fullCollection.TotalResources);
            Assert.AreEqual(5, fullCollection.Entities.Count);
            Assert.AreEqual(1, fullCollection.TotalPages);

            Assert.AreEqual("TestCostCenter", fullCollection.Entities[0].Description);

            //Apply Limit
            searchSettings.Limit = 2;
            var limitedCollection = connector.Find(searchSettings);

            Assert.AreEqual(5, limitedCollection.TotalResources);
            Assert.AreEqual(2, limitedCollection.Entities.Count);
            Assert.AreEqual(3, limitedCollection.TotalPages);

            //Delete entries
            foreach (var entry in fullCollection.Entities)
            {
                connector.Delete(entry.Code);
            }
            #region Delete arranged resources

            //Add code to delete temporary resources

            #endregion Delete arranged resources
        }
    }
}
