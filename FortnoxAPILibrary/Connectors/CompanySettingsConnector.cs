using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FortnoxAPILibrary
{
    public interface ICompanySettingsConnector : IEntityConnector<Sort.By.CompanySettings>
    {
        /// <summary>
        /// Gets the company settings
        /// </summary>
        /// <returns>The company settings</returns>
        CompanySettings Get();
    }

    /// <remarks />
    public class CompanySettingsConnector : EntityConnector<CompanySettings, CompanySettings, Sort.By.CompanySettings>, ICompanySettingsConnector
    {
        /// <remarks />
        public CompanySettingsConnector()
        {
            base.Resource = "settings/company";
        }

        /// <summary>
        /// Gets the company settings
        /// </summary>
        /// <returns>The company settings</returns>
        public CompanySettings Get()
        {
            return base.BaseFind();
        }
    }
}
