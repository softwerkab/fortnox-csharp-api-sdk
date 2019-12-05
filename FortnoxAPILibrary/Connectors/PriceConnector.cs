
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
	/// <remarks/>
	public class PriceConnector : EntityConnector<Price, Prices, Sort.By.Price>
	{

		/// <summary>
		/// Use with Find() to limit the search result
		/// </summary>
		public string PriceList { get; set; }

		/// <summary>
		/// Use with Find() to limit the search result
		/// </summary>
        [FilterProperty]
		public string ArticleNumber { get; set; }

		/// <summary>
		/// Use with Find() to limit the search result
		/// </summary>
        [FilterProperty]
		public string FromQuantity { get; set; }

		/// <remarks/>
		public PriceConnector()
		{
			Resource = "prices";
		}

		/// <summary>
		/// Gets a price
		/// </summary>
		/// <param name="priceList">The price list to find</param>
		/// <param name="articleNumber">The article number to find</param>
		/// <param name="fromQuantity">The from quantity of the price to find. Optional. If omitted, 0 will be used.</param>
		/// <returns>The found price</returns>
		public Price Get(string priceList, string articleNumber, string fromQuantity = "0")
		{
			Resource = "prices";

			return BaseGet(priceList, articleNumber, fromQuantity);
		}

		/// <summary>
		/// Updates a price
		/// </summary>
		/// <param name="price">The price to update</param>
		/// <returns>The updated price</returns>
		public Price Update(Price price)
		{
			Resource = "prices";
			return BaseUpdate(price, price.PriceList, price.ArticleNumber);
		}

		/// <summary>
		/// Create a new price
		/// </summary>
		/// <param name="price">The price to create</param>
		/// <returns>The created price</returns>
		public Price Create(Price price)
		{
			Resource = "prices";
			return BaseCreate(price);
		}

		/// <summary>
		/// Deletes a price
		/// </summary>
		/// <param name="priceList">The pricelist of the price to delete.</param>
		/// <param name="articleNumber">The article number of the price to delete.</param>
		/// <param name="fromQuantity">The from quantity of the price to delete. Optional. If omitted, all prices with the given price list and article number will be deleted.</param>
		/// <returns>If the price was deleted or not</returns>
		public void Delete(string priceList, string articleNumber, string fromQuantity = "0")
		{
			Resource = "prices";
			string id = priceList + "/" + articleNumber;

			if (!string.IsNullOrEmpty(fromQuantity))
			{
				id += "/" + fromQuantity.ToString();
			}

			BaseDelete(id);
		}

		/// <summary>
		/// Gets a list of prices. Use the properties of PriceConnector to limit the result.
		/// </summary>
		/// <returns>A list of prices</returns>
		public Prices Find()
		{
			Resource = "prices/sublist/";

			if (!string.IsNullOrEmpty(PriceList))
			{
				Resource += PriceList;
			}

			return BaseFind();
		}
	}
}
