using System.Collections.Generic;

namespace FortnoxAPILibrary.Connectors
{
	/// <remarks/>
	public class WayOfDeliveryConnector : EntityConnector<WayOfDelivery, WayOfDeliveries, Sort.By.WayOfDelivery>
	{
		/// <summary>
		/// Use with Find() to limit the search result
		/// </summary>
        [FilterProperty]
		public string Code { get; set; }

		/// <remarks/>
		public WayOfDeliveryConnector(string accessToken, string clientSecret) : base(accessToken, clientSecret)
        {
			base.Resource = "wayofdeliveries";
		}

		/// <summary>
		/// Find a way of delivery based on way of delivery code
		/// </summary>
		/// <param name="wayOfDeliveryCode">The way of deliverycode to find</param>
		/// <returns>The resulting way of deliverycode</returns>
		public WayOfDelivery Get(string wayOfDeliveryCode)
		{
			return base.BaseGet(wayOfDeliveryCode);
		}

		/// <summary>
		/// Updates a way of delivery
		/// </summary>
		/// <param name="wayOfDelivery">The way of delivery to update</param>
		/// <returns>The updated way of delivery</returns>
		public WayOfDelivery Update(WayOfDelivery wayOfDelivery)
		{
			return base.BaseUpdate(wayOfDelivery, wayOfDelivery.Code);
		}

		/// <summary>
		/// Create a new way of delivery
		/// </summary>
		/// <param name="wayOfDelivery">The way of delivery to create</param>
		/// <returns>The created way of delivery</returns>
		public WayOfDelivery Create(WayOfDelivery wayOfDelivery)
		{
			return base.BaseCreate(wayOfDelivery);
		}

		/// <summary>
		/// Deletes a way of Delivery
		/// </summary>
		/// <param name="wayOfDeliveryCode">The way of delivery code to delete</param>
		/// <returns>If the way of delivery was deleted or not</returns>
		public void Delete(string wayOfDeliveryCode)
		{
			base.BaseDelete(wayOfDeliveryCode);
		}

		/// <summary>
		/// Gets a list of way of deliveries
		/// </summary>
		/// <returns>A list of way of deliveries</returns>
		public WayOfDeliveries Find()
		{
			return base.BaseFind();
		}
	}
}
