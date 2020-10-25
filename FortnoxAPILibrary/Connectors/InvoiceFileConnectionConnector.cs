using System;
using System.Collections.Generic;
using System.Linq;
using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;
using System.Net.Http;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
	/// <remarks/>
    public class InvoiceFileConnectionConnector : EntityConnector<InvoiceFileConnection, EntityCollection<InvoiceFileConnectionSubset>>, IInvoiceFileConnectionConnector
    {
		public InvoiceFileConnectionSearch Search { get; set; } = new InvoiceFileConnectionSearch();

        /// <remarks/>
		public InvoiceFileConnectionConnector()
		{
			Resource = "fileattachments/attachments-v1";
            BaseUrl = BaseUrl.Replace("3", "api");
        }

        public List<InvoiceFileConnection> GetConnections(long? entityId, EntityType? entityType)
        {
            return GetConnectionsAsync(entityId, entityType).Result;
        }

        /// <summary>
		/// Updates a invoiceFileConnection
		/// </summary>
		/// <param name="invoiceFileConnection">The invoiceFileConnection to update</param>
		/// <returns>The updated invoiceFileConnection</returns>
		public InvoiceFileConnection Update(InvoiceFileConnection invoiceFileConnection)
		{
			return UpdateAsync(invoiceFileConnection).Result;
		}

		/// <summary>
		/// Creates a new invoiceFileConnection
		/// </summary>
		/// <param name="invoiceFileConnection">The invoiceFileConnection to create</param>
		/// <returns>The created invoiceFileConnection</returns>
		public InvoiceFileConnection Create(InvoiceFileConnection invoiceFileConnection)
		{
			return CreateAsync(invoiceFileConnection).Result;
		}

		/// <summary>
		/// Deletes a invoiceFileConnection
		/// </summary>
		/// <param name="id">Identifier of the invoiceFileConnection to delete</param>
		public void Delete(string id)
		{
			DeleteAsync(id).Wait();
		}

		public async Task DeleteAsync(string id)
		{
			await BaseDelete(id).ConfigureAwait(false);
		}
		public async Task<InvoiceFileConnection> CreateAsync(InvoiceFileConnection invoiceFileConnection)
        {
            RequestInfo = new RequestInfo()
            {
                BaseUrl = BaseUrl,
                Resource = Resource,
                Indices = Array.Empty<string>(),
                Method = HttpMethod.Post,
            };

            var entity = new List<InvoiceFileConnection>() { invoiceFileConnection };
            var result = await DoEntityRequest(entity).ConfigureAwait(false);
            return result?.FirstOrDefault();
        }

        public async Task<InvoiceFileConnection> UpdateAsync(InvoiceFileConnection invoiceFileConnection)
        {
            RequestInfo = new RequestInfo()
            {
                BaseUrl = BaseUrl,
                Resource = Resource,
                Indices = new[] {invoiceFileConnection.Id},
                Method = HttpMethod.Put,
            };

            var limitedEntity = new InvoiceFileConnection()
            {
                IncludeOnSend = invoiceFileConnection.IncludeOnSend
            };

            var result = await DoEntityRequest(limitedEntity).ConfigureAwait(false);
            return result;
        }

        public async Task<List<InvoiceFileConnection>> GetConnectionsAsync(long? entityId, EntityType? entityType)
        {
            RequestInfo = new RequestInfo()
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

            var result = await DoEntityRequest<List<InvoiceFileConnection>>().ConfigureAwait(false);
            return result;
        }
    }
}
