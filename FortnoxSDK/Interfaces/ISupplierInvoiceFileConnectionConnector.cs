using System;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces;

/// <remarks/>
public interface ISupplierInvoiceFileConnectionConnector : IEntityConnector
{
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    SupplierInvoiceFileConnection Create(SupplierInvoiceFileConnection supplierInvoiceFileConnection);
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    SupplierInvoiceFileConnection Get(string id);
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    void Delete(string id);
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    EntityCollection<SupplierInvoiceFileConnection> Find(SupplierInvoiceFileConnectionSearch searchSettings);

    Task<SupplierInvoiceFileConnection> CreateAsync(SupplierInvoiceFileConnection supplierInvoiceFileConnection);
    Task<SupplierInvoiceFileConnection> GetAsync(string id);
    Task DeleteAsync(string id);
    Task<EntityCollection<SupplierInvoiceFileConnection>> FindAsync(SupplierInvoiceFileConnectionSearch searchSettings);
}