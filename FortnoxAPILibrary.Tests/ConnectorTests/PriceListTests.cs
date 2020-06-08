using System.Linq;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.Tests.ConnectorTests
{
    [TestClass]
    public class PriceListTests
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
        public void Test_PriceList_CRUD()
        {
            #region Arrange
            #endregion Arrange

            IPriceListConnector connector = new PriceListConnector();

            #region CREATE
            var newPriceList = new PriceList()
            {
                Code = "TST_PR",
                Description = "TestPriceList",
                Comments = "Some comments"
            };

            var alreadyExists = new PriceListConnector().Get("TST_PR") != null; //already created in previous test run

            var createdPriceList = alreadyExists ? connector.Update(newPriceList) : connector.Create(newPriceList);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("TestPriceList", createdPriceList.Description);

            #endregion CREATE

            #region UPDATE

            createdPriceList.Description = "UpdatedTestPriceList";

            var updatedPriceList = connector.Update(createdPriceList); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedTestPriceList", updatedPriceList.Description);

            #endregion UPDATE

            #region READ / GET

            var retrievedPriceList = connector.Get(createdPriceList.Code);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedTestPriceList", retrievedPriceList.Description);

            #endregion READ / GET

            #region DELETE
            //Not available
            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }

        [TestMethod]
        public void Test_Find()
        {
            IPriceListConnector connector = new PriceListConnector();

            var newPriceList = new PriceList()
            {
                Description = "TestPriceList",
                Comments = "EntryForFindRequest"
            };

            for (var i = 0; i < 5; i++)
            {
                newPriceList.Code = "T" + i;
                if (connector.Get(newPriceList.Code) == null) //not exists
                    connector.Create(newPriceList);
                else
                    connector.Update(newPriceList);
                MyAssert.HasNoError(connector);
            }

            //Apply filter -> filter on Comments or Code not working
            //connector.Code = "t";
            //connector.Comments = "EntryForFindRequest";
            var fullCollection = connector.Find();
            MyAssert.HasNoError(connector);

            //Assert.AreEqual(5, fullCollection.TotalResources);
            //Assert.AreEqual(5, fullCollection.Entities.Count);

            Assert.AreEqual(5, fullCollection.Entities.Count(e => e.Comments == "EntryForFindRequest"));

            //Apply Limit
            connector.Limit = 2;
            var limitedCollection = connector.Find();
            MyAssert.HasNoError(connector);

            //Assert.AreEqual(5, limitedCollection.TotalResources);
            Assert.AreEqual(2, limitedCollection.Entities.Count);
            //Assert.AreEqual(3, limitedCollection.TotalPages);
        }
    }
}
