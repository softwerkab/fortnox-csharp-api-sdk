using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;
// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IOrderConnector : IConnector
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
		Order Get(int? id);
        EntityCollection<OrderSubset> Find();
		Order CreateInvoice(int? id);
		Order Cancel(int? id);
		Order Email(int? id);
		Order Print(int? id);
		Order ExternalPrint(int? id);
		Order Preview(int? id);
	}
}
