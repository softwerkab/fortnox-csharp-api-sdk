using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Exceptions;
using Fortnox.SDK.Serialization;
using Fortnox.SDK.Utility;

namespace Fortnox.SDK.Connectors.Base;

internal class ErrorHandler
{
    private const string NoReponseMessage = @"No response from server. Check inner exception for details.";

    protected ISerializer Serializer { get; }

    public ErrorHandler()
    {
        Serializer = new JsonEntitySerializer();
    }

    public async Task HandleErrorResponseAsync(HttpResponseMessage response)
    {
        var content = await response.Content.ReadAsStringAsync();
        var errorInformation = ParseError(content);

        var exception = errorInformation?.Message != null
            ? new FortnoxApiException($"Request failed: {errorInformation.Message}")
            : new FortnoxApiException($"Request failed: {response.ReasonPhrase} ({(int)response.StatusCode})");

        exception.ResponseContent = content;
        exception.StatusCode = response.StatusCode;
        exception.ErrorInfo = errorInformation;

        throw exception;
    }

    public void HandleNoResponse(HttpRequestException ex)
    {
        throw new NoResponseException(NoReponseMessage, ex);
    }

    private ErrorInformation ParseError(string errorJson)
    {
        try
        {
            var wrapper = Serializer.Deserialize<EntityWrapper<ErrorInformation>>(errorJson);
            return wrapper.Entity;
        }
        catch (Exception)
        {
            // Continue
        }

        try
        {
            // Temp workaround for alternative error occured in new auth workflow
            var authError = Serializer.Deserialize<AuthError>(errorJson);
            return new ErrorInformation()
            {
                Error = authError.Error,
                Message = authError.ErrorDescription ?? authError.Error
            };
        }
        catch (Exception)
        {
            // Continue
        }

        try
        {
            // Temp workaround for alternative error occured in new auth workflow
            var simpleError = Serializer.Deserialize<SimpleError>(errorJson);
            return new ErrorInformation()
            {
                Error = simpleError.Message,
                Message = simpleError.Message
            };
        }
        catch (Exception)
        {
            // Continue
        }

        return null; // Failed to parse error 
    }
}
