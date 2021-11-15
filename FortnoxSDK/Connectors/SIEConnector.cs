using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Requests;
using Fortnox.SDK.Utility;

namespace Fortnox.SDK.Connectors;

internal class SIEConnector : BaseConnector, ISIEConnector
{
    public SIEConnector()
    {
        Resource = Endpoints.SIE;
    }

    public byte[] Get(SIEType type, long? finYearID = null, SIEExportOptions exportOptions = null)
    {
        return GetAsync(type, finYearID, exportOptions).GetResult();
    }

    public async Task<byte[]> GetAsync(SIEType type, long? finYearID = null, SIEExportOptions exportOptions = null)
    {
        var request = new FileDownloadRequest()
        {
            Resource = Resource,
            Indices = new List<string> { type.GetStringValue() }
        };

        if (finYearID != null)
            request.Parameters.Add("financialyear", finYearID.ToString());

        if (exportOptions != null)
        {
            foreach (var parameter in GetExportParameters(exportOptions))
                request.Parameters.Add(parameter.Key, parameter.Value);
        }

        return await SendAsync(request).ConfigureAwait(false);
    }

    private static Dictionary<string, string> GetExportParameters(SIEExportOptions exportOptions)
    {
        var parameters = new Dictionary<string, string>();

        if (exportOptions.FromDate != null)
            parameters.Add("fromdate", exportOptions.FromDate?.ToString(ApiConstants.DateFormat));
        if (exportOptions.ToDate != null)
            parameters.Add("todate", exportOptions.ToDate?.ToString(ApiConstants.DateFormat));
        if (exportOptions.ExportAll != null)
            parameters.Add("exportall", exportOptions.ExportAll.ToString().ToLower());
        if (exportOptions.Selection != null)
        {
            var selectionValues = exportOptions.Selection.Where(s => s.VoucherSeries != null).Select(s =>
            {
                var value = s.VoucherSeries;
                if (s.FromVoucherNumber != null || s.ToVoucherNumber != null)
                    value += $",{s.FromVoucherNumber},{s.ToVoucherNumber}";
                return value;
            });

            parameters.Add("selection", string.Join(";", selectionValues));
        }

        return parameters;
    }
}