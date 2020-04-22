using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface ITrustedEmailDomainsConnector : IConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.TrustedEmailDomains? SortBy { get; set; }

        [SearchParameter("filter")]
		Filter.TrustedEmailDomains? FilterBy { get; set; }

        TrustedEmailDomain Create(TrustedEmailDomain trustedEmailDomain);

		TrustedEmailDomain Get(int? id);

		void Delete(int? id);

		EntityCollection<TrustedEmailDomain> Find();
    }
}
