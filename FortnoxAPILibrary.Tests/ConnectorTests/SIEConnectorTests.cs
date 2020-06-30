using System;
using System.Linq;
using FortnoxAPILibrary.Connectors;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.Tests.ConnectorTests
{
    [TestClass]
    public class SIEConnectorTests
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
        public void SIE_Get()
        {
            var types = Enum.GetValues(typeof(SIEType)).Cast<SIEType>().ToList();
            ISIEConnector connector = new SIEConnector();
            
            foreach (var sieType in types)
            {
                var data = connector.Get(sieType);
                MyAssert.HasNoError(connector);
                Assert.IsNotNull(data);
            }
        }
    }
}
