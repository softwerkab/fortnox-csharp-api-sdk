using System;
using System.Net;
using System.Net.Http;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Exceptions;

namespace FortnoxAPILibrary
{
    public class ErrorHandler
    {
        private const string NoReponseMessage = @"No response from server. Check inner exception for details.";

        protected AdaptableSerializer Serializer { get; set; }

        public ErrorHandler()
        {
            Serializer = new AdaptableSerializer();
        }

        public void HandleErrorResponse(HttpWebResponse response)
        {
            using var responseStream = response.GetResponseStream();

            var content = responseStream.ToText().GetResult();
            var errorInformation = ParseError(content);

            var exception = errorInformation != null ?
                new FortnoxApiException($"Request failed: {errorInformation.Message}") :
                new FortnoxApiException($"Request failed: {response.StatusDescription} ({(int)response.StatusCode})");

            exception.ResponseContent = content;
            exception.StatusCode = response.StatusCode;
            exception.ErrorInfo = errorInformation;

            throw exception;
        }

        public void HandleErrorResponse(HttpResponseMessage response)
        {
            var content = response.Content.ReadAsStringAsync().GetResult();
            var errorInformation = ParseError(content);

            var exception = errorInformation != null ?
                new FortnoxApiException($"Request failed: {errorInformation.Message}") :
                new FortnoxApiException($"Request failed: {response.ReasonPhrase} ({(int)response.StatusCode})");

            exception.ResponseContent = content;
            exception.StatusCode = response.StatusCode;
            exception.ErrorInfo = errorInformation;

            throw exception;
        }

        public void HandleNoResponse(WebException we)
        {
            throw new NoResponseException(NoReponseMessage, we);
        }

        public void HandleNoResponse(HttpRequestException we)
        {
            throw new NoResponseException(NoReponseMessage, we);
        }

        private ErrorInformation ParseError(string errorJson)
        {
            try
            {
                return Serializer.Deserialize<EntityWrapper<ErrorInformation>>(errorJson).Entity;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
