using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fortnox.SDK;
using Fortnox.SDK.Exceptions;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Utility;
using jsiSIE;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests;

[TestClass]
public class SIEConnectorTests
{
    private FortnoxClient FortnoxClient;

    [TestInitialize]
    public async Task TestInitialize()
    {
        FortnoxClient ??= await TestClient.GetFortnoxClient();
    }
    [TestMethod]
    public async Task SIE_Get()
    {
        var types = Enum.GetValues(typeof(SIEType)).Cast<SIEType>().ToList();
        var connector = FortnoxClient.SIEConnector;

        foreach (var sieType in types)
        {
            var data = await connector.GetAsync(sieType);
            Assert.IsNotNull(data);

            //var content = Decode(data);
            //var typeLine = content.Split("\n").First(l => l.StartsWith("#SIETYP")).Trim();
            //Assert.AreEqual($"#SIETYP {sieType.GetStringValue()}", typeLine);

            var sieDocument = Parse(data);
            Assert.AreEqual(sieDocument.SIETYP.ToString(), sieType.GetStringValue());
        }
    }

    [TestMethod]
    public async Task SIE_Get_SpecificYear()
    {
        var finYears = (await FortnoxClient.FinancialYearConnector.FindAsync(null)).Entities;

        var connector = FortnoxClient.SIEConnector;

        foreach (var finYear in finYears)
        {
            var data = await connector.GetAsync(SIEType.Transactions, finYear.Id);
            Assert.IsNotNull(data);

            //var content = Decode(data);
            //var yearLine = content.Split("\n").First(l => l.StartsWith("#RAR")).Trim();
            //var expectedYearLine =
            //    $"#RAR 0 {finYear.FromDate?.ToString("yyyyMMdd")} {finYear.ToDate?.ToString("yyyyMMdd")}";
            //Assert.AreEqual(expectedYearLine, yearLine);

            var sieDocument = Parse(data);
            Assert.AreEqual(sieDocument.RAR[0].Start, finYear.FromDate);
            Assert.AreEqual(sieDocument.RAR[0].End, finYear.ToDate);
        }
    }

    [TestMethod]
    public async Task SIE_Get_ExportOptions_Period()
    {
        var connector = FortnoxClient.SIEConnector;
        var exportOptions = new SIEExportOptions()
        {
            FromDate = new DateTime(2020, 4, 1),
            ToDate = new DateTime(2020, 8, 31)
        };

        var data = await connector.GetAsync(SIEType.Transactions, exportOptions: exportOptions, finYearID: 4); // 4: 2020-01-01 -> 2020-12-31
        var sieDocument = Parse(data);

        Assert.AreEqual(false, sieDocument.VER.Any(v => v.VoucherDate < exportOptions.FromDate));
        Assert.AreEqual(false, sieDocument.VER.Any(v => v.VoucherDate > exportOptions.ToDate));

        Assert.AreEqual(true, sieDocument.VER.Any(v => v.VoucherDate > exportOptions.FromDate));
    }


    [TestMethod]
    public async Task SIE_Get_ExportOptions_VoucherSelection()
    {
        var connector = FortnoxClient.SIEConnector;
        var exportOptions = new SIEExportOptions()
        {
            Selection = new List<VoucherSelection>()
            {
                new VoucherSelection()
                {
                    VoucherSeries = "A",
                    FromVoucherNumber = 20,
                    ToVoucherNumber = 24
                },
                new VoucherSelection()
                {
                    VoucherSeries = "B",
                    FromVoucherNumber = 5,
                    ToVoucherNumber = 9
                }
            }
        };

        var data = await connector.GetAsync(SIEType.Transactions, exportOptions: exportOptions);
        var sieDocument = Parse(data);

        Assert.AreEqual(5 + 5, sieDocument.VER.Count);

        Assert.AreEqual(5, sieDocument.VER.Count(v => v.Series == "A"));
        Assert.AreEqual(false, sieDocument.VER.Any(v => v.Series == "A" && int.Parse(v.Number) < 20));
        Assert.AreEqual(false, sieDocument.VER.Any(v => v.Series == "A" && int.Parse(v.Number) > 24));

        Assert.AreEqual(5, sieDocument.VER.Count(v => v.Series == "B"));
        Assert.AreEqual(false, sieDocument.VER.Any(v => v.Series == "B" && int.Parse(v.Number) < 5));
        Assert.AreEqual(false, sieDocument.VER.Any(v => v.Series == "B" && int.Parse(v.Number) > 9));
    }

    [ExpectedException(typeof(FortnoxApiException))]
    [TestMethod]
    public async Task SIE_Get_ExportOptions_VoucherSelection_IncompleteInterval()
    {
        var connector = FortnoxClient.SIEConnector;
        var exportOptions = new SIEExportOptions()
        {
            Selection = new List<VoucherSelection>()
            {
                new VoucherSelection()
                {
                    VoucherSeries = "A",
                    FromVoucherNumber = 20,
                    //ToVoucherNumber = 24
                },
                new VoucherSelection()
                {
                    VoucherSeries = "B",
                    FromVoucherNumber = 5,
                    ToVoucherNumber = 9
                }
            }
        };

        await connector.GetAsync(SIEType.Transactions, exportOptions: exportOptions);
    }

    [TestMethod]
    public async Task SIE_Get_ExportOptions_ExcludeUnused()
    {
        var connector = FortnoxClient.SIEConnector;
        var exportOptionsAll = new SIEExportOptions()
        {
            ExportAll = true
        };
        var exportOptionsExcludeUnused = new SIEExportOptions()
        {
            ExportAll = false
        };

        var data = await connector.GetAsync(SIEType.PeriodBalance, exportOptions: exportOptionsAll);
        var sieDocumentFull = Parse(data);

        data = await connector.GetAsync(SIEType.Transactions, exportOptions: exportOptionsExcludeUnused);
        var sieDocumentFiltered = Parse(data);

        Assert.AreEqual(true, sieDocumentFull.KONTO.Count > sieDocumentFiltered.KONTO.Count);
    }

    private static SieDocument Parse(byte[] data)
    {
        //SIE from Fortnox is encoded in PC-8 (Code page 437) 
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

        var sieDocument = new SieDocument();
        sieDocument.ReadDocument(new MemoryStream(data));

        return sieDocument;
    }
}