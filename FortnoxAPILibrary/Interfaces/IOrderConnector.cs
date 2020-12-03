using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IOrderConnector : IEntityConnector
	{

		Order Update(Order order);
		Order Create(Order order);
		Order Get(long? id);
        EntityCollection<OrderSubset> Find(OrderSearch searchSettings);
		Order CreateInvoice(long? id);
		Order Cancel(long? id);
		Order Email(long? id);
		byte[] Print(long? id);
		Order ExternalPrint(long? id);
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
