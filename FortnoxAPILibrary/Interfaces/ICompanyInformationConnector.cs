using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface ICompanyInformationConnector : IEntityConnector<Sort.By.CompanyInformation> //should be changed to IEntityConnector with missing properties after fully sdk updating
	{
		CompanyInformation Get();

		Task<CompanyInformation> GetAsync();
    }
}
