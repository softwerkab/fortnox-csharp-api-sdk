using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class TermsOfPaymentConnector : EntityConnector<TermsOfPayment, EntityCollection<TermsOfPaymentSubset>, Sort.By.TermsOfPayment?>
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.TermsOfPayment FilterBy { get; set; }


		/// <remarks/>
		public TermsOfPaymentConnector()
		{
			Resource = "termsofpayments";
		}

		/// <summary>
		/// Find a termsOfPayment based on termsOfPaymentnumber
		/// </summary>
		/// <param name="termsOfPaymentNumber">The termsOfPaymentnumber to find</param>
		/// <returns>The found termsOfPayment</returns>
		public TermsOfPayment Get(string termsOfPaymentNumber)
		{
			return BaseGet(termsOfPaymentNumber);
		}

		/// <summary>
		/// Updates a termsOfPayment
		/// </summary>
		/// <param name="termsOfPayment">The termsOfPayment to update</param>
		/// <returns>The updated termsOfPayment</returns>
		public TermsOfPayment Update(TermsOfPayment termsOfPayment)
		{
			return BaseUpdate(termsOfPayment, termsOfPayment.TermsOfPaymentNumber);
		}

		/// <summary>
		/// Create a new termsOfPayment
		/// </summary>
		/// <param name="termsOfPayment">The termsOfPayment to create</param>
		/// <returns>The created termsOfPayment</returns>
		public TermsOfPayment Create(TermsOfPayment termsOfPayment)
		{
			return BaseCreate(termsOfPayment);
		}

		/// <summary>
		/// Deletes a termsOfPayment
		/// </summary>
		/// <param name="termsOfPaymentNumber">The termsOfPaymentnumber to delete</param>
		public void Delete(string termsOfPaymentNumber)
		{
			BaseDelete(termsOfPaymentNumber);
		}

		/// <summary>
		/// Gets a list of termsOfPayments
		/// </summary>
		/// <returns>A list of termsOfPayments</returns>
		public EntityCollection<TermsOfPaymentSubset> Find()
		{
			return BaseFind();
		}
	}
}
