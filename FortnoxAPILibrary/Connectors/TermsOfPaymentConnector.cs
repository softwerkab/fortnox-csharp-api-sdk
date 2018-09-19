namespace FortnoxAPILibrary.Connectors
{
    public interface ITermsOfPaymentConnector : IEntityConnector<Sort.By.TermsOfPayment>
    {
        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        string Code { get; set; }

        /// <summary>
        /// Gets a Terms of payment by code
        /// </summary>
        /// <param name="termsOfPaymentCode"></param>
        /// <returns></returns>
        TermsOfPayment Get(string termsOfPaymentCode);

        /// <summary>
        /// Updates a terms of payment
        /// </summary>
        /// <param name="termsOfPayment"></param>
        /// <returns></returns>
        TermsOfPayment Update(TermsOfPayment termsOfPayment);

        /// <summary>
        /// Create a new Terms of payment
        /// </summary>
        /// <param name="termsOfPayment">The terms of payment entity to create</param>
        /// <returns>The created terms of payment.</returns>
        TermsOfPayment Create(TermsOfPayment termsOfPayment);

        /// <summary>
        /// Delete a terms of payment
        /// </summary>
        /// <param name="termsOfPaymentCode">The terms of payemnt code to delete</param>
        /// <returns>If the terms of payment was deleted. </returns>
        void Delete(string termsOfPaymentCode);

        /// <summary>
        /// Gets a list of terms of payments
        /// </summary>
        /// <returns>A list of terms of payments</returns>
        TermsOfPayments Find();
    }

    /// <remarks/>
	public class TermsOfPaymentConnector : EntityConnector<TermsOfPayment, TermsOfPayments, Sort.By.TermsOfPayment>, ITermsOfPaymentConnector
    {
        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [FilterProperty]
        public string Code { get; set; }

		/// <remarks/>
		public TermsOfPaymentConnector()
		{
			base.Resource = "termsofpayments";
		}

		/// <summary>
		/// Gets a Terms of payment by code
		/// </summary>
		/// <param name="termsOfPaymentCode"></param>
		/// <returns></returns>
		public TermsOfPayment Get(string termsOfPaymentCode)
		{
			return base.BaseGet(termsOfPaymentCode);
		}

		/// <summary>
		/// Updates a terms of payment
		/// </summary>
		/// <param name="termsOfPayment"></param>
		/// <returns></returns>
		public TermsOfPayment Update(TermsOfPayment termsOfPayment)
		{
			return base.BaseUpdate(termsOfPayment, termsOfPayment.Code);
		}

		/// <summary>
		/// Create a new Terms of payment
		/// </summary>
		/// <param name="termsOfPayment">The terms of payment entity to create</param>
		/// <returns>The created terms of payment.</returns>
		public TermsOfPayment Create(TermsOfPayment termsOfPayment)
		{
			return base.BaseCreate(termsOfPayment);
		}

		/// <summary>
		/// Delete a terms of payment
		/// </summary>
		/// <param name="termsOfPaymentCode">The terms of payemnt code to delete</param>
		/// <returns>If the terms of payment was deleted. </returns>
		public void Delete(string termsOfPaymentCode)
		{
			base.BaseDelete(termsOfPaymentCode);
		}

		/// <summary>
		/// Gets a list of terms of payments
		/// </summary>
		/// <returns>A list of terms of payments</returns>
		public TermsOfPayments Find()
        {
			return base.BaseFind();
		}
	}
}
