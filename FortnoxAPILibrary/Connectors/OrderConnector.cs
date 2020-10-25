using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class OrderConnector : EntityConnector<Order, EntityCollection<OrderSubset>>, IOrderConnector
	{
		public OrderSearch Search { get; set; } = new OrderSearch();


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
		public Order Get(long? id)
		{
			return GetAsync(id).Result;
		}

		/// <summary>
		/// Updates a order
		/// </summary>
		/// <param name="order">The order to update</param>
		/// <returns>The updated order</returns>
		public Order Update(Order order)
		{
			return UpdateAsync(order).Result;
		}

		/// <summary>
		/// Creates a new order
		/// </summary>
		/// <param name="order">The order to create</param>
		/// <returns>The created order</returns>
		public Order Create(Order order)
		{
			return CreateAsync(order).Result;
		}

		/// <summary>
		/// Gets a list of orders
		/// </summary>
		/// <returns>A list of orders</returns>
		public EntityCollection<OrderSubset> Find()
		{
			return FindAsync().Result;
		}
		
		/// <summary>
		/// Creates an invoice from the order
		/// <param name="id"></param>
		/// <returns></returns>
		/// </summary>
		public Order CreateInvoice(long? id)
		{
			return DoAction(id.ToString(), Action.CreateInvoice);
		}
		
		/// <summary>
		/// Cancels an order
		/// <param name="id"></param>
		/// <returns></returns>
		/// </summary>
		public Order Cancel(long? id)
		{
			return DoAction(id.ToString(), Action.Cancel);
		}
		
		/// <summary>
		/// Sends an e-mail to the customer with an attached PDF document of the invoice. You can use the field EmailInformation to customize the e-mail message on each invoice.
		/// <param name="id"></param>
		/// <returns></returns>
		/// </summary>
		public Order Email(long? id)
		{
			return DoAction(id.ToString(), Action.Email);
		}
		
		/// <summary>
		/// This action returns a PDF document with the current template that is used by the specific document. Note that this action also sets the field Sent as true.
		/// <param name="id"></param>
		/// <returns></returns>
		/// </summary>
		public byte[] Print(long? id)
		{
			return DoDownloadAction(id.ToString(), Action.Print);
		}
		
		/// <summary>
		/// This action is used to set the field Sent as true from an external system without generating a PDF.
		/// <param name="id"></param>
		/// <returns></returns>
		/// </summary>
		public Order ExternalPrint(long? id)
		{
			return DoAction(id.ToString(), Action.ExternalPrint);
		}
		
		/// <summary>
		/// This action returns a PDF document with the current template that is used by the specific document. Apart from the action print, this action doesn’t set the field Sent as true.
		/// <param name="id"></param>
		/// <returns></returns>
		/// </summary>
		public byte[] Preview(long? id)
		{
			return DoDownloadAction(id.ToString(), Action.Preview);
		}

		public async Task<EntityCollection<OrderSubset>> FindAsync()
		{
			return await BaseFind().ConfigureAwait(false);
		}
		public async Task<Order> CreateAsync(Order order)
		{
			return await BaseCreate(order).ConfigureAwait(false);
		}
		public async Task<Order> UpdateAsync(Order order)
		{
			return await BaseUpdate(order, order.DocumentNumber.ToString()).ConfigureAwait(false);
		}
		public async Task<Order> GetAsync(long? id)
		{
			return await BaseGet(id.ToString()).ConfigureAwait(false);
		}
	}
}
