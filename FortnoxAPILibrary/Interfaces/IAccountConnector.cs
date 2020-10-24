using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IAccountConnector : IEntityConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.Account? SortBy { get; set; }
		Filter.Account? FilterBy { get; set; }

		Account Update(Account account);
		Account Create(Account account);
		Account Get(long? id);
		void Delete(long? id);
		EntityCollection<AccountSubset> Find();

		Task<Account> UpdateAsync(Account account);
		Task<Account> CreateAsync(Account account);
		Task<Account> GetAsync(long? id);
		Task DeleteAsync(long? id);
		Task<EntityCollection<AccountSubset>> FindAsync();
	}
}
