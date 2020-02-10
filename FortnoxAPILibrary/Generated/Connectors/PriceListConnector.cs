using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class PriceListConnector : EntityConnector<PriceList, EntityCollection<PriceListSubset>, Sort.By.PriceList?>
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.PriceList FilterBy { get; set; }


        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string Code { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string Comments { get; set; }

		/// <remarks/>
		public PriceListConnector()
		{
			Resource = "pricelists";
		}

		/// <summary>
		/// Find a priceList based on priceListnumber
		/// </summary>
		/// <param name="priceListNumber">The priceListnumber to find</param>
		/// <returns>The found priceList</returns>
		public PriceList Get(string priceListNumber)
		{
			return BaseGet(priceListNumber);
		}

		/// <summary>
		/// Updates a priceList
		/// </summary>
		/// <param name="priceList">The priceList to update</param>
		/// <returns>The updated priceList</returns>
		public PriceList Update(PriceList priceList)
		{
			return BaseUpdate(priceList, priceList.PriceListNumber);
		}

		/// <summary>
		/// Create a new priceList
		/// </summary>
		/// <param name="priceList">The priceList to create</param>
		/// <returns>The created priceList</returns>
		public PriceList Create(PriceList priceList)
		{
			return BaseCreate(priceList);
		}

		/// <summary>
		/// Deletes a priceList
		/// </summary>
		/// <param name="priceListNumber">The priceListnumber to delete</param>
		public void Delete(string priceListNumber)
		{
			BaseDelete(priceListNumber);
		}

		/// <summary>
		/// Gets a list of priceLists
		/// </summary>
		/// <returns>A list of priceLists</returns>
		public EntityCollection<PriceListSubset> Find()
		{
			return BaseFind();
		}
	}
}
