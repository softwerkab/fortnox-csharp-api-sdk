using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Serialization;
using File = FortnoxAPILibrary.Entities.File;

namespace FortnoxAPILibrary
{
    /// <remarks/>
    public class UrlRequestBase
    {
		private string clientSecret;
        private string accessToken;

        private const int MaxRequestsPerSecond = 3;
        private static DateTime firstRequest = DateTime.Now;
        private static int currentRequestsPerSecond;

        private readonly JsonEntitySerializer serializer;

        /// <summary>
        /// Optional Fortnox Client Secret, if used it will override the static version.
        /// </summary>
        /// <exception cref="Exception">Exception will be thrown if client secret is not set.</exception>
        public string ClientSecret
		{
			get
			{
				if (!string.IsNullOrEmpty(clientSecret))
                    return clientSecret;

                if (!string.IsNullOrEmpty(ConnectionCredentials.ClientSecret))
                    return ConnectionCredentials.ClientSecret;

                throw new Exception("Fortnox Client Secret must be set.");
			}
			set => clientSecret = value;
        }

		/// <summary>
		/// Optional Fortnox Access Token, if used it will override the static version.
		/// </summary>
		/// /// <exception cref="Exception">Exception will be thrown if access token is not set.</exception>
		public string AccessToken
		{
			get
			{
				if (!string.IsNullOrEmpty(accessToken))
                    return accessToken;

                if (!string.IsNullOrEmpty(ConnectionCredentials.AccessToken))
                    return ConnectionCredentials.AccessToken;

                throw new Exception("Fortnox Access Token must be set.");
			}
			set => accessToken = value;
        }

		/// <summary>
		/// Timeout of requests sent to the Fortnox API in miliseconds
		/// </summary>
		public int Timeout { get; set; }

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

        public string Resource { get; protected set; }
        public string Method { get; protected set; }
        public string RequestUriString { get; protected set; }
        public string LocalPath { get; protected set; }

        public RequestResponseType ResponseType { get; protected set; }

        /// <remarks />
        public UrlRequestBase()
        {
            Timeout = 300000;
            serializer = new JsonEntitySerializer();
        }

        protected string GetUrl(string index = "")
        {
            string[] str = {
				ConnectionCredentials.FortnoxAPIServer,
				Resource,
				index
			};

            str = str.Where(s => s != "").ToArray();

            string requestUriString = string.Join("/", str);

            return requestUriString;
        }

        /// <summary>
        /// This method is used to throttle every call to Fortnox. 
        /// </summary>
        protected void RateLimit()
        {
            bool reset = false;

            currentRequestsPerSecond++;

            if ((DateTime.Now - firstRequest).TotalMilliseconds >= 1000.0) reset = true;
            else if (currentRequestsPerSecond >= MaxRequestsPerSecond)
            {
                // Wait out remainder of current second
                Thread.Sleep(Convert.ToInt32(1000.0 - (DateTime.Now - firstRequest).TotalMilliseconds));
                reset = true;
            }

            if (reset)
            {
                currentRequestsPerSecond = 0;
                firstRequest = DateTime.Now;
            }
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
        protected HttpWebRequest SetupRequest(string requestUriString, string method)
        {
            Error = null;

            ServicePointManager.SecurityProtocol = ConnectionCredentials.SecurityProtocol;

            var wr = (HttpWebRequest)WebRequest.Create(requestUriString);
            wr.Headers.Add("access-token", AccessToken);
            wr.Headers.Add("client-secret", ClientSecret);
            wr.ContentType = "application/json";
            wr.Accept = "application/json";
            wr.Method = method;
            wr.Timeout = Timeout;            

            return wr;
        }

        /// <summary>
        /// Perform the request to Fortnox API
        /// </summary>
        protected void DoRequest()
        {
            var wr = SetupRequest(RequestUriString, Method);

            try
            {
                RateLimit();

                if (Method != "GET")
                {
                    using (wr.GetRequestStream()) { } //TODO: What is the purpose of this?
                }

                using var response = (HttpWebResponse) wr.GetResponse();
                HttpStatusCode = response.StatusCode;
            }
            catch (WebException we)
            {
                Error = HandleException(we);
            }
        }

        /// <summary>
        /// Perform the request to Fortnox API
        /// </summary>
        /// <typeparam name="T">The type of entity to create, read, update or delete.</typeparam>
        /// <param name="entity">The entity</param>
        /// <returns>An entity</returns>
        protected T DoRequest<T>(T entity = default)
        {
            var wr = SetupRequest(RequestUriString, Method);
            ResponseContent = "";
            try
            {
                RateLimit();

                if (Method != "GET")
                {
                    using var requestStream = wr.GetRequestStream();
                    var json = Serialize(entity);
                    requestStream.WriteText(json);
                }

                if (Method == "POST" || Method == "PUT")
                {
                    RequestContent = Serialize(entity);
                }

                using var response = (HttpWebResponse) wr.GetResponse();
                HttpStatusCode = response.StatusCode;
                using var responseStream = response.GetResponseStream();
                if (ResponseType == RequestResponseType.PDF)
                {
                    responseStream.ToFile(LocalPath);
                }
                else
                {
                    if (response.Headers["Content-Disposition"] != null && response.Headers["Content-Disposition"].Split(';')[0] == "attachment")
                    {
                        throw new Exception("The specified path is a file. Use DownloadFile() to download the file.");
                    }

                    switch (ResponseType)
                    {
                        case RequestResponseType.JSON:
                            ResponseContent = responseStream.ToText();
                            return Deserialize<T>(ResponseContent);
                        case RequestResponseType.EMAIL:
                            return default;
                        default:
                            responseStream.ToFile(LocalPath);
                            return default;
                    }
                }
            }
            catch (WebException we)
            {
                Error = HandleException(we);
            }

            return default;
        }

        protected T UploadFile<T>(string localPath, byte[] fileData = null, string fileName = null)
        {
            ResponseContent = "";

            T result = default;

            try
            {
				// prepp name and data
				if (fileData == null)
				{
					fileName = Path.GetFileName(localPath);
					fileData = System.IO.File.ReadAllBytes(localPath);
				}

                var rand = new Random();
                var boundary = "----boundary" + rand.Next();
                var header = Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\nContent-Disposition: form-data; name=\"file_path\"; filename=\"" + fileName + "\"\r\nContent-Type: application/octet-stream\r\n\r\n");
                var trailer = Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");

                var request = SetupRequest(RequestUriString, "POST");
                request.ContentType = "multipart/form-data; boundary=" + boundary;

                using var dataStream = request.GetRequestStream();
                dataStream.Write(header, 0, header.Length);
                dataStream.Write(fileData, 0, fileData.Length);
                dataStream.Write(trailer, 0, trailer.Length);
                dataStream.Close();

                // Read the response
                using var response = request.GetResponse();
                using var responseStream = response.GetResponseStream();
                ResponseContent = responseStream.ToText();
                result = Deserialize<EntityWrapper<T>>(ResponseContent).Entity;
            }
            catch (WebException we)
            {
                Error = HandleException(we);
            }

            return result;
        }

