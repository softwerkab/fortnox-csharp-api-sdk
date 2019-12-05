using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks />
    public class CompanySettingsConnector : EntityConnector<CompanySettings, CompanySettings, Sort.By.CompanySettings>
    {
        /// <remarks />
        public CompanySettingsConnector()
        {
            Resource = "settings/company";
        }

        /// <summary>
        /// Gets the company settings
        /// </summary>
        /// <returns>The company settings</returns>
        public CompanySettings Get()
        {
            return BaseFind();
        }
    }
}
