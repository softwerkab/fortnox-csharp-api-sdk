using System;
using System.Linq;
using Fortnox.SDK;
using Fortnox.SDK.Connectors;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests
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

        [Ignore("Does not provide update nor delete")]
        [TestMethod]
        public void Test_FinancialYear_CRUD()
        {
            #region Arrange

            var existingAccountChartType = new AccountChartConnector().Find(null).Entities.First();

            #endregion Arrange

            IFinancialYearConnector connector = new FinancialYearConnector();

            #region CREATE

            var newFinancialYear = new FinancialYear()
            {
                FromDate = new DateTime(2010, 1, 1),
                ToDate = new DateTime(2010, 12, 31),
                AccountChartType = existingAccountChartType.Name,
                AccountingMethod = AccountingMethod.Cash
            };

            var createdFinancialYear = connector.Create(newFinancialYear);
            Assert.AreEqual(new DateTime(2010, 1, 1), createdFinancialYear.FromDate);

            #endregion CREATE

            #region UPDATE

            //Not supported

            #endregion UPDATE

            #region READ / GET

            var retrievedFinancialYear = connector.Get(createdFinancialYear.Id);
            Assert.AreEqual(new DateTime(2010, 1, 1), retrievedFinancialYear.FromDate);

            #endregion READ / GET

            #region DELETE

            //Not supported

            #endregion DELETE

            #region Delete arranged resources

            //Add code to delete temporary resources

            #endregion Delete arranged resources
        }

        [TestMethod]
        public void Test_FinancialYear_Find()
        {
            IFinancialYearConnector connector = new FinancialYearConnector();
            
            var finYears = connector.Find(null);
            Assert.AreEqual(5, finYears.Entities.Count);
            Assert.IsNotNull(finYears.Entities.First().AccountChartType);
        }
    }
}
