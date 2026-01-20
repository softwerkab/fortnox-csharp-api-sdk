using System.IO;
using System.Threading.Tasks;
using Fortnox.SDK;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests;

[TestClass]
public class ArchiveTests
{
    private FortnoxClient FortnoxClient;
    private ArchiveFolder testRootFolder;

    [TestInitialize]
    public async Task TestInitialize()
    {
        FortnoxClient ??= await TestClient.GetFortnoxClient();
        var connector = FortnoxClient.ArchiveConnector;
        testRootFolder = await connector.GetFolderAsync("TestArchive");
    }

    [TestMethod]
    public async Task Test_File_Upload_Download_Delete()
    {
        var connector = FortnoxClient.ArchiveConnector;

        var data = Resource.fortnox_image;
        var randomFileName = TestUtils.RandomString() + ".txt";

        var fortnoxFile = await connector.UploadFileAsync(randomFileName, data, testRootFolder.Name);

        var fileData = await connector.DownloadFileAsync(fortnoxFile.Id);
        CollectionAssert.AreEqual(data, fileData);

        await connector.DeleteFileAsync(fortnoxFile.Id);
    }

    [TestMethod]
    public async Task Test_Folder_Create_Get_Delete()
    {
        var connector = FortnoxClient.ArchiveConnector;
        var randomFolderName = TestUtils.RandomString();

        var createdFolder = await connector.CreateFolderAsync(randomFolderName, testRootFolder.Name);

        var retrievedFolder = await connector.GetFolderAsync(createdFolder.Id);
        Assert.AreEqual(randomFolderName, retrievedFolder.Name);

        await connector.DeleteFileAsync(retrievedFolder.Id);
    }

    [TestMethod]
    public async Task Test_Folder_Delete_ByPath()
    {
        var connector = FortnoxClient.ArchiveConnector;
        var randomFolderName = TestUtils.RandomString();

        var createdFolder = await connector.CreateFolderAsync(randomFolderName, testRootFolder.Name);

        var retrievedFolder = await connector.GetFolderAsync(createdFolder.Id);
        Assert.AreEqual(randomFolderName, retrievedFolder.Name);

        await connector.DeleteFolderAsync(testRootFolder.Name + @"\" + retrievedFolder.Name);
    }

    [TestMethod]
    public async Task Test_GetSupplierFolder()
    {
        var connector1 = FortnoxClient.InboxConnector;
        var folder1 = await connector1.GetFolderAsync(StaticFolders.SupplierInvoices);
        Assert.AreEqual("inbox_s", folder1.Id);

        var connector2 = FortnoxClient.ArchiveConnector;
        var folder2 = await connector2.GetFolderAsync(StaticFolders.SupplierInvoices);
        Assert.AreEqual("inbox_s", folder2.Id);
    }

    [TestMethod]
    public async Task Test_Upload_Download_Delete_From_Static_Folder()
    {
        var connector = FortnoxClient.ArchiveConnector;

        var data = Resource.fortnox_image;
        var randomFileName = TestUtils.RandomString() + ".txt";

        var fortnoxFile = await connector.UploadFileAsync(randomFileName, data, StaticFolders.SupplierInvoices);

        var fileData = await connector.DownloadFileAsync(fortnoxFile.Id);
        CollectionAssert.AreEqual(data, fileData);

        await connector.DeleteFileAsync(fortnoxFile.Id);
    }

    [TestMethod]
    public async Task Test_ManyRequests()
    {
        var connector = FortnoxClient.ArchiveConnector;

        for (var i = 0; i < 20; i++)
        {
            var data = Resource.fortnox_image;
            var randomFileName = TestUtils.RandomString() + ".txt";

            var fortnoxFile = await connector.UploadFileAsync(randomFileName, data, StaticFolders.Root);

            var fileData = await connector.DownloadFileAsync(fortnoxFile.Id);
            CollectionAssert.AreEqual(data, fileData);

            await connector.DeleteFileAsync(fortnoxFile.Id);
        }
    }

    [TestMethod]
    public async Task Test_Get_Root()
    {
        var connector = FortnoxClient.ArchiveConnector;
        var rootFolder = await connector.GetRootAsync();
        Assert.AreEqual("root", rootFolder.Id);
    }

    [TestMethod]
    public async Task Test_Download_To_Local_System()
    {
        var connector = FortnoxClient.ArchiveConnector;

        //Arrange
        var data = Resource.fortnox_image;
        var randomFileName = TestUtils.RandomString() + ".txt";

        var fortnoxFile = await connector.UploadFileAsync(randomFileName, data, testRootFolder.Name);

        //Act
        var localFilePath = TestUtils.GenerateTmpFilePath();
        var fileInfo = await connector.DownloadFileAsync(fortnoxFile.Id, localFilePath);
        Assert.IsTrue(fileInfo.Exists);
        Assert.AreEqual(data.Length, fileInfo.Length);

        //Clean
        File.Delete(localFilePath);
        await connector.DeleteFileAsync(fortnoxFile.Id);
    }

    [TestMethod]
    public async Task Test_Upload_From_Local_System()
    {
        var connector = FortnoxClient.ArchiveConnector;

        //Arrange
        var data = Resource.fortnox_image;
        var localFilePath = TestUtils.GenerateTmpFilePath();
        await File.WriteAllBytesAsync(localFilePath, data);

        //Act
        var fortnoxFile = await connector.UploadFileAsync(localFilePath, testRootFolder.Name);
        Assert.AreEqual(data.Length, int.Parse(fortnoxFile.Size));

        //Clean
        File.Delete(localFilePath);
        await connector.DeleteFileAsync(fortnoxFile.Id);
    }
}