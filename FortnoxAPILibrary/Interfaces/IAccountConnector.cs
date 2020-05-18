using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IAccountConnector : IConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.Account? SortBy { get; set; }
		Filter.Account? FilterBy { get; set; }

		string SRU { get; set; }

		Account Update(Account account);
		Account Create(Account account);
		Account Get(int? id);
		void Delete(int? id);
		EntityCollection<AccountSubset> Find();

		Task<Account> UpdateAsync(Account account);
		Task<Account> CreateAsync(Account account);
		Task<Account> GetAsync(int? id);
		Task DeleteAsync(int? id);
		Task<EntityCollection<AccountSubset>> FindAsync();
	}
}
