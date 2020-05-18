using System.Collections.Generic;
using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class VoucherConnector : EntityConnector<Voucher, EntityCollection<VoucherSubset>, Sort.By.Voucher?>, IVoucherConnector
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.Voucher? FilterBy { get; set; }

        /// <summary>
        /// <para>Use FinancialYearDate to select the financial year to use.</para>
        /// <para>If omitted the default financial year will be selected</para>
        /// </summary>
        [SearchParameter("financialyeardate")]
        public string FinancialYearDate { get; set; }

        /// <summary>
        /// <para>Use FinancialYearID to select the financial year to use.</para>
        /// <para>If omitted the default financial year will be selected</para>
        /// </summary>
        [SearchParameter("financialyear")]
        public string FinancialYearID { get; set; }

		/// <summary>
		/// Use with Find() to limit the search result
		/// </summary>
		[SearchParameter]
		public string CostCenter { get; set; }

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
        public Voucher Get(int? id, string seriesId, int? financialYearId)
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
			return await BaseFind();
		}
		public async Task<Voucher> CreateAsync(Voucher voucher)
		{
			return await BaseCreate(voucher);
		}
        public async Task<Voucher> GetAsync(int? id, string seriesId, int? financialYearId)
		{
            if (financialYearId != null)
            {
                ParametersInjection = new Dictionary<string, string>
                {
                    {"financialyear", financialYearId.ToString()}
                };
            }

            return await BaseGet(seriesId, id.ToString());
        }
    }
}
