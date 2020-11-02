using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface ICompanyInformationConnector : IEntityConnector
	{
		CompanyInformation Get();

		Task<CompanyInformation> GetAsync();
    }
}
