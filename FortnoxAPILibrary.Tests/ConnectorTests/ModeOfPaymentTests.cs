using System.Collections.Generic;
using System.Linq;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.Tests.ConnectorTests
{
    [TestClass]
    public class ModeOfPaymentTests
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
        public void Test_ModeOfPayment_CRUD()
        {
            #region Arrange
            var tmpAccount = new AccountConnector().Get(0123) ?? new AccountConnector().Create(new Account(){Description = "TestAccount", Number = 0123});
            #endregion Arrange

            IModeOfPaymentConnector connector = new ModeOfPaymentConnector();

            #region CREATE
            var newModeOfPayment = new ModeOfPayment()
            {
                Description = "TestMode",
                AccountNumber = tmpAccount.Number,
                Code = "TEST_MODE",
            };

            var createdModeOfPayment = connector.Create(newModeOfPayment);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("TestMode", createdModeOfPayment.Description);

            #endregion CREATE

            #region UPDATE

            createdModeOfPayment.Description = "UpdatedMode";

            var updatedModeOfPayment = connector.Update(createdModeOfPayment); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedMode", updatedModeOfPayment.Description);

            #endregion UPDATE

            #region READ / GET

            var retrievedModeOfPayment = connector.Get(createdModeOfPayment.Code);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedMode", retrievedModeOfPayment.Description);

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdModeOfPayment.Code);
            MyAssert.HasNoError(connector);

            retrievedModeOfPayment = connector.Get(createdModeOfPayment.Code);
            Assert.AreEqual(null, retrievedModeOfPayment, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            new AccountConnector().Delete(0123);
            #endregion Delete arranged resources
        }

        [TestMethod]
        public void Test_Find()
        {
            #region Arrange
            var tmpAccount = new AccountConnector().Get(0123) ?? new AccountConnector().Create(new Account() { Description = "TestAccount", Number = 0123 });
            #endregion Arrange

            IModeOfPaymentConnector connector = new ModeOfPaymentConnector();

            var existingCount = connector.Find().Entities.Count;
            var testKeyMark = TestUtils.RandomString();

            var createdEntries = new List<ModeOfPayment>();
            //Add entries
            for (var i = 0; i < 5; i++)
            {
                var createdEntry = connector.Create(new ModeOfPayment() { Code = TestUtils.RandomString(), Description = testKeyMark, AccountNumber = tmpAccount.Number });
                createdEntries.Add(createdEntry);
            }

            //Filter not supported
            var fullCollection = connector.Find();
            MyAssert.HasNoError(connector);

            Assert.AreEqual(existingCount + 5, fullCollection.Entities.Count);
            Assert.AreEqual(5, fullCollection.Entities.Count(e => e.Description == testKeyMark));

            //Apply Limit
            connector.Limit = 2;
            var limitedCollection = connector.Find();
            MyAssert.HasNoError(connector);

            Assert.AreEqual(existingCount + 5, limitedCollection.TotalResources);
            Assert.AreEqual(2, limitedCollection.Entities.Count);

            //Delete entries
            foreach (var entry in createdEntries)
            {
                connector.Delete(entry.Code);
            }

            #region Delete arranged resources
            new AccountConnector().Delete(0123);
            #endregion Delete arranged resources
        }
    }
}
