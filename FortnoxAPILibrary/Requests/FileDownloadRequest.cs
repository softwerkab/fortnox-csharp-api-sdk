using System.Net.Http;

namespace FortnoxAPILibrary.Requests
{
    public class FileDownloadRequest : BaseRequest
    {
        public FileDownloadRequest()
        {
            Method = HttpMethod.Get;
        }
    }
}