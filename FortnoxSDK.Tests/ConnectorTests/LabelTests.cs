using System.Collections.Generic;
using System.Threading.Tasks;
using Fortnox.SDK;
using Fortnox.SDK.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests
{
    [TestClass]
    public class LabelTests
    {
        public FortnoxClient FortnoxClient = TestUtils.DefaultFortnoxClient;

        [TestMethod]
        public async Task Test_Label_CRUD()
        {
            #region Arrange
            //Add code to create required resources
            #endregion Arrange

            var connector = FortnoxClient.LabelConnector;

            var randomLabel = TestUtils.RandomString();

            #region CREATE
            var newLabel = new Label()
            {
                Description = randomLabel
            };

            var createdLabel = await connector.CreateAsync(newLabel);
            Assert.AreEqual(randomLabel, createdLabel.Description);

            #endregion CREATE

            #region UPDATE

            var updatedRandomLabel = TestUtils.RandomString();
            createdLabel.Description = updatedRandomLabel;

            var updatedLabel = await connector.UpdateAsync(createdLabel);
            Assert.AreEqual(updatedRandomLabel, updatedLabel.Description);

            #endregion UPDATE

            #region READ / GET
            //Not allowed to read single label
            #endregion READ / GET

            #region DELETE

            await connector.DeleteAsync(createdLabel.Id);

            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }

        [TestMethod]
        public async Task Test_Find()
        {
            var connector = FortnoxClient.LabelConnector;

            var existingCount = (await connector.FindAsync(null)).Entities.Count;

            var createdEntries = new List<Label>();
            //Add entries
            for (var i = 0; i < 5; i++)
            {
                var createdEntry = await connector.CreateAsync(new Label() { Description = TestUtils.RandomString() });
                createdEntries.Add(createdEntry);
            }

            //Filter not supported
            var fullCollection = await connector.FindAsync(null);

            Assert.AreEqual(existingCount + 5, fullCollection.Entities.Count);

            //Limit not supported

            //Delete entries
            foreach (var entry in createdEntries)
            {
                await connector.DeleteAsync(entry.Id);
            }
        }
    }
}
