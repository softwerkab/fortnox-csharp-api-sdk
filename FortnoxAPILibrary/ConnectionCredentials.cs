
using System.Net;
using System.IO;
using System.Xml;
namespace FortnoxAPILibrary
{
	/// <remarks/>
	public static class ConnectionCredentials
	{
        /// <remarks/>
        public static string AccessToken { get; set; }

        /// <remarks/>
        public static string ClientSecret { get; set; }
        /// <remarks/>
        public static string FortnoxAPIServer = "https://api.fortnox.se/3";
	}
}
