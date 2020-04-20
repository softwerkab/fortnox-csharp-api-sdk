using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IWayOfDeliveryConnector : IConnector
	{
        [SearchParameter("filter")]
		Filter.WayOfDelivery? FilterBy { get; set; }

		WayOfDelivery Update(WayOfDelivery wayOfDelivery);

		WayOfDelivery Create(WayOfDelivery wayOfDelivery);

		WayOfDelivery Get(string id);

		void Delete(string id);

		EntityCollection<WayOfDelivery> Find();

	}
}
