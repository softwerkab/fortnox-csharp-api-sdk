using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class CompanySettingsConnector : EntityConnector<CompanySettings, EntityWrapper<CompanySettings>>, ICompanySettingsConnector
	{
		public CompanySettingsSearch Search { get; set; } = new CompanySettingsSearch();

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
			return GetAsync().Result;
        }

        public async Task<CompanySettings> GetAsync()
        {
            return (await BaseFind().ConfigureAwait(false))?.Entity;
        }
    }
}
