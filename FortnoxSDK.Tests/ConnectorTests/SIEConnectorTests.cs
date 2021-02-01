using System;
using System.Linq;
using System.Text;
using Fortnox.SDK;
using Fortnox.SDK.Connectors;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests
{
    [TestClass]
    public class SIEConnectorTests
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
        public void SIE_Get()
        {
            var types = Enum.GetValues(typeof(SIEType)).Cast<SIEType>().ToList();
            ISIEConnector connector = new SIEConnector();
            
            foreach (var sieType in types)
            {
                var data = connector.Get(sieType);
                Assert.IsNotNull(data);

                var content = Decode(data);
                var typeLine = content.Split("\n").First(l => l.StartsWith("#SIETYP")).Trim();
                Assert.AreEqual($"#SIETYP {sieType.GetStringValue()}", typeLine);
            }
        }

        [TestMethod]
        public void SIE_Get_SpecificYear()
        {
            var finYears = new FinancialYearConnector().Find(null).Entities;

            ISIEConnector connector = new SIEConnector();

            foreach (var finYear in finYears)
            {
                var data = connector.Get(SIEType.Transactions, finYear.Id);
                Assert.IsNotNull(data);

                var content = Decode(data);
                var yearLine = content.Split("\n").First(l => l.StartsWith("#RAR")).Trim();
                var expectedYearLine =
                    $"#RAR 0 {finYear.FromDate?.ToString("yyyyMMdd")} {finYear.ToDate?.ToString("yyyyMMdd")}";
                Assert.AreEqual(expectedYearLine, yearLine);
            }
        }

        private string Decode(byte[] data)
        {
            //SIE from Fortnox is encoded in PC-8
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            return Encoding.GetEncoding(437).GetString(data); //Decode with PC-8
        }
    }
}
