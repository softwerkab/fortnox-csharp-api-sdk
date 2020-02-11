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
                //TODO: Populate Entity
            };

            var createdCostCenter = connector.Create(newCostCenter);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("PropertyValue", createdCostCenter.SomeProperty); //TODO: Adapt

            #endregion CREATE

            #region UPDATE

            createdCostCenter.SomeProperty = "UpdatedPropertyValue"; //TODO: Adapt

            var updatedCostCenter = connector.Update(createdCostCenter); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", updatedCostCenter.SomeProperty); //TODO: Adapt

            #endregion UPDATE

            #region READ / GET

            var retrievedCostCenter = connector.Get(createdCostCenter.Code); //TODO: Check ID property
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", retrievedCostCenter.SomeProperty); //TODO: Adapt

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdCostCenter.Code); //TODO: Check ID property
            MyAssert.HasNoError(connector);

            retrievedCostCenter = connector.Get(createdCostCenter.Code); //TODO: Check ID property
            Assert.AreEqual(null, retrievedCostCenter, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }
    }
}
