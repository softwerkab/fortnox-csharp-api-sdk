using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fortnox.SDK;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Exceptions;
using Fortnox.SDK.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests
{
    [TestClass]
    public class ModeOfPaymentTests
    {
        public FortnoxClient FortnoxClient = TestUtils.DefaultFortnoxClient;

        [TestMethod]
        public async Task Test_ModeOfPayment_CRUD()
        {
            #region Arrange
            var tmpAccount = await FortnoxClient.AccountConnector.CreateAsync(new Account(){Description = "TestAccount", Number = TestUtils.GetUnusedAccountNumber()});
            #endregion Arrange

            var connector = FortnoxClient.ModeOfPaymentConnector;

            #region CREATE
            var newModeOfPayment = new ModeOfPayment()
            {
                Description = "TestMode",
                AccountNumber = tmpAccount.Number,
                Code = "TEST_MODE",
            };

            var createdModeOfPayment = await connector.CreateAsync(newModeOfPayment);
            Assert.AreEqual("TestMode", createdModeOfPayment.Description);

            #endregion CREATE

            #region UPDATE

            createdModeOfPayment.Description = "UpdatedMode";

            var updatedModeOfPayment = await connector.UpdateAsync(createdModeOfPayment); 
            Assert.AreEqual("UpdatedMode", updatedModeOfPayment.Description);

            #endregion UPDATE

            #region READ / GET

            var retrievedModeOfPayment = await connector.GetAsync(createdModeOfPayment.Code);
            Assert.AreEqual("UpdatedMode", retrievedModeOfPayment.Description);

            #endregion READ / GET

            #region DELETE

            await connector.DeleteAsync(createdModeOfPayment.Code);

            Assert.ThrowsException<FortnoxApiException>(
                () => connector.Get(createdModeOfPayment.Code),
                "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            await FortnoxClient.AccountConnector.DeleteAsync(tmpAccount.Number);
            #endregion Delete arranged resources
        }

        [TestMethod]
        public async Task Test_Find()
        {
            #region Arrange
            var tmpAccount = await FortnoxClient.AccountConnector.CreateAsync(new Account() { Description = "TestAccount", Number = TestUtils.GetUnusedAccountNumber() });
            #endregion Arrange

            var connector = FortnoxClient.ModeOfPaymentConnector;

            var existingCount = (await connector.FindAsync(null)).Entities.Count;
            var testKeyMark = TestUtils.RandomString();

            var createdEntries = new List<ModeOfPayment>();
            //Add entries
            for (var i = 0; i < 5; i++)
            {
                var createdEntry = await connector.CreateAsync(new ModeOfPayment() { Code = TestUtils.RandomString(), Description = testKeyMark, AccountNumber = tmpAccount.Number });
                createdEntries.Add(createdEntry);
            }

            //Filter not supported
            var fullCollection = await connector.FindAsync(null);

            Assert.AreEqual(existingCount + 5, fullCollection.Entities.Count);
            Assert.AreEqual(5, fullCollection.Entities.Count(e => e.Description == testKeyMark));

            //Apply Limit
            var searchSettings = new ModeOfPaymentSearch();
            searchSettings.Limit = 2;
            var limitedCollection = await connector.FindAsync(searchSettings);

            Assert.AreEqual(existingCount + 5, limitedCollection.TotalResources);
            Assert.AreEqual(2, limitedCollection.Entities.Count);

            //Delete entries
            foreach (var entry in createdEntries)
            {
                await connector.DeleteAsync(entry.Code);
            }

            #region Delete arranged resources
            await FortnoxClient.AccountConnector.DeleteAsync(tmpAccount.Number);
            #endregion Delete arranged resources
        }
    }
}
