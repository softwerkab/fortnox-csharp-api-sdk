using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class TrustedEmailDomainsConnector : EntityConnector<TrustedEmailDomains, EntityCollection<TrustedEmailDomainsSubset>, Sort.By.TrustedEmailDomains?>
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.TrustedEmailDomains? FilterBy { get; set; }


		/// <remarks/>
		public TrustedEmailDomainsConnector()
		{
			Resource = "trustedemaildomains";
		}

		/// <summary>
		/// Find a trustedEmailDomains based on id
		/// </summary>
		/// <param name="id">Identifier of the trustedEmailDomains to find</param>
		/// <returns>The found trustedEmailDomains</returns>
		public TrustedEmailDomains Get(string id)
		{
			return BaseGet(id);
		}

		/// <summary>
		/// Updates a trustedEmailDomains
		/// </summary>
		/// <param name="trustedEmailDomains">The trustedEmailDomains to update</param>
		/// <returns>The updated trustedEmailDomains</returns>
		public TrustedEmailDomains Update(TrustedEmailDomains trustedEmailDomains)
		{
			return BaseUpdate(trustedEmailDomains, trustedEmailDomains.Id.ToString());
		}

		/// <summary>
		/// Creates a new trustedEmailDomains
		/// </summary>
		/// <param name="trustedEmailDomains">The trustedEmailDomains to create</param>
		/// <returns>The created trustedEmailDomains</returns>
		public TrustedEmailDomains Create(TrustedEmailDomains trustedEmailDomains)
		{
			return BaseCreate(trustedEmailDomains);
		}

		/// <summary>
		/// Deletes a trustedEmailDomains
		/// </summary>
		/// <param name="id">Identifier of the trustedEmailDomains to delete</param>
		public void Delete(string id)
		{
			BaseDelete(id);
		}

		/// <summary>
		/// Gets a list of trustedEmailDomainss
		/// </summary>
		/// <returns>A list of trustedEmailDomainss</returns>
		public EntityCollection<TrustedEmailDomainsSubset> Find()
		{
			return BaseFind();
		}
	}
}
