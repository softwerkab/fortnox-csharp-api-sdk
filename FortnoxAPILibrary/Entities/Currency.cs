using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
	[Entity(SingularName = "Currency", PluralName = "Currencies")]
	public class Currency 
    {
        /// <summary>
		/// <para>The buy rate of the currency</para>
		/// <para>Required:		No</para>
		/// <para>Type:			Float</para>
		/// <para>Permissions:	RW</para>
		/// </summary>
		[JsonProperty]
		public decimal? BuyRate { get; set; }

        /// <summary>
        /// <para>Code of the currency</para>
        /// <para>Required:		Yes</para>
        /// <para>Limits:		3 chars, A-Z</para>
        /// <para>Type:			String</para>
        /// <para>Permissions:	RW</para>
        /// </summary>
        [JsonProperty]
        public string Code { get; set; }

        /// <summary>
        /// <para>Date of creation</para>
        /// <para>Type:			Date</para>
        /// <para>Permissions:	R</para>
        /// </summary>
		[ReadOnly]
		[JsonProperty]
		public string Date { get; private set; }

        /// <summary>
        /// <para>Description of the currency</para>
        /// <para>Required:		No</para>
        /// <para>Type:			Date</para>
        /// <para>Permissions:	R</para>
        /// </summary>
        [JsonProperty]
        public string Description { get; set; }

        /// <summary>
        /// <para>The sell rate of the currency</para>
        /// <para>Required:		No</para>
        /// <para>Type:			Float</para>
        /// <para>Permissions:	RW</para>
        /// </summary>
        [JsonProperty]
        public decimal? SellRate { get; set; }

        /// <summary>
        /// <para>The unit of the currency</para>
        /// <para>Required:		No</para>
        /// <para>Type:			Float</para>
        /// <para>Permissions:	RW</para>
        /// </summary>
        [JsonProperty]
        public decimal? Unit { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[ReadOnly]
		[JsonProperty(PropertyName = "@url")]
		public string Url { get; private set; }

        [ReadOnly]
        [JsonProperty]
        public bool? IsAutomatic { get; private set; }
    }

    /// <remarks/>
    [Entity(SingularName = "Currency", PluralName = "Currencies")]
    public class CurrencySubset
    {
        /// <remarks/>
        [JsonProperty]
        public decimal? BuyRate { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Code { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Date { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Description { get; set; }

        /// <remarks/>
        [JsonProperty]
        public decimal? SellRate { get; set; }

        /// <remarks/>
        [JsonProperty]
        public decimal? Unit { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly]
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; private set; }

        [ReadOnly]
        [JsonProperty]
        public bool? IsAutomatic { get; private set; }
    }
}

