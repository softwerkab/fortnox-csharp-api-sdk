using System.Collections.Generic;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces;

/// <remarks/>
public interface IInvoiceFileConnectionConnector : IEntityConnector
{
    Task<InvoiceFileConnection> UpdateAsync(InvoiceFileConnection invoiceFileConnection);
    Task<InvoiceFileConnection> CreateAsync(InvoiceFileConnection invoiceFileConnection);
    Task DeleteAsync(string id);
    Task<IList<InvoiceFileConnection>> GetConnectionsAsync(long? entityId, EntityType? entityType);
}