using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface ICompanySettingsConnector : IEntityConnector
	{
        CompanySettings Get();

		Task<CompanySettings> GetAsync();
	}
}
