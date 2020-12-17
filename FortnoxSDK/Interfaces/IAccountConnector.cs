using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface IAccountConnector : IEntityConnector
	{
        Account Update(Account account, long? finYearID = null);
		Account Create(Account account, long? finYearID = null);
		Account Get(long? id, long? finYearID = null);
		void Delete(long? id, long? finYearID = null);
		EntityCollection<AccountSubset> Find(AccountSearch searchSettings);

		Task<Account> UpdateAsync(Account account, long? finYearID = null);
		Task<Account> CreateAsync(Account account, long? finYearID = null);
		Task<Account> GetAsync(long? id, long? finYearID = null);
		Task DeleteAsync(long? id, long? finYearID = null);
		Task<EntityCollection<AccountSubset>> FindAsync(AccountSearch searchSettings);
	}
}
