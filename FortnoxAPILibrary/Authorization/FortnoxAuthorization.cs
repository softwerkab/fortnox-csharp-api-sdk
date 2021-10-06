using System.Net;
using System.Net.Http;

namespace FortnoxAPILibrary.SDK.Auth
{
    /// <summary>
    /// Represents authorization/credentials for accessing Fortnox API
    /// </summary>
    public abstract class FortnoxAuthorization
    {   
        public string AccessToken { get; set; }
        internal abstract void ApplyTo(HttpRequestMessage request);
        internal abstract void ApplyTo(HttpWebRequest request);
    }
}
