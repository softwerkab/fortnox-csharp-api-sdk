using System.Net.Http;

namespace Fortnox.SDK.Requests;

internal class FileDownloadRequest : BaseRequest
{
    public FileDownloadRequest()
    {
        Method = HttpMethod.Get;
    }
}