namespace FortnoxAPILibrary
{
    /// <summary>
    /// Default (global) connection settings. 
    /// <remarks>Changes are not applied to already created connectors.</remarks>
    /// </summary>
    public static class ConnectionSettings
    {
        /// <summary>
        /// Throttles thread on each request
        /// This avoids connection failure due to server side rate limit
        /// </summary>
        public static bool UseRateLimiter { get; set; } = true;

        /// <summary>
        /// API Server URL
        /// </summary>
        public static string FortnoxAPIServer { get; set; } = "https://api.fortnox.se/3"; //TODO: remove /3

        /// <summary>
        /// Timeout for getting response. Default value is 30 seconds
        /// </summary>
        public static int Timeout { get; set; } = 30 * 10000;
    }
}