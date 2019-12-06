using System;
using System.Collections.Generic;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>

    [Serializable]
	
	
	public class PrintTemplates
	{
        /// <remarks/>
		public List<PrintTemplatesPrintTemplateSubset> PrintTemplateSubset { get; set; }

        /// <remarks/>
		public string TotalResources { get; set; }

        /// <remarks/>
		public string TotalPages { get; set; }

        /// <remarks/>
		public string CurrentPage { get; set; }
    }

	/// <remarks/>
	
	[Serializable]
	
	
	public class PrintTemplatesPrintTemplateSubset
	{
        /// <remarks/>
		public string Template { get; set; }

        /// <remarks/>
        public string Name { get; set; }
    }
}
