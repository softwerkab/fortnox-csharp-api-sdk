using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;
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

        /// <summary>
        /// Optional Fortnox Client Secret, if used it will override the static version.
        /// </summary>
        /// <exception cref="Exception">Exception will be thrown if client secret is not set.</exception>
        public string ClientSecret
		{
			get
			{
				if (!string.IsNullOrEmpty(clientSecret))
				{
					return clientSecret;
				}

				if (!string.IsNullOrEmpty(ConnectionCredentials.ClientSecret))
				{
					return ConnectionCredentials.ClientSecret;
				}

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
				{
					return accessToken;
				}

				if (!string.IsNullOrEmpty(ConnectionCredentials.AccessToken))
				{
					return ConnectionCredentials.AccessToken;
				}

				throw new Exception("Fortnox Access Token must be set.");
			}
			set => accessToken = value;
        }

		/// <summary>
		/// Timeout of requests sent to the Fortnox API in miliseconds
		/// </summary>
		public int Timeout { get; set; }

        /// <remarks/>
        public ErrorInformation Error { get; set; }

        /// <summary>
        /// The HttpStatusCode returned by Fortnox API.
        /// </summary>
        public HttpStatusCode HttpStatusCode { get; set; }

        /// <summary>
        /// The data sent to Fortnox in Xml-format.
        /// </summary>
        public string RequestXml { get; set; }
        /// <summary>
        /// The data returned from Fortnox in Xml-format. 
        /// </summary>
        public string ResponseXml { get; set; }

        /// <summary>
        /// True if something went wrong with the request. Otherwise false.
        /// </summary>
        public bool HasError => Error != null;

        internal string Resource { get; set; }
        internal string Method { get; set; }
        internal string RequestUriString { get; set; }
        internal string LocalPath { get; set; }

        internal RequestResponseType ResponseType { get; set; }
        internal enum RequestResponseType
        {
            XML,
            PDF,
            File,
            EMAIL
        }

        /// <remarks />
        public UrlRequestBase()
        {
            Timeout = 300000;
        }

        internal string GetUrl(string index = "")
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
        internal void RateLimit()
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
        internal HttpWebRequest SetupRequest(string requestUriString, string method)
        {
            Error = null;

            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(requestUriString);
            wr.Headers.Add("access-token", AccessToken);
            wr.Headers.Add("client-secret", ClientSecret);
            wr.ContentType = "application/xml";
            wr.Accept = "application/xml";
            wr.Method = method;
            wr.Timeout = Timeout;            

            return wr;
        }

        /// <summary>
        /// Perform the request to Fortnox API
        /// </summary>
        internal void DoRequest()
        {
            var wr = SetupRequest(RequestUriString, Method);

            try
            {
                RateLimit();

                if (Method != "GET")
                {
                    using (wr.GetRequestStream()) { }
                }

                using (var response = (HttpWebResponse) wr.GetResponse())
                {
                    HttpStatusCode = response.StatusCode;
                }
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
        internal T DoRequest<T>(T entity = default)
        {
            var wr = SetupRequest(RequestUriString, Method);
            ResponseXml = "";
            try
            {
                RateLimit();

                var xs = new XmlSerializer(typeof(T));

                if (Method != "GET")
                {
                    using (Stream requestStream = wr.GetRequestStream())
                    {
                        xs.Serialize(requestStream, entity);
                    }
                }

                if (Method == "POST" || Method == "PUT")
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        using (var xmlWriter = XmlWriter.Create(memoryStream))
                        {
                            xs.Serialize(xmlWriter, entity);
                            RequestXml = Encoding.UTF8.GetString(memoryStream.ToArray());
                        }
                    }
                }

                using (var response = (HttpWebResponse) wr.GetResponse())
                {
                    HttpStatusCode = response.StatusCode;
                    using (var responseStream = response.GetResponseStream())
                    {
                        if (ResponseType == RequestResponseType.PDF)
                        {
                            WriteStream(responseStream);
                        }
                        else
                        {
                            if (response.Headers["Content-Disposition"] != null && response.Headers["Content-Disposition"].Split(';')[0] == "attachment")
                            {
                                throw new Exception("The specified path is a file. Use DownloadFile() to download the file.");
                            }

                            if (ResponseType == RequestResponseType.XML)
                            {
                                using (var sr = new StreamReader(responseStream))
                                {
                                    ResponseXml = sr.ReadToEnd();
                                    try
                                    {
                                        return (T)xs.Deserialize(new StringReader(ResponseXml));
                                    }
                                    catch (Exception e)
                                    {
                                        throw new Exception("An error occured while deserializing the response. Check ResponseXML.", e.InnerException);
                                    }
                                }
                            }

                            if (ResponseType == RequestResponseType.EMAIL)
                            {
                                return default;
                            }

                            using (var sr = new StreamReader(responseStream))
                            {
                                using (var sw = new StreamWriter(LocalPath))
                                {
                                    sw.Write(sr.ReadToEnd());
                                }
                            }
                            return default;
                        }
                    }
                }
            }
            catch (WebException we)
            {
                Error = HandleException(we);
            }

            return entity;
        }

        internal T UploadFile<T>(string localPath, byte[] fileData = null, string fileName = null)
        {
            ResponseXml = "";

            T result = default;

            try
            {
				// prepp name and data
				if (fileData == null)
				{
					fileName = Path.GetFileName(localPath);
					fileData = System.IO.File.ReadAllBytes(localPath);
				}

				var xs = new XmlSerializer(typeof(T));

                var rand = new Random();
                var boundary = "----boundary" + rand.Next();
                var header = Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\nContent-Disposition: form-data; name=\"file_path\"; filename=\"" + fileName + "\"\r\nContent-Type: application/octet-stream\r\n\r\n");
                var trailer = Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");

                var request = SetupRequest(RequestUriString, "POST");
                request.ContentType = "multipart/form-data; boundary=" + boundary;

                using (var dataStream = request.GetRequestStream())
                {
                    dataStream.Write(header, 0, header.Length);
                    dataStream.Write(fileData, 0, fileData.Length);
                    dataStream.Write(trailer, 0, trailer.Length);
                    dataStream.Close();

                    // Read the response
                    using (var response = request.GetResponse())
                    {
                        using (var responseDataStream = response.GetResponseStream())
                        {
                            using (var sr = new StreamReader(responseDataStream))
                            {
                                ResponseXml = sr.ReadToEnd();
                            }
                            using (var sr = new StringReader(ResponseXml))
                            {
                                result = (T)xs.Deserialize(sr);
                            }
                        }
                    }
                }
            }
            catch (WebException we)
            {
                Error = HandleException(we);
            }

            return result;
        }

        internal void DownloadFile(string idOrPath, string localPath, File file = null)
        {
            ResponseXml = "";

            try
            {
                string url;
                
                if (Guid.TryParse(idOrPath, out var unused))
                    url = GetUrl(idOrPath);
                else
                    url = GetUrl() + "?path=" + Uri.EscapeDataString(idOrPath);

                LocalPath = localPath;

                var request = SetupRequest(url, "GET");

                using (var response = (HttpWebResponse) request.GetResponse())
                {
                    HttpStatusCode = response.StatusCode;
                    using (var responseStream = response.GetResponseStream())
                    {
						if (file == null)
						{
							// hdd
							WriteStream(responseStream);
						}
						else
						{
							// memory                          
							using (var ms = new MemoryStream())
							{
								file.ContentType = response.Headers["Content-Type"];
								responseStream.CopyTo(ms);
								file.Data = ms.ToArray();								
							}
						}
					}
				}
			}
            catch (WebException we)
            {
                Error = HandleException(we);
            }
        }

        internal File MoveFile(string fileId, string destination)
        {
            ResponseXml = "";

            try
            {
                var xs = new XmlSerializer(typeof(File));

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
                using (var response = (HttpWebResponse) request.GetResponse())
                {
                    HttpStatusCode = response.StatusCode;
                    using (var responseStream = response.GetResponseStream())
                    {
                        using (var sr = new StreamReader(responseStream))
                        {
                            ResponseXml = sr.ReadToEnd();
                        }
                        using (var sr = new StringReader(ResponseXml))
                        {
                            return (File) xs.Deserialize(sr);
                        }
                    }
                }
            }
            catch (WebException we)
            {
                Error = HandleException(we);
            }

            return null;
        }

        private void WriteStream(Stream readStream)
        {
            using (var writeStream = new FileStream(LocalPath, FileMode.Create, FileAccess.Write))
            {
                readStream.CopyTo(writeStream);
            }
        }

        internal ErrorInformation HandleException(WebException we)
        {
            if (we.Response == null)
            {
                throw new Exception("Inget svar från Fortnox API. Kontrollera inre exception.", we);
            }
            using (var response = (HttpWebResponse)we.Response)
            {
                HttpStatusCode = response.StatusCode;

                if (response == null || HttpStatusCode == HttpStatusCode.InternalServerError)
                {
                    throw we;
                }
                using (var errorStream = response.GetResponseStream())
                {
                    var errorSerializer = new XmlSerializer(typeof(ErrorInformation));

                    try
                    {
                        Error = (ErrorInformation)errorSerializer.Deserialize(errorStream);
                        if (Error.Code == "2001392")
                        {
                            Error.Message = "No information was provided for the entity.";
                        }

                        return Error;
                    }
                    catch (Exception ex)
                    {
                        throw we;//TODO: Fix Bug - crashed when TooManyRequests Error (429)

                        /*errorStream.Position = 0;
                        using (StreamReader reader = new StreamReader(errorStream))
                        {
                            string text = reader.ReadToEnd();

                            throw new Exception("Kunde inte tolka felmeddelandet från Fortnox API.\n\n" + text, ex.InnerException);
                        }*/
                    }
                }
            }
        }
    }
}
