using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface IAccountConnector : IEntityConnector
	{

		Account Update(Account account);
		Account Create(Account account);
		Account Get(long? id);
		void Delete(long? id);
		EntityCollection<AccountSubset> Find(AccountSearch searchSettings);

		Task<Account> UpdateAsync(Account account);
		Task<Account> CreateAsync(Account account);
		Task<Account> GetAsync(long? id);
		Task DeleteAsync(long? id);
		Task<EntityCollection<AccountSubset>> FindAsync(AccountSearch searchSettings);
	}
}
