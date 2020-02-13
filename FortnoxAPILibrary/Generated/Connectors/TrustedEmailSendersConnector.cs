using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Reused;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class TrustedEmailSendersConnector : EntityConnector<TrustedEmailSender, EntityWrapper<EmailSenders>, Sort.By.TrustedEmailSenders?>
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.TrustedEmailSenders? FilterBy { get; set; }


		/// <remarks/>
		public TrustedEmailSendersConnector()
		{
			Resource = "emailsenders/trusted";
		}
		/// <summary>
		/// Find a trustedEmailSenders based on id
		/// </summary>
		/// <param name="id">Identifier of the trustedEmailSenders to find</param>
		/// <returns>The found trustedEmailSenders</returns>
		public TrustedEmailSender Get(int? id)
		{
			return BaseGet(id.ToString());
		}
		
		/// <summary>
		/// Creates a new trustedEmailSenders
		/// </summary>
		/// <param name="trustedEmailSenders">The trustedEmailSenders to create</param>
		/// <returns>The created trustedEmailSenders</returns>
		public TrustedEmailSender Create(TrustedEmailSender trustedEmailSenders)
		{
			return BaseCreate(trustedEmailSenders);
		}

		/// <summary>
		/// Deletes a trustedEmailSenders
		/// </summary>
		/// <param name="id">Identifier of the trustedEmailSenders to delete</param>
		public void Delete(int? id)
		{
			BaseDelete(id.ToString());
		}

        /// <summary>
        /// Retrieves all trusted and rejected emails with id.
        /// </summary>
        /// <returns>Collection of emails with id </returns>
        public EmailSenders Find()
        {
			Resource = "emailsenders";
            var res = BaseFind()?.Entity;
            Resource = "emailsenders/trusted";
            return res;
		}
	}
}
