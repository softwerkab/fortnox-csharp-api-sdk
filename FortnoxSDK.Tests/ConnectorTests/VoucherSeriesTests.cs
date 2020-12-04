using Fortnox.SDK;
using Fortnox.SDK.Connectors;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests
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

            IVoucherSeriesConnector connector = new VoucherSeriesConnector();

            #region CREATE
            //var digits = new char[]{ '0', '1', '2', '3', '4', '5'}
            var newVoucherSeries = new VoucherSeries()
            {
                Code = TestUtils.RandomInt().ToString(),
                Description = "TestVoucherSeries",
            };

            var createdVoucherSeries = connector.Create(newVoucherSeries) ?? connector.Update(newVoucherSeries); //if already exists, update it instead
            Assert.AreEqual("TestVoucherSeries", createdVoucherSeries.Description);

            #endregion CREATE

            #region UPDATE

            createdVoucherSeries.Description = "UpdatedTestVoucherSeries";

            var updatedVoucherSeries = connector.Update(createdVoucherSeries); 
            Assert.AreEqual("UpdatedTestVoucherSeries", updatedVoucherSeries.Description);

            #endregion UPDATE

            #region READ / GET

            var retrievedVoucherSeries = connector.Get(createdVoucherSeries.Code);
            Assert.AreEqual("UpdatedTestVoucherSeries", retrievedVoucherSeries.Description);

            #endregion READ / GET

            #region DELETE
            //Not supported
            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }
    }
}
