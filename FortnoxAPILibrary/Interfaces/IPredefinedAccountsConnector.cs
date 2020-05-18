using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IPredefinedAccountsConnector : IConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.PredefinedAccounts? SortBy { get; set; }
		Filter.PredefinedAccounts? FilterBy { get; set; }

		PredefinedAccount Update(PredefinedAccount predefinedAccounts);
        PredefinedAccount Get(string id);
		EntityCollection<PredefinedAccount> Find();

		Task<PredefinedAccount> UpdateAsync(PredefinedAccount predefinedAccounts);
        Task<PredefinedAccount> GetAsync(string id);
		Task<EntityCollection<PredefinedAccount>> FindAsync();
	}
}
