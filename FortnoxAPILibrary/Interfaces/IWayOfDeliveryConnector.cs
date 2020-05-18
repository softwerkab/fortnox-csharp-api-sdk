using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IWayOfDeliveryConnector : IConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.WayOfDelivery? SortBy { get; set; }
		Filter.WayOfDelivery? FilterBy { get; set; }


		WayOfDelivery Update(WayOfDelivery wayOfDelivery);
		WayOfDelivery Create(WayOfDelivery wayOfDelivery);
		WayOfDelivery Get(string id);
		void Delete(string id);
		EntityCollection<WayOfDelivery> Find();

		Task<WayOfDelivery> UpdateAsync(WayOfDelivery wayOfDelivery);
		Task<WayOfDelivery> CreateAsync(WayOfDelivery wayOfDelivery);
		Task<WayOfDelivery> GetAsync(string id);
		Task DeleteAsync(string id);
		Task<EntityCollection<WayOfDelivery>> FindAsync();
	}
}
