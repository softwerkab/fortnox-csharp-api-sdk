using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.Tests
{
    [TestClass]
    public class SupplierTests
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
        public void Test_Supplier_CRUD()
        {
            var connector = new SupplierConnector();

            #region CREATE
            var newSupplier = new Supplier()
            {
                Name = "TestSupplier",
                Address1 = "TestStreet 1",
                Address2 = "TestStreet 2",
                ZipCode = "01010",
                City = "Testopolis",
                CountryCode = "SE", //CountryCode needs to be valid
                Email = "testSupplier@test.com",
                Active = false,
                Bank = "TestBank",
                Currency = "SEK",
                Phone1 = "01011111345",
                
            };

            var createdSupplier = connector.Create(newSupplier);
            MyAssert.HasNoError(connector);
            Assert.AreEqual(createdSupplier.Name, "TestSupplier");

            #endregion CREATE

            #region UPDATE

            createdSupplier.Name = "UpdatedTestSupplier";

            var updatedSupplier = connector.Update(createdSupplier);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedTestSupplier", updatedSupplier.Name);

            #endregion UPDATE

            #region READ / GET

            var retrievedSupplier = connector.Get(createdSupplier.SupplierNumber);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedTestSupplier", retrievedSupplier.Name);

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdSupplier.SupplierNumber);
            MyAssert.HasNoError(connector);

            retrievedSupplier = connector.Get(createdSupplier.SupplierNumber);
            Assert.AreEqual(null, retrievedSupplier, "Entity still exists after Delete!");

            #endregion DELETE
        }
    }
}
