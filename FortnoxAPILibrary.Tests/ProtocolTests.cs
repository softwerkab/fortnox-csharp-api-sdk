using System;
using System.Net;
using FortnoxAPILibrary.Connectors;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.Tests
{
    [TestClass]
    public class ProtocolTests
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
        public void TestConnection_Protocol_Default_Success()
        {
            var connector = new PreDefinedAccountConnector();
            connector.Find();

            MyAssert.HasNoError(connector);
        }

        [TestMethod]
        public void TestConnection_Protocol_Tls12_Success()
        {
            var defaultProtocol = ConnectionCredentials.SecurityProtocol;
            ConnectionCredentials.SecurityProtocol = SecurityProtocolType.Tls12;

            var connector = new PreDefinedAccountConnector();
            connector.Find();

            MyAssert.HasNoError(connector);

            //restore
            ConnectionCredentials.SecurityProtocol = defaultProtocol;
        }

        [TestMethod]
        public void TestConnection_Protocol_Tls11_Exception()
        {
            var defaultProtocol = ConnectionCredentials.SecurityProtocol;
            ConnectionCredentials.SecurityProtocol = SecurityProtocolType.Tls11;

            var connector = new PreDefinedAccountConnector();

            Exception exception = null;
            try
            {
                connector.Find();
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsNotNull(exception);

            //restore
            ConnectionCredentials.SecurityProtocol = defaultProtocol;
        }
    }
}
