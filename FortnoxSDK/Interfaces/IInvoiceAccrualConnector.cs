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
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		InvoiceAccrual Update(InvoiceAccrual invoiceAccrual);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		InvoiceAccrual Create(InvoiceAccrual invoiceAccrual);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		InvoiceAccrual Get(long? id);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		void Delete(long? id);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		EntityCollection<InvoiceAccrualSubset> Find(InvoiceAccrualSearch searchSettings);

		Task<InvoiceAccrual> UpdateAsync(InvoiceAccrual invoiceAccrual);
		Task<InvoiceAccrual> CreateAsync(InvoiceAccrual invoiceAccrual);
		Task<InvoiceAccrual> GetAsync(long? id);
		Task DeleteAsync(long? id);
		Task<EntityCollection<InvoiceAccrualSubset>> FindAsync(InvoiceAccrualSearch searchSettings);
	}
}
