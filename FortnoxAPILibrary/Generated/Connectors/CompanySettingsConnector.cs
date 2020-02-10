using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class CompanySettingsConnector : EntityConnector<CompanySettings, EntityCollection<CompanySettingsSubset>, Sort.By.CompanySettings?>
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.CompanySettings? FilterBy { get; set; }


		/// <remarks/>
		public CompanySettingsConnector()
		{
			Resource = "companysettings";
		}

		/// <summary>
		/// Find a companySettings based on id
		/// </summary>
        /// <returns>The found companySettings</returns>
		public CompanySettings Get()
		{
			return BaseGet();
		}

		/// <summary>
		/// Updates a companySettings
		/// </summary>
		/// <param name="companySettings">The companySettings to update</param>
		/// <returns>The updated companySettings</returns>
		public CompanySettings Update(CompanySettings companySettings)
		{
			return BaseUpdate(companySettings, companySettings.Name.ToString());
		}

		/// <summary>
		/// Creates a new companySettings
		/// </summary>
		/// <param name="companySettings">The companySettings to create</param>
		/// <returns>The created companySettings</returns>
		public CompanySettings Create(CompanySettings companySettings)
		{
			return BaseCreate(companySettings);
		}

		/// <summary>
		/// Deletes a companySettings
		/// </summary>
		/// <param name="id">Identifier of the companySettings to delete</param>
		public void Delete(string id)
		{
			BaseDelete(id);
		}

		/// <summary>
		/// Gets a list of companySettingss
		/// </summary>
		/// <returns>A list of companySettingss</returns>
		public EntityCollection<CompanySettingsSubset> Find()
		{
			return BaseFind();
		}
	}
}
