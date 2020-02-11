using System;
using System.Collections.Generic;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.GeneratedTests
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

            var connector = new ProjectConnector();

            #region CREATE
            var newProject = new Project()
            {
                //TODO: Populate Entity
            };

            var createdProject = connector.Create(newProject);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("PropertyValue", createdProject.SomeProperty); //TODO: Adapt

            #endregion CREATE

            #region UPDATE

            createdProject.SomeProperty = "UpdatedPropertyValue"; //TODO: Adapt

            var updatedProject = connector.Update(createdProject); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", updatedProject.SomeProperty); //TODO: Adapt

            #endregion UPDATE

            #region READ / GET

            var retrievedProject = connector.Get(createdProject.ProjectNumber); //TODO: Check ID property
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", retrievedProject.SomeProperty); //TODO: Adapt

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdProject.ProjectNumber); //TODO: Check ID property
            MyAssert.HasNoError(connector);

            retrievedProject = connector.Get(createdProject.ProjectNumber); //TODO: Check ID property
            Assert.AreEqual(null, retrievedProject, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }
    }
}
