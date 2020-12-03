using System.Collections.Generic;
using System.Threading.Tasks;
using FortnoxAPILibrary.Requests;

namespace FortnoxAPILibrary.Connectors
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
