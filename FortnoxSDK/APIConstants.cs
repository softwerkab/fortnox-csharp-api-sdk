// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK
{
    /// <remarks/>
    public class APIConstants
    {
        //TODO: Temporary constant - remove when not needed anymore
        internal const string ObsoleteSyncMethodWarning = @"Method will be removed. Use async variant. If it does't exist, report an issue. See https://github.com/FortnoxAB/csharp-api-sdk/issues/180";

        /// <summary>
        /// Base URI of Fortnox API server
        /// </summary>
        public const string FortnoxApi = @"https://api.fortnox.se";

        /// <summary>
        /// Use this to make a field blank in Fortnox.
        /// </summary>
        public const string BlankValue = "API_BLANK";

        /// <summary>
        /// Use this to format date to a string
        /// </summary>
        public const string DateFormat = "yyyy-MM-dd";

        /// <summary>
        /// Use this to format date with time to a string
        /// </summary>
        public const string DateAndTimeFormat = "yyyy-MM-dd HH:mm:ss";

        /// <summary>
        /// Maximal page size (limit) offered by the API
        /// Use with Limit field in search settings
        /// </summary>
        public const int MaxLimit = 500; //Max limit

        /// <summary>
        /// Unlimited page size. This setting is not supported by the server API.
        /// When used, connector will gather all available pages, and return it as a single large page.
        /// Note that multiple HTTP requests may be send under the hood.
        /// </summary>
        public const int Unlimited = -1;
    }
}
