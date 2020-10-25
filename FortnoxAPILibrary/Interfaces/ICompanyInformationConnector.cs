using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface ICompanyInformationConnector : IEntityConnector
	{
		CompanyInformationSearch Search { get; set; }

		CompanyInformation Get();

		Task<CompanyInformation> GetAsync();
    }
}
