using System;
using System.Collections.Generic;
using System.Text;
using FortnoxAPILibrary.Connectors;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.Tests
{
    [TestClass]
    public class ConnectionTests
    {
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestConnection_WithoutCredenials_Error()
        {
            //Arrange
            ConnectionCredentials.AccessToken = "";
            ConnectionCredentials.ClientSecret = "";

            //Act
            var cc = new CustomerConnector();
            cc.AccessToken = "";
            cc.ClientSecret = "";
            cc.Find();
        }

        [TestMethod]
        public void TestConnection_LocalCredentials_Set()
        {
            //Arrange
            ConnectionCredentials.AccessToken = "";
            ConnectionCredentials.ClientSecret = "";

            //Act
            var connector = new CustomerConnector();
            connector.AccessToken = TestCredentials.Access_Token;
            connector.ClientSecret = TestCredentials.Client_Secret;

            var customers = connector.Find();
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'.");
            Assert.IsNotNull(customers);
        }

        [TestMethod]
        public void TestConnection_GlobalCredentials_Set()
        {
            //Arrange
            ConnectionCredentials.AccessToken = TestCredentials.Access_Token;
            ConnectionCredentials.ClientSecret = TestCredentials.Client_Secret;

            //Act
            var connector = new CustomerConnector();
            connector.AccessToken = "";
            connector.ClientSecret = "";

            var customers = connector.Find();
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'.");
            Assert.IsNotNull(customers);
        }

        [TestMethod]
        public void TestConnection_MultipleCredentials_Set()
        {
            ConnectionCredentials.AccessToken = "123";
            ConnectionCredentials.ClientSecret = "456";

            var connector1 = new CustomerConnector();
            connector1.AccessToken = "A";
            connector1.ClientSecret = "B";

            var connector2 = new CustomerConnector();
            connector2.AccessToken = "AA";
            connector2.ClientSecret = "BB";

            Assert.IsTrue(connector1.AccessToken == "A" && connector2.AccessToken == "AA");
        }
    }
}
