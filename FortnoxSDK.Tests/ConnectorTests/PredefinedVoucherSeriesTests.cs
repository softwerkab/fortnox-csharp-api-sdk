using System.Linq;
using Fortnox.SDK;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests
{
    [TestClass]
    public class PredefinedVoucherSeriesTests
    {
        public FortnoxClient FortnoxClient = TestUtils.DefaultFortnoxClient;

        [TestMethod]
        public void Test_PredefinedVoucherSeries_CRUD()
        {
            var connector = FortnoxClient.PredefinedVoucherSeriesConnector;

            //Get
            var predefinedVoucherSeries = connector.Get("INVOICE");
            Assert.AreEqual("B", predefinedVoucherSeries.VoucherSeries);

            //Update
            predefinedVoucherSeries.VoucherSeries = "L"; //Lon -> "SALARY"
            connector.Update(predefinedVoucherSeries);
            Assert.AreEqual("L", predefinedVoucherSeries.VoucherSeries);

            //Reset
            predefinedVoucherSeries.VoucherSeries = "B";
            connector.Update(predefinedVoucherSeries);
            Assert.AreEqual("B", predefinedVoucherSeries.VoucherSeries);
        }

        [TestMethod]
        public void Test_Find()
        {
            var connector = FortnoxClient.PredefinedVoucherSeriesConnector;

            var fullCollection = connector.Find(null);

            Assert.AreEqual(13, fullCollection.Entities.Count);
            Assert.IsNotNull(fullCollection.Entities.First().Name);

            //Limit not supported
        }
    }
}
