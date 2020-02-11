using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class CompanySettingsConnector : EntityConnector<CompanySettings, EntityWrapper<CompanySettings>, Sort.By.CompanySettings?>
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.CompanySettings? FilterBy { get; set; }


		/// <remarks/>
		public CompanySettingsConnector()
		{
			Resource = "settings/company";
		}

        public CompanySettings Get()
        {
            return BaseFind().Entity;
        }
    }
}
