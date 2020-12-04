using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Utility;

// ReSharper disable UnusedMember.Global

namespace Fortnox.SDK.Connectors
{
    /// <remarks/>
    public class CompanySettingsConnector : EntityConnector<CompanySettings>, ICompanySettingsConnector
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
			return GetAsync().GetResult();
        }

        public async Task<CompanySettings> GetAsync()
        {
            return await BaseGet().ConfigureAwait(false);
        }
    }
}
