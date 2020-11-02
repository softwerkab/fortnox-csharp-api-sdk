using System;
using System.Collections.Generic;
using System.Net.Http;
using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
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
			return CreateAsync(trustedEmailSenders).Result;
		}

		/// <summary>
		/// Deletes a trustedEmailSenders
		/// </summary>
		/// <param name="id">Identifier of the trustedEmailSenders to delete</param>
		public void Delete(long? id)
		{
			DeleteAsync(id).Wait();
		}

        /// <summary>
        /// Retrieves all trusted and rejected emails with id.
        /// </summary>
        /// <returns>Collection of emails with id </returns>
        public EmailSenders GetAll()
        {
            return GetAllAsync().Result;
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
           
            RequestInfo = new RequestInfo()
            {
                BaseUrl = BaseUrl,
                Resource = "emailsenders",
                Indices = Array.Empty<string>(),
                Parameters = new Dictionary<string, string>(),
                Method = HttpMethod.Get,
            };
            ParametersInjection = null;

            var result = await DoEntityRequest<EntityWrapper<EmailSenders>>().ConfigureAwait(false);
            return result?.Entity;
        }
    }
}
