using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class PriceConnector : EntityConnector<Price, EntityCollection<PriceSubset>, Sort.By.Price?>
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.Price? FilterBy { get; set; }


        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string ArticleNumber { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string FromQuantity { get; set; }

		/// <remarks/>
		public PriceConnector()
		{
			Resource = "prices";
		}

        /// <summary>
        /// Find a price
        /// </summary>
        /// <param name="priceListCode"></param>
        /// <param name="articleNumber"></param>
        /// <param name="fromQuantity"></param>
        /// <returns>The found price</returns>
        public Price Get(string priceListCode, string articleNumber, decimal? fromQuantity = null)
        {
            return BaseGet(priceListCode, articleNumber, fromQuantity?.ToString());
        }

        /// <summary>
        /// Updates a price
        /// </summary>
        /// <param name="price">The price to update</param>
        /// <returns>The updated price</returns>
        public Price Update(Price price)
        {
            return BaseUpdate(price, price.PriceList, price.ArticleNumber, price.FromQuantity?.ToString());
        }

        /// <summary>
        /// Creates a price
        /// </summary>
        /// <param name="price">The price to create</param>
        /// <returns>The created price</returns>
        public Price Create(Price price)
        {
            return BaseCreate(price);
        }

        /// <summary>
        /// Deletes a price
        /// </summary>
        /// <param name="priceListCode"></param>
        /// <param name="articleNumber"></param>
        /// <param name="fromQuantity"></param>
        public void Delete(string priceListCode, string articleNumber, decimal? fromQuantity = null)
        {
            BaseDelete(priceListCode, articleNumber, fromQuantity?.ToString());
        }

		/// <summary>
		/// Gets a list of prices
		/// </summary>
		/// <returns>A list of prices</returns>
		public EntityCollection<PriceSubset> Find(string priceListId, string articleId = null)
		{
			return BaseFind(null, "sublist", priceListId, articleId);
		}
	}
}
