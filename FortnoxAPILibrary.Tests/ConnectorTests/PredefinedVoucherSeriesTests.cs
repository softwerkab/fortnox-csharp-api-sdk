using System.Linq;
using FortnoxAPILibrary.Connectors;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.Tests.ConnectorTests
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
            IPredefinedVoucherSeriesConnector connector = new PredefinedVoucherSeriesConnector();

            //Get
            var predefinedVoucherSeries = connector.Get("INVOICE");
            MyAssert.HasNoError(connector);
            Assert.AreEqual("B", predefinedVoucherSeries.VoucherSeries);

            //Update
            predefinedVoucherSeries.VoucherSeries = "L"; //Lon -> "SALARY"
            connector.Update(predefinedVoucherSeries);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("L", predefinedVoucherSeries.VoucherSeries);

            //Reset
            predefinedVoucherSeries.VoucherSeries = "B";
            connector.Update(predefinedVoucherSeries);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("B", predefinedVoucherSeries.VoucherSeries);
        }

        [TestMethod]
        public void Test_Find()
        {
            IPredefinedVoucherSeriesConnector connector = new PredefinedVoucherSeriesConnector();

            var fullCollection = connector.Find();
            MyAssert.HasNoError(connector);

            Assert.AreEqual(13, fullCollection.Entities.Count);
            Assert.IsNotNull(fullCollection.Entities.First().Name);

            //Limit not supported
        }
    }
}
