using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface IPredefinedAccountsConnector : IEntityConnector
	{

		PredefinedAccount Update(PredefinedAccount predefinedAccounts);
        PredefinedAccount Get(string id);
		EntityCollection<PredefinedAccount> Find(PredefinedAccountsSearch searchSettings);

		Task<PredefinedAccount> UpdateAsync(PredefinedAccount predefinedAccounts);
        Task<PredefinedAccount> GetAsync(string id);
		Task<EntityCollection<PredefinedAccount>> FindAsync(PredefinedAccountsSearch searchSettings);
	}
}
