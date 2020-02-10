using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class TrustedEmailSendersConnector : EntityConnector<TrustedEmailSenders, EntityCollection<TrustedEmailSendersSubset>, Sort.By.TrustedEmailSenders?>
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.TrustedEmailSenders? FilterBy { get; set; }


		/// <remarks/>
		public TrustedEmailSendersConnector()
		{
			Resource = "trustedemailsenders";
		}

		/// <summary>
		/// Find a trustedEmailSenders based on id
		/// </summary>
		/// <param name="id">Identifier of the trustedEmailSenders to find</param>
		/// <returns>The found trustedEmailSenders</returns>
		public TrustedEmailSenders Get(string id)
		{
			return BaseGet(id);
		}

		/// <summary>
		/// Updates a trustedEmailSenders
		/// </summary>
		/// <param name="trustedEmailSenders">The trustedEmailSenders to update</param>
		/// <returns>The updated trustedEmailSenders</returns>
		public TrustedEmailSenders Update(TrustedEmailSenders trustedEmailSenders)
		{
			return BaseUpdate(trustedEmailSenders, trustedEmailSenders.Id.ToString());
		}

		/// <summary>
		/// Creates a new trustedEmailSenders
		/// </summary>
		/// <param name="trustedEmailSenders">The trustedEmailSenders to create</param>
		/// <returns>The created trustedEmailSenders</returns>
		public TrustedEmailSenders Create(TrustedEmailSenders trustedEmailSenders)
		{
			return BaseCreate(trustedEmailSenders);
		}

		/// <summary>
		/// Deletes a trustedEmailSenders
		/// </summary>
		/// <param name="id">Identifier of the trustedEmailSenders to delete</param>
		public void Delete(string id)
		{
			BaseDelete(id);
		}

		/// <summary>
		/// Gets a list of trustedEmailSenderss
		/// </summary>
		/// <returns>A list of trustedEmailSenderss</returns>
		public EntityCollection<TrustedEmailSendersSubset> Find()
		{
			return BaseFind();
		}
	}
}
