namespace FortnoxAPILibrary
{
    /// <summary>
    /// Default (global) connection credentials. 
    /// <remarks>Changes are not applied to already created connectors.</remarks>
    /// </summary>
	public static class ConnectionCredentials
	{
		/// <remarks/>
		public static string AccessToken { get; set; }

		/// <remarks/>
		public static string ClientSecret { get; set; }
    }
}
