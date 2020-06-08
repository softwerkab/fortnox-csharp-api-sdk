using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface ICompanyInformationConnector : IConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.CompanyInformation? SortBy { get; set; }

		CompanyInformation Get();

		Task<CompanyInformation> GetAsync();
    }
}
