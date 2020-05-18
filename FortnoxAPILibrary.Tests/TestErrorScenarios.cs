using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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

            ErrorInformation error = null;
            for (var i = 0; i < 200; i++)
            {
                connector.Find();
                if (connector.HasError)
                {
                    error = connector.Error;
                    break;
                }
            }

            //Restore settings
            ConnectionSettings.UseRateLimiter = true;

            //Assert
            Assert.IsNotNull(error);
            Assert.IsTrue(error.Message.Contains("Too Many Requests")); }
    }
}
