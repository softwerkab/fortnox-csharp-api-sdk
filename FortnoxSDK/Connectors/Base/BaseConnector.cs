using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Fortnox.SDK.Requests;
using Fortnox.SDK.Serialization;

namespace Fortnox.SDK.Connectors.Base;

internal abstract class BaseConnector : BaseClient
{
    protected ISerializer Serializer { get; set; }
    protected string Resource { get; set; }

    protected BaseConnector()
    {
        Serializer = new JsonEntitySerializer();
    }

    protected async Task<byte[]> SendAsync(BaseRequest fortnoxRequest)
    {
        var httpRequest = new HttpRequestMessage(fortnoxRequest.Method, fortnoxRequest.AbsoluteUrl);

        if (fortnoxRequest.Headers != null)
            foreach (var header in fortnoxRequest.Headers)
                httpRequest.Headers.Add(header.Key, header.Value);

        if (fortnoxRequest.Content != null && httpRequest.Method != HttpMethod.Get)
            httpRequest.Content = new ByteArrayContent(fortnoxRequest.Content);

        return await SendAsync(httpRequest).ConfigureAwait(false);
    }

    protected async Task<byte[]> SendAsync(FileDownloadRequest fortnoxRequest)
    {
        return await SendAsync((BaseRequest)fortnoxRequest).ConfigureAwait(false);
    }

    protected async Task<byte[]> SendAsync(FileUploadRequest fortnoxRequest)
    {
        var boundary = "----boundary" + new Random().Next();
        var content = new MultipartFormDataContent(boundary);

        var fileContent = new ByteArrayContent(fortnoxRequest.FileData);
        fileContent.Headers.Add("Content-Type", "application/octet-stream");
        var headerValue = "form-data; name=\"Filedata\"; filename=\"" + fortnoxRequest.FileName + "\"";

        //Issue: file name can contain special characters e.g. "äöå", HttpClient follows strict HTTP standard for headers encoding, while server expects pure UTF-8
        // Workaround inspired by https://stackoverflow.com/questions/21928982/how-to-disable-base64-encoded-filenames-in-httpclient-multipartformdatacontent
        var bytes = Encoding.UTF8.GetBytes(headerValue);
        var chars = bytes.Select(b => (char)b).ToArray();
        headerValue = new string(chars);
        //-------------End of workaround-------------//

        fileContent.Headers.Add("Content-Disposition", headerValue);
        content.Add(fileContent, "Filedata", fortnoxRequest.FileName);

        var httpRequest = new HttpRequestMessage(HttpMethod.Post, fortnoxRequest.AbsoluteUrl);
        httpRequest.Content = content;

        return await SendAsync(httpRequest).ConfigureAwait(false);
    }
}