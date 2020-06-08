using System.Linq;
using FortnoxAPILibrary.Connectors;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.Tests.ConnectorTests
{
    [TestClass]
    public class AccountChartTests
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
        public void Test_AccountChart_CRUD()
        {
            //Not supported
        }

        [TestMethod]
        public void Test_Find()
        {
            IAccountChartConnector connector = new AccountChartConnector();

            var fullCollection = connector.Find();
            MyAssert.HasNoError(connector);

            Assert.AreEqual(6, fullCollection.Entities.Count);
            Assert.IsNotNull(fullCollection.Entities.First().Name);

            //Limit not supported
        }
    }
}