        protected void DownloadFile(string idOrPath, string localPath, File file = null)
        {
            ResponseContent = "";

            try
            {
                string url;
                
                if (Guid.TryParse(idOrPath, out var unused))
                    url = GetUrl(idOrPath);
                else
                    url = GetUrl() + "?path=" + Uri.EscapeDataString(idOrPath);

                LocalPath = localPath;

                var request = SetupRequest(url, "GET");

                using var response = (HttpWebResponse) request.GetResponse();
                HttpStatusCode = response.StatusCode;
                using var responseStream = response.GetResponseStream();
                if (file == null)
                {
                    // hdd
                    responseStream.ToFile(LocalPath);
                }
                else
                {
                    // memory                          
                    file.ContentType = response.Headers["Content-Type"];
                    file.Data = responseStream.ToBytes();
                }
            }
            catch (WebException we)
            {
                Error = HandleException(we);
            }
        }

        protected File MoveFile(string fileId, string destination)
        {
            ResponseContent = "";

            try
            {
                var url = ConnectionCredentials.FortnoxAPIServer + "/" + Resource + "/move/" + fileId;

                if (string.IsNullOrWhiteSpace(destination) || Guid.TryParse(destination, out var unused))
                {
                    url += "/" + destination;
                }
                else
                {
                    url += "/?destination=" + Uri.EscapeDataString(destination);
                }

                var request = SetupRequest(url, "PUT");
                using var response = (HttpWebResponse)request.GetResponse();
                HttpStatusCode = response.StatusCode;
                using var responseStream = response.GetResponseStream();
                ResponseContent = responseStream.ToText();
                return Deserialize<EntityWrapper<File>>(ResponseContent).Entity;
            }
            catch (WebException we)
            {
                Error = HandleException(we);
            }

            return null;
        }
        
        protected ErrorInformation HandleException(WebException we)
        {
            if (we.Response == null)
            {
                throw new Exception("Inget svar från Fortnox API. Kontrollera inre exception.", we);
            }

            using var response = (HttpWebResponse)we.Response;
            HttpStatusCode = response.StatusCode;

            if (response == null || HttpStatusCode == HttpStatusCode.InternalServerError)
            {
                throw we;
            }

            using var responseStream = response.GetResponseStream();
            string errorJson = responseStream.ToText();

            try
            {
                Error = Deserialize<EntityWrapper<ErrorInformation>>(errorJson).Entity;
                if (Error.Code == "2001392")
                {
                    Error.Message = "No information was provided for the entity.";
                }

                return Error;
            }
            catch (Exception)
            {
                //Could not interpret error message from Fortnox API.
                throw we;
            }
        }

        protected string Serialize<T>(T entity)
        {
            return serializer.Serialize(entity);
        }

        protected T Deserialize<T>(string content)
        {
            try
            {
                return serializer.Deserialize<T>(content);
            }
            catch (Exception e)
            {
                throw new Exception("An error occured while deserializing the response. Check ResponseContent.", e.InnerException);
            }
        }

        public enum RequestResponseType
        {
            JSON,
            PDF,
            File,
            EMAIL
        }
    }
}
