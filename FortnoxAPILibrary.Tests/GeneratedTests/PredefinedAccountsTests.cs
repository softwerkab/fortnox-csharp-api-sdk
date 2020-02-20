using System;
using System.Collections.Generic;
using System.Linq;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.GeneratedTests
{
    [TestClass]
    public class PredefinedAccountsTests
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
        public void Test_PredefinedAccounts_CRUD()
        {
            var connector = new PredefinedAccountsConnector();
            var list = connector.Find().Entities;
            //Get
            var bygAccount = connector.Get("CONSTRUCTION_DEB");
            MyAssert.HasNoError(connector);
            Assert.AreEqual(2647, bygAccount.Account);

            var patentAccount = connector.Get("PRODUCT_DEB");
            MyAssert.HasNoError(connector);
            Assert.AreEqual(2645, patentAccount.Account);

            //Update
            patentAccount.Account = bygAccount.Account;
            connector.Update(patentAccount);
            MyAssert.HasNoError(connector);
            Assert.AreEqual(2647, patentAccount.Account);

            //Revert
            patentAccount.Account = 2645;
            connector.Update(patentAccount);
            MyAssert.HasNoError(connector);
            Assert.AreEqual(2645, patentAccount.Account);
        }
    }
}
