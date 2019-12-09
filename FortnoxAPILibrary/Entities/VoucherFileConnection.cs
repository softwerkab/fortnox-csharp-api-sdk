using System;
using System.ComponentModel;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
	[Entity(SingularName = "VoucherFileConnection", PluralName = "VoucherFileConnections")]
	public class VoucherFileConnection 
	{
        /// <remarks/>
		[JsonProperty]
		public string FileId { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string VoucherDescription { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string VoucherNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string VoucherSeries { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string VoucherYear { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty(PropertyName = "@url")]
		public string Url { get; private set; }
    }

    /// <remarks/>
    [Entity(SingularName = "VoucherFileConnection", PluralName = "VoucherFileConnections")]
    public class VoucherFileConnectionSubset
    {
        /// <remarks/>
        [JsonProperty]
        public string FileId { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string VoucherDescription { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string VoucherNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string VoucherSeries { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string VoucherYear { get; set; }

        /// <remarks/>
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }
    }
}
