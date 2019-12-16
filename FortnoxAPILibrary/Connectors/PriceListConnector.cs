using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
	/// <remarks/>
	public class PriceListConnector : EntityConnector<PriceList, EntityCollection<PriceListSubset>, Sort.By.PriceList?>
	{
		/// <remarks/>
		public PriceListConnector()
		{
			Resource = "pricelists";
		}

		/// <summary>
		/// Gets a price list 
		/// </summary>
		/// <param name="code">The code of the price list to find</param>
		/// <returns>The found price list</returns>
		public PriceList Get(string code)
		{
			return BaseGet(code);
		}

		/// <summary>
		/// Updates a price list
		/// </summary>
		/// <param name="priceList">The price list to update</param>
		/// <returns>The updated price list</returns>
		public PriceList Update(PriceList priceList)
		{
			return BaseUpdate(priceList, priceList.Code);
		}

		/// <summary>
		/// Create a new price list
		/// </summary>
		/// <param name="priceList">The price list to create</param>
		/// <returns>The created price list</returns>
		public PriceList Create(PriceList priceList)
		{
			return BaseCreate(priceList);
		}

		/// <summary>
		/// Gets a list of price lists
		/// </summary>
		/// <returns>A list of price lists</returns>
		public EntityCollection<PriceListSubset> Find()
		{
			return BaseFind();
		}
	}
}
