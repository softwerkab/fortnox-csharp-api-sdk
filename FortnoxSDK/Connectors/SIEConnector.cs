using System.Collections.Generic;
using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Requests;
using Fortnox.SDK.Utility;

namespace Fortnox.SDK.Connectors
{
    public class SIEConnector : BaseConnector, ISIEConnector
    {

        public SIEConnector()
        {
            Resource = "sie";
        }

        public byte[] Get(SIEType type, long? finYearID = null)
        {
            return GetAsync(type, finYearID).GetResult();
        }

        public async Task<byte[]> GetAsync(SIEType type, long? finYearID = null)
        {
            var request = new FileDownloadRequest()
            {
                Resource = Resource,
                Indices = new List<string> { type.GetStringValue() }
            };
            if (finYearID != null)
                request.Parameters.Add("financialyear", finYearID.ToString());

            return await SendAsync(request).ConfigureAwait(false);
        }
    }
}
