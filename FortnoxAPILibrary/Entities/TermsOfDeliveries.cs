using System;
using System.Collections.Generic;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>

	
	
	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	public class TermsOfDeliveries
	{
        /// <remarks/>
		[JsonProperty]
		public List<TermsOfDeliverySubset> TermsOfDeliverySubset { get; set; }

        /// <remarks/>
		[JsonProperty]
		public string TotalResources { get; set; }

        /// <remarks/>
		[JsonProperty]
		public string TotalPages { get; set; }

        /// <remarks/>
		[JsonProperty]
		public string CurrentPage { get; set; }
    }

	/// <remarks/>
	
	
	
	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	public class TermsOfDeliverySubset
	{

		private string codeField;

		private string descriptionField;

		private string urlField;

		/// <remarks/>
		public string Code
		{
			get
			{
				return codeField;
			}
			set
			{
				codeField = value;
			}
		}

		/// <remarks/>
		public string Description
		{
			get
			{
				return descriptionField;
			}
			set
			{
				descriptionField = value;
			}
		}

		/// <remarks/>
		public string url
		{
			get
			{
				return urlField;
			}
			set
			{
				urlField = value;
			}
		}
	}
}
