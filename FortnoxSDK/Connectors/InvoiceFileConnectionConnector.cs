using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Requests;
using Fortnox.SDK.Utility;

// ReSharper disable UnusedMember.Global

namespace Fortnox.SDK.Connectors;

/// <remarks/>
internal class InvoiceFileConnectionConnector : EntityConnector<InvoiceFileConnection>, IInvoiceFileConnectionConnector
{

    /// <remarks/>
    public InvoiceFileConnectionConnector()
    {
        Resource = "fileattachments/attachments-v1";
    }

    public IList<InvoiceFileConnection> GetConnections(long? entityId, EntityType? entityType)
    {
        return GetConnectionsAsync(entityId, entityType).GetResult();
    }

    /// <summary>
    /// Updates a invoiceFileConnection
    /// </summary>
    /// <param name="invoiceFileConnection">The invoiceFileConnection to update</param>
    /// <returns>The updated invoiceFileConnection</returns>
    public InvoiceFileConnection Update(InvoiceFileConnection invoiceFileConnection)
    {
        return UpdateAsync(invoiceFileConnection).GetResult();
    }

    /// <summary>
    /// Creates a new invoiceFileConnection
    /// </summary>
    /// <param name="invoiceFileConnection">The invoiceFileConnection to create</param>
    /// <returns>The created invoiceFileConnection</returns>
    public InvoiceFileConnection Create(InvoiceFileConnection invoiceFileConnection)
    {
        return CreateAsync(invoiceFileConnection).GetResult();
    }

    /// <summary>
    /// Deletes a invoiceFileConnection
    /// </summary>
    /// <param name="id">Identifier of the invoiceFileConnection to delete</param>
    public void Delete(string id)
    {
        DeleteAsync(id).GetResult();
    }

    public async Task DeleteAsync(string id)
    {
        var request = new BaseRequest
        {
            Version = "api",
            Resource = Resource,
            Indices = new List<string>() { id },
            Method = HttpMethod.Delete,
        };

        await SendAsync(request).ConfigureAwait(false);
    }
    public async Task<InvoiceFileConnection> CreateAsync(InvoiceFileConnection invoiceFileConnection)
    {
        var request = new EntityRequest<List<InvoiceFileConnection>>()
        {
            Version = "api",
            Resource = Resource,
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
            Version = "api",
            Resource = Resource,
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
            Version = "api",
            Resource = Resource,
            Parameters = new Dictionary<string, string>
            {
                {"entityid", entityId?.ToString()},
                {"entitytype", entityType?.GetStringValue()}
            },
            Method = HttpMethod.Get,
            UseEntityWrapper = false
        };

        var result = await SendAsync(request).ConfigureAwait(false);
        return result;
    }
}