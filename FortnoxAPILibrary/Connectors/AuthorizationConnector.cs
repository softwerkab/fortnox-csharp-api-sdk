using System.Net;
using FortnoxAPILibrary.Entities;
using Authorization = FortnoxAPILibrary.Entities.Authorization;

// ReSharper disable UnusedMember.Global

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
		/// <param name="authorizationCode">The authorisation-code given to you by Fortnox</param>
		/// <param name="clientSecret">The Client-Secret code given to you by Fortnox</param>
		/// <returns>The Access-Token to use with Fortnox</returns>
		public string GetAccessToken(string authorizationCode, string clientSecret)
		{
			string accessToken = "";
			try
			{
				if (string.IsNullOrEmpty(authorizationCode) || string.IsNullOrEmpty(clientSecret))
				{
					return "";
				}

				var wr = SetupRequest(ConnectionSettings.FortnoxAPIServer, authorizationCode, clientSecret);
                using var response = wr.GetResponse();
                using var responseStream = response.GetResponseStream();
				var auth = Deserialize<EntityWrapper<Authorization>>(responseStream.ToText());
				accessToken = auth.Entity.AccessToken;
			}
			catch (WebException we)
			{
				Error = HandleException(we);
			}

			return accessToken;
		}

		private static HttpWebRequest SetupRequest(string requestUriString, string authorizationCode, string clientSecret)
		{
			var wr = (HttpWebRequest)WebRequest.Create(requestUriString);
			wr.Headers.Add("authorization-code", authorizationCode);
			wr.Headers.Add("client-secret", clientSecret);
			wr.ContentType = "application/json";
			wr.Accept = "application/json";
			wr.Method = "GET";
			return wr;
		}

	}
}
