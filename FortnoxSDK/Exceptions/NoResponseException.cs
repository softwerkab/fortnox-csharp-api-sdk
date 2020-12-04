using System;

namespace Fortnox.SDK.Exceptions
{
    /// <summary>
    /// Represents connection error where no response could be retrieved from server.
    /// Typically happens if server is unrechable or connection was refused. Inner exception should be checked to see underlying issues.
    /// </summary>
    public class NoResponseException : Exception
    {
        public NoResponseException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}