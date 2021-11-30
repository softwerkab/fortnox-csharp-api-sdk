using System;
using System.Net;
using Fortnox.SDK.Entities;

namespace Fortnox.SDK.Exceptions;

/// <summary>
/// Represents error response sent by the server (Fortnox API).
/// Typically happens if request contain inconsistent data or requested resource does not exist.
/// Error message is typically in Swedish.
/// </summary>
public class FortnoxApiException : Exception //RequestException
{
    public ErrorInformation ErrorInfo { get; set; }
    public HttpStatusCode StatusCode { get; set; }
    public string ResponseContent { get; set; }

    public FortnoxApiException(string message, Exception innerException = null) : base(message, innerException)
    {

    }
}
