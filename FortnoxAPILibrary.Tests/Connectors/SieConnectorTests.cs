using FortnoxAPILibrary.Connectors;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.Tests.Connectors
{
    [TestClass]
    public class SieConnectorTests : ConnectorTestsBase
    {
        readonly ISIEConnector _connector;

        public SieConnectorTests()
        {
            _connector = new SIEConnector
            {
                AccessToken = AccessToken,
                ClientSecret = ClientSecret
            };
        }

        [TestMethod]
        public void GetSieShouldReturnSieWithHeaders()
        {
            var sieResponse = _connector.ExportSIE(SIEConnector.SIEType.SIE4);
            Assert.AreNotEqual(sieResponse.Content, null);
            Assert.AreNotEqual(sieResponse.ContentDisposition, null);
        }
    }
}
