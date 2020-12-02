using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FortnoxAPILibrary.Requests;

namespace FortnoxAPILibrary
{
    public class BaseConnector : BaseClient
    {
        protected ErrorHandler ErrorHandler { get; set; }
        protected AdaptableSerializer Serializer { get; set; }

        protected string Resource { get; set; }
        
        public BaseConnector()
        {
            Serializer = new AdaptableSerializer();
            ErrorHandler = new ErrorHandler();
        }
        
        protected async Task<byte[]> SendAsync(FortnoxRequest fortnoxRequest)
        {
            try
            {
                var httpRequest = new HttpRequestMessage(fortnoxRequest.Method, fortnoxRequest.AbsoluteUrl);

                if (fortnoxRequest.Headers != null)
                    foreach (var header in fortnoxRequest.Headers)
                        httpRequest.Headers.Add(header.Key, header.Value);

                if (fortnoxRequest.Content != null && httpRequest.Method != HttpMethod.Get)
                    httpRequest.Content = new ByteArrayContent(fortnoxRequest.Content);

                using var httpResponse = await SendAsync(httpRequest).ConfigureAwait(false);

                if (httpResponse.IsSuccessStatusCode)
                    return await httpResponse.Content.ReadAsByteArrayAsync().ConfigureAwait(false);

                ErrorHandler.HandleErrorResponse(httpResponse);
                return default;

            }
            catch (HttpRequestException ex)
            {
                ErrorHandler.HandleNoResponse(ex);
                return default;
            }
        }

        protected async Task<byte[]> SendAsync(FileUploadRequest fortnoxRequest)
        {
            try
            {
                var httpRequest = (HttpWebRequest)WebRequest.Create(fortnoxRequest.AbsoluteUrl);
                httpRequest.Method = "POST";

                var rand = new Random();
                var boundary = "----boundary" + rand.Next();
                var header = Encoding.UTF8.GetBytes("\r\n--" + boundary + "\r\nContent-Disposition: form-data; name=\"file_path\"; filename=\"" + fortnoxRequest.FileName + "\"\r\nContent-Type: application/octet-stream\r\n\r\n");
                var trailer = Encoding.UTF8.GetBytes("\r\n--" + boundary + "--\r\n");

                httpRequest.ContentType = "multipart/form-data; boundary=" + boundary;

                using var dataStream = httpRequest.GetRequestStream();
                await dataStream.WriteAsync(header, 0, header.Length);
                await dataStream.WriteAsync(fortnoxRequest.FileData, 0, fortnoxRequest.FileData.Length).ConfigureAwait(false);
                await dataStream.WriteAsync(trailer, 0, trailer.Length);
                dataStream.Close();

                // Read the response
                using var response = await SendAsync(httpRequest).ConfigureAwait(false);
                using var responseStream = response.GetResponseStream();

                return await responseStream.ToBytes();
            }
            catch (WebException ex)
            {
                if (ex.Response != null)
                    ErrorHandler.HandleErrorResponse(ex.Response as HttpWebResponse);
                else
                    ErrorHandler.HandleNoResponse(ex);

                return default;
            }
        }
    }
}
