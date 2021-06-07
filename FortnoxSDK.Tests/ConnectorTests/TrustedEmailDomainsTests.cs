using Fortnox.SDK;
using Fortnox.SDK.Connectors;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Exceptions;
using Fortnox.SDK.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests
{
    [TestClass]
    public class TrustedEmailDomainsTests
    {
        public FortnoxClient FortnoxClient = TestUtils.DefaultFortnoxClient;

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
            Assert.AreEqual("testdomain.tst", createdTrustedEmailDomains.Domain);

            #endregion CREATE

            #region UPDATE
            //Not supported
            #endregion UPDATE

            #region READ / GET

            var retrievedTrustedEmailDomains = connector.Get(createdTrustedEmailDomains.Id);
            Assert.AreEqual("testdomain.tst", retrievedTrustedEmailDomains.Domain);

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdTrustedEmailDomains.Id);

            Assert.ThrowsException<FortnoxApiException>(
                () => connector.Get(createdTrustedEmailDomains.Id),
                "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }
    }
}
