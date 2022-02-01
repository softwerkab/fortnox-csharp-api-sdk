using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces;

/// <remarks/>
public interface IOrderConnector : IEntityConnector
{
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
    Task<Order> WarehouseReady(long? id);
}