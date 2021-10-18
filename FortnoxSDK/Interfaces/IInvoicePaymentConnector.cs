using System;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface IInvoicePaymentConnector : IEntityConnector
    {
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
        InvoicePayment Update(InvoicePayment invoicePayment);
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
        InvoicePayment Create(InvoicePayment invoicePayment);
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
        InvoicePayment Get(long? id);
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
        void Delete(long? id);
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
        EntityCollection<InvoicePaymentSubset> Find(InvoicePaymentSearch searchSettings);
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
        void Bookkeep(long? id);

        Task<InvoicePayment> UpdateAsync(InvoicePayment invoicePayment);
        Task<InvoicePayment> CreateAsync(InvoicePayment invoicePayment);
        Task<InvoicePayment> GetAsync(long? id);
        Task DeleteAsync(long? id);
        Task<EntityCollection<InvoicePaymentSubset>> FindAsync(InvoicePaymentSearch searchSettings);
        Task BookkeepAsync(long? id);

    }
}
