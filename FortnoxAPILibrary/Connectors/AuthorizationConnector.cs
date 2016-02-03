using System;
using System.IO;
using System.Net;
using System.Xml;
using System.Xml.Serialization;

namespace FortnoxAPILibrary.Connectors
{
	/// <remarks/>
	public class AuthorizationConnector : UrlRequestBase
	{
		/// <summary>
		/// <para>Use this function to create and get your Access-Token.</para>
		/// <para>NOTE!</para>
		/// <para>This functions should be used only once to get your access-token. If used again the authorisation-code given to you by Fortnox will be invalid. </para>
		/// </summary>
		/// <param name="AuthorizationCode">The authorisation-code given to you by Fortnox</param>
		/// <param name="ClientSecret">The Client-Secret code given to you by Fortnox</param>
		/// <returns>The Access-Token to use with Fortnox</returns>
		public string GetAccessToken(string AuthorizationCode, string ClientSecret)
		{
			string AccessToken = "";
			try
			{
				if (string.IsNullOrEmpty(AuthorizationCode) || string.IsNullOrEmpty(ClientSecret))
				{
					return "";
				}

				HttpWebRequest wr = SetupRequest(ConnectionCredentials.FortnoxAPIServer, AuthorizationCode, ClientSecret);
				WebResponse response = wr.GetResponse();
				Stream responseStream = response.GetResponseStream();
				XmlSerializer xs = new XmlSerializer(typeof(Authorization));
				Authorization auth = (Authorization)xs.Deserialize(responseStream);
				AccessToken = auth.AccessToken;
			}
			catch (WebException we)
			{
				Error = HandleException(we);
			}

			return AccessToken;
		}

		private static HttpWebRequest SetupRequest(string requestUriString, string AuthorizationCode, string ClientSecret)
		{
			HttpWebRequest wr = (HttpWebRequest)HttpWebRequest.Create(requestUriString);
			wr.Headers.Add("authorization-code", AuthorizationCode);
			wr.Headers.Add("client-secret", ClientSecret);
			wr.ContentType = "application/xml";
			wr.Accept = "application/xml";
			wr.Method = "GET";
			return wr;
		}
	}
}
