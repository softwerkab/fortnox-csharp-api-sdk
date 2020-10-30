using System.Collections.Generic;
using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class VoucherConnector : SearchableEntityConnector<Voucher, VoucherSubset>, IVoucherConnector
	{
		public VoucherSearch Search { get; set; } = new VoucherSearch();

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
			return GetAsync(id, seriesId, financialYearId).Result;
        }

		/// <summary>
		/// Creates a new voucher
		/// </summary>
		/// <param name="voucher">The voucher to create</param>
		/// <returns>The created voucher</returns>
		public Voucher Create(Voucher voucher)
		{
			return CreateAsync(voucher).Result;
		}

		/// <summary>
		/// Gets a list of vouchers
		/// </summary>
		/// <returns>A list of vouchers</returns>
		public EntityCollection<VoucherSubset> Find()
		{
			return FindAsync().Result;
		}

		public async Task<EntityCollection<VoucherSubset>> FindAsync()
		{
			return await BaseFind().ConfigureAwait(false);
		}
		public async Task<Voucher> CreateAsync(Voucher voucher)
		{
			return await BaseCreate(voucher).ConfigureAwait(false);
		}
        public async Task<Voucher> GetAsync(long? id, string seriesId, long? financialYearId)
		{
            if (financialYearId != null)
            {
                ParametersInjection = new Dictionary<string, string>
                {
                    {"financialyear", financialYearId.ToString()}
                };
            }

            return await BaseGet(seriesId, id.ToString()).ConfigureAwait(false);
        }
    }
}
