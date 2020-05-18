using System;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.Tests.ConnectorTests
{
    [TestClass]
    public class CostCenterTests
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
        public void Test_CostCenter_CRUD()
        {
            #region Arrange
            //Add code to create required resources
            #endregion Arrange

            ICostCenterConnector connector = new CostCenterConnector();

            #region CREATE
            var newCostCenter = new CostCenter()
            {
                Code = TestUtils.RandomString(5),
                Description = "TestCostCenter",
                Active = true,
                Note = "Some notes"
            };

            var createdCostCenter = connector.Create(newCostCenter);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("TestCostCenter", createdCostCenter.Description);

            #endregion CREATE

            #region UPDATE

            createdCostCenter.Description = "UpdatedTestCostCenter";

            var updatedCostCenter = connector.Update(createdCostCenter); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedTestCostCenter", updatedCostCenter.Description);

            #endregion UPDATE

            #region READ / GET

            var retrievedCostCenter = connector.Get(createdCostCenter.Code);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedTestCostCenter", retrievedCostCenter.Description);

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdCostCenter.Code);
            MyAssert.HasNoError(connector);

            retrievedCostCenter = connector.Get(createdCostCenter.Code);
            Assert.AreEqual(null, retrievedCostCenter, "Entity still exists after Delete!");

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

            ICostCenterConnector connector = new CostCenterConnector();
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
                MyAssert.HasNoError(connector);
            }

            //Apply base test filter
            connector.LastModified = DateTime.Now.AddMinutes(-5);
            var fullCollection = connector.Find();
            MyAssert.HasNoError(connector);

            Assert.AreEqual(5, fullCollection.TotalResources);
            Assert.AreEqual(5, fullCollection.Entities.Count);
            Assert.AreEqual(1, fullCollection.TotalPages);

            Assert.AreEqual("TestCostCenter", fullCollection.Entities[0].Description);

            //Apply Limit
            connector.Limit = 2;
            var limitedCollection = connector.Find();
            MyAssert.HasNoError(connector);

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
