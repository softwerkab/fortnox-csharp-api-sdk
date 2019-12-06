using System;
using System.Collections.Generic;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>

	
	
	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	public class PrintTemplates
	{
        /// <remarks/>
		[JsonProperty]
		public List<PrintTemplatesPrintTemplateSubset> PrintTemplateSubset { get; set; }

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
	public class PrintTemplatesPrintTemplateSubset
	{
        /// <remarks/>
		[JsonProperty]
		public string Template { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Name { get; set; }
    }
}
