using System;
using TimeZoneConverter;

namespace Fortnox.SDK;

/// <summary>
/// Fortnox server information.
/// </summary>
public class FortnoxServerInfo
{
    /// <summary>
    /// Fortnox server time zone. (Swedish)
    /// </summary>
    public static TimeZoneInfo ServerTimeZone => TZConvert.GetTimeZoneInfo("Europe/Stockholm"); // Swedish time zone 

    /// <summary>
    /// Current client machine time converted into the Fortnox server time zone.
    /// </summary>
    /// <remarks>Not 100% accurate, since the client and server time are not synchronized.</remarks>
    public static DateTime ServerTime => TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, ServerTimeZone);
}