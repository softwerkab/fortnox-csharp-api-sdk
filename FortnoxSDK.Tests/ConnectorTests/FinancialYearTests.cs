using System;
using System.Linq;
using System.Threading.Tasks;
using Fortnox.SDK;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests
{
    [TestClass]
    public class FinancialYearTests
    {
        public FortnoxClient FortnoxClient = TestUtils.DefaultFortnoxClient;

        [Ignore("Does not provide update nor delete")]
        [TestMethod]
        public async Task Test_FinancialYear_CRUD()
        {
            #region Arrange

            var existingAccountChartType = (await FortnoxClient.AccountChartConnector.FindAsync(null)).Entities.First();

            #endregion Arrange

            var connector = FortnoxClient.FinancialYearConnector;

            #region CREATE

            var newFinancialYear = new FinancialYear()
            {
                FromDate = new DateTime(2010, 1, 1),
                ToDate = new DateTime(2010, 12, 31),
                AccountChartType = existingAccountChartType.Name,
                AccountingMethod = AccountingMethod.Cash
            };

            var createdFinancialYear = await connector.CreateAsync(newFinancialYear);
            Assert.AreEqual(new DateTime(2010, 1, 1), createdFinancialYear.FromDate);

            #endregion CREATE

            #region UPDATE

            //Not supported

            #endregion UPDATE

            #region READ / GET

            var retrievedFinancialYear = await connector.GetAsync(createdFinancialYear.Id);
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
        public async Task Test_FinancialYear_Find()
        {
            var connector = FortnoxClient.FinancialYearConnector;

            var finYears = await connector.FindAsync(null);
            Assert.AreEqual(5, finYears.Entities.Count);
            Assert.IsNotNull(finYears.Entities.First().FromDate);
        }

        [TestMethod]
        public async Task Test_FinancialYear_Find_By_Date()
        {
            var connector = FortnoxClient.FinancialYearConnector;

            var search = new FinancialYearSearch()
            {
                Date = new DateTime(2022, 05, 24)
            };

            var finYears = await connector.FindAsync(search);
            Assert.AreEqual(1, finYears.Entities.Count);
            Assert.AreEqual(new DateTime(2022, 1, 1), finYears.Entities.Single().FromDate);
            Assert.AreEqual(new DateTime(2022, 12, 31), finYears.Entities.Single().ToDate);
        }

        [TestMethod]
        public async Task Test_FinancialYear_Find_By_FinYearDate()
        {
            var connector = FortnoxClient.FinancialYearConnector;

            var search = new FinancialYearSearch()
            {
                FinancialYearDate = new DateTime(2022, 05, 24)
            };

            var finYears = await connector.FindAsync(search);
            Assert.AreEqual(1, finYears.Entities.Count);
            Assert.AreEqual(new DateTime(2022, 1, 1), finYears.Entities.Single().FromDate);
            Assert.AreEqual(new DateTime(2022, 12, 31), finYears.Entities.Single().ToDate);
        }
    }
}
