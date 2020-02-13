using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class OrderConnector : EntityConnector<Order, EntityCollection<OrderSubset>, Sort.By.Order?>
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.Order? FilterBy { get; set; }


        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string CostCenter { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string CustomerName { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string CustomerNumber { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string DocumentNumber { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string ExternalInvoiceReference1 { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string ExternalInvoiceReference2 { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string OrderDate { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string OurReference { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string Project { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string Sent { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string YourReference { get; set; }

		/// <remarks/>
		public OrderConnector()
		{
			Resource = "orders";
		}

		/// <summary>
		/// Find a order based on id
		/// </summary>
		/// <param name="id">Identifier of the order to find</param>
		/// <returns>The found order</returns>
		public Order Get(int? id)
		{
			return BaseGet(id.ToString());
		}

		/// <summary>
		/// Updates a order
		/// </summary>
		/// <param name="order">The order to update</param>
		/// <returns>The updated order</returns>
		public Order Update(Order order)
		{
			return BaseUpdate(order, order.DocumentNumber.ToString());
		}

		/// <summary>
		/// Creates a new order
		/// </summary>
		/// <param name="order">The order to create</param>
		/// <returns>The created order</returns>
		public Order Create(Order order)
		{
			return BaseCreate(order);
		}

		/// <summary>
		/// Gets a list of orders
		/// </summary>
		/// <returns>A list of orders</returns>
		public EntityCollection<OrderSubset> Find()
		{
			return BaseFind();
		}
		
		/// <summary>
		/// Creates an invoice from the order
		/// <param name="id"></param>
		/// <returns></returns>
		/// </summary>
		public Order CreateInvoice(int? id)
		{
			return DoAction(id.ToString(), "createinvoice");
		}
		
		/// <summary>
		/// Cancels an order
		/// <param name="id"></param>
		/// <returns></returns>
		/// </summary>
		public Order Cancel(int? id)
		{
			return DoAction(id.ToString(), "cancel");
		}
		
		/// <summary>
		/// Sends an e-mail to the customer with an attached PDF document of the invoice. You can use the field EmailInformation to customize the e-mail message on each invoice.
		/// <param name="id"></param>
		/// <returns></returns>
		/// </summary>
		public Order Email(int? id)
		{
			return DoAction(id.ToString(), "email");
		}
		
		/// <summary>
		/// This action returns a PDF document with the current template that is used by the specific document. Note that this action also sets the field Sent as true.
		/// <param name="id"></param>
		/// <returns></returns>
		/// </summary>
		public Order Print(int? id)
		{
			return DoAction(id.ToString(), "print");
		}
		
		/// <summary>
		/// This action is used to set the field Sent as true from an external system without generating a PDF.
		/// <param name="id"></param>
		/// <returns></returns>
		/// </summary>
		public Order ExternalPrint(int? id)
		{
			return DoAction(id.ToString(), "externalprint");
		}
		
		/// <summary>
		/// This action returns a PDF document with the current template that is used by the specific document. Apart from the action print, this action doesn’t set the field Sent as true.
		/// <param name="id"></param>
		/// <returns></returns>
		/// </summary>
		public Order Preview(int? id)
		{
			return DoAction(id.ToString(), "preview");
		}
	}
}
