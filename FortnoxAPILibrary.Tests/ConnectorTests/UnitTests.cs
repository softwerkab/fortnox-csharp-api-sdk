using System.Collections.Generic;
using System.Linq;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.Tests.ConnectorTests
{
    [TestClass]
    public class UnitTests
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
        public void Test_Unit_CRUD()
        {
            #region Arrange
            //Add code to create required resources
            #endregion Arrange

            IUnitConnector connector = new UnitConnector();

            #region CREATE
            var newUnit = new Unit()
            {
                Code = "TST",
                Description = "TestUnit"
            };

            var createdUnit = connector.Create(newUnit);
            Assert.AreEqual("TestUnit", createdUnit.Description);

            #endregion CREATE

            #region UPDATE

            createdUnit.Description = "UpdatedTestUnit";

            var updatedUnit = connector.Update(createdUnit); 
            Assert.AreEqual("UpdatedTestUnit", updatedUnit.Description);

            #endregion UPDATE

            #region READ / GET

            var retrievedUnit = connector.Get(createdUnit.Code);
            Assert.AreEqual("UpdatedTestUnit", retrievedUnit.Description);

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdUnit.Code);

            Assert.ThrowsException<FortnoxApiException>(
                () => connector.Get(createdUnit.Code),
                "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }

        [TestMethod]
        public void Test_Find()
        {
            IUnitConnector connector = new UnitConnector();

            var existingCount = connector.Find(null).TotalResources;

            var marks = TestUtils.RandomString();
            var createdEntries = new List<Unit>();
            //Add entries
            for (var i = 0; i < 5; i++)
            {
                var createdEntry = connector.Create(new Unit() { Code = marks + i, Description = TestUtils.RandomString() });
                createdEntries.Add(createdEntry);
            }

            //Filter not supported
            var fullCollection = connector.Find(null);

            Assert.AreEqual(existingCount + 5, fullCollection.TotalResources);
            Assert.AreEqual(5, fullCollection.Entities.Count(x => x.Code.StartsWith(marks)));

            //Limit not supported
            var searchSettings = new UnitSearch();
            searchSettings.Limit = 2;
            var limitedCollection = connector.Find(searchSettings);
            Assert.AreEqual(2, limitedCollection.Entities.Count);

            //Delete entries
            foreach (var entry in createdEntries)
            {
                connector.Delete(entry.Code);
            }
        }
    }
}
