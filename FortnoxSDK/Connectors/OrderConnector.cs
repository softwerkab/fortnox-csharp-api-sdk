using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;

namespace Fortnox.SDK.Connectors;

internal class OrderConnector : SearchableEntityConnector<Order, OrderSubset, OrderSearch>, IOrderConnector
{
    public OrderConnector()
    {
        Endpoint = Endpoints.Orders;
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