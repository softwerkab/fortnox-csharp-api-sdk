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
		public Filter.TrustedEmailSenders FilterBy { get; set; }


		/// <remarks/>
		public TrustedEmailSendersConnector()
		{
			Resource = "trustedemailsenders";
		}

		/// <summary>
		/// Find a trustedEmailSenders based on trustedEmailSendersnumber
		/// </summary>
		/// <param name="trustedEmailSendersNumber">The trustedEmailSendersnumber to find</param>
		/// <returns>The found trustedEmailSenders</returns>
		public TrustedEmailSenders Get(string trustedEmailSendersNumber)
		{
			return BaseGet(trustedEmailSendersNumber);
		}

		/// <summary>
		/// Updates a trustedEmailSenders
		/// </summary>
		/// <param name="trustedEmailSenders">The trustedEmailSenders to update</param>
		/// <returns>The updated trustedEmailSenders</returns>
		public TrustedEmailSenders Update(TrustedEmailSenders trustedEmailSenders)
		{
			return BaseUpdate(trustedEmailSenders, trustedEmailSenders.TrustedEmailSendersNumber);
		}

		/// <summary>
		/// Create a new trustedEmailSenders
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
		/// <param name="trustedEmailSendersNumber">The trustedEmailSendersnumber to delete</param>
		public void Delete(string trustedEmailSendersNumber)
		{
			BaseDelete(trustedEmailSendersNumber);
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
