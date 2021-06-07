using System.Linq;
using Fortnox.SDK;
using Fortnox.SDK.Connectors;
using Fortnox.SDK.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests
{
    [TestClass]
    public class AccountChartTests
    {
        public FortnoxClient FortnoxClient = TestUtils.DefaultFortnoxClient;

        [TestMethod]
        public void Test_AccountChart_CRUD()
        {
            //Not supported
        }

        [TestMethod]
        public void Test_Find()
        {
            IAccountChartConnector connector = new AccountChartConnector();

            var fullCollection = connector.Find(null);

            Assert.AreEqual(6, fullCollection.Entities.Count);
            Assert.IsNotNull(fullCollection.Entities.First().Name);

            //Limit not supported
        }
    }
}
