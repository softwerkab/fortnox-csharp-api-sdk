using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.Tests.ConnectorTests
{
    [TestClass]
    public class NoxFinansInvoiceTests
    {
        [TestInitialize]
        public void Init()
        {
            //Set global credentials for SDK
            //--- Open 'TestCredentials.resx' to edit the values ---\\
            ConnectionCredentials.AccessToken = TestCredentials.Access_Token;
            ConnectionCredentials.ClientSecret = TestCredentials.Client_Secret;
        }

        [Ignore("Domain not understood")]
        [TestMethod]
        public void Test_NoxFinansInvoice_CRUD()
        {
            /*#region Arrange
            //Add code to create required resources
            #endregion Arrange

            INoxFinansInvoiceConnector connector = new NoxFinansInvoiceConnector();

            #region CREATE
            var newNoxFinansInvoice = new NoxFinansInvoice()
            {
                //TODO: Populate Entity
            };

            var createdNoxFinansInvoice = connector.Create(newNoxFinansInvoice);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("PropertyValue", createdNoxFinansInvoice.SomeProperty); //TODO: Adapt

            #endregion CREATE

            #region UPDATE

            createdNoxFinansInvoice.SomeProperty = "UpdatedPropertyValue"; //TODO: Adapt

            var updatedNoxFinansInvoice = connector.Update(createdNoxFinansInvoice); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", updatedNoxFinansInvoice.SomeProperty); //TODO: Adapt

            #endregion UPDATE

            #region READ / GET

            var retrievedNoxFinansInvoice = connector.Get(createdNoxFinansInvoice.ID); //TODO: Check ID property
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", retrievedNoxFinansInvoice.SomeProperty); //TODO: Adapt

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdNoxFinansInvoice.ID); //TODO: Check ID property
            MyAssert.HasNoError(connector);

            retrievedNoxFinansInvoice = connector.Get(createdNoxFinansInvoice.ID); //TODO: Check ID property
            Assert.AreEqual(null, retrievedNoxFinansInvoice, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources*/
        }
    }
}
