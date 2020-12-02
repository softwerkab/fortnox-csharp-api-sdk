using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class CompanyInformationConnector : EntityConnector<CompanyInformation>, ICompanyInformationConnector
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
