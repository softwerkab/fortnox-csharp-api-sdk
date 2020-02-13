using System;
using System.Collections.Generic;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.GeneratedTests
{
    [TestClass]
    public class PriceListTests
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
        public void Test_PriceList_CRUD()
        {
            #region Arrange
            #endregion Arrange

            var connector = new PriceListConnector();

            #region CREATE
            var newPriceList = new PriceList()
            {
                Code = "TST_PR",
                Description = "TestPriceList",
                Comments = "Some comments"
            };

            var alreadyExists = new PriceListConnector().Get("TST_PR") != null; //already created in previous test run

            var createdPriceList = alreadyExists ? connector.Update(newPriceList) : connector.Create(newPriceList);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("TestPriceList", createdPriceList.Description);

            #endregion CREATE

            #region UPDATE

            createdPriceList.Description = "UpdatedTestPriceList";

            var updatedPriceList = connector.Update(createdPriceList); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedTestPriceList", updatedPriceList.Description);

            #endregion UPDATE

            #region READ / GET

            var retrievedPriceList = connector.Get(createdPriceList.Code);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedTestPriceList", retrievedPriceList.Description);

            #endregion READ / GET

            #region DELETE
            //Not available
            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }
    }
}
