using System.Threading.Tasks;

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
            return GetAsync(type).Result;
        }

        public async Task<byte[]> GetAsync(SIEType type)
        {
            RequestInfo = new RequestInfo()
            {
                BaseUrl = BaseUrl,
                Resource = Resource,
                Indices = new[] { type.GetStringValue() }
            };

            return await DownloadFile().ConfigureAwait(false);
        }
    }
}
