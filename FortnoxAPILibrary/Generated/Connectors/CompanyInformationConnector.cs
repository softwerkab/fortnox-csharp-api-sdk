using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class CompanyInformationConnector : EntityConnector<CompanyInformation, EntityWrapper<CompanyInformation>, Sort.By.CompanyInformation?>
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.CompanyInformation? FilterBy { get; set; }


		/// <remarks/>
		public CompanyInformationConnector()
		{
			Resource = "companyinformation";
		}

		/// <summary>
		/// Retrieves the Company Information.
		/// </summary>
		/// <returns></returns>
		public CompanyInformation Get()
        {
            return BaseFind()?.Entity;
        }
	}
}
