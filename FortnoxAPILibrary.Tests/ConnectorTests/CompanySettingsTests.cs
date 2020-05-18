using FortnoxAPILibrary.Connectors;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.Tests.ConnectorTests
{
    [TestClass]
    public class CompanySettingsTests
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
        public void Test_CompanySettings_CRUD()
        {
            #region Arrange
            //Add code to create required resources
            #endregion Arrange

            ICompanySettingsConnector connector = new CompanySettingsConnector();

            #region CREATE
            //Not Allowed
            #endregion CREATE

            #region UPDATE
            //Not Allowed
            #endregion UPDATE

            #region READ / GET

            var retrievedCompanySettings = connector.Get();
            MyAssert.HasNoError(connector);
            Assert.IsNotNull(retrievedCompanySettings?.Name);

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
