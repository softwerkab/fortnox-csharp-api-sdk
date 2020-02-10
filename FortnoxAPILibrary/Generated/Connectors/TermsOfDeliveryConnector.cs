using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class TermsOfDeliveryConnector : EntityConnector<TermsOfDelivery, EntityCollection<TermsOfDeliverySubset>, Sort.By.TermsOfDelivery?>
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.TermsOfDelivery FilterBy { get; set; }


        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string Code { get; set; }

		/// <remarks/>
		public TermsOfDeliveryConnector()
		{
			Resource = "termsofdeliveries";
		}

		/// <summary>
		/// Find a termsOfDelivery based on termsOfDeliverynumber
		/// </summary>
		/// <param name="termsOfDeliveryNumber">The termsOfDeliverynumber to find</param>
		/// <returns>The found termsOfDelivery</returns>
		public TermsOfDelivery Get(string termsOfDeliveryNumber)
		{
			return BaseGet(termsOfDeliveryNumber);
		}

		/// <summary>
		/// Updates a termsOfDelivery
		/// </summary>
		/// <param name="termsOfDelivery">The termsOfDelivery to update</param>
		/// <returns>The updated termsOfDelivery</returns>
		public TermsOfDelivery Update(TermsOfDelivery termsOfDelivery)
		{
			return BaseUpdate(termsOfDelivery, termsOfDelivery.TermsOfDeliveryNumber);
		}

		/// <summary>
		/// Create a new termsOfDelivery
		/// </summary>
		/// <param name="termsOfDelivery">The termsOfDelivery to create</param>
		/// <returns>The created termsOfDelivery</returns>
		public TermsOfDelivery Create(TermsOfDelivery termsOfDelivery)
		{
			return BaseCreate(termsOfDelivery);
		}

		/// <summary>
		/// Deletes a termsOfDelivery
		/// </summary>
		/// <param name="termsOfDeliveryNumber">The termsOfDeliverynumber to delete</param>
		public void Delete(string termsOfDeliveryNumber)
		{
			BaseDelete(termsOfDeliveryNumber);
		}

		/// <summary>
		/// Gets a list of termsOfDeliverys
		/// </summary>
		/// <returns>A list of termsOfDeliverys</returns>
		public EntityCollection<TermsOfDeliverySubset> Find()
		{
			return BaseFind();
		}
	}
}
