using System.Linq;
using System.Threading.Tasks;
using Fortnox.SDK;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests
{
    [TestClass]
    public class AccountChartTests
    {
        public FortnoxClient FortnoxClient = TestUtils.DefaultFortnoxClient;

        [TestMethod]
        public async Task Test_AccountChart_CRUD()
        {
            //Not supported
        }

        [TestMethod]
        public async Task Test_Find()
        {
            var connector = FortnoxClient.AccountChartConnector;

            var fullCollection = await connector.FindAsync(null);

            Assert.AreEqual(6, fullCollection.Entities.Count);
            Assert.IsNotNull(fullCollection.Entities.First().Name);

            //Limit not supported
        }
    }
}
