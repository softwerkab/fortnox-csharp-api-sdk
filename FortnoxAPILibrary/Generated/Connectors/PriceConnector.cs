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
		/// Find a price based on id
		/// </summary>
		/// <param name="id">Identifier of the price to find</param>
		/// <returns>The found price</returns>
		public Price Get(string id)
		{
			return BaseGet(id);
		}

		/// <summary>
		/// Updates a price
		/// </summary>
		/// <param name="price">The price to update</param>
		/// <returns>The updated price</returns>
		public Price Update(Price price)
		{
			return BaseUpdate(price, price.Id.ToString());
		}

		/// <summary>
		/// Creates a new price
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
		/// <param name="id">Identifier of the price to delete</param>
		public void Delete(string id)
		{
			BaseDelete(id);
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
