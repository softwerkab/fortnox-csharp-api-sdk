using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IAccountConnector : IEntityConnector
	{
		AccountSearch Search { get; set; }

		Account Update(Account account, long? financialYearId = null);
		Account Create(Account account, long? financialYearId = null);
		Account Get(long? id, long? financialYearId = null);
		void Delete(long? id, long? financialYearId = null);
		EntityCollection<AccountSubset> Find();

		Task<Account> UpdateAsync(Account account, long? financialYearId = null);
		Task<Account> CreateAsync(Account account, long? financialYearId = null);
		Task<Account> GetAsync(long? id, long? financialYearId = null);
		Task DeleteAsync(long? id, long? financialYearId = null);
		Task<EntityCollection<AccountSubset>> FindAsync();
	}
}
