using System;
using System.Net;
using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;
using ErrorInformation = FortnoxError.ErrorInformation;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class CompanyInformationConnector : EntityAsyncConnector<CompanyInformation, EntityWrapper<CompanyInformation>,
		Sort.By.CompanyInformation?>, ICompanyInformationConnector
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
			return (await BaseFind().ConfigureAwait(false))?.Entity;
		}
// has been added because of IEntityConnector<TSortBy>, which is used as constraint in Zwapgrid.Integrations.Fortnox.Clients.FortnoxClientBase
//should be deleted after fully sdk updating
		#region Delete
		public Sort.Order SortOrder { get; set; }
		public Sort.By.CompanyInformation SortBy { get; set; }
		public int Limit { get; set; }
		public DateTime LastModified { get; set; }
		public int Page { get; set; }
		public int Offset { get; set; }
		public ErrorInformation Error { get; set; }
		public HttpStatusCode httpStatusCode { get; set; }
		public string RequestXml { get; set; }
		public string ResponseXml { get; set; }
		#endregion
	}
}
