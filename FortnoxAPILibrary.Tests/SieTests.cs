using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using FortnoxAPILibrary.Connectors;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.Tests
{
    [TestClass]
    public class SieTests
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
        public void Test_SIE_ExportToFile()
        {
            var tmpPath = TestUtils.GetTempFilePath();
            var connector = new SIEConnector();

            connector.ExportSIE(SIEConnector.SIEType.SIE3, tmpPath);
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'.");
            Assert.IsTrue(File.Exists(tmpPath) && new FileInfo(tmpPath).Length > 0);

            File.Delete(tmpPath);
        }

        [TestMethod]
        public void Test_SIE_ExportData()
        {
            var connector = new SIEConnector();

            var data = connector.ExportSIE(SIEConnector.SIEType.SIE3);
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'.");
            Assert.IsTrue(data.Length > 0);
        }

        [TestMethod]
        public void Test_SIE_Preview()
        {
            var tmpPath = TestUtils.GetTempFilePath();
            File.WriteAllBytes(tmpPath, Resource.sie_file); //Create a SIE file

            var connector = new SIEConnector();
            var summary = connector.ImportSIE(tmpPath, true);
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'.");
            Assert.IsNotNull(summary.DateOfGeneration);
        }

        [Ignore] //Need a dummy SIE file to not risk creating real data resources
        [TestMethod]
        public void Test_SIE_Import()
        {
            var tmpPath = TestUtils.GetTempFilePath();
            File.WriteAllBytes(tmpPath, Resource.sie_file); //Create a SIE file

            var connector = new SIEConnector();
            var summary = connector.ImportSIE(tmpPath);
            Assert.IsFalse(connector.HasError, $"Request failed due to '{connector.Error?.Message}'.");
            Assert.IsNotNull(summary.DateOfGeneration);
        }
    }
}
