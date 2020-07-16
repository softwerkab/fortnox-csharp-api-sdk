using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IOrderConnector : IEntityConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.Order? SortBy { get; set; }
		Filter.Order? FilterBy { get; set; }

		string CostCenter { get; set; }
		string CustomerName { get; set; }
		string CustomerNumber { get; set; }
		string DocumentNumber { get; set; }
		string ExternalInvoiceReference1 { get; set; }
		string ExternalInvoiceReference2 { get; set; }
		string OrderDate { get; set; }
		string OurReference { get; set; }
		string Project { get; set; }
		string Sent { get; set; }
		string YourReference { get; set; }

		Order Update(Order order);
		Order Create(Order order);
		Order Get(long? id);
        EntityCollection<OrderSubset> Find();
		Order CreateInvoice(long? id);
		Order Cancel(long? id);
		Order Email(long? id);
		byte[] Print(long? id);
		Order ExternalPrint(long? id);
		byte[] Preview(long? id);

		Task<Order> UpdateAsync(Order order);
		Task<Order> CreateAsync(Order order);
		Task<Order> GetAsync(long? id);
        Task<EntityCollection<OrderSubset>> FindAsync();
	}
}
