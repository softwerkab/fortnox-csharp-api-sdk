using System;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface IOrderConnector : IEntityConnector
	{
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		Order Update(Order order);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		Order Create(Order order);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		Order Get(long? id);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		EntityCollection<OrderSubset> Find(OrderSearch searchSettings);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		Order CreateInvoice(long? id);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		Order Cancel(long? id);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        Order Email(long? id);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        byte[] Print(long? id);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        Order ExternalPrint(long? id);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        byte[] Preview(long? id);

        Task<Order> UpdateAsync(Order order);
		Task<Order> CreateAsync(Order order);
		Task<Order> GetAsync(long? id);
        Task<EntityCollection<OrderSubset>> FindAsync(OrderSearch searchSettings);
        Task<Order> CreateInvoiceAsync(long? id);
        Task<Order> CancelAsync(long? id);
        Task<Order> EmailAsync(long? id);
        Task<byte[]> PrintAsync(long? id);
        Task<Order> ExternalPrintAsync(long? id);
        Task<byte[]> PreviewAsync(long? id);
	}
}
