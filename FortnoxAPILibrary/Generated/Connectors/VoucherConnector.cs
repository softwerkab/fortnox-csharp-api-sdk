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
		public Voucher Get(string id)
		{
			return BaseGet(id);
		}

		/// <summary>
		/// Updates a voucher
		/// </summary>
		/// <param name="voucher">The voucher to update</param>
		/// <returns>The updated voucher</returns>
		public Voucher Update(Voucher voucher)
		{
			return BaseUpdate(voucher, voucher.Id.ToString());
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
		public void Delete(string id)
		{
			BaseDelete(id);
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
