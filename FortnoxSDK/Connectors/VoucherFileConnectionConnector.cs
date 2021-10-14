using System.Net.Http;
using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Requests;
using Fortnox.SDK.Search;
using Fortnox.SDK.Utility;

// ReSharper disable UnusedMember.Global

namespace Fortnox.SDK.Connectors
{
    /// <remarks/>
    internal class VoucherFileConnectionConnector : SearchableEntityConnector<VoucherFileConnection, VoucherFileConnection, VoucherFileConnectionSearch>, IVoucherFileConnectionConnector
    {
        /// <remarks/>
		public VoucherFileConnectionConnector()
        {
            Resource = "voucherfileconnections";
        }

        /// <summary>
        /// Find a voucherFileConnection based on id
        /// </summary>
        /// <param name="id">Identifier of the voucherFileConnection to find</param>
        /// <returns>The found voucherFileConnection</returns>
        public VoucherFileConnection Get(string id)
        {
            return GetAsync(id).GetResult();
        }

        /// <summary>
        /// Creates a new voucherFileConnection
        /// </summary>
        /// <param name="voucherFileConnection">The voucherFileConnection to create</param>
        /// <param name="financialYearId">Financial year of the voucher</param>
        /// <returns>The created voucherFileConnection</returns>
        public VoucherFileConnection Create(VoucherFileConnection voucherFileConnection, long? financialYearId = null)
        {
            return CreateAsync(voucherFileConnection, financialYearId).GetResult();
        }

        /// <summary>
        /// Deletes a voucherFileConnection
        /// </summary>
        /// <param name="id">Identifier of the voucherFileConnection to delete</param>
        public void Delete(string id)
        {
            DeleteAsync(id).GetResult();
        }

        /// <summary>
        /// Gets a list of voucherFileConnections
        /// </summary>
        /// <returns>A list of voucherFileConnections</returns>
        public EntityCollection<VoucherFileConnection> Find(VoucherFileConnectionSearch searchSettings)
        {
            return FindAsync(searchSettings).GetResult();
        }

        public async Task<EntityCollection<VoucherFileConnection>> FindAsync(VoucherFileConnectionSearch searchSettings)
        {
            return await BaseFind(searchSettings).ConfigureAwait(false);
        }
        public async Task DeleteAsync(string id)
        {
            await BaseDelete(id).ConfigureAwait(false);
        }
        public async Task<VoucherFileConnection> CreateAsync(VoucherFileConnection voucherFileConnection, long? financialYearId = null)
        {
            var request = new EntityRequest<VoucherFileConnection>()
            {
                Resource = Resource,
                Method = HttpMethod.Post,
                Entity = voucherFileConnection
            };

            if (financialYearId != null)
                request.Parameters.Add("financialyear", financialYearId.ToString());

            return await SendAsync(request).ConfigureAwait(false);
        }
        public async Task<VoucherFileConnection> GetAsync(string id)
        {
            return await BaseGet(id).ConfigureAwait(false);
        }
    }
}
