using System;
using System.Linq;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.Tests.ConnectorTests
{
    [TestClass]
    public class ProjectTests
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
        public void Test_Project_CRUD()
        {
            #region Arrange
            //Add code to create required resources
            #endregion Arrange

            IProjectConnector connector = new ProjectConnector();

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
            MyAssert.HasNoError(connector);
            Assert.AreEqual("TestProject", createdProject.Description);

            #endregion CREATE

            #region UPDATE

            createdProject.Description = "UpdatedProject";

            var updatedProject = connector.Update(createdProject); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedProject", updatedProject.Description);

            #endregion UPDATE

            #region READ / GET

            var retrievedProject = connector.Get(createdProject.ProjectNumber);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedProject", retrievedProject.Description);

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdProject.ProjectNumber);
            MyAssert.HasNoError(connector);

            retrievedProject = connector.Get(createdProject.ProjectNumber);
            Assert.AreEqual(null, retrievedProject, "Entity still exists after Delete!");

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

            IProjectConnector connector = new ProjectConnector();
            var existingEntries = connector.Find().Entities.Count;
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
            var fullCollection = connector.Find();
            MyAssert.HasNoError(connector);

            Assert.AreEqual(existingEntries + 5, fullCollection.Entities.Count);
            Assert.AreEqual(5, fullCollection.Entities.Count(e => e.Description == testKeyMark));

            //Apply Limit
            connector.Limit = 2;
            var limitedCollection = connector.Find();
            MyAssert.HasNoError(connector);

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
    }
}
