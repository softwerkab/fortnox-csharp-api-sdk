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
		public Filter.Price FilterBy { get; set; }


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
		/// Find a price based on pricenumber
		/// </summary>
		/// <param name="priceNumber">The pricenumber to find</param>
		/// <returns>The found price</returns>
		public Price Get(string priceNumber)
		{
			return BaseGet(priceNumber);
		}

		/// <summary>
		/// Updates a price
		/// </summary>
		/// <param name="price">The price to update</param>
		/// <returns>The updated price</returns>
		public Price Update(Price price)
		{
			return BaseUpdate(price, price.PriceNumber);
		}

		/// <summary>
		/// Create a new price
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
		/// <param name="priceNumber">The pricenumber to delete</param>
		public void Delete(string priceNumber)
		{
			BaseDelete(priceNumber);
		}

		/// <summary>
		/// Gets a list of prices
		/// </summary>
		/// <returns>A list of prices</returns>
		public EntityCollection<PriceSubset> Find()
		{
			return BaseFind();
		}
	}
}
