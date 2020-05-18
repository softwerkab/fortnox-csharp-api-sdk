using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class PriceConnector : EntityConnector<Price, EntityCollection<PriceSubset>, Sort.By.Price?>, IPriceConnector
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
			return GetAsync(priceListCode, articleNumber, fromQuantity).Result;
        }

        /// <summary>
        /// Updates a price
        /// </summary>
        /// <param name="price">The price to update</param>
        /// <returns>The updated price</returns>
        public Price Update(Price price)
        {
			return UpdateAsync(price).Result;
        }

        /// <summary>
        /// Creates a price
        /// </summary>
        /// <param name="price">The price to create</param>
        /// <returns>The created price</returns>
        public Price Create(Price price)
        {
			return CreateAsync(price).Result;
        }

        /// <summary>
        /// Deletes a price
        /// </summary>
        /// <param name="priceListCode"></param>
        /// <param name="articleNumber"></param>
        /// <param name="fromQuantity"></param>
        public void Delete(string priceListCode, string articleNumber, decimal? fromQuantity = null)
        {
			DeleteAsync(priceListCode, articleNumber, fromQuantity).Wait();
        }

		/// <summary>
		/// Gets a list of prices
		/// </summary>
		/// <returns>A list of prices</returns>
		public EntityCollection<PriceSubset> Find(string priceListId, string articleId = null)
		{
			return FindAsync(priceListId, articleId).Result;
		}

		public async Task<EntityCollection<PriceSubset>> FindAsync(string priceListId, string articleId = null)
		{
			return await BaseFind("sublist", priceListId, articleId);
		}
        public async Task DeleteAsync(string priceListCode, string articleNumber, decimal? fromQuantity = null)
        {
            await BaseDelete(priceListCode, articleNumber, fromQuantity?.ToString());
        }
        public async Task<Price> CreateAsync(Price price)
        {
            return await BaseCreate(price);
        }
        public async Task<Price> UpdateAsync(Price price)
        {
            return await BaseUpdate(price, price.PriceList, price.ArticleNumber, price.FromQuantity?.ToString());
        }
        public async Task<Price> GetAsync(string priceListCode, string articleNumber, decimal? fromQuantity = null)
        {
            return await BaseGet(priceListCode, articleNumber, fromQuantity?.ToString());
        }
	}
}
