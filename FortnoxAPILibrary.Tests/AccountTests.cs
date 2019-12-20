using Microsoft.VisualStudio.TestTools.UnitTesting;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;

namespace FortnoxAPILibrary.Tests
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
            var connector = new AccountConnector();
            if (connector.Get("8454") != null) //Delete if already exists
                connector.Delete("8454");

            #region CREATE
            var newAccount = new Account
            {
                Description = "Test Account",
                Active = "false",
                Number = "8454",
                CostCenterSettings = CostCenterSettingsValue.ALLOWED,
                ProjectSettings = ProjectSettingsValue.ALLOWED,
                SRU = "123"
            };

            //Act
            var createdAccount = connector.Create(newAccount);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("Test Account", createdAccount.Description);

            #endregion CREATE

            #region UPDATE

            createdAccount.Description = "Updated Test Account";

            var updatedAccount = connector.Update(createdAccount);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("Updated Test Account", updatedAccount.Description);

            #endregion UPDATE

            #region READ / GET

            var retrievedAccount = connector.Get(createdAccount.Number);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("Updated Test Account", retrievedAccount.Description);

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdAccount.Number);
            MyAssert.HasNoError(connector);

            retrievedAccount = connector.Get(createdAccount.Number);
            Assert.AreEqual(null, retrievedAccount, "Entity still exists after Delete!");

            #endregion DELETE
        }
    }
}
