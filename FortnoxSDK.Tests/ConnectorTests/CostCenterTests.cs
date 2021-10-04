using System;
using System.Threading.Tasks;
using Fortnox.SDK;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Exceptions;
using Fortnox.SDK.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests
{
    [TestClass]
    public class CostCenterTests
    {
        public FortnoxClient FortnoxClient = TestUtils.DefaultFortnoxClient;

        [TestMethod]
        public async Task Test_CostCenter_CRUD()
        {
            #region Arrange
            //Add code to create required resources
            #endregion Arrange

            var connector = FortnoxClient.CostCenterConnector;

            #region CREATE
            var newCostCenter = new CostCenter()
            {
                Code = TestUtils.RandomString(5),
                Description = "TestCostCenter",
                Active = true,
                Note = "Some notes"
            };

            var createdCostCenter = await connector.CreateAsync(newCostCenter);
            Assert.AreEqual("TestCostCenter", createdCostCenter.Description);

            #endregion CREATE

            #region UPDATE

            createdCostCenter.Description = "UpdatedTestCostCenter";

            var updatedCostCenter = await connector.UpdateAsync(createdCostCenter); 
            Assert.AreEqual("UpdatedTestCostCenter", updatedCostCenter.Description);

            #endregion UPDATE

            #region READ / GET

            var retrievedCostCenter = await connector.GetAsync(createdCostCenter.Code);
            Assert.AreEqual("UpdatedTestCostCenter", retrievedCostCenter.Description);

            #endregion READ / GET

            #region DELETE

            await connector.DeleteAsync(createdCostCenter.Code);

            Assert.ThrowsException<FortnoxApiException>(
                () => connector.Get(createdCostCenter.Code),
                "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }

        [TestMethod]
        public async Task Test_Find()
        {
            #region Arrange
            //Add code to create required resources
            #endregion Arrange

            var connector = FortnoxClient.CostCenterConnector;
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
                await connector.CreateAsync(newCostCenter);
            }

            //Apply base test filter
            var searchSettings = new CostCenterSearch();
            searchSettings.LastModified = TestUtils.Recently;
            var fullCollection = await connector.FindAsync(searchSettings);

            Assert.AreEqual(5, fullCollection.TotalResources);
            Assert.AreEqual(5, fullCollection.Entities.Count);
            Assert.AreEqual(1, fullCollection.TotalPages);

            Assert.AreEqual("TestCostCenter", fullCollection.Entities[0].Description);

            //Apply Limit
            searchSettings.Limit = 2;
            var limitedCollection = await connector.FindAsync(searchSettings);

            Assert.AreEqual(5, limitedCollection.TotalResources);
            Assert.AreEqual(2, limitedCollection.Entities.Count);
            Assert.AreEqual(3, limitedCollection.TotalPages);

            //Delete entries
            foreach (var entry in fullCollection.Entities)
            {
                await connector.DeleteAsync(entry.Code);
            }
            #region Delete arranged resources

            //Add code to delete temporary resources

            #endregion Delete arranged resources
        }
    }
}
