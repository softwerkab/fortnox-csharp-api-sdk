using System;
using System.IO;
using System.Net;
using System.Xml;
using System.Xml.Serialization;

namespace FortnoxAPILibrary.Connectors
{
	/// <remarks/>
	public class AuthorisationConnector : UrlRequestBase
	{
		/// <summary>
		/// <para>Use this function to create and get your Access-Token.</para>
		/// <para>NOTE!</para>
		/// <para>This functions should be used only once to get your access-token. If used again the authorisation-code given to you by Fortnox will be invalid. </para>
		/// </summary>
		/// <param name="AuthorisationCode">The authorisation-code given to you by Fortnox</param>
		/// <param name="ClientSecret">The Client-Secret code given to you by Fortnox</param>
		/// <returns>The Access-Token to use with Fortnox</returns>
		public string GetAccessToken(string AuthorisationCode, string ClientSecret)
		{
			string AccessToken = "";
			try
			{
				if (string.IsNullOrEmpty(AuthorisationCode) || string.IsNullOrEmpty(ClientSecret))
				{
					return "";
				}

				HttpWebRequest wr = SetupRequest(ConnectionCredentials.FortnoxAPIServer + "/customers", AuthorisationCode, ClientSecret);
				WebResponse response = wr.GetResponse();
				Stream responseStream = response.GetResponseStream();
				XmlSerializer xs = new XmlSerializer(typeof(Authorisation));
				Authorisation auth = (Authorisation)xs.Deserialize(responseStream);
				AccessToken = auth.AccessToken;
			}
			catch (WebException we)
			{
				Error = HandleException(we);
			}

			return AccessToken;
		}

		private static HttpWebRequest SetupRequest(string requestUriString, string AuthorisationCode, string ClientSecret)
		{
			HttpWebRequest wr = (HttpWebRequest)HttpWebRequest.Create(requestUriString);
			wr.Headers.Add("authorisation-code", AuthorisationCode);
			wr.Headers.Add("client-secret", ClientSecret);
			wr.ContentType = "application/xml";
			wr.Accept = "application/xml";
			wr.Method = "GET";
			return wr;
		}

	}
}
