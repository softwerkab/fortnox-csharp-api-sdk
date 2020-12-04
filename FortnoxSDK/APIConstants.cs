// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK
{
	/// <remarks/>
	public class APIConstants
	{
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
        public static int MaxLimit = 500; //Max limit

        /// <summary>
        /// Unlimited page size. This is special search settings not supported by the server API.
        /// When used, connector will gather all available pages, and return it as a single large page.
        /// Note that multiple HTTP requests may be send under the hood.
        /// The properties like url or response content of a connector will contain only the last one.
        /// </summary>
        public static int Unlimited = -1;
    }
}
