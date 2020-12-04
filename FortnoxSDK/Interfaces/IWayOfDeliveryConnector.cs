using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface IWayOfDeliveryConnector : IEntityConnector
	{


		WayOfDelivery Update(WayOfDelivery wayOfDelivery);
		WayOfDelivery Create(WayOfDelivery wayOfDelivery);
		WayOfDelivery Get(string id);
		void Delete(string id);
		EntityCollection<WayOfDelivery> Find(WayOfDeliverySearch searchSettings);

		Task<WayOfDelivery> UpdateAsync(WayOfDelivery wayOfDelivery);
		Task<WayOfDelivery> CreateAsync(WayOfDelivery wayOfDelivery);
		Task<WayOfDelivery> GetAsync(string id);
		Task DeleteAsync(string id);
		Task<EntityCollection<WayOfDelivery>> FindAsync(WayOfDeliverySearch searchSettings);
	}
}
