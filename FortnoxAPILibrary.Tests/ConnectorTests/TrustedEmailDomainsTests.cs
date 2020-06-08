using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.Tests.ConnectorTests
{
    [TestClass]
    public class TrustedEmailDomainsTests
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
        public void Test_TrustedEmailDomains_CRUD()
        {
            #region Arrange
            //Add code to create required resources
            #endregion Arrange

            ITrustedEmailDomainsConnector connector = new TrustedEmailDomainsConnector();

            #region CREATE
            var newTrustedEmailDomains = new TrustedEmailDomain()
            {
                Domain = "testdomain.tst",
            };

            var createdTrustedEmailDomains = connector.Create(newTrustedEmailDomains);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("testdomain.tst", createdTrustedEmailDomains.Domain);

            #endregion CREATE

            #region UPDATE
            //Not supported
            #endregion UPDATE

            #region READ / GET

            var retrievedTrustedEmailDomains = connector.Get(createdTrustedEmailDomains.Id);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("testdomain.tst", retrievedTrustedEmailDomains.Domain);

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdTrustedEmailDomains.Id);
            MyAssert.HasNoError(connector);

            retrievedTrustedEmailDomains = connector.Get(createdTrustedEmailDomains.Id);
            Assert.AreEqual(null, retrievedTrustedEmailDomains, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }
    }
}
