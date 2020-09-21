using System;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ComposableAsync;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Serialization;
using RateLimiter;

namespace FortnoxAPILibrary
{
    /// <remarks/>
    public class UrlRequestBase
    {
        private const int LimitPerSecond = 3;
        private static readonly TimeLimiter RateLimiter = TimeLimiter.GetFromMaxCountByInterval(LimitPerSecond, TimeSpan.FromSeconds(1));

        private string clientSecret;
        private string accessToken;

        private readonly JsonEntitySerializer serializer;

        protected string Resource { get; set; }
        protected virtual string BaseUrl => ConnectionSettings.FortnoxAPIServer;

        protected Func<string, string> FixRequestContent; //Needed for fixing irregular json requests
        protected Func<string, string> FixResponseContent; //Needed for fixing irregular json responses

        /// <summary>
        /// Http client used under-the-hood for all request (except file upload due to a server-side limitation)
        /// </summary>
        public HttpClient HttpClient { get; set; }

        /// <summary>
        /// Optional Fortnox Client Secret, if used it will override the static version.
        /// </summary>
        public string ClientSecret
		{
			get => !string.IsNullOrEmpty(clientSecret) ? clientSecret : ConnectionCredentials.ClientSecret;
            set => clientSecret = value;
        }

		/// <summary>
		/// Optional Fortnox Access Token, if used it will override the static version.
		/// </summary>
		/// /// <exception cref="Exception">Exception will be thrown if access token is not set.</exception>
		public string AccessToken
		{
			get => !string.IsNullOrEmpty(accessToken) ? accessToken : ConnectionCredentials.AccessToken;
            set => accessToken = value;
        }

        /// <summary>
        /// Timeout of requests sent to the Fortnox API in miliseconds
        /// </summary>
        public int Timeout
        {
            get => (int)HttpClient.Timeout.TotalMilliseconds;
            set => HttpClient.Timeout = TimeSpan.FromMilliseconds(value);
        }

        /// <remarks/>
        public ErrorInformation Error { get; protected set; }

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
        /// True if something went wrong with the request. Otherwise false.
        /// </summary>
        public bool HasError => Error != null;

        /// <summary>
        /// Aggregate data used for request setup
        /// </summary>
        public RequestInfo RequestInfo { get; protected set; }

        /// <remarks />
        public UrlRequestBase()
        {
            HttpClient = new HttpClient();
            Timeout = 30 * 1000;
            serializer = new JsonEntitySerializer();
        }

        /// <summary>
        /// This method is used to throttle every call to Fortnox. 
        /// </summary>
        protected async Task RateLimit()
        {
            if (ConnectionSettings.UseRateLimiter)
                await RateLimiter;
        }

        /// <summary>
        /// This method is used to setup the WebRequest used in every call to Fortnox. 
        /// </summary>
        /// <param name="requestUriString">The url to the resource</param>
        /// <param name="method">
        /// <para>The method to use:</para>
        /// <para>GET</para>
        /// <para>POST</para>
        /// <para>PUT</para>
        /// <para>DELETE</para>
        /// </param>
        /// <returns></returns>
        protected HttpRequestMessage SetupRequest(string requestUriString, RequestMethod method)
        {
            if (string.IsNullOrEmpty(ClientSecret))
                throw new Exception("Fortnox Client Secret must be set.");
            if (string.IsNullOrEmpty(AccessToken))
                throw new Exception("Fortnox Access Token must be set.");

            Error = null;

            /*var wr = (HttpWebRequest)WebRequest.Create(requestUriString);
            wr.Headers.Add("access-token", AccessToken);
            wr.Headers.Add("client-secret", ClientSecret);
            wr.ContentType = "application/json";
            wr.Accept = "application/json";
            wr.Method = method.GetStringValue();
            wr.Timeout = Timeout;            

            return wr;*/

            HttpMethod m;
            switch (method)
            {
                case RequestMethod.Get:
                    m = HttpMethod.Get;
                    break;
                case RequestMethod.Post:
                    m = HttpMethod.Post;
                    break;
                case RequestMethod.Put:
                    m = HttpMethod.Put;
                    break;
                case RequestMethod.Delete:
                    m = HttpMethod.Delete;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(method), method, null);
            }
            var request = new HttpRequestMessage(m, requestUriString);
            request.Headers.Add("access-token", AccessToken);
            request.Headers.Add("client-secret", ClientSecret);
            request.Headers.Add("Accept", "application/json");

            return request;
        }

        protected HttpWebRequest SetupRequestLegacy(string requestUriString, RequestMethod method)
        {
            if (string.IsNullOrEmpty(ClientSecret))
                throw new Exception("Fortnox Client Secret must be set.");
            if (string.IsNullOrEmpty(AccessToken))
                throw new Exception("Fortnox Access Token must be set.");

            Error = null;

            var wr = (HttpWebRequest)WebRequest.Create(requestUriString);
            wr.Headers.Add("access-token", AccessToken);
            wr.Headers.Add("client-secret", ClientSecret);
            wr.ContentType = "application/json";
            wr.Accept = "application/json";
            wr.Method = method.GetStringValue();
            wr.Timeout = Timeout;            

            return wr;
        }

