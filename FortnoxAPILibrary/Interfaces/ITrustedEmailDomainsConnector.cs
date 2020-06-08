using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface ITrustedEmailDomainsConnector : IConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.TrustedEmailDomains? SortBy { get; set; }
		Filter.TrustedEmailDomains? FilterBy { get; set; }

        TrustedEmailDomain Create(TrustedEmailDomain trustedEmailDomain);
		TrustedEmailDomain Get(int? id);
		void Delete(int? id);
		EntityCollection<TrustedEmailDomain> Find();

        Task<TrustedEmailDomain> CreateAsync(TrustedEmailDomain trustedEmailDomain);
		Task<TrustedEmailDomain> GetAsync(int? id);
		Task DeleteAsync(int? id);
		Task<EntityCollection<TrustedEmailDomain>> FindAsync();
    }
}
