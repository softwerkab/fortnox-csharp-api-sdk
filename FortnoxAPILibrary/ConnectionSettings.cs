namespace FortnoxAPILibrary
{
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
        public static string FortnoxAPIServer { get; set; } = "https://api.fortnox.se/3";
    }
}