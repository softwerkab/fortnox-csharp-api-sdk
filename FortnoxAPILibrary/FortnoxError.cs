using System;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary
{
	/// <remarks/>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class ErrorInformation
	{
		/// <remarks/>
        [JsonProperty]
        public string Error { get; set; }

		/// <remarks/>
        [JsonProperty]
        public string Message { get; set; }

		/// <remarks/>
        [JsonProperty]
        public string Code { get; set; }
	}
}