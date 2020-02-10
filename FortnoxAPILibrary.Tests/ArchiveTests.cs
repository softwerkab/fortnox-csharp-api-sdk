/*
using System.IO;
using System.Linq;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using File = FortnoxAPILibrary.Entities.File;

namespace FortnoxAPILibrary.Tests
{

    [TestClass]
    public class ArchiveTests
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
        public void Test_Folder_Create_Find_Delete()
        {
            var connector = new ArchiveConnector();

            var folder = connector.CreateFolder(new Folder { Name = Path.GetRandomFileName() });
            MyAssert.HasNoError(connector);

            var subFolder1 = connector.CreateFolder(new Folder { Name = "TestSubFolder1" }, folder.Name);
            MyAssert.HasNoError(connector);
            var subFolder2 = connector.CreateFolder(new Folder { Name = "TestSubFolder2" }, folder.Name);
            MyAssert.HasNoError(connector);

            connector.FolderId = folder.Id;
            var  folderContent = connector.Find();
            MyAssert.HasNoError(connector);
            Assert.AreEqual(2, folderContent.Folders.Count);
            Assert.IsTrue(folderContent.Folders.Any(f => f.Name.Equals(subFolder1.Name))); //contains subfolder1
            Assert.IsTrue(folderContent.Folders.Any(f => f.Name.Equals(subFolder2.Name))); //contains subfolder2

            connector.DeleteFolder(subFolder1.Id);
            MyAssert.HasNoError(connector);
            connector.DeleteFolder(subFolder2.Id);
            MyAssert.HasNoError(connector);
            connector.DeleteFolder(folder.Id);
            MyAssert.HasNoError(connector);
        }


        [TestMethod]
        public void Test_File_Upload_Download_Delete()
        {
            //Arrange
            var tmpPath = TestUtils.GetTempFilePath();
            System.IO.File.WriteAllBytes(tmpPath, Resource.fortnox_image); //Create local file

            var connector = new ArchiveConnector();

            //UPLOAD FILE
            var uploadedFile = connector.UploadFile(tmpPath, "");
            MyAssert.HasNoError(connector);

            System.IO.File.Delete(tmpPath); //Delete local file
            Assert.IsFalse(System.IO.File.Exists(tmpPath));

            //DOWNLOAD FILE
            connector.DownloadFile(uploadedFile.Id, tmpPath);
            MyAssert.HasNoError(connector);
            Assert.IsTrue(System.IO.File.Exists(tmpPath)); //Local file created by download

            //DELETE FILE
            connector.DeleteFile(uploadedFile.Id);
            MyAssert.HasNoError(connector);

            System.IO.File.Delete(tmpPath);
        }

        [TestMethod]
        public void Test_File_Data_Upload_Download_Delete()
        {
            var connector = new ArchiveConnector();

            // UPLOAD FILE DATA
            var uploadedFile = connector.UploadFileData(Resource.fortnox_image, "FortnoxImage.png", "");
            MyAssert.HasNoError(connector);
            Assert.AreEqual("image/png", uploadedFile.ContentType);
            
            //DOWNLOAD FILE DATA
            var downloadedFile = new File() { Id = uploadedFile.Id };
            connector.DownloadFileData(downloadedFile);
            Assert.AreEqual(Resource.fortnox_image.Length, downloadedFile.Data.Length);
            MyAssert.HasNoError(connector);

            //DELETE FILE
            connector.DeleteFile(uploadedFile.Id);
            MyAssert.HasNoError(connector);
        }
    }
}
*/
