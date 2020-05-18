using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class CompanyInformationConnector : EntityConnector<CompanyInformation, EntityWrapper<CompanyInformation>, Sort.By.CompanyInformation?>, ICompanyInformationConnector
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
			return GetAsync().Result;
        }

		public async Task<CompanyInformation> GetAsync()
        {
            return (await BaseFind())?.Entity;
        }
	}
}
