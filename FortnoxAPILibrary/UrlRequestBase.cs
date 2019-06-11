using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;
using FortnoxAPILibrary.Exceptions;
using FortnoxError;

namespace FortnoxAPILibrary
{
    /// <remarks/>
    public class UrlRequestBase
    {
		string clientSecret;

		string accessToken;

        /// <summary>
        /// link to restriction info:
        /// https://developer.fortnox.se/documentation/general/regarding-fortnox-api-rate-limits/
        /// </summary>
        private int MAX_REQUESTS_PER_SECOND = 4;
        private DateTime firstRequest = DateTime.Now;
        private int currentRequestsPerSecond = 0;

        /// <summary>
        /// Optional Fortnox Client Secret, if used it will override the static version.
        /// </summary>
        /// <exception cref="Exception">Exception will be thrown if client secret is not set.</exception>
        public string ClientSecret
		{
			get
			{
				if (!string.IsNullOrEmpty(this.clientSecret))
				{
					return this.clientSecret;
				}

				if (!string.IsNullOrEmpty(ConnectionCredentials.ClientSecret))
				{
					return ConnectionCredentials.ClientSecret;
				}

				throw new Exception("Fortnox Client Secret must be set.");
			}
			set
			{
				this.clientSecret = value;
			}
		}

		/// <summary>
		/// Optional Fortnox Access Token, if used it will override the static version.
		/// </summary>
		/// /// <exception cref="Exception">Exception will be thrown if access token is not set.</exception>
		public string AccessToken
		{
			get
			{
				if (!string.IsNullOrEmpty(this.accessToken))
				{
					return this.accessToken;
				}

				if (!string.IsNullOrEmpty(ConnectionCredentials.AccessToken))
				{
					return ConnectionCredentials.AccessToken;
				}

				throw new Exception("Fortnox Access Token must be set.");
			}
			set
			{
				this.accessToken = value;
			}
		}

		/// <summary>
		/// Timeout of requests sent to the Fortnox API in miliseconds
		/// </summary>
		public int Timeout { get; set; }

        /// <remarks/>
        public FortnoxError.ErrorInformation Error { get; set; }

        /// <summary>
        /// The HttpStatusCode returned by Fortnox API.
        /// </summary>
        public HttpStatusCode httpStatusCode { get; set; }

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
        public bool HasError
        {
            get { return this.Error != null ? true : false; }
        }

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
            this.Timeout = 300000;
        }

        internal string GetUrl(string index = "")
        {
            string[] str = new string[]{
				ConnectionCredentials.FortnoxAPIServer,
				this.Resource,
				index
			};

            str = str.Where(s => s != "").ToArray();

            string requestUriString = String.Join("/", str);

            return requestUriString;
        }

