using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fortnox.SDK;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Exceptions;
using Fortnox.SDK.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests
{
    [TestClass]
    public class UnitTests
    {
        public FortnoxClient FortnoxClient = TestUtils.DefaultFortnoxClient;

        [TestMethod]
        public async Task Test_Unit_CRUD()
        {
            #region Arrange
            //Add code to create required resources
            #endregion Arrange

            var connector = FortnoxClient.UnitConnector;

            #region CREATE
            var newUnit = new Unit()
            {
                Code = "TST",
                Description = "TestUnit"
            };

            var createdUnit = await connector.CreateAsync(newUnit);
            Assert.AreEqual("TestUnit", createdUnit.Description);

            #endregion CREATE

            #region UPDATE

            createdUnit.Description = "UpdatedTestUnit";

            var updatedUnit = await connector.UpdateAsync(createdUnit);
            Assert.AreEqual("UpdatedTestUnit", updatedUnit.Description);

            #endregion UPDATE

            #region READ / GET

            var retrievedUnit = await connector.GetAsync(createdUnit.Code);
            Assert.AreEqual("UpdatedTestUnit", retrievedUnit.Description);

            #endregion READ / GET

            #region DELETE

            await connector.DeleteAsync(createdUnit.Code);

            Assert.ThrowsException<FortnoxApiException>(
                () => connector.Get(createdUnit.Code),
                "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }

        [TestMethod]
        public async Task Test_Find()
        {
            var connector = FortnoxClient.UnitConnector;

            var existingCount = (await connector.FindAsync(null)).TotalResources;

            var marks = TestUtils.RandomString();
            var createdEntries = new List<Unit>();
            //Add entries
            for (var i = 0; i < 5; i++)
            {
                var createdEntry = await connector.CreateAsync(new Unit() { Code = marks + i, Description = TestUtils.RandomString() });
                createdEntries.Add(createdEntry);
            }

            //Filter not supported
            var fullCollection = await connector.FindAsync(null);

            Assert.AreEqual(existingCount + 5, fullCollection.TotalResources);
            Assert.AreEqual(5, fullCollection.Entities.Count(x => x.Code.StartsWith(marks)));

            //Limit not supported
            var searchSettings = new UnitSearch();
            searchSettings.Limit = 2;
            var limitedCollection = await connector.FindAsync(searchSettings);
            Assert.AreEqual(2, limitedCollection.Entities.Count);

            //Delete entries
            foreach (var entry in createdEntries)
            {
                await connector.DeleteAsync(entry.Code);
            }
        }
    }
}
