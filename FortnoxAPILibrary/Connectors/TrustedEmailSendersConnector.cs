using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class TrustedEmailSendersConnector : EntityConnector<TrustedEmailSender, EntityWrapper<EmailSenders>, Sort.By.TrustedEmailSenders?>, ITrustedEmailSendersConnector
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
		/// Creates a new trustedEmailSenders
		/// </summary>
		/// <param name="trustedEmailSenders">The trustedEmailSenders to create</param>
		/// <returns>The created trustedEmailSenders</returns>
		public TrustedEmailSender Create(TrustedEmailSender trustedEmailSenders)
		{
			return CreateAsync(trustedEmailSenders).Result;
		}

		/// <summary>
		/// Deletes a trustedEmailSenders
		/// </summary>
		/// <param name="id">Identifier of the trustedEmailSenders to delete</param>
		public void Delete(int? id)
		{
			DeleteAsync(id).Wait();
		}

        /// <summary>
        /// Retrieves all trusted and rejected emails with id.
        /// </summary>
        /// <returns>Collection of emails with id </returns>
        public EmailSenders Find()
        {
            return FindAsync().Result;
        }

        public async Task<TrustedEmailSender> CreateAsync(TrustedEmailSender trustedEmailSenders)
        {
            return await BaseCreate(trustedEmailSenders);
        }

        public async Task DeleteAsync(int? id)
        {
            await BaseDelete(id.ToString());
        }

        public async Task<EmailSenders> FindAsync()
        {
            Resource = "emailsenders";
            var res = (await BaseFind())?.Entity;
            Resource = "emailsenders/trusted";
            return res;
        }
	}
}
