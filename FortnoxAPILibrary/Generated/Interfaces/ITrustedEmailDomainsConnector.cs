using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface ITrustedEmailDomainsConnector : IConnector
	{
        [SearchParameter("filter")]
		Filter.TrustedEmailDomains? FilterBy { get; set; }

        TrustedEmailDomain Create(TrustedEmailDomain trustedEmailDomain);

		TrustedEmailDomain Get(int? id);

		void Delete(int? id);

		EntityCollection<TrustedEmailDomain> Find();
    }
}
