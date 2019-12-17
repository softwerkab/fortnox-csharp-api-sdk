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

            connector.ExportSIE(SIEType.SIE3, tmpPath);
            MyAssert.HasNoError(connector);
            Assert.IsTrue(File.Exists(tmpPath) && new FileInfo(tmpPath).Length > 0);

            File.Delete(tmpPath);
        }

        [TestMethod]
        public void Test_SIE_ExportData()
        {
            var connector = new SIEConnector();

            var data = connector.ExportSIE(SIEType.SIE3);
            MyAssert.HasNoError(connector);
            Assert.IsTrue(data.Length > 0);
        }

        [TestMethod]
        public void Test_SIE_Preview()
        {
            var tmpPath = TestUtils.GetTempFilePath();
            File.WriteAllBytes(tmpPath, Resource.sie_file); //Create a SIE file

            var connector = new SIEConnector();
            var summary = connector.ImportSIE(tmpPath, true);
            MyAssert.HasNoError(connector);
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
            MyAssert.HasNoError(connector);
            Assert.IsNotNull(summary.DateOfGeneration);
        }
    }
}
