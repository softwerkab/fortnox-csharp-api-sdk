using System.IO;
using Fortnox.SDK;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests
{
    [TestClass]
    public class ArchiveTests
    {
        public FortnoxClient FortnoxClient = TestUtils.DefaultFortnoxClient;

        private ArchiveFolder testRootFolder;

        [TestInitialize]
        public void Init()
        {
            var connector = FortnoxClient.ArchiveConnector;
            testRootFolder = connector.GetFolder("TestArchive");
        }

        [TestMethod]
        public void Test_File_Upload_Download_Delete()
        {
            var connector = FortnoxClient.ArchiveConnector;

            var data = Resource.fortnox_image;
            var randomFileName = TestUtils.RandomString()+".txt";

            var fortnoxFile = connector.UploadFile(randomFileName, data, testRootFolder.Name);

            var fileData = connector.DownloadFile(fortnoxFile.Id);
            CollectionAssert.AreEqual(data, fileData);

            connector.DeleteFile(fortnoxFile.Id);
        }

        [TestMethod]
        public void Test_Folder_Create_Get_Delete()
        {
            var connector = FortnoxClient.ArchiveConnector;
            var randomFolderName = TestUtils.RandomString();

            var createdFolder = connector.CreateFolder(randomFolderName, testRootFolder.Name);

            var retrievedFolder = connector.GetFolder(createdFolder.Id);
            Assert.AreEqual(randomFolderName, retrievedFolder.Name);

            connector.DeleteFile(retrievedFolder.Id);
        }

        [TestMethod]
        public void Test_Folder_Delete_ByPath()
        {
            var connector = FortnoxClient.ArchiveConnector;
            var randomFolderName = TestUtils.RandomString();

            var createdFolder = connector.CreateFolder(randomFolderName, testRootFolder.Name);

            var retrievedFolder = connector.GetFolder(createdFolder.Id);
            Assert.AreEqual(randomFolderName, retrievedFolder.Name);

            connector.DeleteFolder(testRootFolder.Name + @"\" + retrievedFolder.Name);
        }

        [TestMethod]
        public void Test_GetSupplierFolder()
        {
            var connector1 = FortnoxClient.InboxConnector;
            var folder1 = connector1.GetFolder(StaticFolders.SupplierInvoices);
            Assert.AreEqual("inbox_s", folder1.Id);

            var connector2 = FortnoxClient.ArchiveConnector;
            var folder2 = connector2.GetFolder(StaticFolders.SupplierInvoices);
            Assert.AreEqual("inbox_s", folder2.Id);
        }

        [TestMethod]
        public void Test_Upload_Download_Delete_From_Static_Folder()
        {
            var connector = FortnoxClient.ArchiveConnector;

            var data = Resource.fortnox_image;
            var randomFileName = TestUtils.RandomString() + ".txt";

            var fortnoxFile = connector.UploadFile(randomFileName, data, StaticFolders.SupplierInvoices);

            var fileData = connector.DownloadFile(fortnoxFile.Id);
            CollectionAssert.AreEqual(data, fileData);

            connector.DeleteFile(fortnoxFile.Id);
        }

        [TestMethod]
        public void Test_ManyRequests()
        {
            var connector = FortnoxClient.ArchiveConnector;

            for (var i = 0; i < 20; i++)
            {
                var data = Resource.fortnox_image;
                var randomFileName = TestUtils.RandomString() + ".txt";

                var fortnoxFile = connector.UploadFile(randomFileName, data, StaticFolders.Root);

                var fileData = connector.DownloadFile(fortnoxFile.Id);
                CollectionAssert.AreEqual(data, fileData);

                connector.DeleteFile(fortnoxFile.Id);
            }
        }

        [TestMethod]
        public void Test_Get_Root()
        {
            var connector = FortnoxClient.ArchiveConnector;
            var rootFolder = connector.GetRoot();
            Assert.AreEqual("root", rootFolder.Id);
        }

        [TestMethod]
        public void Test_Download_To_Local_System()
        {
            var connector = FortnoxClient.ArchiveConnector;
            
            //Arrange
            var data = Resource.fortnox_image;
            var randomFileName = TestUtils.RandomString() + ".txt";

            var fortnoxFile = connector.UploadFile(randomFileName, data, testRootFolder.Name);

            //Act
            var localFilePath = TestUtils.GenerateTmpFilePath();
            var fileInfo = connector.DownloadFile(fortnoxFile.Id, localFilePath);
            Assert.IsTrue(fileInfo.Exists);
            Assert.AreEqual(data.Length, fileInfo.Length);

            //Clean
            File.Delete(localFilePath);
            connector.DeleteFile(fortnoxFile.Id);
        }

        [TestMethod]
        public void Test_Upload_From_Local_System()
        {
            var connector = FortnoxClient.ArchiveConnector;

            //Arrange
            var data = Resource.fortnox_image;
            var localFilePath = TestUtils.GenerateTmpFilePath();
            File.WriteAllBytes(localFilePath, data);

            //Act
            var fortnoxFile = connector.UploadFile(localFilePath, testRootFolder.Name);
            Assert.AreEqual(data.Length, int.Parse(fortnoxFile.Size));

            //Clean
            File.Delete(localFilePath);
            connector.DeleteFile(fortnoxFile.Id);
        }
    }
}
