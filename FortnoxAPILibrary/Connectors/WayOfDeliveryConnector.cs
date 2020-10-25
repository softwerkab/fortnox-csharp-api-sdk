using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class WayOfDeliveryConnector : EntityConnector<WayOfDelivery, EntityCollection<WayOfDelivery>>, IWayOfDeliveryConnector
	{
		public WayOfDeliverySearch Search { get; set; } = new WayOfDeliverySearch();


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
			return GetAsync(id).Result;
		}

		/// <summary>
		/// Updates a wayOfDelivery
		/// </summary>
		/// <param name="wayOfDelivery">The wayOfDelivery to update</param>
		/// <returns>The updated wayOfDelivery</returns>
		public WayOfDelivery Update(WayOfDelivery wayOfDelivery)
		{
			return UpdateAsync(wayOfDelivery).Result;
		}

		/// <summary>
		/// Creates a new wayOfDelivery
		/// </summary>
		/// <param name="wayOfDelivery">The wayOfDelivery to create</param>
		/// <returns>The created wayOfDelivery</returns>
		public WayOfDelivery Create(WayOfDelivery wayOfDelivery)
		{
			return CreateAsync(wayOfDelivery).Result;
		}

		/// <summary>
		/// Deletes a wayOfDelivery
		/// </summary>
		/// <param name="id">Identifier of the wayOfDelivery to delete</param>
		public void Delete(string id)
		{
			DeleteAsync(id).Wait();
		}

		/// <summary>
		/// Gets a list of wayOfDeliverys
		/// </summary>
		/// <returns>A list of wayOfDeliverys</returns>
		public EntityCollection<WayOfDelivery> Find()
		{
			return FindAsync().Result;
		}

		public async Task<EntityCollection<WayOfDelivery>> FindAsync()
		{
			return await BaseFind().ConfigureAwait(false);
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
