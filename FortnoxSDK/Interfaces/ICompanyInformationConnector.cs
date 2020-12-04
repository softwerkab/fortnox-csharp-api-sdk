using System.Threading.Tasks;
using Fortnox.SDK.Entities;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface ICompanyInformationConnector : IEntityConnector
	{
		CompanyInformation Get();

		Task<CompanyInformation> GetAsync();
    }
}
