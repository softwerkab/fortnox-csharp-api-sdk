using System;
using System.ComponentModel;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	public class PreDefinedAccount
	{
        /// <remarks/>
		[JsonProperty]
		public string Account { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string Name { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string url { get; private set; }
    }
}
