using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface IInvoiceFileConnectionConnector : IEntityConnector
	{
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        InvoiceFileConnection Update(InvoiceFileConnection invoiceFileConnection);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        InvoiceFileConnection Create(InvoiceFileConnection invoiceFileConnection);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        void Delete(string id);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        IList<InvoiceFileConnection> GetConnections(long? entityId, EntityType? entityType);

		Task<InvoiceFileConnection> UpdateAsync(InvoiceFileConnection invoiceFileConnection);
		Task<InvoiceFileConnection> CreateAsync(InvoiceFileConnection invoiceFileConnection);
        Task DeleteAsync(string id);
        Task<IList<InvoiceFileConnection>> GetConnectionsAsync(long? entityId, EntityType? entityType);
	}
}
