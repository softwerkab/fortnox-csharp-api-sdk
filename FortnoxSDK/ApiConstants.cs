// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK;

public class ApiConstants
{
    /// <summary>
    /// Base URI of Fortnox API server.
    /// </summary>
    public const string FortnoxApi = "https://api.fortnox.se";

    /// <summary>
    /// Use this to make a field blank in Fortnox.
    /// </summary>
    public const string BlankValue = "API_BLANK";

    /// <summary>
    /// Use this to format date to a string.
    /// </summary>
    public const string DateFormat = "yyyy-MM-dd";

    /// <summary>
    /// Use this to format date with time to a string.
    /// </summary>
    public const string DateAndTimeFormat = "yyyy-MM-dd HH:mm:ss";

    /// <summary>
    /// Maximal page size (limit) offered by the API.
    /// Use with Limit field in search settings.
    /// </summary>
    public const int MaxLimit = 500;

    /// <summary>
    /// Unlimited page size. This setting is not supported by the server API.
    /// When used, connector will gather all available pages, and return it as a single large page.
    /// Note that multiple HTTP requests may be sent under the hood.
    /// </summary>
    public const int Unlimited = -1;
}