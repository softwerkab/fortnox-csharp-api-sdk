using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IOrderConnector
	{
        [SearchParameter("filter")]
		Filter.Order? FilterBy { get; set; }

        [SearchParameter]
		string CostCenter { get; set; }

        [SearchParameter]
		string CustomerName { get; set; }

        [SearchParameter]
		string CustomerNumber { get; set; }

        [SearchParameter]
		string DocumentNumber { get; set; }

        [SearchParameter]
		string ExternalInvoiceReference1 { get; set; }

        [SearchParameter]
		string ExternalInvoiceReference2 { get; set; }

        [SearchParameter]
		string OrderDate { get; set; }

        [SearchParameter]
		string OurReference { get; set; }

        [SearchParameter]
		string Project { get; set; }

        [SearchParameter]
		string Sent { get; set; }

        [SearchParameter]
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
