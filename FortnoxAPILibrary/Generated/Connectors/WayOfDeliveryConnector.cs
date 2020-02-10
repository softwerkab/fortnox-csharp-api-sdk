using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class WayOfDeliveryConnector : EntityConnector<WayOfDelivery, EntityCollection<WayOfDeliverySubset>, Sort.By.WayOfDelivery?>
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.WayOfDelivery? FilterBy { get; set; }


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
			return BaseGet(id);
		}

		/// <summary>
		/// Updates a wayOfDelivery
		/// </summary>
		/// <param name="wayOfDelivery">The wayOfDelivery to update</param>
		/// <returns>The updated wayOfDelivery</returns>
		public WayOfDelivery Update(WayOfDelivery wayOfDelivery)
		{
			return BaseUpdate(wayOfDelivery, wayOfDelivery.Code.ToString());
		}

		/// <summary>
		/// Creates a new wayOfDelivery
		/// </summary>
		/// <param name="wayOfDelivery">The wayOfDelivery to create</param>
		/// <returns>The created wayOfDelivery</returns>
		public WayOfDelivery Create(WayOfDelivery wayOfDelivery)
		{
			return BaseCreate(wayOfDelivery);
		}

		/// <summary>
		/// Deletes a wayOfDelivery
		/// </summary>
		/// <param name="id">Identifier of the wayOfDelivery to delete</param>
		public void Delete(string id)
		{
			BaseDelete(id);
		}

		/// <summary>
		/// Gets a list of wayOfDeliverys
		/// </summary>
		/// <returns>A list of wayOfDeliverys</returns>
		public EntityCollection<WayOfDeliverySubset> Find()
		{
			return BaseFind();
		}
	}
}
