using System;
using System.Collections.Generic;
using System.Linq;
using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;
using System.Net.Http;
using FortnoxAPILibrary.Requests;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
	/// <remarks/>
    public class InvoiceFileConnectionConnector : EntityConnector<InvoiceFileConnection>, IInvoiceFileConnectionConnector
    {

        /// <remarks/>
		public InvoiceFileConnectionConnector()
		{
			Resource = "fileattachments/attachments-v1";
            BaseUrl = BaseUrl.Replace("3", "api");
        }

        public List<InvoiceFileConnection> GetConnections(long? entityId, EntityType? entityType)
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
			await BaseDelete(id).ConfigureAwait(false);
		}
		public async Task<InvoiceFileConnection> CreateAsync(InvoiceFileConnection invoiceFileConnection)
        {
            var request = new EntityRequest<List<InvoiceFileConnection>>()
            {
                BaseUrl = BaseUrl,
                Resource = Resource,
                Indices = Array.Empty<string>(),
                Method = HttpMethod.Post,
                Entity = new List<InvoiceFileConnection>() { invoiceFileConnection }
            };

            var result = await SendAsync(request).ConfigureAwait(false);
            return result?.FirstOrDefault();
        }

        public async Task<InvoiceFileConnection> UpdateAsync(InvoiceFileConnection invoiceFileConnection)
        {
            var request = new EntityRequest<InvoiceFileConnection>()
            {
                BaseUrl = BaseUrl,
                Resource = Resource,
                Indices = new[] {invoiceFileConnection.Id},
                Method = HttpMethod.Put,
                Entity = new InvoiceFileConnection()
                {
                    IncludeOnSend = invoiceFileConnection.IncludeOnSend
                }
            };

            var result = await SendAsync(request).ConfigureAwait(false);
            return result;
        }

        public async Task<List<InvoiceFileConnection>> GetConnectionsAsync(long? entityId, EntityType? entityType)
        {
            var request = new EntityRequest<List<InvoiceFileConnection>>()
            {
                BaseUrl = BaseUrl,
                Resource = Resource,
                Parameters = new Dictionary<string, string>
                {
                    {"entityid", entityId?.ToString()},
                    {"entitytype", entityType?.GetStringValue()}
                },
                Method = HttpMethod.Get,
            };

            var result = await SendAsync(request).ConfigureAwait(false);
            return result;
        }
    }
}
