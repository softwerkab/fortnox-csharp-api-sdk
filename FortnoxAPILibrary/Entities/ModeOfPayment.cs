using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
	[Entity(SingularName = "ModeOfPayment")]
	public class ModeOfPayment 
	{
        /// <remarks/>
		[JsonProperty]
		public string AccountNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Code { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Description { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[ReadOnly]
		[JsonProperty(PropertyName = "@url")]
		public string Url { get; private set; }
    }

    /// <remarks/>
    [Entity(SingularName = "ModeOfPayment")]
    public class ModeOfPaymentSubset
    {
        /// <remarks/>
        [JsonProperty]
        public string AccountNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Code { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Description { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly]
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; private set; }
    }
}
