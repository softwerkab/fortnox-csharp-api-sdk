using System;
using System.ComponentModel;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
    [Entity(SingularName = "CostCenter", PluralName = "CostCenters")]
    public class CostCenter : CostCenterSubset
	{
        /// <summary>
		/// <para>Code of the cost center</para>
		/// <para>Limits:		6 chars, a-z, 0.9</para>
		/// <para>Required:		Yes</para>
		/// <para>Type:			String</para>
		/// <para>Permissions:	RW</para>
		/// </summary>
		[JsonProperty]
		public string Code { get; set; }

        /// <summary>
        /// <para>Description of the cost center</para>
        /// <para>Required:		No</para>
        /// <para>Type:			String</para>
        /// <para>Permissions:	RW</para>
        /// </summary>
        [JsonProperty]
        public string Description { get; set; }

        /// <summary>
        /// <para>Note</para>
        /// <para>Required:		No</para>
        /// <para>Type:			String</para>
        /// <para>Permissions:	RW</para>
        /// </summary>
        [JsonProperty]
        public string Note { get; set; }

        /// <summary>
        /// <para>Status of the cost center</para>
        /// <para>Required:		No</para>
        /// <para>Type:			Bool</para>
        /// <para>Permissions:	RW</para>
        /// </summary>
        [JsonProperty]
        public string Active { get; set; }

        /// <remarks/>
		[JsonProperty(PropertyName = "@url")]
		public string Url { get; private set; }
    }

    /// <remarks/>
    [Entity(SingularName = "CostCenter", PluralName = "CostCenters")]
    public class CostCenterSubset
    {
        /// <remarks/>
        [JsonProperty]
        public string Code { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Description { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Note { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Active { get; set; }

        /// <remarks/>
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }
    }
}
