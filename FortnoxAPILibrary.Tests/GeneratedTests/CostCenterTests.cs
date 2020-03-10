using System;
using System.Collections.Generic;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.GeneratedTests
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

            var connector = new CostCenterConnector();

            #region CREATE
            var newCostCenter = new CostCenter()
            {
                Code = "TST",
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

            var testKeyMark = TestUtils.RandomInt();

            var connector = new AccountConnector();
            var newAccount = new Account()
            {
                Description = "Test Account",
                Active = false,
                CostCenterSettings = CostCenterSettings.ALLOWED,
                ProjectSettings = ProjectSettings.ALLOWED,
                SRU = testKeyMark
            };

            //Add entries
            for (var i = 0; i < 5; i++)
            {
                for (var j = 0; j < 10; j++) //try 10x times to create unique account number
                {
                    var number = TestUtils.RandomInt(0, 9999);
                    if (connector.Get(number) == null) //not exists
                    {
                        newAccount.Number = number;
                        break;
                    }
                }

                connector.Create(newAccount);
            }

            //Apply base test filter
            connector.SRU = testKeyMark.ToString();
            var fullCollection = connector.Find();
            MyAssert.HasNoError(connector);

            Assert.AreEqual(5, fullCollection.TotalResources);
            Assert.AreEqual(5, fullCollection.Entities.Count);
            Assert.AreEqual(1, fullCollection.TotalPages);

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
                connector.Delete(entry.Number);
            }
            #region Delete arranged resources

            //Add code to delete temporary resources

            #endregion Delete arranged resources
        }
    }
}
