using System;
using System.Collections.Generic;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Tests;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Resources;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.GeneratedTests
{
    [TestClass]
    public class FileTests
    {
        private ArchiveFolder testRootFolder;

        [TestInitialize]
        public void Init()
        {
            //Set global credentials for SDK
            //--- Open 'TestCredentials.resx' to edit the values ---\\
            ConnectionCredentials.AccessToken = TestCredentials.Access_Token;
            ConnectionCredentials.ClientSecret = TestCredentials.Client_Secret;

            IArchiveConnector connector = new ArchiveConnector();
            testRootFolder = connector.GetFolder("TestArchive") ?? connector.CreateFolder("TestArchive");
        }

        [TestMethod]
        public void Test_File_Upload_Download_Delete()
        {
            IArchiveConnector connector = new ArchiveConnector();

            var data = Resource.fortnox_image;
            var randomFileName = TestUtils.RandomString()+".txt";

            var fortnoxFile = connector.UploadFile(randomFileName, data, testRootFolder.Name);
            MyAssert.HasNoError(connector);

            var fileData = connector.DownloadFile(fortnoxFile.Id);
            MyAssert.HasNoError(connector);
            CollectionAssert.AreEqual(data, fileData);

            connector.DeleteFile(fortnoxFile.Id);
            MyAssert.HasNoError(connector);
        }

        [TestMethod]
        public void Test_Folder_Create_Get_Delete()
        {
            IArchiveConnector connector = new ArchiveConnector();
            var randomFolderName = TestUtils.RandomString();

            var createdFolder = connector.CreateFolder(randomFolderName, testRootFolder.Name);
            MyAssert.HasNoError(connector);

            var retrievedFolder = connector.GetFolder(createdFolder.Id);
            MyAssert.HasNoError(connector);
            Assert.AreEqual(randomFolderName, retrievedFolder.Name);

            connector.DeleteFile(retrievedFolder.Id);
            MyAssert.HasNoError(connector);
        }

        [TestMethod]
        public void Test_Folder_Delete_ByPath()
        {
            IArchiveConnector connector = new ArchiveConnector();
            var randomFolderName = TestUtils.RandomString();

            var createdFolder = connector.CreateFolder(randomFolderName, testRootFolder.Name);
            MyAssert.HasNoError(connector);

            var retrievedFolder = connector.GetFolder(createdFolder.Id);
            MyAssert.HasNoError(connector);
            Assert.AreEqual(randomFolderName, retrievedFolder.Name);

            connector.DeleteFolder(testRootFolder.Name + @"\" + retrievedFolder.Name);
            MyAssert.HasNoError(connector);
        }

        [TestMethod]
        public void Test_GetSupplierFolder()
        {
            IArchiveConnector connector1 = new InboxConnector();
            var folder1 = connector1.GetFolder(StaticFolders.SupplierInvoices);
            Assert.AreEqual("inbox_s", folder1.Id);

            IArchiveConnector connector2 = new ArchiveConnector();
            var folder2 = connector2.GetFolder(StaticFolders.SupplierInvoices);
            Assert.AreEqual("inbox_s", folder1.Id);
        }

        [TestMethod]
        public void Test_Upload_Download_Delete_From_Static_Folder()
        {
            IArchiveConnector connector = new ArchiveConnector();

            var data = Resource.fortnox_image;
            var randomFileName = TestUtils.RandomString() + ".txt";

            var fortnoxFile = connector.UploadFile(randomFileName, data, StaticFolders.SupplierInvoices);
            MyAssert.HasNoError(connector);

            var fileData = connector.DownloadFile(fortnoxFile.Id);
            MyAssert.HasNoError(connector);
            CollectionAssert.AreEqual(data, fileData);

            connector.DeleteFile(fortnoxFile.Id);
            MyAssert.HasNoError(connector);
        }

        [TestMethod]
        public void Test_ManyRequests()
        {
            IArchiveConnector connector = new ArchiveConnector();

            for (int i = 0; i < 20; i++)
            {
                var data = Resource.fortnox_image;
                var randomFileName = TestUtils.RandomString() + ".txt";

                var fortnoxFile = connector.UploadFile(randomFileName, data, StaticFolders.Root);
                MyAssert.HasNoError(connector);

                var fileData = connector.DownloadFile(fortnoxFile.Id);
                MyAssert.HasNoError(connector);
                CollectionAssert.AreEqual(data, fileData);

                connector.DeleteFile(fortnoxFile.Id);
                MyAssert.HasNoError(connector);
            }
        }

        [TestMethod]
        public void Test_Get_Root()
        {
            IArchiveConnector connector = new ArchiveConnector();
            var rootFolder = connector.GetRoot();
            Assert.AreEqual("root", rootFolder.Id);
        }
    }
}
