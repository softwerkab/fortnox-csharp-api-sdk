using Fortnox.SDK;
using Fortnox.SDK.Connectors;
using Fortnox.SDK.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests
{
    [TestClass]
    public class LockedPeriodTests
    {
        public FortnoxClient FortnoxClient = TestUtils.DefaultFortnoxClient;

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
