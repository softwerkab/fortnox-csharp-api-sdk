using System.Collections.Generic;
using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Requests;
using Fortnox.SDK.Search;
using Fortnox.SDK.Utility;

// ReSharper disable UnusedMember.Global

namespace Fortnox.SDK.Connectors
{
    /// <remarks/>
    public class PriceConnector : SearchableEntityConnector<Price, PriceSubset, PriceSearch>, IPriceConnector
	{


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
			return GetAsync(priceListCode, articleNumber, fromQuantity).GetResult();
        }

        /// <summary>
        /// Updates a price
        /// </summary>
        /// <param name="price">The price to update</param>
        /// <returns>The updated price</returns>
        public Price Update(Price price)
        {
			return UpdateAsync(price).GetResult();
        }

        /// <summary>
        /// Creates a price
        /// </summary>
        /// <param name="price">The price to create</param>
        /// <returns>The created price</returns>
        public Price Create(Price price)
        {
			return CreateAsync(price).GetResult();
        }

        /// <summary>
        /// Deletes a price
        /// </summary>
        /// <param name="priceListCode"></param>
        /// <param name="articleNumber"></param>
        /// <param name="fromQuantity"></param>
        public void Delete(string priceListCode, string articleNumber, decimal? fromQuantity = null)
        {
			DeleteAsync(priceListCode, articleNumber, fromQuantity).GetResult();
        }

		/// <summary>
		/// Gets a list of prices
		/// </summary>
		/// <returns>A list of prices</returns>
		public EntityCollection<PriceSubset> Find(string priceListId, string articleId, PriceSearch searchSettings)
		{
			return FindAsync(priceListId, articleId, searchSettings).GetResult();
		}

		public async Task<EntityCollection<PriceSubset>> FindAsync(string priceListId, string articleId, PriceSearch searchSettings)
		{
            var request = new SearchRequest<PriceSubset>()
            {
                Resource = $"{Resource}/sublist",
                Indices = new List<string>(){ priceListId, articleId },
                SearchSettings = searchSettings
            };

            return await SendAsync(request).ConfigureAwait(false);
        }
        public async Task DeleteAsync(string priceListCode, string articleNumber, decimal? fromQuantity = null)
        {
            await BaseDelete(priceListCode, articleNumber, fromQuantity?.ToString()).ConfigureAwait(false);
        }
        public async Task<Price> CreateAsync(Price price)
        {
            return await BaseCreate(price).ConfigureAwait(false);
        }
        public async Task<Price> UpdateAsync(Price price)
        {
            return await BaseUpdate(price, price.PriceList, price.ArticleNumber, price.FromQuantity?.ToString()).ConfigureAwait(false);
        }
        public async Task<Price> GetAsync(string priceListCode, string articleNumber, decimal? fromQuantity = null)
        {
            return await BaseGet(priceListCode, articleNumber, fromQuantity?.ToString()).ConfigureAwait(false);
        }
	}
}
