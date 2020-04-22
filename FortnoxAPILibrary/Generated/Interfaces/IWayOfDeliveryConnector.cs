using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IWayOfDeliveryConnector : IConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.WayOfDelivery? SortBy { get; set; }

        [SearchParameter("filter")]
		Filter.WayOfDelivery? FilterBy { get; set; }

		WayOfDelivery Update(WayOfDelivery wayOfDelivery);

		WayOfDelivery Create(WayOfDelivery wayOfDelivery);

		WayOfDelivery Get(string id);

		void Delete(string id);

		EntityCollection<WayOfDelivery> Find();

	}
}
