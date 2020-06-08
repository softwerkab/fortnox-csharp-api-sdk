using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class PriceListConnector : EntityConnector<PriceList, EntityCollection<PriceList>, Sort.By.PriceList?>, IPriceListConnector
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.PriceList? FilterBy { get; set; }


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
		/// Find a priceList based on id
		/// </summary>
		/// <param name="id">Identifier of the priceList to find</param>
		/// <returns>The found priceList</returns>
		public PriceList Get(string id)
		{
			return GetAsync(id).Result;
		}

		/// <summary>
		/// Updates a priceList
		/// </summary>
		/// <param name="priceList">The priceList to update</param>
		/// <returns>The updated priceList</returns>
		public PriceList Update(PriceList priceList)
		{
			return UpdateAsync(priceList).Result;
		}

		/// <summary>
		/// Creates a new priceList
		/// </summary>
		/// <param name="priceList">The priceList to create</param>
		/// <returns>The created priceList</returns>
		public PriceList Create(PriceList priceList)
		{
			return CreateAsync(priceList).Result;
		}
		
		/// <summary>
		/// Gets a list of priceLists
		/// </summary>
		/// <returns>A list of priceLists</returns>
		public EntityCollection<PriceList> Find()
		{
			return FindAsync().Result;
		}

		public async Task<EntityCollection<PriceList>> FindAsync()
		{
			return await BaseFind();
		}
		public async Task<PriceList> CreateAsync(PriceList priceList)
		{
			return await BaseCreate(priceList);
		}
		public async Task<PriceList> UpdateAsync(PriceList priceList)
		{
			return await BaseUpdate(priceList, priceList.Code);
		}
		public async Task<PriceList> GetAsync(string id)
		{
			return await BaseGet(id);
		}
	}
}
