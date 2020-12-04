using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;
using Fortnox.SDK.Utility;

// ReSharper disable UnusedMember.Global

namespace Fortnox.SDK.Connectors
{
    /// <remarks/>
    public class PriceListConnector : SearchableEntityConnector<PriceList, PriceList, PriceListSearch>, IPriceListConnector
	{


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
			return GetAsync(id).GetResult();
		}

		/// <summary>
		/// Updates a priceList
		/// </summary>
		/// <param name="priceList">The priceList to update</param>
		/// <returns>The updated priceList</returns>
		public PriceList Update(PriceList priceList)
		{
			return UpdateAsync(priceList).GetResult();
		}

		/// <summary>
		/// Creates a new priceList
		/// </summary>
		/// <param name="priceList">The priceList to create</param>
		/// <returns>The created priceList</returns>
		public PriceList Create(PriceList priceList)
		{
			return CreateAsync(priceList).GetResult();
		}
		
		/// <summary>
		/// Gets a list of priceLists
		/// </summary>
		/// <returns>A list of priceLists</returns>
		public EntityCollection<PriceList> Find(PriceListSearch searchSettings)
		{
			return FindAsync(searchSettings).GetResult();
		}

		public async Task<EntityCollection<PriceList>> FindAsync(PriceListSearch searchSettings)
		{
			return await BaseFind(searchSettings).ConfigureAwait(false);
		}
		public async Task<PriceList> CreateAsync(PriceList priceList)
		{
			return await BaseCreate(priceList).ConfigureAwait(false);
		}
		public async Task<PriceList> UpdateAsync(PriceList priceList)
		{
			return await BaseUpdate(priceList, priceList.Code).ConfigureAwait(false);
		}
		public async Task<PriceList> GetAsync(string id)
		{
			return await BaseGet(id).ConfigureAwait(false);
		}
	}
}
