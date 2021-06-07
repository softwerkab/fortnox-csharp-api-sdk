using System;
using System.Net.Http;
using Fortnox.SDK;
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
            var fortnoxClient = new FortnoxClient()
            {
                AccessToken = null,
                ClientSecret = null
            };

            //Act
            ICustomerConnector cc = fortnoxClient.CustomerConnector;
            cc.Find(null);
        }

        [TestMethod]
        [ExpectedException(typeof(FortnoxApiException))]
        public void TestConnection_EmptyCredenials_Error()
        {
            //Arrange
            var fortnoxClient = new FortnoxClient()
            {
                AccessToken = "",
                ClientSecret = ""
            };

            //Act
            ICustomerConnector cc = fortnoxClient.CustomerConnector;
            cc.Find(null);
        }

        [TestMethod]
        [ExpectedException(typeof(FortnoxApiException))]
        public void TestConnection_WrongCredenials_Error()
        {
            //Arrange
            var fortnoxClient = new FortnoxClient()
            {
                AccessToken = "ABC",
                ClientSecret = "DEF"
            };

            //Act
            ICustomerConnector cc = fortnoxClient.CustomerConnector;
            cc.Find(null);
        }

        [TestMethod]
        public void TestConnection_Credentials_Correct()
        {
            //Arrange
            var fortnoxClient = new FortnoxClient()
            {
                AccessToken = TestCredentials.Access_Token,
                ClientSecret = TestCredentials.Client_Secret
            };

            //Act
            ICustomerConnector connector = fortnoxClient.CustomerConnector;
            var customers = connector.Find(null);

            //Assert
            Assert.IsNotNull(customers);
        }

        [TestMethod]
        public void TestConnection_MultipleCredentials_Set()
        {
            var fortnoxClient1 = new FortnoxClient()
            {
                AccessToken = "AT1",
                ClientSecret = "CS1"
            };

            var fortnoxClient2 = new FortnoxClient()
            {
                AccessToken = "AT2",
                ClientSecret = "CS2"
            };

            ICustomerConnector connector1 = fortnoxClient1.CustomerConnector;
            ICustomerConnector connector2 = fortnoxClient2.CustomerConnector;

            Assert.IsTrue(connector1.AccessToken == "AT1" && connector2.AccessToken == "AT2");
            Assert.IsTrue(connector1.ClientSecret == "CS1" && connector2.ClientSecret == "CS2");
        }

        [TestMethod]
        public void TestConnection_Config_Set()
        {
            var fortnoxClient = new FortnoxClient()
            {
                AccessToken = "AccToken",
                ClientSecret = "Secret",
                UseRateLimiter = false,
                HttpClient = new HttpClient() {Timeout = TimeSpan.FromSeconds(10)}
            };

            var connector = fortnoxClient.CustomerConnector;

            Assert.AreEqual("AccToken", connector.AccessToken);
            Assert.AreEqual("Secret", connector.ClientSecret);
            Assert.AreEqual(false, connector.UseRateLimiter);
            Assert.AreEqual(10, connector.HttpClient.Timeout.Seconds);
        }
    }
}
