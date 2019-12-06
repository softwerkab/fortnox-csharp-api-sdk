using System;
using System.Collections.Generic;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>

	
	
	public class TermsOfDeliveries
	{
        /// <remarks/>
		public List<TermsOfDeliverySubset> TermsOfDeliverySubset { get; set; }

        /// <remarks/>
		public string TotalResources { get; set; }

        /// <remarks/>
		public string TotalPages { get; set; }

        /// <remarks/>
		public string CurrentPage { get; set; }
    }

	/// <remarks/>
	
	
	
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
