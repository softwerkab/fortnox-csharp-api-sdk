using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
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