        /// <summary>
        /// This method is used to throttle every call to Fortnox. 
        /// </summary>
        internal void RateLimit()
        {
            bool reset = false;

            currentRequestsPerSecond++;

            if ((DateTime.Now - firstRequest).TotalMilliseconds >= (double)1000.0) reset = true;
            else if (currentRequestsPerSecond >= MAX_REQUESTS_PER_SECOND)
            {
                // Wait out remainder of current second
                Thread.Sleep(Convert.ToInt32((double)1000.0 - (DateTime.Now - firstRequest).TotalMilliseconds));
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

            HttpWebRequest wr = (HttpWebRequest)HttpWebRequest.Create(requestUriString);
            wr.Headers.Add("access-token", this.AccessToken);
            wr.Headers.Add("client-secret", this.ClientSecret);
            wr.ContentType = "application/xml";
            wr.Accept = "application/xml";
            wr.Method = method;
            wr.Timeout = this.Timeout;            

            return wr;
        }

        /// <summary>
        /// Perform the request to Fortnox API
        /// </summary>
        internal void DoRequest()
        {
            HttpWebRequest wr = this.SetupRequest(this.RequestUriString, Method);

            try
            {
                RateLimit();

                if (Method != "GET")
                {
                    using (wr.GetRequestStream()) { }
                }

                using (HttpWebResponse response = (HttpWebResponse) wr.GetResponse())
                {
                    httpStatusCode = response.StatusCode;
                }
            }
            catch (WebException we)
            {
                Error = this.HandleException(we);
            }
        }

        /// <summary>
        /// Perform the request to Fortnox API
        /// </summary>
        /// <typeparam name="T">The type of entity to create, read, update or delete.</typeparam>
        /// <param name="entity">The entity</param>
        /// <returns>An entity</returns>
        internal T DoRequest<T>(T entity = default(T))
        {
            HttpWebRequest wr = this.SetupRequest(this.RequestUriString, Method);
            this.ResponseXml = "";
            try
            {
                RateLimit();

                XmlSerializer xs = new XmlSerializer(typeof(T));

                if (Method != "GET")
                {
                    using (Stream requestStream = (Stream) wr.GetRequestStream())
                    {
                        xs.Serialize(requestStream, entity);
                    }
                }

                if (Method == "POST" || Method == "PUT")
                {
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        using (XmlWriter xmlWriter = XmlWriter.Create(memoryStream))
                        {
                            xs.Serialize(xmlWriter, entity);
                            RequestXml = Encoding.UTF8.GetString(memoryStream.ToArray());
                        }
                    }
                }

                using (HttpWebResponse response = (HttpWebResponse) wr.GetResponse())
                {
                    httpStatusCode = response.StatusCode;
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        if (this.ResponseType == RequestResponseType.PDF)
                        {
                            WriteStream(responseStream);
                        }
                        else
                        {
                            if (response.Headers["Content-Disposition"] != null && response.Headers["Content-Disposition"].Split(';')[0] == "attachment")
                            {
                                throw new Exception("The specified path is a file. Use DownloadFile() to download the file.");
                            }
                            else if (this.ResponseType == RequestResponseType.XML)
                            {
                                using (var sr = new StreamReader(responseStream))
                                {
                                    this.ResponseXml = sr.ReadToEnd();
                                    try
                                    {
                                        return (T)xs.Deserialize(new StringReader(this.ResponseXml));
                                    }
                                    catch (Exception e)
                                    {
                                        throw new Exception("An error occured while deserializing the response. Check ResponseXML.", e.InnerException);
                                    }
                                }
                            }
                            else if (this.ResponseType == RequestResponseType.EMAIL)
                            {
                                return default(T);
                            }
                            else
                            {
                                using (StreamReader sr = new StreamReader(responseStream))
                                {
                                    using (StreamWriter sw = new StreamWriter(this.LocalPath))
                                    {
                                        sw.Write(sr.ReadToEnd());
                                    }
                                }
                                return default(T);
                            }
                        }
                    }
                }
            }
            catch (WebException we)
            {
                this.HandleException(we);
            }

