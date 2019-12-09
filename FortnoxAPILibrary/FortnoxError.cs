using System;
using FortnoxAPILibrary.Entities;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary
{
    /// <remarks/>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    [Entity(SingularName = "ErrorInformation")]
    public class ErrorInformation
    {
        /// <remarks/>
        [JsonProperty(PropertyName = "error")]
        public string Error { get; set; }

        /// <remarks/>
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        /// <remarks/>
        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }
    }
}