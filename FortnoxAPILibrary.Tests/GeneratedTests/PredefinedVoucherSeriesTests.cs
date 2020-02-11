using System;
using System.Collections.Generic;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.GeneratedTests
{
    [TestClass]
    public class PredefinedVoucherSeriesTests
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
        public void Test_PredefinedVoucherSeries_CRUD()
        {
            #region Arrange
            //Add code to create required resources
            #endregion Arrange

            var connector = new PredefinedVoucherSeriesConnector();

            #region CREATE
            var newPredefinedVoucherSeries = new PredefinedVoucherSeries()
            {
                //TODO: Populate Entity
            };

            var createdPredefinedVoucherSeries = connector.Create(newPredefinedVoucherSeries);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("PropertyValue", createdPredefinedVoucherSeries.SomeProperty); //TODO: Adapt

            #endregion CREATE

            #region UPDATE

            createdPredefinedVoucherSeries.SomeProperty = "UpdatedPropertyValue"; //TODO: Adapt

            var updatedPredefinedVoucherSeries = connector.Update(createdPredefinedVoucherSeries); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", updatedPredefinedVoucherSeries.SomeProperty); //TODO: Adapt

            #endregion UPDATE

            #region READ / GET

            var retrievedPredefinedVoucherSeries = connector.Get(createdPredefinedVoucherSeries.ID); //TODO: Check ID property
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", retrievedPredefinedVoucherSeries.SomeProperty); //TODO: Adapt

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdPredefinedVoucherSeries.ID); //TODO: Check ID property
            MyAssert.HasNoError(connector);

            retrievedPredefinedVoucherSeries = connector.Get(createdPredefinedVoucherSeries.ID); //TODO: Check ID property
            Assert.AreEqual(null, retrievedPredefinedVoucherSeries, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }
    }
}
