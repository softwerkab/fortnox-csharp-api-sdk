using System.Collections.Generic;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface IInvoiceFileConnectionConnector : IEntityConnector
	{
		InvoiceFileConnection Update(InvoiceFileConnection invoiceFileConnection);
		InvoiceFileConnection Create(InvoiceFileConnection invoiceFileConnection);
        void Delete(string id);
        List<InvoiceFileConnection> GetConnections(long? entityId, EntityType? entityType);

		Task<InvoiceFileConnection> UpdateAsync(InvoiceFileConnection invoiceFileConnection);
		Task<InvoiceFileConnection> CreateAsync(InvoiceFileConnection invoiceFileConnection);
        Task DeleteAsync(string id);
        Task<List<InvoiceFileConnection>> GetConnectionsAsync(long? entityId, EntityType? entityType);
	}
}
