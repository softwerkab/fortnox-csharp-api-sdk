using System;
using System.Collections.Generic;
using System.Linq;
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
            var existingAccountChartType = new AccountChartConnector().Find().Entities.First();
            #endregion Arrange

            var connector = new FinancialYearConnector();

            #region CREATE
            var newFinancialYear = new FinancialYear()
            {
                FromDate = new DateTime(2000,1,1),
                ToDate = new DateTime(2000,12,31),
                AccountChartType = existingAccountChartType.Name,
                AccountingMethod = AccountingMethod.CASH
            };

            var createdFinancialYear = connector.Create(newFinancialYear);
            MyAssert.HasNoError(connector);
            Assert.AreEqual(new DateTime(2000,1,1).ToString(), createdFinancialYear.FromDate?.ToString());

            #endregion CREATE

            #region UPDATE

            createdFinancialYear.FromDate = new DateTime(2000, 2, 1);

            var updatedFinancialYear = connector.Update(createdFinancialYear); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual(new DateTime(2000, 2, 1).ToString(), updatedFinancialYear.FromDate?.ToString());

            #endregion UPDATE

            #region READ / GET

            var retrievedFinancialYear = connector.Get(createdFinancialYear.Id);
            MyAssert.HasNoError(connector);
            Assert.AreEqual(new DateTime(2000, 2, 1).ToString(), retrievedFinancialYear.FromDate?.ToString());

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdFinancialYear.Id);
            MyAssert.HasNoError(connector);

            retrievedFinancialYear = connector.Get(createdFinancialYear.Id);
            Assert.AreEqual(null, retrievedFinancialYear, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }
    }
}
