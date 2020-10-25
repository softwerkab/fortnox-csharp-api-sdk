using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface ITrustedEmailDomainsConnector : IEntityConnector
	{
		TrustedEmailDomainsSearch Search { get; set; }

        TrustedEmailDomain Create(TrustedEmailDomain trustedEmailDomain);
		TrustedEmailDomain Get(long? id);
		void Delete(long? id);
		EntityCollection<TrustedEmailDomain> Find();

        Task<TrustedEmailDomain> CreateAsync(TrustedEmailDomain trustedEmailDomain);
		Task<TrustedEmailDomain> GetAsync(long? id);
		Task DeleteAsync(long? id);
		Task<EntityCollection<TrustedEmailDomain>> FindAsync();
    }
}
