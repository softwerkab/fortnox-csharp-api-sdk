using System.Collections.Generic;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.Tests.ConnectorTests
{
    [TestClass]
    public class LabelTests
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
        public void Test_Label_CRUD()
        {
            #region Arrange
            //Add code to create required resources
            #endregion Arrange

            ILabelConnector connector = new LabelConnector();

            var randomLabel = TestUtils.RandomString();

            #region CREATE
            var newLabel = new Label()
            {
                Description = randomLabel
            };

            var createdLabel = connector.Create(newLabel);
            MyAssert.HasNoError(connector);
            Assert.AreEqual(randomLabel, createdLabel.Description);

            #endregion CREATE

            #region UPDATE

            var updatedRandomLabel = TestUtils.RandomString();
            createdLabel.Description = updatedRandomLabel;

            var updatedLabel = connector.Update(createdLabel); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual(updatedRandomLabel, updatedLabel.Description);

            #endregion UPDATE

            #region READ / GET
            //Not allowed to read single label
            #endregion READ / GET

            #region DELETE

            connector.Delete(createdLabel.Id);
            MyAssert.HasNoError(connector);

            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }

        [TestMethod]
        public void Test_Find()
        {
            ILabelConnector connector = new LabelConnector();

            var existingCount = connector.Find().Entities.Count;

            var createdEntries = new List<Label>();
            //Add entries
            for (var i = 0; i < 5; i++)
            {
                var createdEntry = connector.Create(new Label() {Description = TestUtils.RandomString()});
                createdEntries.Add(createdEntry);
            }

            //Filter not supported
            var fullCollection = connector.Find();
            MyAssert.HasNoError(connector);

            Assert.AreEqual(existingCount + 5, fullCollection.Entities.Count);

            //Limit not supported
            
            //Delete entries
            foreach (var entry in createdEntries)
            {
                connector.Delete(entry.Id);
            }
        }
    }
}
