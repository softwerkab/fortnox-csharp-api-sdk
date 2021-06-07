using System;
using System.Linq;
using Fortnox.SDK;
using Fortnox.SDK.Connectors;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Exceptions;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests
{
    [TestClass]
    public class ProjectTests
    {
        public FortnoxClient FortnoxClient = TestUtils.DefaultFortnoxClient;

        [TestMethod]
        public void Test_Project_CRUD()
        {
            #region Arrange
            //Add code to create required resources
            #endregion Arrange

            IProjectConnector connector = FortnoxClient.ProjectConnector;

            #region CREATE
            var newProject = new Project()
            {
                Description = "TestProject",
                Status = Status.Ongoing,
                StartDate = new DateTime(2019, 10, 10),
                EndDate = new DateTime(2021, 10, 10),
                ProjectLeader = "TestProjectLeader",
                ContactPerson = "TestContactPerson",
                Comments = "TestComments"
            };

            var createdProject = connector.Create(newProject);
            Assert.AreEqual("TestProject", createdProject.Description);

            #endregion CREATE

            #region UPDATE

            createdProject.Description = "UpdatedProject";

            var updatedProject = connector.Update(createdProject); 
            Assert.AreEqual("UpdatedProject", updatedProject.Description);

            #endregion UPDATE

            #region READ / GET

            var retrievedProject = connector.Get(createdProject.ProjectNumber);
            Assert.AreEqual("UpdatedProject", retrievedProject.Description);

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdProject.ProjectNumber);

            Assert.ThrowsException<FortnoxApiException>(
                () => connector.Get(createdProject.ProjectNumber),
                "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }

        [TestMethod]
        public void Test_Find()
        {
            #region Arrange
            //Add code to create required resources
            #endregion Arrange

            IProjectConnector connector = FortnoxClient.ProjectConnector;
            var existingEntries = connector.Find(null).Entities.Count;
            var testKeyMark = TestUtils.RandomString();

            var newProject = new Project()
            {
                Description = testKeyMark,
                Status = Status.Ongoing,
                StartDate = new DateTime(2019, 10, 10),
                EndDate = new DateTime(2021, 10, 10),
                ProjectLeader = "TestProjectLeader",
                ContactPerson = "TestContactPerson",
                Comments = "TestComments"
            };

            //Add entries
            for (var i = 0; i < 5; i++)
            {
                connector.Create(newProject);
            }

            //No filter supported
            var fullCollection = connector.Find(null);

            Assert.AreEqual(existingEntries + 5, fullCollection.Entities.Count);
            Assert.AreEqual(5, fullCollection.Entities.Count(e => e.Description == testKeyMark));

            //Apply Limit
            var searchSettings = new ProjectSearch();
            searchSettings.Limit = 2;
            var limitedCollection = connector.Find(searchSettings);

            Assert.AreEqual(existingEntries + 5, limitedCollection.TotalResources);
            Assert.AreEqual(2, limitedCollection.Entities.Count);

            //Delete entries
            foreach (var entry in fullCollection.Entities)
            {
                connector.Delete(entry.ProjectNumber);
            }

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }

        [TestMethod]
        public void Test_Find_By_Description()
        {
            #region Arrange
            //Add code to create required resources
            #endregion Arrange

            IProjectConnector connector = FortnoxClient.ProjectConnector;
            var existingEntries = connector.Find(null).Entities.Count;
            var description = TestUtils.RandomString();

            var newProject = new Project()
            {
                Description = description,
                Status = Status.Ongoing,
                StartDate = new DateTime(2019, 10, 10),
                EndDate = new DateTime(2021, 10, 10),
                ProjectLeader = "TestProjectLeader",
                ContactPerson = "TestContactPerson",
                Comments = "TestComments"
            };

            //Add entries
            for (var i = 0; i < 5; i++)
                connector.Create(newProject);
            var otherDescription = TestUtils.RandomString();
            newProject.Description = otherDescription;
            for (var i = 0; i < 5; i++)
                connector.Create(newProject);

            var fullCollection = connector.Find(null);

            Assert.AreEqual(existingEntries + 5 + 5, fullCollection.Entities.Count);
            Assert.AreEqual(5, fullCollection.Entities.Count(e => e.Description == description));
            Assert.AreEqual(5, fullCollection.Entities.Count(e => e.Description == otherDescription));

            //Apply filter
            var searchSettings = new ProjectSearch();
            searchSettings.Description = otherDescription;
            var filteredCollection = connector.Find(searchSettings);

            Assert.AreEqual(5, filteredCollection.TotalResources);
            Assert.AreEqual(5, filteredCollection.Entities.Count);

            //Delete entries
            foreach (var entry in fullCollection.Entities)
            {
                connector.Delete(entry.ProjectNumber);
            }

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }
    }
}
