using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class OfferConnector : EntityConnector<Offer, EntityCollection<OfferSubset>, Sort.By.Offer?>, IOfferConnector
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.Offer? FilterBy { get; set; }


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
		/// Find a offer based on id
		/// </summary>
		/// <param name="id">Identifier of the offer to find</param>
		/// <returns>The found offer</returns>
		public Offer Get(int? id)
		{
			return GetAsync(id).Result;
		}

		/// <summary>
		/// Updates a offer
		/// </summary>
		/// <param name="offer">The offer to update</param>
		/// <returns>The updated offer</returns>
		public Offer Update(Offer offer)
		{
			return UpdateAsync(offer).Result;
		}

		/// <summary>
		/// Creates a new offer
		/// </summary>
		/// <param name="offer">The offer to create</param>
		/// <returns>The created offer</returns>
		public Offer Create(Offer offer)
		{
			return CreateAsync(offer).Result;
		}

		/// <summary>
		/// Gets a list of offers
		/// </summary>
		/// <returns>A list of offers</returns>
		public EntityCollection<OfferSubset> Find()
		{
			return FindAsync().Result;
		}
		
		/// <summary>
		/// Creates an order from the offer
		/// <param name="id"></param>
		/// <returns></returns>
		/// </summary>
		public Offer CreateOrder(int? id)
		{
			return DoAction(id.ToString(), Action.CreateOrder);
		}
		
		/// <summary>
		/// Cancels an offer
		/// <param name="id"></param>
		/// <returns></returns>
		/// </summary>
		public Offer Cancel(int? id)
		{
			return DoAction(id.ToString(), Action.Cancel);
		}
		
		/// <summary>
		/// Sends an e-mail to the customer with an attached PDF document of the offer. You can use the fieldEmailInformation to customize the e-mail message on each offer.
		/// <param name="id"></param>
		/// <returns></returns>
		/// </summary>
		public Offer Email(int? id)
		{
			return DoAction(id.ToString(), Action.Email);
		}
		
		/// <summary>
		/// This action returns a PDF document with the current template that is used by the specific document. Note that this action also sets the field Sent as true.
		/// <param name="id"></param>
		/// <returns></returns>
		/// </summary>
		public byte[] Print(int? id)
		{
			return DoDownloadAction(id.ToString(), Action.Print);
		}
		
		/// <summary>
		/// This action is used to set the field Sent as true from an external system without generating a PDF.
		/// <param name="id"></param>
		/// <returns></returns>
		/// </summary>
		public Offer ExternalPrint(int? id)
		{
			return DoAction(id.ToString(), Action.ExternalPrint);
		}
		
		/// <summary>
		/// This action returns a PDF document with the current template that is used by the specific document. Apart from the action print, this action doesn’t set the field Sent as true.
		/// <param name="id"></param>
		/// <returns></returns>
		/// </summary>
		public byte[] Preview(int? id)
		{
			return DoDownloadAction(id.ToString(), Action.Preview);
		}

		public async Task<EntityCollection<OfferSubset>> FindAsync()
		{
			return await BaseFind();
		}
		public async Task<Offer> CreateAsync(Offer offer)
		{
			return await BaseCreate(offer);
		}
		public async Task<Offer> UpdateAsync(Offer offer)
		{
			return await BaseUpdate(offer, offer.DocumentNumber.ToString());
		}
		public async Task<Offer> GetAsync(int? id)
		{
			return await BaseGet(id.ToString());
		}
	}
}
