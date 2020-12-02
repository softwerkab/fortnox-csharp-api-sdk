using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.Tests
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
            cc.Find();
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
            cc.Find();
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
            cc.Find();
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

            var customers = connector.Find();
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

            var customers = connector.Find();
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
    }
}
