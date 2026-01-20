using System;
using System.Linq;
using System.Threading.Tasks;
using Fortnox.SDK;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Exceptions;
using Fortnox.SDK.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests;

[TestClass]
public class ProjectTests
{
    private FortnoxClient FortnoxClient;

    [TestInitialize]
    public async Task TestInitialize()
    {
        FortnoxClient ??= await TestClient.GetFortnoxClient();
    }

    [TestMethod]
    public async Task Test_Project_CRUD()
    {
        #region Arrange
        //Add code to create required resources
        #endregion Arrange

        var connector = FortnoxClient.ProjectConnector;

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

        var createdProject = await connector.CreateAsync(newProject);
        Assert.AreEqual("TestProject", createdProject.Description);

        #endregion CREATE

        #region UPDATE

        createdProject.Description = "UpdatedProject";

        var updatedProject = await connector.UpdateAsync(createdProject);
        Assert.AreEqual("UpdatedProject", updatedProject.Description);

        #endregion UPDATE

        #region READ / GET

        var retrievedProject = await connector.GetAsync(createdProject.ProjectNumber);
        Assert.AreEqual("UpdatedProject", retrievedProject.Description);

        #endregion READ / GET

        #region DELETE

        await connector.DeleteAsync(createdProject.ProjectNumber);

        await Assert.ThrowsExceptionAsync<FortnoxApiException>(
            async () => await connector.GetAsync(createdProject.ProjectNumber),
            "Entity still exists after Delete!");

        #endregion DELETE

        #region Delete arranged resources
        //Add code to delete temporary resources
        #endregion Delete arranged resources
    }

    [TestMethod]
    public async Task Test_Project_Find()
    {
        #region Arrange
        //Add code to create required resources
        #endregion Arrange

        var connector = FortnoxClient.ProjectConnector;
        var existingEntries = (await connector.FindAsync(null)).Entities.Count;
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
            await connector.CreateAsync(newProject);
        }

        //No filter supported
        var fullCollection = await connector.FindAsync(null);

        Assert.AreEqual(existingEntries + 5, fullCollection.Entities.Count);
        Assert.AreEqual(5, fullCollection.Entities.Count(e => e.Description == testKeyMark));

        //Apply Limit
        var searchSettings = new ProjectSearch();
        searchSettings.Limit = 2;
        var limitedCollection = await connector.FindAsync(searchSettings);

        Assert.AreEqual(existingEntries + 5, limitedCollection.TotalResources);
        Assert.AreEqual(2, limitedCollection.Entities.Count);

        //Delete entries
        foreach (var entry in fullCollection.Entities)
        {
            await connector.DeleteAsync(entry.ProjectNumber);
        }

        #region Delete arranged resources
        //Add code to delete temporary resources
        #endregion Delete arranged resources
    }

    [TestMethod]
    public async Task Test_Project_Find_By_Description()
    {
        #region Arrange
        //Add code to create required resources
        #endregion Arrange

        var connector = FortnoxClient.ProjectConnector;
        var existingEntries = (await connector.FindAsync(null)).Entities.Count;
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
            await connector.CreateAsync(newProject);
        var otherDescription = TestUtils.RandomString();
        newProject.Description = otherDescription;
        for (var i = 0; i < 5; i++)
            await connector.CreateAsync(newProject);

        var fullCollection = await connector.FindAsync(null);

        Assert.AreEqual(existingEntries + 5 + 5, fullCollection.Entities.Count);
        Assert.AreEqual(5, fullCollection.Entities.Count(e => e.Description == description));
        Assert.AreEqual(5, fullCollection.Entities.Count(e => e.Description == otherDescription));

        //Apply filter
        var searchSettings = new ProjectSearch();
        searchSettings.Description = otherDescription;
        var filteredCollection = await connector.FindAsync(searchSettings);

        Assert.AreEqual(5, filteredCollection.TotalResources);
        Assert.AreEqual(5, filteredCollection.Entities.Count);

        //Delete entries
        foreach (var entry in fullCollection.Entities)
        {
            await connector.DeleteAsync(entry.ProjectNumber);
        }

        #region Delete arranged resources
        //Add code to delete temporary resources
        #endregion Delete arranged resources
    }
}