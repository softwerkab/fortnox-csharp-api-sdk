using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;
using Fortnox.SDK.Utility;

// ReSharper disable UnusedMember.Global

namespace Fortnox.SDK.Connectors
{
    /// <remarks/>
    public class OfferConnector : SearchableEntityConnector<Offer, OfferSubset, OfferSearch>, IOfferConnector
	{


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
		public Offer Get(long? id)
		{
			return GetAsync(id).GetResult();
		}

		/// <summary>
		/// Updates a offer
		/// </summary>
		/// <param name="offer">The offer to update</param>
		/// <returns>The updated offer</returns>
		public Offer Update(Offer offer)
		{
			return UpdateAsync(offer).GetResult();
		}

		/// <summary>
		/// Creates a new offer
		/// </summary>
		/// <param name="offer">The offer to create</param>
		/// <returns>The created offer</returns>
		public Offer Create(Offer offer)
		{
			return CreateAsync(offer).GetResult();
		}

		/// <summary>
		/// Gets a list of offers
		/// </summary>
		/// <returns>A list of offers</returns>
		public EntityCollection<OfferSubset> Find(OfferSearch searchSettings)
		{
			return FindAsync(searchSettings).GetResult();
		}
		
		/// <summary>
		/// Creates an order from the offer
		/// <param name="id"></param>
		/// <returns></returns>
		/// </summary>
		public Offer CreateOrder(long? id)
		{
			return CreateOrderAsync(id).GetResult(); ;
		}
		
		/// <summary>
		/// Cancels an offer
		/// <param name="id"></param>
		/// <returns></returns>
		/// </summary>
		public Offer Cancel(long? id)
		{
			return CancelAsync(id).GetResult(); ;
		}
		
		/// <summary>
		/// Sends an e-mail to the customer with an attached PDF document of the offer. You can use the fieldEmailInformation to customize the e-mail message on each offer.
		/// <param name="id"></param>
		/// <returns></returns>
		/// </summary>
		public Offer Email(long? id)
		{
			return EmailAsync(id).GetResult(); ;
		}
		
		/// <summary>
		/// This action returns a PDF document with the current template that is used by the specific document. Note that this action also sets the field Sent as true.
		/// <param name="id"></param>
		/// <returns></returns>
		/// </summary>
		public byte[] Print(long? id)
		{
			return PrintAsync(id).GetResult(); ;
		}
		
		/// <summary>
		/// This action is used to set the field Sent as true from an external system without generating a PDF.
		/// <param name="id"></param>
		/// <returns></returns>
		/// </summary>
		public Offer ExternalPrint(long? id)
		{
			return ExternalPrintAsync(id).GetResult(); ;
		}
		
		/// <summary>
		/// This action returns a PDF document with the current template that is used by the specific document. Apart from the action print, this action doesn’t set the field Sent as true.
		/// <param name="id"></param>
		/// <returns></returns>
		/// </summary>
		public byte[] Preview(long? id)
        {
            return PreviewAsync(id).GetResult();
        }

		public async Task<EntityCollection<OfferSubset>> FindAsync(OfferSearch searchSettings)
		{
			return await BaseFind(searchSettings).ConfigureAwait(false);
		}
		public async Task<Offer> CreateAsync(Offer offer)
		{
			return await BaseCreate(offer).ConfigureAwait(false);
		}
		public async Task<Offer> UpdateAsync(Offer offer)
		{
			return await BaseUpdate(offer, offer.DocumentNumber.ToString()).ConfigureAwait(false);
		}
		public async Task<Offer> GetAsync(long? id)
		{
			return await BaseGet(id.ToString()).ConfigureAwait(false);
		}

        public async Task<Offer> CreateOrderAsync(long? id)
        {
            return await DoActionAsync(id.ToString(), Action.CreateOrder).ConfigureAwait(false);
		}

        public async Task<Offer> CancelAsync(long? id)
        {
            return await DoActionAsync(id.ToString(), Action.Cancel).ConfigureAwait(false);
		}

        public async Task<Offer> EmailAsync(long? id)
        {
            return await DoActionAsync(id.ToString(), Action.Email).ConfigureAwait(false);
		}

        public async Task<byte[]> PrintAsync(long? id)
        {
            return await DoDownloadActionAsync(id.ToString(), Action.Print).ConfigureAwait(false);
		}

        public async Task<Offer> ExternalPrintAsync(long? id)
        {
            return await DoActionAsync(id.ToString(), Action.ExternalPrint).ConfigureAwait(false);
		}

        public async Task<byte[]> PreviewAsync(long? id)
        {
            return await DoDownloadActionAsync(id.ToString(), Action.Preview).ConfigureAwait(false);
        }
	}
}
