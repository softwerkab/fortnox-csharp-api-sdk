using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class CompanySettingsConnector : EntityConnector<CompanySettings, EntityWrapper<CompanySettings>, Sort.By.CompanySettings?>, ICompanySettingsConnector
	{
		/// <remarks/>
		public CompanySettingsConnector()
		{
			Resource = "settings/company";
		}

        /// <summary>
        /// Retrieves the company settings.
        /// </summary>
        /// <returns></returns>
        public CompanySettings Get()
        {
            return BaseFind()?.Entity;
        }

        public async Task<CompanySettings> GetAsync()
        {
            return await BaseFind()?.Entity;
        }
    }
}
