using System;
using System.Collections.Generic;
using System.Linq;
using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;
using System.Web;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
	/// <remarks/>
    public class InvoiceFileConnectionConnector : EntityConnector<InvoiceFileConnection, EntityCollection<InvoiceFileConnectionSubset>, Sort.By.InvoiceFileConnection?>, IInvoiceFileConnectionConnector
    {
        public override string BaseUrl => base.BaseUrl.Replace("3", "api");

		/// <summary>
		/// Use with Find() to limit the search result
		/// </summary>
		[SearchParameter("filter")]
		public Filter.InvoiceFileConnection? FilterBy { get; set; }


		/// <remarks/>
		public InvoiceFileConnectionConnector()
		{
			Resource = "fileattachments/attachments-v1";
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
			await BaseDelete(id);
		}
		public async Task<InvoiceFileConnection> CreateAsync(InvoiceFileConnection invoiceFileConnection)
        {
            Parameters = new Dictionary<string, string>();
            var requestUriString = GetUrl();
            requestUriString = AddParameters(requestUriString);

            Method = RequestMethod.Post;
            ResponseType = RequestResponseType.JSON;
            RequestUriString = requestUriString;

            var entity = new List<InvoiceFileConnection>() { invoiceFileConnection };
            var result = await DoRequest(entity);
            return result?.FirstOrDefault();
        }

        public async Task<InvoiceFileConnection> UpdateAsync(InvoiceFileConnection invoiceFileConnection)
        {
            Parameters = new Dictionary<string, string>();
            var indices = new [] { invoiceFileConnection.Id };
            var searchValue = string.Join("/", indices.Select(HttpUtility.UrlEncode));
            var requestUriString = GetUrl(searchValue);
            requestUriString = AddParameters(requestUriString);

            Method = RequestMethod.Put;
            ResponseType = RequestResponseType.JSON;
            RequestUriString = requestUriString;

            var limitedEntity = new InvoiceFileConnection()
            {
                IncludeOnSend = invoiceFileConnection.IncludeOnSend
            };

            var result = await DoRequest(limitedEntity);
            return result;
        }

        public async Task<List<InvoiceFileConnection>> GetConnectionsAsync(long? entityId, EntityType? entityType)
        {
            Parameters = new Dictionary<string, string>
            {
                {"entityid", entityId?.ToString()}, 
                {"entitytype", entityType?.GetStringValue()}
            };
            var indices = Array.Empty<string>();
            var searchValue = string.Join("/", indices.Select(HttpUtility.UrlEncode));
            var requestUriString = GetUrl(searchValue);
            requestUriString = AddParameters(requestUriString);

            Method = RequestMethod.Get;
            ResponseType = RequestResponseType.JSON;
            RequestUriString = requestUriString;

            var result = await DoRequest<List<InvoiceFileConnection>>();
            return result;
        }
    }
}
