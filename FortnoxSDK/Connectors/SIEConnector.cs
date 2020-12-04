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

        public byte[] Get(SIEType type)
        {
            return GetAsync(type).GetResult();
        }

        public async Task<byte[]> GetAsync(SIEType type)
        {
            var request = new FileDownloadRequest()
            {
                BaseUrl = BaseUrl,
                Resource = Resource,
                Indices = new List<string> { type.GetStringValue() }
            };

            return await SendAsync(request).ConfigureAwait(false);
        }
    }
}
