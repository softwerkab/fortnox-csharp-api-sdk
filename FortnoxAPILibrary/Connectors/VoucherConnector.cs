using System.Collections.Generic;
using System.Net.Http;
using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;
using FortnoxAPILibrary.Requests;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
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

		public async Task<EntityCollection<VoucherSubset>> FindAsync(VoucherSearch searchSettings)
		{
			return await BaseFind(searchSettings).ConfigureAwait(false);
		}
		public async Task<Voucher> CreateAsync(Voucher voucher)
		{
			return await BaseCreate(voucher).ConfigureAwait(false);
		}
        public async Task<Voucher> GetAsync(long? id, string seriesId, long? financialYearId)
		{
            var request = new EntityRequest<Voucher>()
            {
                BaseUrl = BaseUrl,
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