            return entity;
        }

        internal T UploadFile<T>(string localPath, byte[] fileData = null, string fileName = null)
        {
            this.ResponseXml = "";

            T result = default(T);

            try
            {
				// prepp name and data
				if (fileData == null)
				{
					fileName = System.IO.Path.GetFileName(localPath);
					fileData = System.IO.File.ReadAllBytes(localPath);
				}

				XmlSerializer xs = new XmlSerializer(typeof(T));

                Random rand = new Random();
                string boundary = "----boundary" + rand.Next().ToString();
                byte[] header = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\nContent-Disposition: form-data; name=\"file_path\"; filename=\"" + fileName + "\"\r\nContent-Type: application/octet-stream\r\n\r\n");
                byte[] trailer = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");

                HttpWebRequest request = this.SetupRequest(this.RequestUriString, "POST");
                request.ContentType = "multipart/form-data; boundary=" + boundary;

                using (Stream data_stream = request.GetRequestStream())
                {
                    data_stream.Write(header, 0, header.Length);
                    data_stream.Write(fileData, 0, fileData.Length);
                    data_stream.Write(trailer, 0, trailer.Length);
                    data_stream.Close();

                    // Read the response
                    using (WebResponse response = request.GetResponse())
                    {
                        using (var response_data_stream = response.GetResponseStream())
                        {
                            using (var sr = new StreamReader(response_data_stream))
                            {
                                this.ResponseXml = sr.ReadToEnd();
                            }
                            using (var sr = new StringReader(this.ResponseXml))
                            {
                                result = (T)xs.Deserialize(sr);
                            }
                        }
                    }
                }
            }
            catch (WebException we)
            {
                Error = this.HandleException(we);
            }

            return result;
        }

        internal void DownloadFile(string idOrPath, string localPath, File file = null)
        {
            this.ResponseXml = "";

            try
            {
                string url = "";
                Guid test = new Guid();

                if (Guid.TryParse(idOrPath, out test))
                {
                    url = this.GetUrl(idOrPath);
                }
                else
                {
                    url = this.GetUrl() + "?path=" + Uri.EscapeDataString(idOrPath);
                }

                this.LocalPath = localPath;

                HttpWebRequest request = this.SetupRequest(url, "GET");

                using (HttpWebResponse response = (HttpWebResponse) request.GetResponse())
                {
                    httpStatusCode = response.StatusCode;
                    using (Stream responseStream = response.GetResponseStream())
                    {
						if (file == null)
						{
							// hdd
							WriteStream(responseStream);
						}
						else
						{
							// memory                          
							using (var ms = new System.IO.MemoryStream())
							{
								file.ContentType = response.Headers["Content-Type"];
                                file.Name = GetFileName(response.Headers);
								responseStream.CopyTo(ms);
								file.Data = ms.ToArray();								
							}
						}
					}
				}
			}
            catch (WebException we)
            {
                Error = this.HandleException(we);
            }
        }

        static string GetFileName(WebHeaderCollection responseHeaders)
        {
            var contentDisposition = responseHeaders.Get("Content-Disposition");
            if (string.IsNullOrEmpty(contentDisposition))
                return null;

            var parts = contentDisposition.Split(";");
            var fileNamePart = parts.FirstOrDefault(p => p.Trim().StartsWith("filename="));

            return fileNamePart?.Trim().Replace("filename=", string.Empty);
        }

        internal File MoveFile(string fileId, string destination)
        {
            this.ResponseXml = "";

            File file = default(File);

            try
            {

                XmlSerializer xs = new XmlSerializer(typeof(File));

                string url = ConnectionCredentials.FortnoxAPIServer + "/" + this.Resource + "/move/" + fileId;
                Guid test = new Guid();

                if (String.IsNullOrWhiteSpace(destination) || Guid.TryParse(destination, out test))
                {
                    url += "/" + destination;
                }
                else
                {
                    url += "/?destination=" + Uri.EscapeDataString(destination);
                }

                HttpWebRequest request = this.SetupRequest(url, "PUT");
                using (HttpWebResponse response = (HttpWebResponse) request.GetResponse())
                {
                    httpStatusCode = response.StatusCode;
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        using (var sr = new StreamReader(responseStream))
                        {
                            this.ResponseXml = sr.ReadToEnd();
                        }
                        using (var sr = new StringReader(this.ResponseXml))
                        {
                            return (File) xs.Deserialize(sr);
                        }
                    }
                }
            }
            catch (WebException we)
            {
                Error = this.HandleException(we);
            }

            return file;
        }

        private void WriteStream(Stream readStream)
        {
            using (FileStream writeStream = new FileStream(this.LocalPath, FileMode.Create, FileAccess.Write))
            {
                readStream.CopyTo(writeStream);
            }
        }

        internal FortnoxError.ErrorInformation HandleException(WebException we)
        {
            if (we.Response == null)
            {
                throw new Exception("Inget svar från Fortnox API. Kontrollera inre exception.", we);
            }
            using (HttpWebResponse response = (HttpWebResponse)we.Response)
            {
                this.httpStatusCode = response.StatusCode;

                switch (httpStatusCode)
                {
                    case HttpStatusCode.InternalServerError:
                        throw we;
                    case HttpStatusCode.TooManyRequests:
                        throw new FortnoxTooManyRequestsException(we.Message, we)
                        {
                            Code = httpStatusCode
                        };
                }

                using (var errorStream = response.GetResponseStream())
                using (var memStream = new MemoryStream())
                {
                    errorStream.CopyTo(memStream);
                    memStream.Seek(0, SeekOrigin.Begin);

                    XmlSerializer errorSerializer = new XmlSerializer(typeof(FortnoxError.ErrorInformation));

                    try
                    {
                        Error = (FortnoxError.ErrorInformation)errorSerializer.Deserialize(memStream);
                        if (Error.Code == "2001392")
                        {
                            Error.Message = "No information was provided for the entity.";
                        }

                        return Error;
                    }
                    catch (Exception ex)
                    {
                        memStream.Seek(0, SeekOrigin.Begin);
                        using (StreamReader reader = new StreamReader(memStream))
                        {
                            string text = reader.ReadToEnd();

                            throw new Exception("Kunde inte tolka felmeddelandet från Fortnox API.\n\n" + text, ex.InnerException);
                        }
                    }
                }
            }
        }
    }
}
