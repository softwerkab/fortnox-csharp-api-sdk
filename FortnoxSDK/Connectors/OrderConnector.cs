using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;
using Fortnox.SDK.Utility;

// ReSharper disable UnusedMember.Global

namespace Fortnox.SDK.Connectors;

/// <remarks/>
internal class OrderConnector : SearchableEntityConnector<Order, OrderSubset, OrderSearch>, IOrderConnector
{


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
        return GetAsync(id).GetResult();
    }

    /// <summary>
    /// Updates a order
    /// </summary>
    /// <param name="order">The order to update</param>
    /// <returns>The updated order</returns>
    public Order Update(Order order)
    {
        return UpdateAsync(order).GetResult();
    }

    /// <summary>
    /// Creates a new order
    /// </summary>
    /// <param name="order">The order to create</param>
    /// <returns>The created order</returns>
    public Order Create(Order order)
    {
        return CreateAsync(order).GetResult();
    }

    /// <summary>
    /// Gets a list of orders
    /// </summary>
    /// <returns>A list of orders</returns>
    public EntityCollection<OrderSubset> Find(OrderSearch searchSettings)
    {
        return FindAsync(searchSettings).GetResult();
    }

    /// <summary>
    /// Creates an invoice from the order
    /// <param name="id"></param>
    /// <returns></returns>
    /// </summary>
    public Order CreateInvoice(long? id)
    {
        return CreateInvoiceAsync(id).GetResult();
    }

    /// <summary>
    /// Cancels an order
    /// <param name="id"></param>
    /// <returns></returns>
    /// </summary>
    public Order Cancel(long? id)
    {
        return CancelAsync(id).GetResult();
    }

    /// <summary>
    /// Sends an e-mail to the customer with an attached PDF document of the invoice. You can use the field EmailInformation to customize the e-mail message on each invoice.
    /// <param name="id"></param>
    /// <returns></returns>
    /// </summary>
    public Order Email(long? id)
    {
        return EmailAsync(id).GetResult();
    }

    /// <summary>
    /// This action returns a PDF document with the current template that is used by the specific document. Note that this action also sets the field Sent as true.
    /// <param name="id"></param>
    /// <returns></returns>
    /// </summary>
    public byte[] Print(long? id)
    {
        return PrintAsync(id).GetResult();
    }

    /// <summary>
    /// This action is used to set the field Sent as true from an external system without generating a PDF.
    /// <param name="id"></param>
    /// <returns></returns>
    /// </summary>
    public Order ExternalPrint(long? id)
    {
        return ExternalPrintAsync(id).GetResult();
    }

    /// <summary>
    /// This action returns a PDF document with the current template that is used by the specific document. Apart from the action print, this action doesn’t set the field Sent as true.
    /// <param name="id"></param>
    /// <returns></returns>
    /// </summary>
    public byte[] Preview(long? id)
    {
        return PreviewAsync(id).GetResult();
    }

    public async Task<EntityCollection<OrderSubset>> FindAsync(OrderSearch searchSettings)
    {
        return await BaseFind(searchSettings).ConfigureAwait(false);
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

    public async Task<Order> CreateInvoiceAsync(long? id)
    {
        return await DoActionAsync(id.ToString(), Action.CreateInvoice).ConfigureAwait(false);
    }

    public async Task<Order> CancelAsync(long? id)
    {
        return await DoActionAsync(id.ToString(), Action.Cancel).ConfigureAwait(false);
    }

    public async Task<Order> EmailAsync(long? id)
    {
        return await DoActionAsync(id.ToString(), Action.Email).ConfigureAwait(false);
    }

    public async Task<byte[]> PrintAsync(long? id)
    {
        return await DoDownloadActionAsync(id.ToString(), Action.Print).ConfigureAwait(false);
    }

    public async Task<Order> ExternalPrintAsync(long? id)
    {
        return await DoActionAsync(id.ToString(), Action.ExternalPrint).ConfigureAwait(false);
    }

    public async Task<byte[]> PreviewAsync(long? id)
    {
        return await DoDownloadActionAsync(id.ToString(), Action.Preview).ConfigureAwait(false);
    }
}