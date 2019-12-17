using Microsoft.VisualStudio.TestTools.UnitTesting;
using FortnoxAPILibrary.Connectors;

namespace FortnoxAPILibrary.Tests
{
    [TestClass]
    public class OtherTests
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
		public void TestFinicialYear()
		{
            /* Assumes a financial year exists (Financial year can not be deleted, therefore test should not create one */

            var connector = new FinancialYearConnector();
            var finicialYear = connector.Get(1);
            MyAssert.HasNoError(connector); 
        }

        [TestMethod]
        public void Test_CompanySettings_Get()
        {
            var connector = new CompanySettingsConnector();
            var settings = connector.Get();
            MyAssert.HasNoError(connector);
            Assert.IsNotNull(settings?.Name);
        }

        [TestMethod]
        public void Test_LockedPeriod_Get()
        {
            var connector = new LockedPeriodConnector();
            var period = connector.Get();
            MyAssert.HasNoError(connector);
            Assert.IsNotNull(period);
        }
    }
}
