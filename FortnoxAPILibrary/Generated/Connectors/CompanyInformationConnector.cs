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
		public Filter.CompanyInformation FilterBy { get; set; }


		/// <remarks/>
		public CompanyInformationConnector()
		{
			Resource = "companyinformation";
		}

		/// <summary>
		/// Find a companyInformation based on companyInformationnumber
		/// </summary>
		/// <param name="companyInformationNumber">The companyInformationnumber to find</param>
		/// <returns>The found companyInformation</returns>
		public CompanyInformation Get(string companyInformationNumber)
		{
			return BaseGet(companyInformationNumber);
		}

		/// <summary>
		/// Updates a companyInformation
		/// </summary>
		/// <param name="companyInformation">The companyInformation to update</param>
		/// <returns>The updated companyInformation</returns>
		public CompanyInformation Update(CompanyInformation companyInformation)
		{
			return BaseUpdate(companyInformation, companyInformation.CompanyInformationNumber);
		}

		/// <summary>
		/// Create a new companyInformation
		/// </summary>
		/// <param name="companyInformation">The companyInformation to create</param>
		/// <returns>The created companyInformation</returns>
		public CompanyInformation Create(CompanyInformation companyInformation)
		{
			return BaseCreate(companyInformation);
		}

		/// <summary>
		/// Deletes a companyInformation
		/// </summary>
		/// <param name="companyInformationNumber">The companyInformationnumber to delete</param>
		public void Delete(string companyInformationNumber)
		{
			BaseDelete(companyInformationNumber);
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
