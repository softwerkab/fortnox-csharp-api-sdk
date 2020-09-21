using System;
using System.Net;
using System.Net.Http;
using FortnoxAPILibrary.Entities;

namespace FortnoxAPILibrary
{
    public class ErrorHandler
    {
        protected AdaptableSerializer Serializer { get; set; }

        public ErrorHandler()
        {
            Serializer = new AdaptableSerializer();
        }

        public ErrorInformation HandleError(HttpWebResponse response)
        {
            using var responseStream = response.GetResponseStream();

            var errorJson = responseStream.ToText().Result;
            return ParseError(errorJson);
        }

        public ErrorInformation HandleError(HttpResponseMessage response)
        {
            var errorJson = response.Content.ReadAsStringAsync().Result;
            return ParseError(errorJson);
        }

        public ErrorInformation HandleConnectionException(WebException we)
        {
            throw new Exception("Connection to server failed. Check inner exception.", we);
        }

        public ErrorInformation HandleConnectionException(HttpRequestException we)
        {
            throw new Exception("Connection to server failed. Check inner exception.", we);
        }

        protected ErrorInformation ParseError(string errorJson)
        {
            try
            {
                return Serializer.Deserialize<EntityWrapper<ErrorInformation>>(errorJson).Entity;
            }
            catch (Exception)
            {
                return new ErrorInformation() { Message = $"Could not interpret error information. Response: '{errorJson}'" };
            }
        }
    }
}
