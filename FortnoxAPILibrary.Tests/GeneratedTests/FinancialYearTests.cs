using System;
using System.Collections.Generic;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.GeneratedTests
{
    [TestClass]
    public class FinancialYearTests
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
        public void Test_FinancialYear_CRUD()
        {
            #region Arrange
            //Add code to create required resources
            #endregion Arrange

            var connector = new FinancialYearConnector();

            #region CREATE
            var newFinancialYear = new FinancialYear()
            {
                //TODO: Populate Entity
            };

            var createdFinancialYear = connector.Create(newFinancialYear);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("PropertyValue", createdFinancialYear.SomeProperty); //TODO: Adapt

            #endregion CREATE

            #region UPDATE

            createdFinancialYear.SomeProperty = "UpdatedPropertyValue"; //TODO: Adapt

            var updatedFinancialYear = connector.Update(createdFinancialYear); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", updatedFinancialYear.SomeProperty); //TODO: Adapt

            #endregion UPDATE

            #region READ / GET

            var retrievedFinancialYear = connector.Get(createdFinancialYear.Id); //TODO: Check ID property
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", retrievedFinancialYear.SomeProperty); //TODO: Adapt

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdFinancialYear.Id); //TODO: Check ID property
            MyAssert.HasNoError(connector);

            retrievedFinancialYear = connector.Get(createdFinancialYear.Id); //TODO: Check ID property
            Assert.AreEqual(null, retrievedFinancialYear, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }
    }
}
