using System;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface IWayOfDeliveryConnector : IEntityConnector
    {
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
        WayOfDelivery Update(WayOfDelivery wayOfDelivery);
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
        WayOfDelivery Create(WayOfDelivery wayOfDelivery);
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
        WayOfDelivery Get(string id);
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
        void Delete(string id);
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
        EntityCollection<WayOfDelivery> Find(WayOfDeliverySearch searchSettings);

        Task<WayOfDelivery> UpdateAsync(WayOfDelivery wayOfDelivery);
        Task<WayOfDelivery> CreateAsync(WayOfDelivery wayOfDelivery);
        Task<WayOfDelivery> GetAsync(string id);
        Task DeleteAsync(string id);
        Task<EntityCollection<WayOfDelivery>> FindAsync(WayOfDeliverySearch searchSettings);
    }
}
