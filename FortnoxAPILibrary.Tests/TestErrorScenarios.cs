using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net;

namespace FortnoxAPILibrary.Tests
{
    [TestClass]
    public class TestErrorScenarios
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
        public void Test_FailedCreate_NoEntity()
        {
            var connector = new CustomerConnector();

            var createdCustomer = connector.Create(new Customer() {Name = "TestCustomer", CountryCode = "InvalidCountryCode"});
            Assert.IsTrue(connector.HasError);
            Assert.IsNull(createdCustomer);
        }

        [TestMethod]
        public void Test_FailedUpdate_NoEntity()
        {
            var connector = new CustomerConnector();

            var createdCustomer = connector.Update(new Customer() { Name = "TestCustomer", CustomerNumber = "NotExistingCustomerNumber"});
            Assert.IsTrue(connector.HasError);
            Assert.IsNull(createdCustomer);
        }

        [TestMethod]
        public void Test_NoRateLimiter_TooManyRequest_Error()
        {
            ConnectionSettings.UseRateLimiter = false;
            var connector = new CustomerConnector();

            Exception exception = null;
            try
            {
                for (var i = 0; i < 200; i++)
                {
                    connector.Find();
                }
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            //Restore settings
            ConnectionSettings.UseRateLimiter = true;

            //Assert
            Assert.IsNotNull(exception);
            Assert.IsTrue(exception.Message.Contains("Too Many Requests"));
        }

        [TestMethod]
        public void Test_TlsConnection_NotEstablishd_Error()
        {
            var defaultTlsSettings = ServicePointManager.SecurityProtocol;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11;
            var connector = new CustomerConnector();

            Exception exception = null;
            try
            {
                connector.Find();
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            //Restore settings
            ServicePointManager.SecurityProtocol = defaultTlsSettings;

            //Assert
            Assert.IsNotNull(exception);
            Assert.IsTrue(exception.InnerException.Message.Contains("The SSL connection could not be established"));
        }
    }
}
