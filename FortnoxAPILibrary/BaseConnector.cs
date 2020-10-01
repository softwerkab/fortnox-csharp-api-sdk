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

        /// <remarks/>
        public ErrorInformation Error { get; protected set; }

        /// <summary>
        /// True if something went wrong with the request. Otherwise false.
        /// </summary>
        public bool HasError => Error != null;

        /// <summary>
        /// The HttpStatusCode returned by Fortnox API.
        /// </summary>
        public HttpStatusCode HttpStatusCode { get; protected set; }

        /// <summary>
        /// The data sent to Fortnox in JSON-format.
        /// </summary>
        public string RequestContent { get; protected set; }
        /// <summary>
        /// The data returned from Fortnox in JSON-format. 
        /// </summary>
        public string ResponseContent { get; protected set; }

        /// <summary>
        /// Aggregate data used for request setup
        /// </summary>
        public RequestInfo RequestInfo { get; protected set; }

        /// <remarks />
        public BaseConnector()
        {
            HttpClient = this;
            Serializer = new AdaptableSerializer();
            ErrorHandler = new ErrorHandler();
        }

        protected HttpRequestMessage SetupRequest(string requestUriString, HttpMethod method)
        {
            Error = null;
            ResponseContent = string.Empty;

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
                using var response = await HttpClient.SendAsync(wr).ConfigureAwait(false);
                HttpStatusCode = response.StatusCode;

                if (!response.IsSuccessStatusCode)
                    Error = ErrorHandler.HandleError(response);
            }
            catch (HttpRequestException we)
            {
                ErrorHandler.HandleConnectionException(we);
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
            RequestContent = requestJson;

            var requestData = Encoding.UTF8.GetBytes(requestJson);
            var responseData = await DoSimpleRequest(requestData).ConfigureAwait(false);

            if (responseData == null)
            {
                ResponseContent = string.Empty;
                return default;
            }

            var responseJson = Encoding.UTF8.GetString(responseData);
            ResponseContent = responseJson;

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
                HttpStatusCode = response.StatusCode;

                if (!response.IsSuccessStatusCode)
                {
                    Error = ErrorHandler.HandleError(response);
                    return default;
                }

                return await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
            }
            catch (HttpRequestException we)
            {
                ErrorHandler.HandleConnectionException(we);
                return default;
            }
        }

        protected async Task<T> UploadFile<T>(byte[] fileData = null, string fileName = null)
        {
            Error = null;
            ResponseContent = "";

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
                ResponseContent = responseStream.ToText().Result;
                result = Serializer.Deserialize<EntityWrapper<T>>(ResponseContent).Entity;
            }
            catch (WebException we)
            {
                if (we.Response != null)
                    ErrorHandler.HandleError(we.Response as HttpWebResponse);
                else
                    ErrorHandler.HandleConnectionException(we);
            }

            return result;
        }

        protected async Task<byte[]> DownloadFile()
        {
            var request = SetupRequest(RequestInfo.AbsoluteUrl, HttpMethod.Get);

            try
            {
                using var response = await HttpClient.SendAsync(request).ConfigureAwait(false);
                HttpStatusCode = response.StatusCode;

                if (!response.IsSuccessStatusCode)
                {
                    Error = ErrorHandler.HandleError(response);
                    return null;
                }

                var data = await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
                return data;
            }
            catch (HttpRequestException we)
            {
                ErrorHandler.HandleConnectionException(we);
                return null;
            }
        }
    }
}
