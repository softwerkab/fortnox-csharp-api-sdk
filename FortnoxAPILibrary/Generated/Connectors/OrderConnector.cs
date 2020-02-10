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
		public Filter.Order FilterBy { get; set; }


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
		/// Find a order based on ordernumber
		/// </summary>
		/// <param name="orderNumber">The ordernumber to find</param>
		/// <returns>The found order</returns>
		public Order Get(string orderNumber)
		{
			return BaseGet(orderNumber);
		}

		/// <summary>
		/// Updates a order
		/// </summary>
		/// <param name="order">The order to update</param>
		/// <returns>The updated order</returns>
		public Order Update(Order order)
		{
			return BaseUpdate(order, order.OrderNumber);
		}

		/// <summary>
		/// Create a new order
		/// </summary>
		/// <param name="order">The order to create</param>
		/// <returns>The created order</returns>
		public Order Create(Order order)
		{
			return BaseCreate(order);
		}

		/// <summary>
		/// Deletes a order
		/// </summary>
		/// <param name="orderNumber">The ordernumber to delete</param>
		public void Delete(string orderNumber)
		{
			BaseDelete(orderNumber);
		}

		/// <summary>
		/// Gets a list of orders
		/// </summary>
		/// <returns>A list of orders</returns>
		public EntityCollection<OrderSubset> Find()
		{
			return BaseFind();
		}
	}
}
