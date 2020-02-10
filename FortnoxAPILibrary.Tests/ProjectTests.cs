using System;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.Tests
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
            var connector = new ProjectConnector();

            #region CREATE
            var newProject = new Project()
            {
                Description = "TestProject",
                Status =  Status.ONGOING,
                StartDate = new DateTime(2019, 10, 10),
                EndDate = new DateTime(2021, 10, 10),
                ProjectLeader = "TestProjectLeader",
                ContactPerson = "TestContactPerson",
                Comments = "TestComments"
            };

            var createdProject = connector.Create(newProject);
            MyAssert.HasNoError(connector);
            Assert.AreEqual(createdProject.Description, "TestProject");

            #endregion CREATE

            #region UPDATE

            createdProject.Description = "UpdatedTestProject";

            var updatedProject = connector.Update(createdProject);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedTestProject", updatedProject.Description);

            #endregion UPDATE

            #region READ / GET

            var retrievedProject = connector.Get(createdProject.ProjectNumber);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedTestProject", retrievedProject.Description);

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdProject.ProjectNumber);
            MyAssert.HasNoError(connector);

            retrievedProject = connector.Get(createdProject.ProjectNumber);
            Assert.AreEqual(null, retrievedProject, "Entity still exists after Delete!");

            #endregion DELETE
        }
    }
}
