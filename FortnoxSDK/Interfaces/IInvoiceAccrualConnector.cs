using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces;

/// <remarks/>
public interface IInvoiceAccrualConnector : IEntityConnector
{
    Task<InvoiceAccrual> UpdateAsync(InvoiceAccrual invoiceAccrual);
    Task<InvoiceAccrual> CreateAsync(InvoiceAccrual invoiceAccrual);
    Task<InvoiceAccrual> GetAsync(long? id);
    Task DeleteAsync(long? id);
    Task<EntityCollection<InvoiceAccrualSubset>> FindAsync(InvoiceAccrualSearch searchSettings);
}