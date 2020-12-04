using System.Threading.Tasks;
using Fortnox.SDK.Entities;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface ICompanySettingsConnector : IEntityConnector
	{
        CompanySettings Get();

		Task<CompanySettings> GetAsync();
	}
}
