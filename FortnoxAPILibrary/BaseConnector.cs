using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FortnoxAPILibrary.Entities;

namespace FortnoxAPILibrary
{
    /// <remarks/>
    public class BaseConnector : BaseClient
    {
        protected BaseClient HttpClient { get; set; }
        protected ErrorHandler ErrorHandler { get; set; }
        protected AdaptableSerializer Serializer { get; set; }

        protected string Resource { get; set; }

        public RequestInfo RequestInfo { get; set; }

        public BaseConnector()
        {
            HttpClient = this;
            Serializer = new AdaptableSerializer();
            ErrorHandler = new ErrorHandler();
        }

        protected HttpRequestMessage SetupRequest(string requestUriString, HttpMethod method)
        {
            var request = new HttpRequestMessage(method, requestUriString);
            return request;
        }
        
        /// <summary>
        /// Perform the request to Fortnox API
        /// </summary>
        protected async Task DoRequest()
        {
            var wr = SetupRequest(RequestInfo.AbsoluteUrl, RequestInfo.Method);

            try
            {
                using var httpResponse = await HttpClient.SendAsync(wr).ConfigureAwait(false);

                if (!httpResponse.IsSuccessStatusCode)
                    ErrorHandler.HandleErrorResponse(httpResponse);
            }
            catch (HttpRequestException we)
            {
                ErrorHandler.HandleNoResponse(we);
            }
        }

        /// <summary>
        /// Perform the request to Fortnox API
        /// </summary>
        /// <typeparam name="T">The type of entity to create, read, update or delete.</typeparam>
        /// <param name="entity">The entity</param>
        /// <returns>An entity</returns>
        protected async Task<T> DoEntityRequest<T>(T entity = default)
        {
            var requestJson = entity == null ? string.Empty : Serializer.Serialize(entity);

            var requestData = Encoding.UTF8.GetBytes(requestJson);
            var responseData = await DoSimpleRequest(requestData).ConfigureAwait(false);

            var responseJson = Encoding.UTF8.GetString(responseData);

            return Serializer.Deserialize<T>(responseJson);
        }

        protected async Task<byte[]> DoSimpleRequest(byte[] data = null)
        {
            var wr = SetupRequest(RequestInfo.AbsoluteUrl, RequestInfo.Method);

            try
            {
                if (data != null && RequestInfo.Method != HttpMethod.Get) 
                    wr.Content = new ByteArrayContent(data);

                using var response = await HttpClient.SendAsync(wr).ConfigureAwait(false);

                if (!response.IsSuccessStatusCode)
                {
                    ErrorHandler.HandleErrorResponse(response);
                    return default;
                }

                return await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
            }
            catch (HttpRequestException we)
            {
                ErrorHandler.HandleNoResponse(we);
                return default;
            }
        }

        protected async Task<T> UploadFile<T>(byte[] fileData = null, string fileName = null)
        {
            T result = default;

            try
            {
                var wr = (HttpWebRequest)WebRequest.Create(RequestInfo.AbsoluteUrl);
                wr.Method = "POST";

                var request = wr;

                var rand = new Random();
                var boundary = "----boundary" + rand.Next();
                var header = Encoding.UTF8.GetBytes("\r\n--" + boundary + "\r\nContent-Disposition: form-data; name=\"file_path\"; filename=\"" + fileName + "\"\r\nContent-Type: application/octet-stream\r\n\r\n");
                var trailer = Encoding.UTF8.GetBytes("\r\n--" + boundary + "--\r\n");

                request.ContentType = "multipart/form-data; boundary=" + boundary;

                using var dataStream = request.GetRequestStream();
                await dataStream.WriteAsync(header, 0, header.Length);
                await dataStream.WriteAsync(fileData, 0, fileData.Length).ConfigureAwait(false);
                await dataStream.WriteAsync(trailer, 0, trailer.Length);
                dataStream.Close();

                // Read the response
                using var response = await HttpClient.SendAsync(wr).ConfigureAwait(false);
                using var responseStream = response.GetResponseStream();
                var responseJson = responseStream.ToText().GetResult();
                result = Serializer.Deserialize<EntityWrapper<T>>(responseJson).Entity;
            }
            catch (WebException we)
            {
                if (we.Response != null)
                    ErrorHandler.HandleErrorResponse(we.Response as HttpWebResponse);
                else
                    ErrorHandler.HandleNoResponse(we);
            }

            return result;
        }

        protected async Task<byte[]> DownloadFile()
        {
            var request = SetupRequest(RequestInfo.AbsoluteUrl, HttpMethod.Get);

            try
            {
                using var response = await HttpClient.SendAsync(request).ConfigureAwait(false);

                if (!response.IsSuccessStatusCode)
                {
                    ErrorHandler.HandleErrorResponse(response);
                    return null;
                }

                var data = await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
                return data;
            }
            catch (HttpRequestException we)
            {
                ErrorHandler.HandleNoResponse(we);
                return null;
            }
        }
    }
}
