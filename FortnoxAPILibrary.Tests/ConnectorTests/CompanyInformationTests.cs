using FortnoxAPILibrary.Connectors;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.Tests.ConnectorTests
{
    [TestClass]
    public class CompanyInformationTests
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
        public void Test_CompanyInformation_CRUD()
        {
            #region Arrange
            //Add code to create required resources
            #endregion Arrange

            ICompanyInformationConnector connector = new CompanyInformationConnector();

            #region CREATE
            //Not Allowed
            #endregion CREATE

            #region UPDATE
            //Not Allowed

            #endregion UPDATE

            #region READ / GET

            var retrievedCompanyInformation = connector.Get();
            MyAssert.HasNoError(connector);
            Assert.IsNotNull(retrievedCompanyInformation?.CompanyName);

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
