using System;
using System.Net;
using System.Xml.Linq;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.Tests.ConnectorTests
{
    [TestClass]
    public class AccountTests
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
        public void Test_Account_CRUD()
        {
            IAccountConnector connector = new AccountConnector();

            #region CREATE
            var newAccount = new Account()
            {
                Description = "Test Account",
                Active = false,
                Number = TestUtils.GetUnusedAccountNumber(),
                CostCenterSettings = CostCenterSettings.Allowed,
                ProjectSettings = ProjectSettings.Allowed,
                SRU = 123
            };

            var createdAccount = connector.Create(newAccount);
            Assert.AreEqual("Test Account", createdAccount.Description);

            #endregion CREATE

            #region UPDATE

            createdAccount.Description = "Updated Test Account";

            var updatedAccount = connector.Update(createdAccount); 
            Assert.AreEqual("Updated Test Account", updatedAccount.Description);

            #endregion UPDATE

            #region READ / GET

            var retrievedAccount = connector.Get(createdAccount.Number);
            Assert.AreEqual("Updated Test Account", retrievedAccount.Description);

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdAccount.Number);

            Assert.ThrowsException<FortnoxApiException>(
                () => connector.Get(createdAccount.Number),
                "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }

        [TestMethod]
        public void Test_Find()
        {
            #region Arrange
            //Add code to create required resources
            #endregion Arrange

            var testKeyMark = TestUtils.RandomInt();

            IAccountConnector connector = new AccountConnector();
            var newAccount = new Account()
            {
                Description = "Test Account",
                Active = false,
                CostCenterSettings = CostCenterSettings.Allowed,
                ProjectSettings = ProjectSettings.Allowed,
                SRU = testKeyMark
            };

            //Add entries
            for (var i = 0; i < 5; i++)
            {
                newAccount.Number = TestUtils.GetUnusedAccountNumber();
                connector.Create(newAccount);
            }

            //Apply base test filter
            var searchSettings = new AccountSearch();
            searchSettings.SRU = testKeyMark.ToString();

            var fullCollection = connector.Find(searchSettings);

            Assert.AreEqual(5, fullCollection.TotalResources);
            Assert.AreEqual(5, fullCollection.Entities.Count);
            Assert.AreEqual(1, fullCollection.TotalPages);

            //Apply Limit
            searchSettings.Limit = 2;
            var limitedCollection = connector.Find(searchSettings);

            Assert.AreEqual(5, limitedCollection.TotalResources);
            Assert.AreEqual(2, limitedCollection.Entities.Count);
            Assert.AreEqual(3, limitedCollection.TotalPages);

            //Delete entries
            foreach (var entry in fullCollection.Entities)
            {
                connector.Delete(entry.Number);
            }
            #region Delete arranged resources

            //Add code to delete temporary resources

            #endregion Delete arranged resources
        }
    }
}
