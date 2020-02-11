using System;
using System.Collections.Generic;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.GeneratedTests
{
    [TestClass]
    public class AccountChartTests
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
        public void Test_AccountChart_CRUD()
        {
            #region Arrange
            //Add code to create required resources
            #endregion Arrange

            var connector = new AccountChartConnector();

            #region CREATE
            var newAccountChart = new AccountChart()
            {
                //TODO: Populate Entity
            };

            var createdAccountChart = connector.Create(newAccountChart);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("PropertyValue", createdAccountChart.SomeProperty); //TODO: Adapt

            #endregion CREATE

            #region UPDATE

            createdAccountChart.SomeProperty = "UpdatedPropertyValue"; //TODO: Adapt

            var updatedAccountChart = connector.Update(createdAccountChart); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", updatedAccountChart.SomeProperty); //TODO: Adapt

            #endregion UPDATE

            #region READ / GET

            var retrievedAccountChart = connector.Get(createdAccountChart.ID); //TODO: Check ID property
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", retrievedAccountChart.SomeProperty); //TODO: Adapt

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdAccountChart.ID); //TODO: Check ID property
            MyAssert.HasNoError(connector);

            retrievedAccountChart = connector.Get(createdAccountChart.ID); //TODO: Check ID property
            Assert.AreEqual(null, retrievedAccountChart, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }
    }
}
