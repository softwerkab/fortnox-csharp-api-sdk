using System;

namespace Fortnox.SDK
{
    /// <summary>
    /// Default (global) connection credentials.
    /// All connectors created by constructor will use these credentials by default
    /// <remarks>Changes are not applied to already created connectors.</remarks>
    /// </summary>
    [Obsolete("Use FortnoxClient class instead")]
	public static class ConnectionCredentials
	{
		/// <remarks/>
		public static string AccessToken { get; set; }

		/// <remarks/>
		public static string ClientSecret { get; set; }
    }
}
