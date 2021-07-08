using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Utility;

// ReSharper disable UnusedMember.Global

namespace Fortnox.SDK.Connectors
{
    /// <remarks/>
    internal class CompanyInformationConnector : EntityConnector<CompanyInformation>, ICompanyInformationConnector
	{

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
			return GetAsync().GetResult();
        }

		public async Task<CompanyInformation> GetAsync()
        {
            return await BaseGet().ConfigureAwait(false);
        }
	}
}
