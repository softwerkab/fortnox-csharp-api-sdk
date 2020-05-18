using FortnoxAPILibrary.Connectors;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.Tests.ConnectorTests
{
    [TestClass]
    public class LockedPeriodTests
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
        public void Test_LockedPeriod_CRUD()
        {
            #region Arrange
            //Add code to create required resources
            #endregion Arrange

            ILockedPeriodConnector connector = new LockedPeriodConnector();

            #region CREATE
            //Not Allowed
            #endregion CREATE

            #region UPDATE
            //Not Allowed
            #endregion UPDATE

            #region READ / GET

            var retrievedLockedPeriod = connector.Get();
            MyAssert.HasNoError(connector);
            Assert.IsNotNull(retrievedLockedPeriod);

            Assert.IsNull(retrievedLockedPeriod.EndDate); //No period is locked

            #endregion READ / GET

            #region DELETE
            //Not Allowed
            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }
    }
}
