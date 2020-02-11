using System;
using System.Collections.Generic;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.GeneratedTests
{
    [TestClass]
    public class VoucherSeriesTests
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
        public void Test_VoucherSeries_CRUD()
        {
            #region Arrange
            //Add code to create required resources
            #endregion Arrange

            var connector = new VoucherSeriesConnector();

            #region CREATE
            var newVoucherSeries = new VoucherSeries()
            {
                //TODO: Populate Entity
            };

            var createdVoucherSeries = connector.Create(newVoucherSeries);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("PropertyValue", createdVoucherSeries.SomeProperty); //TODO: Adapt

            #endregion CREATE

            #region UPDATE

            createdVoucherSeries.SomeProperty = "UpdatedPropertyValue"; //TODO: Adapt

            var updatedVoucherSeries = connector.Update(createdVoucherSeries); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", updatedVoucherSeries.SomeProperty); //TODO: Adapt

            #endregion UPDATE

            #region READ / GET

            var retrievedVoucherSeries = connector.Get(createdVoucherSeries.Code); //TODO: Check ID property
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", retrievedVoucherSeries.SomeProperty); //TODO: Adapt

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdVoucherSeries.Code); //TODO: Check ID property
            MyAssert.HasNoError(connector);

            retrievedVoucherSeries = connector.Get(createdVoucherSeries.Code); //TODO: Check ID property
            Assert.AreEqual(null, retrievedVoucherSeries, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }
    }
}