        /// <summary>
        /// Perform the request to Fortnox API
        /// </summary>
        protected async Task DoRequest()
        {
            var wr = SetupRequest(RequestInfo.AbsoluteUrl, RequestInfo.Method);

            try
            {
                await RateLimit().ConfigureAwait(false);


                using var response = await HttpClient.SendAsync(wr).ConfigureAwait(false);
                HttpStatusCode = response.StatusCode;

                if (!response.IsSuccessStatusCode)
                    HandleError(response);

            }
            catch (HttpRequestException we)
            {
                HandleConnectionException(we);
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
            if (RequestInfo.ResponseType != RequestResponseType.JSON)
                throw new Exception("Unexpected request");

            var requestJson = entity == null ? string.Empty : Serialize(entity);
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

            return Deserialize<T>(responseJson);
        }

        protected async Task<byte[]> DoSimpleRequest(byte[] data = null)
        {
            var wr = SetupRequest(RequestInfo.AbsoluteUrl, RequestInfo.Method);
            ResponseContent = "";
            try
            {
                await RateLimit().ConfigureAwait(false);

                if (data != null && RequestInfo.Method != RequestMethod.Get) 
                    wr.Content = new ByteArrayContent(data);

                using var response = await HttpClient.SendAsync(wr).ConfigureAwait(false);
                HttpStatusCode = response.StatusCode;

                if (!response.IsSuccessStatusCode)
                {
                    HandleError(response);
                    return default;
                }

                return await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
            }
            catch (HttpRequestException we)
            {
                HandleConnectionException(we);
                return default;
            }
        }

        protected async Task<T> UploadFile<T>(byte[] fileData = null, string fileName = null)
        {
            ResponseContent = "";

            T result = default;

            try
            {
                await RateLimit().ConfigureAwait(false);

                var rand = new Random();
                var boundary = "----boundary" + rand.Next();
                var header = Encoding.UTF8.GetBytes("\r\n--" + boundary + "\r\nContent-Disposition: form-data; name=\"file_path\"; filename=\"" + fileName + "\"\r\nContent-Type: application/octet-stream\r\n\r\n");
                var trailer = Encoding.UTF8.GetBytes("\r\n--" + boundary + "--\r\n");

                var request = SetupRequestLegacy(RequestInfo.AbsoluteUrl, RequestMethod.Post);

                request.ContentType = "multipart/form-data; boundary=" + boundary;

                using var dataStream = request.GetRequestStream();
                await dataStream.WriteAsync(header, 0, header.Length);
                await dataStream.WriteAsync(fileData, 0, fileData.Length).ConfigureAwait(false);
                await dataStream.WriteAsync(trailer, 0, trailer.Length);
                dataStream.Close();

                // Read the response
                using var response = await request.GetResponseAsync().ConfigureAwait(false);
                using var responseStream = response.GetResponseStream();
                ResponseContent = responseStream.ToText().Result;
                result = Deserialize<EntityWrapper<T>>(ResponseContent).Entity;
            }
            catch (WebException we)
            {
                if (we.Response != null)
                    HandleError(we.Response as HttpWebResponse);
                else
                    HandleConnectionException(we);
            }

            return result;
        }

        protected async Task<byte[]> DownloadFile()
        {
            ResponseContent = "";

            try
            {
                await RateLimit().ConfigureAwait(false);

                var request = SetupRequest(RequestInfo.AbsoluteUrl, RequestMethod.Get);

                using var response = await HttpClient.SendAsync(request).ConfigureAwait(false);
                HttpStatusCode = response.StatusCode;

                if (!response.IsSuccessStatusCode)
                {
                    HandleError(response);
                    return null;
                }

                var data = await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
                return data;
            }
            catch (HttpRequestException we)
            {
                HandleConnectionException(we);
                return null;
            }
        }

        protected ErrorInformation HandleConnectionException(Exception we)
        {
            throw new Exception("Connection to server failed. Check inner exception.", we);
        }
        
        protected void HandleError(HttpWebResponse response)
        {
            using var responseStream = response.GetResponseStream();
            string errorJson = responseStream.ToText().Result;

            try
            {
                Error = Deserialize<EntityWrapper<ErrorInformation>>(errorJson).Entity;
            }
            catch (Exception)
            {
                Error = new ErrorInformation() { Message = $"Could not interpret error information. Response: '{errorJson}'" };
            }
        }

        protected void HandleError(HttpResponseMessage response)
        {
            var errorJson = response.Content.ReadAsStringAsync().Result;

            try
            {
                Error = Deserialize<EntityWrapper<ErrorInformation>>(errorJson).Entity;
            }
            catch (Exception)
            {
                Error = new ErrorInformation() { Message = $"Could not interpret error information. Response: '{errorJson}'"  };
            }
        }

        protected string Serialize<T>(T entity)
        {
            var json = serializer.Serialize(entity);

            if (FixRequestContent != null)
                json = FixRequestContent(json);

            FixRequestContent = null;
            return json;
        }

        protected T Deserialize<T>(string content)
        {
            try
            {
                if (FixResponseContent != null)
                    content = FixResponseContent(content);
                FixResponseContent = null;
                return serializer.Deserialize<T>(content);
            }
            catch (Exception e)
            {
                throw new SerializationException("An error occured while deserializing the response. Check ResponseContent.", e.InnerException);
            }
        }
    }
}
