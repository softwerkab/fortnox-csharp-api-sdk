using System;
using System.Net.Http;
using Fortnox.SDK;
using Fortnox.SDK.Connectors;
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
            var FortnoxClient = new FortnoxClient()
            {
                AccessToken = null,
                ClientSecret = null
            };

            //Act
            ICustomerConnector cc = new CustomerConnector();
            cc.Find(null);
        }

        [TestMethod]
        [ExpectedException(typeof(FortnoxApiException))]
        public void TestConnection_EmptyCredenials_Error()
        {
            //Arrange
            var FortnoxClient = new FortnoxClient()
            {
                AccessToken = "",
                ClientSecret = ""
            };

            //Act
            ICustomerConnector cc = new CustomerConnector();
            cc.Find(null);
        }

        [TestMethod]
        [ExpectedException(typeof(FortnoxApiException))]
        public void TestConnection_WrongCredenials_Error()
        {
            //Arrange
            var FortnoxClient = new FortnoxClient()
            {
                AccessToken = "ABC",
                ClientSecret = "DEF"
            };

            //Act
            ICustomerConnector cc = new CustomerConnector();
            cc.Find(null);
        }

        [TestMethod]
        public void TestConnection_Credentials_Set()
        {
            //Arrange
            var FortnoxClient = new FortnoxClient()
            {
                AccessToken = "",
                ClientSecret = ""
            };

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
            var FortnoxClient = new FortnoxClient()
            {
                AccessToken = TestCredentials.Access_Token,
                ClientSecret = TestCredentials.Client_Secret
            };

            //Act
            ICustomerConnector connector = new CustomerConnector();

            var customers = connector.Find(null);
            Assert.IsNotNull(customers);
        }

        [TestMethod]
        public void TestConnection_MultipleCredentials_Set()
        {
            var FortnoxClient = new FortnoxClient()
            {
                AccessToken = "123",
                ClientSecret = "456"
            };

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
