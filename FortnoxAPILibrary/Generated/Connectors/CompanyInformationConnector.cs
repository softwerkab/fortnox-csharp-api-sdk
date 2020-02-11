using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class CompanyInformationConnector : EntityConnector<CompanyInformation, EntityCollection<CompanyInformationSubset>, Sort.By.CompanyInformation?>
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
		/// Gets a list of companyInformations
		/// </summary>
		/// <returns>A list of companyInformations</returns>
		public EntityCollection<CompanyInformationSubset> Find()
		{
			return BaseFind();
		}
	}
}
