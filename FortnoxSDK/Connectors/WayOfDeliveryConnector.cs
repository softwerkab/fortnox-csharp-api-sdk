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
    public class WayOfDeliveryConnector : SearchableEntityConnector<WayOfDelivery, WayOfDelivery, WayOfDeliverySearch>, IWayOfDeliveryConnector
	{


		/// <remarks/>
		public WayOfDeliveryConnector()
		{
			Resource = "wayofdeliveries";
		}
		/// <summary>
		/// Find a wayOfDelivery based on id
		/// </summary>
		/// <param name="id">Identifier of the wayOfDelivery to find</param>
		/// <returns>The found wayOfDelivery</returns>
		public WayOfDelivery Get(string id)
		{
			return GetAsync(id).GetResult();
		}

		/// <summary>
		/// Updates a wayOfDelivery
		/// </summary>
		/// <param name="wayOfDelivery">The wayOfDelivery to update</param>
		/// <returns>The updated wayOfDelivery</returns>
		public WayOfDelivery Update(WayOfDelivery wayOfDelivery)
		{
			return UpdateAsync(wayOfDelivery).GetResult();
		}

		/// <summary>
		/// Creates a new wayOfDelivery
		/// </summary>
		/// <param name="wayOfDelivery">The wayOfDelivery to create</param>
		/// <returns>The created wayOfDelivery</returns>
		public WayOfDelivery Create(WayOfDelivery wayOfDelivery)
		{
			return CreateAsync(wayOfDelivery).GetResult();
		}

		/// <summary>
		/// Deletes a wayOfDelivery
		/// </summary>
		/// <param name="id">Identifier of the wayOfDelivery to delete</param>
		public void Delete(string id)
		{
			DeleteAsync(id).GetResult();
		}

		/// <summary>
		/// Gets a list of wayOfDeliverys
		/// </summary>
		/// <returns>A list of wayOfDeliverys</returns>
		public EntityCollection<WayOfDelivery> Find(WayOfDeliverySearch searchSettings)
		{
			return FindAsync(searchSettings).GetResult();
		}

		public async Task<EntityCollection<WayOfDelivery>> FindAsync(WayOfDeliverySearch searchSettings)
		{
			return await BaseFind(searchSettings).ConfigureAwait(false);
		}
		public async Task DeleteAsync(string id)
		{
			await BaseDelete(id).ConfigureAwait(false);
		}
		public async Task<WayOfDelivery> CreateAsync(WayOfDelivery wayOfDelivery)
		{
			return await BaseCreate(wayOfDelivery).ConfigureAwait(false);
		}
		public async Task<WayOfDelivery> UpdateAsync(WayOfDelivery wayOfDelivery)
		{
			return await BaseUpdate(wayOfDelivery, wayOfDelivery.Code).ConfigureAwait(false);
		}
		public async Task<WayOfDelivery> GetAsync(string id)
		{
			return await BaseGet(id).ConfigureAwait(false);
		}
	}
}
