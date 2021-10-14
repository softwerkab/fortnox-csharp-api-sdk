using System;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface ISupplierConnector : IEntityConnector
    {
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        Supplier Update(Supplier supplier);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        Supplier Create(Supplier supplier);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        Supplier Get(string id);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        void Delete(string id);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        EntityCollection<SupplierSubset> Find(SupplierSearch searchSettings);

        Task<Supplier> UpdateAsync(Supplier supplier);
        Task<Supplier> CreateAsync(Supplier supplier);
        Task<Supplier> GetAsync(string id);
        Task DeleteAsync(string id);
        Task<EntityCollection<SupplierSubset>> FindAsync(SupplierSearch searchSettings);
    }
}
