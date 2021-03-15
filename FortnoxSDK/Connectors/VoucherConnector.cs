using System.Collections.Generic;
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
    public class VoucherConnector : SearchableEntityConnector<Voucher, VoucherSubset, VoucherSearch>, IVoucherConnector
	{

		/// <remarks/>
		public VoucherConnector()
		{
			Resource = "vouchers";
		}

        /// <summary>
        /// Find a voucher based on id
        /// </summary>
        /// <param name="id">Identifier of the voucher to find</param>
        /// <param name="seriesId">Idendifier of the voucher series</param>
        /// <param name="financialYearId">Identifier of the financial year</param>
        /// <returns>The found voucher</returns>
        public Voucher Get(long? id, string seriesId, long? financialYearId)
		{
			return GetAsync(id, seriesId, financialYearId).GetResult();
        }

		/// <summary>
		/// Creates a new voucher
		/// </summary>
		/// <param name="voucher">The voucher to create</param>
		/// <returns>The created voucher</returns>
		public Voucher Create(Voucher voucher)
		{
			return CreateAsync(voucher).GetResult();
		}

		/// <summary>
		/// Gets a list of vouchers
		/// </summary>
		/// <returns>A list of vouchers</returns>
		public EntityCollection<VoucherSubset> Find(VoucherSearch searchSettings)
		{
			return FindAsync(searchSettings).GetResult();
		}

        public void Delete(long? id, string seriesId, long? financialYearId)
        {
            DeleteAsync(id, seriesId, financialYearId).GetResult();
        }

        public async Task<EntityCollection<VoucherSubset>> FindAsync(VoucherSearch searchSettings)
		{
			return await BaseFind(searchSettings).ConfigureAwait(false);
		}

        public async Task DeleteAsync(long? id, string seriesId, long? financialYearId)
        {
			var request = new BaseRequest()
            {
                Resource = Resource,
                Indices = new List<string> { seriesId, id.ToString() },
                Method = HttpMethod.Delete
            };

            if (financialYearId != null)
                request.Parameters.Add("financialyear", financialYearId.ToString());

            await SendAsync(request).ConfigureAwait(false);
		}

        public async Task<Voucher> CreateAsync(Voucher voucher)
		{
			return await BaseCreate(voucher).ConfigureAwait(false);
		}
        public async Task<Voucher> GetAsync(long? id, string seriesId, long? financialYearId)
		{
            var request = new EntityRequest<Voucher>()
            {
                Resource = Resource,
                Indices = new List<string>{ seriesId, id.ToString() },
                Method = HttpMethod.Get
            };

			if (financialYearId != null)
				request.Parameters.Add("financialyear", financialYearId.ToString());

			return await SendAsync(request).ConfigureAwait(false);
        }
    }
}
