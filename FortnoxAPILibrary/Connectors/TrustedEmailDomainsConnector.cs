using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class TrustedEmailDomainsConnector : EntityConnector<TrustedEmailDomain, EntityCollection<TrustedEmailDomain>, Sort.By.TrustedEmailDomains?>, ITrustedEmailDomainsConnector
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.TrustedEmailDomains? FilterBy { get; set; }

        /// <remarks/>
		public TrustedEmailDomainsConnector()
		{
			Resource = "emailtrusteddomains";
		}

		/// <summary>
		/// Find a trustedEmailDomains based on id
		/// </summary>
		/// <param name="id">Identifier of the trustedEmailDomains to find</param>
		/// <returns>The found trustedEmailDomains</returns>
		public TrustedEmailDomain Get(int? id)
		{
			return GetAsync(id).Result;
		}

		/// <summary>
		/// Creates a new trustedEmailDomains
		/// </summary>
		/// <param name="trustedEmailDomains">The trustedEmailDomains to create</param>
		/// <returns>The created trustedEmailDomains</returns>
		public TrustedEmailDomain Create(TrustedEmailDomain trustedEmailDomains)
		{
			return CreateAsync(trustedEmailDomains).Result;
		}

		/// <summary>
		/// Deletes a trustedEmailDomains
		/// </summary>
		/// <param name="id">Identifier of the trustedEmailDomains to delete</param>
		public void Delete(int? id)
		{
			DeleteAsync(id).Wait();
		}

		/// <summary>
		/// Gets a list of trustedEmailDomainss
		/// </summary>
		/// <returns>A list of trustedEmailDomainss</returns>
		public EntityCollection<TrustedEmailDomain> Find()
		{
			return FindAsync().Result;
		}

		public async Task<EntityCollection<TrustedEmailDomain>> FindAsync()
		{
			return await BaseFind();
		}
		public async Task DeleteAsync(int? id)
		{
			await BaseDelete(id.ToString());
		}
		public async Task<TrustedEmailDomain> CreateAsync(TrustedEmailDomain trustedEmailDomains)
		{
			return await BaseCreate(trustedEmailDomains);
		}
		public async Task<TrustedEmailDomain> GetAsync(int? id)
		{
			return await BaseGet(id.ToString());
		}
    }
}
