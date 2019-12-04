
using FortnoxAPILibrary.Entities;

namespace FortnoxAPILibrary.Connectors
{
	/// <remarks/>
	public class PriceListConnector : EntityConnector<PriceList, PriceLists, Sort.By.PriceList>
	{
		/// <remarks/>
		public PriceListConnector()
		{
			base.Resource = "pricelists";
		}

		/// <summary>
		/// Gets a price list 
		/// </summary>
		/// <param name="code">The code of the price list to find</param>
		/// <returns>The found price list</returns>
		public PriceList Get(string code)
		{
			return base.BaseGet(code);
		}

		/// <summary>
		/// Updates a price list
		/// </summary>
		/// <param name="priceList">The price list to update</param>
		/// <returns>The updated price list</returns>
		public PriceList Update(PriceList priceList)
		{
			return base.BaseUpdate(priceList, priceList.Code);
		}

		/// <summary>
		/// Create a new price list
		/// </summary>
		/// <param name="priceList">The price list to create</param>
		/// <returns>The created price list</returns>
		public PriceList Create(PriceList priceList)
		{
			return base.BaseCreate(priceList);
		}

		/// <summary>
		/// Gets a list of price lists
		/// </summary>
		/// <returns>A list of price lists</returns>
		public PriceLists Find()
		{
			return base.BaseFind();
		}
	}
}
