using System.Net.Http;
using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Requests;
using Fortnox.SDK.Utility;

// ReSharper disable UnusedMember.Global

namespace Fortnox.SDK.Connectors
{
    /// <remarks/>
    public class TrustedEmailSendersConnector : EntityConnector<TrustedEmailSender>, ITrustedEmailSendersConnector
	{

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
			return CreateAsync(trustedEmailSenders).GetResult();
		}

		/// <summary>
		/// Deletes a trustedEmailSenders
		/// </summary>
		/// <param name="id">Identifier of the trustedEmailSenders to delete</param>
		public void Delete(long? id)
		{
			DeleteAsync(id).GetResult();
		}

        /// <summary>
        /// Retrieves all trusted and rejected emails with id.
        /// </summary>
        /// <returns>Collection of emails with id </returns>
        public EmailSenders GetAll()
        {
            return GetAllAsync().GetResult();
        }

        public async Task<TrustedEmailSender> CreateAsync(TrustedEmailSender trustedEmailSenders)
        {
            return await BaseCreate(trustedEmailSenders).ConfigureAwait(false);
        }

        public async Task DeleteAsync(long? id)
        {
            await BaseDelete(id.ToString()).ConfigureAwait(false);
        }

        public async Task<EmailSenders> GetAllAsync()
        {
            //This method is inconsistent with others, as it should be part of a new connector with single Get similar to CompanySettingsConnector
            //It returns a single entity, containing both trusted and refused email senders.
           
            var request = new EntityRequest<EmailSenders>()
            {
                Resource = "emailsenders",
                Method = HttpMethod.Get
            };

            return await SendAsync(request).ConfigureAwait(false);
        }
    }
}
