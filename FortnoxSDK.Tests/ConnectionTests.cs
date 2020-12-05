using System;
using System.Net.Http;
using System.Reflection;
using Fortnox.SDK;
using Fortnox.SDK.Connectors;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Exceptions;
using Fortnox.SDK.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests
{
    [TestClass]
    public class ConnectionTests
    {
        [TestMethod]
        [ExpectedException(typeof(FortnoxApiException))]
        public void TestConnection_NoCredenials_Error()
        {
            //Arrange
            ConnectionCredentials.AccessToken = null;
            ConnectionCredentials.ClientSecret = null;

            //Act
            ICustomerConnector cc = new CustomerConnector();
            cc.Find(null);
        }

        [TestMethod]
        [ExpectedException(typeof(FortnoxApiException))]
        public void TestConnection_EmptyCredenials_Error()
        {
            //Arrange
            ConnectionCredentials.AccessToken = "";
            ConnectionCredentials.ClientSecret = "";

            //Act
            ICustomerConnector cc = new CustomerConnector();
            cc.Find(null);
        }

        [TestMethod]
        [ExpectedException(typeof(FortnoxApiException))]
        public void TestConnection_WrongCredenials_Error()
        {
            //Arrange
            ConnectionCredentials.AccessToken = "ABC";
            ConnectionCredentials.ClientSecret = "DEF";

            //Act
            ICustomerConnector cc = new CustomerConnector();
            cc.Find(null);
        }

        [TestMethod]
        public void TestConnection_LocalCredentials_Set()
        {
            //Arrange
            ConnectionCredentials.AccessToken = "";
            ConnectionCredentials.ClientSecret = "";

            //Act
            ICustomerConnector connector = new CustomerConnector();
            connector.AccessToken = TestCredentials.Access_Token;
            connector.ClientSecret = TestCredentials.Client_Secret;

            var customers = connector.Find(null);
            Assert.IsNotNull(customers);
        }

        [TestMethod]
        public void TestConnection_GlobalCredentials_Set()
        {
            //Arrange
            ConnectionCredentials.AccessToken = TestCredentials.Access_Token;
            ConnectionCredentials.ClientSecret = TestCredentials.Client_Secret;

            //Act
            ICustomerConnector connector = new CustomerConnector();

            var customers = connector.Find(null);
            Assert.IsNotNull(customers);
        }

        [TestMethod]
        public void TestConnection_MultipleCredentials_Set()
        {
            ConnectionCredentials.AccessToken = "123";
            ConnectionCredentials.ClientSecret = "456";

            ICustomerConnector connector1 = new CustomerConnector();
            connector1.AccessToken = "A";
            connector1.ClientSecret = "B";

            ICustomerConnector connector2 = new CustomerConnector();
            connector2.AccessToken = "AA";
            connector2.ClientSecret = "BB";

            Assert.IsTrue(connector1.AccessToken == "A" && connector2.AccessToken == "AA");
        }

        [TestMethod]
        public void TestConnection_Using_FortnoxClient()
        {
            var fortnoxClient = new FortnoxClient()
            {
                AccessToken = "AccToken",
                ClientSecret = "Secret",
                UseRateLimiter = false,
                HttpClient = new HttpClient() {Timeout = TimeSpan.FromSeconds(10)}
            };

            var connector = fortnoxClient.Get<CustomerConnector>();

            Assert.AreEqual("AccToken", connector.AccessToken);
            Assert.AreEqual("Secret", connector.ClientSecret);
            Assert.AreEqual(false, connector.UseRateLimiter);
            Assert.AreEqual(10, connector.HttpClient.Timeout.Seconds);
        }
    }
}
