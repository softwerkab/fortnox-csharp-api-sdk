using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Requests;
using Fortnox.SDK.Utility;

namespace Fortnox.SDK.Connectors;

internal class InvoiceFileConnectionConnector : EntityConnector<InvoiceFileConnection>, IInvoiceFileConnectionConnector
{
    public InvoiceFileConnectionConnector()
    {
        Endpoint = Endpoints.InvoiceFileConnections;
    }

    public IList<InvoiceFileConnection> GetConnections(long? entityId, EntityType? entityType)
    {
        return GetConnectionsAsync(entityId, entityType).GetResult();
    }

    public InvoiceFileConnection Update(InvoiceFileConnection invoiceFileConnection)
    {
        return UpdateAsync(invoiceFileConnection).GetResult();
    }

    public InvoiceFileConnection Create(InvoiceFileConnection invoiceFileConnection)
    {
        return CreateAsync(invoiceFileConnection).GetResult();
    }

    public void Delete(string id)
    {
        DeleteAsync(id).GetResult();
    }

    public async Task DeleteAsync(string id)
    {
        var request = new BaseRequest
        {
            Endpoint = Endpoint,
            Indices = new List<string>() { id },
            Method = HttpMethod.Delete,
        };

        await SendAsync(request).ConfigureAwait(false);
    }

    public async Task<InvoiceFileConnection> CreateAsync(InvoiceFileConnection invoiceFileConnection)
    {
        var request = new EntityRequest<List<InvoiceFileConnection>>()
        {
            Endpoint = Endpoint,
            Method = HttpMethod.Post,
            Entity = new List<InvoiceFileConnection>() { invoiceFileConnection },
            UseEntityWrapper = false
        };

        var result = await SendAsync(request).ConfigureAwait(false);
        return result?.FirstOrDefault();
    }

    public async Task<InvoiceFileConnection> UpdateAsync(InvoiceFileConnection invoiceFileConnection)
    {
        var request = new EntityRequest<InvoiceFileConnection>()
        {
            Endpoint = Endpoint,
            Indices = new List<string> { invoiceFileConnection.Id },
            Method = HttpMethod.Put,
            Entity = new InvoiceFileConnection()
            {
                IncludeOnSend = invoiceFileConnection.IncludeOnSend
            },
            UseEntityWrapper = false
        };

        var result = await SendAsync(request).ConfigureAwait(false);
        return result;
    }

    public async Task<IList<InvoiceFileConnection>> GetConnectionsAsync(long? entityId, EntityType? entityType)
    {
        var request = new EntityRequest<List<InvoiceFileConnection>>()
        {
            Endpoint = Endpoint,
            Parameters = new Dictionary<string, string>
            {
                { "entityid", entityId?.ToString() },
                { "entitytype", entityType?.GetStringValue() }
            },
            Method = HttpMethod.Get,
            UseEntityWrapper = false
        };

        var result = await SendAsync(request).ConfigureAwait(false);
        return result;
    }
}