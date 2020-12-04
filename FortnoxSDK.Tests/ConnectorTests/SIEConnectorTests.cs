using System;
using System.Linq;
using Fortnox.SDK;
using Fortnox.SDK.Connectors;
using Fortnox.SDK.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests
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
                Assert.IsNotNull(data);
            }
        }
    }
}
