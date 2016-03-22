
namespace FortnoxAPILibrary.Connectors
{
	/// <remarks/>
	public class CurrencyConnector : EntityConnector<Currency, Currencies, Sort.By.Currency>
	{
		/// <remarks/>
		public CurrencyConnector(string accessToken, string clientSecret) : base(accessToken, clientSecret)
        {
			base.Resource = "currencies";
		}

        /// <remarks/>
        public CurrencyConnector() : this(null, null)
        {
        }

        /// <summary>
        /// Gets a currency based on currency code
        /// </summary>
        /// <param name="currencyCode"></param>
        /// <returns></returns>
        public Currency Get(string currencyCode)
		{
			return base.BaseGet(currencyCode);
		}

		/// <summary>
		/// Updates a currency
		/// </summary>
		/// <param name="currency">The currency entity to update</param>
		/// <returns>The updated currency entity</returns>
		public Currency Update(Currency currency)
		{
			return base.BaseUpdate(currency, currency.Code);
		}

		/// <summary>
		/// Create a new currency
		/// </summary>
		/// <param name="currency">The currency entity to create</param>
		/// <returns>The created currency entity</returns>
		public Currency Create(Currency currency)
		{
			return base.BaseCreate(currency);
		}

		/// <summary>
		/// Deletes a currency
		/// </summary>
		/// <param name="currencyCode">The currency code to delete</param>
		/// <returns>If the currency was deleted or not</returns>
		public void Delete(string currencyCode)
		{
			base.BaseDelete(currencyCode);
		}

		/// <summary>
		/// Gets at list of currencies
		/// </summary>
		/// <returns>A list of currencies</returns>
		public Currencies Find()
		{
			return base.BaseFind();
		}
	}
}
