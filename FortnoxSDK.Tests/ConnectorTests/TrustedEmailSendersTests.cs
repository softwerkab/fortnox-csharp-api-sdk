using System.Linq;
using Fortnox.SDK;
using Fortnox.SDK.Connectors;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests
{
    [TestClass]
    public class TrustedEmailSendersTests
    {
        public FortnoxClient FortnoxClient = TestUtils.DefaultFortnoxClient;

        [TestMethod]
        public void Test_TrustedEmailSenders_CRUD()
        {
            #region Arrange
            #endregion Arrange

            ITrustedEmailSendersConnector connector = FortnoxClient.TrustedEmailSendersConnector;

            var randomAddress = $"{TestUtils.RandomString()}@test.tst";
            #region CREATE
            var newTrustedEmailSender = new TrustedEmailSender()
            {
                Email = randomAddress
            };

            var createdTrustedEmailSender = connector.Create(newTrustedEmailSender);
            Assert.AreEqual(randomAddress, createdTrustedEmailSender.Email);

            #endregion CREATE

            #region UPDATE
            //Not supported
            #endregion UPDATE

            #region READ / GET
            //Single get is not supported, full list is used instead
            var retrievedTrustedEmailSender = connector.GetAll().TrustedSenders.FirstOrDefault(t => t.Id == createdTrustedEmailSender.Id);
            Assert.AreEqual(randomAddress, retrievedTrustedEmailSender?.Email);
            #endregion READ / GET

            #region DELETE

            connector.Delete(createdTrustedEmailSender.Id);

            retrievedTrustedEmailSender = connector.GetAll().TrustedSenders.FirstOrDefault(t => t.Id == createdTrustedEmailSender.Id);
            Assert.AreEqual(null, retrievedTrustedEmailSender);

            #endregion DELETE

            #region Delete arranged resources

            //Add code to delete temporary resources

            #endregion Delete arranged resources
        }
    }
}
