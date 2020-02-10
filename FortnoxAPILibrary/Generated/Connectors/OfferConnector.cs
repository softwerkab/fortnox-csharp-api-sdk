using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class OfferConnector : EntityConnector<Offer, EntityCollection<OfferSubset>, Sort.By.Offer?>
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.Offer FilterBy { get; set; }


        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string CostCenter { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string CustomerName { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string CustomerNumber { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string DocumentNumber { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string OfferDate { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string OurReference { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string Project { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string YourReference { get; set; }

		/// <remarks/>
		public OfferConnector()
		{
			Resource = "offers";
		}

		/// <summary>
		/// Find a offer based on offernumber
		/// </summary>
		/// <param name="offerNumber">The offernumber to find</param>
		/// <returns>The found offer</returns>
		public Offer Get(string offerNumber)
		{
			return BaseGet(offerNumber);
		}

		/// <summary>
		/// Updates a offer
		/// </summary>
		/// <param name="offer">The offer to update</param>
		/// <returns>The updated offer</returns>
		public Offer Update(Offer offer)
		{
			return BaseUpdate(offer, offer.OfferNumber);
		}

		/// <summary>
		/// Create a new offer
		/// </summary>
		/// <param name="offer">The offer to create</param>
		/// <returns>The created offer</returns>
		public Offer Create(Offer offer)
		{
			return BaseCreate(offer);
		}

		/// <summary>
		/// Deletes a offer
		/// </summary>
		/// <param name="offerNumber">The offernumber to delete</param>
		public void Delete(string offerNumber)
		{
			BaseDelete(offerNumber);
		}

		/// <summary>
		/// Gets a list of offers
		/// </summary>
		/// <returns>A list of offers</returns>
		public EntityCollection<OfferSubset> Find()
		{
			return BaseFind();
		}
	}
}
