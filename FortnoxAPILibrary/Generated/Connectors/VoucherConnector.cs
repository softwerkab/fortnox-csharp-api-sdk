using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class VoucherConnector : EntityConnector<Voucher, EntityCollection<VoucherSubset>, Sort.By.Voucher?>
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
		/// <returns>The found voucher</returns>
		public Voucher Get(int? id)
		{
			return BaseGet(id.ToString());
		}

		/// <summary>
		/// Updates a voucher
		/// </summary>
		/// <param name="voucher">The voucher to update</param>
		/// <returns>The updated voucher</returns>
		public Voucher Update(Voucher voucher)
		{
			return BaseUpdate(voucher, voucher.VoucherNumber.ToString());
		}

		/// <summary>
		/// Creates a new voucher
		/// </summary>
		/// <param name="voucher">The voucher to create</param>
		/// <returns>The created voucher</returns>
		public Voucher Create(Voucher voucher)
		{
			return BaseCreate(voucher);
		}

		/// <summary>
		/// Deletes a voucher
		/// </summary>
		/// <param name="id">Identifier of the voucher to delete</param>
		public void Delete(int? id)
		{
			BaseDelete(id.ToString());
		}

		/// <summary>
		/// Gets a list of vouchers
		/// </summary>
		/// <returns>A list of vouchers</returns>
		public EntityCollection<VoucherSubset> Find()
		{
			return BaseFind();
		}
    }
}
