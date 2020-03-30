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

            var connector = new ArchiveConnector();
            testRootFolder = connector.GetFolder("TestArchive") ?? connector.CreateFolder("TestArchive");
        }

        [TestMethod]
        public void Test_File_Upload_Download_Delete()
        {
            var connector = new ArchiveConnector();

            var data = Resource.fortnox_image;

            var fortnoxFile = connector.UploadFile("test.txt", data, testRootFolder.Name);
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
            var connector = new ArchiveConnector();

            var createdFolder = connector.CreateFolder("MyFolder", testRootFolder.Name);
            MyAssert.HasNoError(connector);

            var retrievedFolder = connector.GetFolder(createdFolder.Id);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("MyFolder", retrievedFolder.Name);

            connector.DeleteFile(retrievedFolder.Id);
            MyAssert.HasNoError(connector);
        }

        [TestMethod]
        public void Test_Folder_Delete_ByPath()
        {
            var connector = new ArchiveConnector();

            var createdFolder = connector.CreateFolder("MyFolder", testRootFolder.Name);
            MyAssert.HasNoError(connector);

            var retrievedFolder = connector.GetFolder(createdFolder.Id);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("MyFolder", retrievedFolder.Name);

            connector.DeleteFolder(testRootFolder.Name+ @"\" + retrievedFolder.Name);
            MyAssert.HasNoError(connector);
        }
    }
}
