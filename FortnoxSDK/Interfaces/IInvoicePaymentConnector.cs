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
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        InvoicePayment Update(InvoicePayment invoicePayment);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        InvoicePayment Create(InvoicePayment invoicePayment);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        InvoicePayment Get(long? id);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        void Delete(long? id);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        EntityCollection<InvoicePaymentSubset> Find(InvoicePaymentSearch searchSettings);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        void Bookkeep(long? id);

        Task<InvoicePayment> UpdateAsync(InvoicePayment invoicePayment);
        Task<InvoicePayment> CreateAsync(InvoicePayment invoicePayment);
        Task<InvoicePayment> GetAsync(long? id);
        Task DeleteAsync(long? id);
        Task<EntityCollection<InvoicePaymentSubset>> FindAsync(InvoicePaymentSearch searchSettings);
        Task BookkeepAsync(long? id);

    }
}
