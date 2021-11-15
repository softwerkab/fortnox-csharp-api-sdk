using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;
using Fortnox.SDK.Utility;

namespace Fortnox.SDK.Connectors;

internal class OrderConnector : SearchableEntityConnector<Order, OrderSubset, OrderSearch>, IOrderConnector
{
    public OrderConnector()
    {
        Resource = Endpoints.Orders;
    }

    public Order Get(long? id)
    {
        return GetAsync(id).GetResult();
    }

    public Order Update(Order order)
    {
        return UpdateAsync(order).GetResult();
    }

    public Order Create(Order order)
    {
        return CreateAsync(order).GetResult();
    }

    public EntityCollection<OrderSubset> Find(OrderSearch searchSettings)
    {
        return FindAsync(searchSettings).GetResult();
    }

    public Order CreateInvoice(long? id)
    {
        return CreateInvoiceAsync(id).GetResult();
    }

    public Order Cancel(long? id)
    {
        return CancelAsync(id).GetResult();
    }

    public Order Email(long? id)
    {
        return EmailAsync(id).GetResult();
    }

    public byte[] Print(long? id)
    {
        return PrintAsync(id).GetResult();
    }

    public Order ExternalPrint(long? id)
    {
        return ExternalPrintAsync(id).GetResult();
    }

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