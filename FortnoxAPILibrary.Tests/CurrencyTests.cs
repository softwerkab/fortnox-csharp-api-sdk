using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.Tests
{
    [TestClass]
    public class CurrencyTests
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
        public void Test_Currency_CRUD()
        {
            var connector = new CurrencyConnector();

            //Random currency code is not accepted by the server, therefore "SKK" is used.
            if (connector.Get("SKK") != null) //Delete currency if already exists
                connector.Delete("SKK");

            #region CREATE
            var newCurrency = new Currency()
            {
                Description = "TestCurrency",
                Code = "SKK",
                BuyRate = "1.11",
                SellRate = "1.21"
            };


            var createdCurrency = connector.Create(newCurrency);
            MyAssert.HasNoError(connector);
            Assert.AreEqual(createdCurrency.Description, "TestCurrency");

            #endregion CREATE

            #region UPDATE

            createdCurrency.Description = "UpdatedTestCurrency";

            var updatedCurrency = connector.Update(createdCurrency);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedTestCurrency", updatedCurrency.Description);

            #endregion UPDATE

            #region READ / GET

            var retrievedCurrency = connector.Get(createdCurrency.Code);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedTestCurrency", retrievedCurrency.Description);

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdCurrency.Code);
            MyAssert.HasNoError(connector);

            retrievedCurrency = connector.Get(createdCurrency.Code);
            Assert.AreEqual(null, retrievedCurrency, "Entity still exists after Delete!");

            #endregion DELETE
        }
    }
}
