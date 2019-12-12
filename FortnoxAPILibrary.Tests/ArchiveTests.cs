using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
        public void Test_Folder_Create_Delete()
        {
            var connector = new ArchiveConnector();

            var folder = connector.CreateFolder(new Folder { Name = Path.GetRandomFileName() });
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'.");

            var subFolder1 = connector.CreateFolder(new Folder { Name = folder.Name+"/TestSubFolder1" });
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'.");
            var subFolder2 = connector.CreateFolder(new Folder { Name = folder.Name + "/TestSubFolder2" });
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'.");

            var root = connector.Find();
            //TODO: Can not get specific folder !!

            connector.DeleteFolder(subFolder1.Id);
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'.");
            connector.DeleteFolder(subFolder2.Id);
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'.");
            connector.DeleteFolder(folder.Id);
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'.");
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
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'.");

            System.IO.File.Delete(tmpPath); //Delete local file
            Assert.IsFalse(System.IO.File.Exists(tmpPath));

            //DOWNLOAD FILE
            connector.DownloadFile(uploadedFile.Id, tmpPath);
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'.");
            Assert.IsTrue(System.IO.File.Exists(tmpPath)); //Local file created by download

            //DELETE FILE
            connector.DeleteFile(uploadedFile.Id);
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'.");

            System.IO.File.Delete(tmpPath);
        }

        [TestMethod]
        public void Test_File_Data_Upload_Download_Delete()
        {
            var connector = new ArchiveConnector();

            // UPLOAD FILE DATA
            var uploadedFile = connector.UploadFileData(Resource.fortnox_image, "FortnoxImage.png", "");
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'.");
            Assert.AreEqual("image/png", uploadedFile.ContentType);
            
            //DOWNLOAD FILE DATA
            var downloadedFile = new File() { Id = uploadedFile.Id };
            connector.DownloadFileData(downloadedFile);
            Assert.AreEqual(Resource.fortnox_image.Length, downloadedFile.Data.Length);
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'.");

            //DELETE FILE
            connector.DeleteFile(uploadedFile.Id);
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'.");
        }
    }
}
