using System;
using System.Net;
using System.Net.Http;

namespace FortnoxAPILibrary.SDK.Auth
{
    public class StaticTokenAuth : FortnoxAuthorization
    {
        public string ClientSecret { get; set; }

        public StaticTokenAuth(string accessToken, string clientSecret)
        {
            AccessToken = accessToken;
            ClientSecret = clientSecret;
        }

        internal override void ApplyTo(HttpRequestMessage request)
        {
            throw new NotSupportedException("Static authorization flow is not support anymore. Use Auth2.0");
        }

        internal override void ApplyTo(HttpWebRequest request)
        {
            throw new NotSupportedException("Static authorization flow is not support anymore. Use Auth2.0");
        }
    }
}