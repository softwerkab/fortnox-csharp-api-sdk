using FortnoxAPILibrary.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IInvoiceFileConnectionConnector : IConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.InvoiceFileConnection? SortBy { get; set; }
		Filter.InvoiceFileConnection? FilterBy { get; set; }


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
