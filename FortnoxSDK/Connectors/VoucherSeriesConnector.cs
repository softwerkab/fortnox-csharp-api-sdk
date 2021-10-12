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
    internal class VoucherSeriesConnector : SearchableEntityConnector<VoucherSeries, VoucherSeriesSubset, VoucherSeriesSearch>, IVoucherSeriesConnector
	{


		/// <remarks/>
		public VoucherSeriesConnector()
		{
			Resource = "voucherseries";
		}
		/// <summary>
		/// Find a voucherSeries based on id
		/// </summary>
		/// <param name="id">Identifier of the voucherSeries to find</param>
		/// <returns>The found voucherSeries</returns>
        public VoucherSeries Get(string id, long? financialYearId = null)
		{
			return GetAsync(id, financialYearId).GetResult();
		}

		/// <summary>
		/// Updates a voucherSeries
		/// </summary>
		/// <param name="voucherSeries">The voucherSeries to update</param>
		/// <returns>The updated voucherSeries</returns>
        public VoucherSeries Update(VoucherSeries voucherSeries, long? financialYearId = null)
		{
			return UpdateAsync(voucherSeries, financialYearId).GetResult();
		}

		/// <summary>
		/// Creates a new voucherSeries
		/// </summary>
		/// <param name="voucherSeries">The voucherSeries to create</param>
		/// <returns>The created voucherSeries</returns>
        public VoucherSeries Create(VoucherSeries voucherSeries, long? financialYearId = null)
		{
			return CreateAsync(voucherSeries, financialYearId).GetResult();
		}

        /// <summary>
		/// Gets a list of voucherSeriess
		/// </summary>
		/// <returns>A list of voucherSeriess</returns>
		public EntityCollection<VoucherSeriesSubset> Find(VoucherSeriesSearch searchSettings)
		{
			return FindAsync(searchSettings).GetResult();
		}

		public async Task<EntityCollection<VoucherSeriesSubset>> FindAsync(VoucherSeriesSearch searchSettings)
		{
			return await BaseFind(searchSettings).ConfigureAwait(false);
		}
		public async Task<VoucherSeries> CreateAsync(VoucherSeries voucherSeries, long? financialYearId = null)
		{
            var request = new EntityRequest<VoucherSeries>()
            {
                Resource = Resource,
                Method = HttpMethod.Post,
                Entity = voucherSeries,
            };

            if (financialYearId != null)
                request.Parameters.Add("financialyear", financialYearId.ToString());

			return await SendAsync(request).ConfigureAwait(false);
        }
		public async Task<VoucherSeries> UpdateAsync(VoucherSeries voucherSeries, long? financialYearId = null)
		{
            var request = new EntityRequest<VoucherSeries>()
            {
                Resource = Resource,
                Method = HttpMethod.Put,
                Entity = voucherSeries
            };

            request.Indices.Add(voucherSeries.Code);

            if (financialYearId != null)
                request.Parameters.Add("financialyear", financialYearId.ToString());

            return await SendAsync(request).ConfigureAwait(false);
        }
		public async Task<VoucherSeries> GetAsync(string id, long? financialYearId = null)
		{
            var request = new EntityRequest<VoucherSeries>()
            {
                Resource = Resource,
                Method = HttpMethod.Get,
            };

            request.Indices.Add(id);

            if (financialYearId != null)
                request.Parameters.Add("financialyear", financialYearId.ToString());

            return await SendAsync(request).ConfigureAwait(false);
        }
	}
}
