using System;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface IInvoiceAccrualConnector : IEntityConnector
	{
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
		InvoiceAccrual Update(InvoiceAccrual invoiceAccrual);
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
		InvoiceAccrual Create(InvoiceAccrual invoiceAccrual);
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
		InvoiceAccrual Get(long? id);
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
		void Delete(long? id);
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
		EntityCollection<InvoiceAccrualSubset> Find(InvoiceAccrualSearch searchSettings);

		Task<InvoiceAccrual> UpdateAsync(InvoiceAccrual invoiceAccrual);
		Task<InvoiceAccrual> CreateAsync(InvoiceAccrual invoiceAccrual);
		Task<InvoiceAccrual> GetAsync(long? id);
		Task DeleteAsync(long? id);
		Task<EntityCollection<InvoiceAccrualSubset>> FindAsync(InvoiceAccrualSearch searchSettings);
	}
}
