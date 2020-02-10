using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class VoucherSeriesConnector : EntityConnector<VoucherSeries, EntityCollection<VoucherSeriesSubset>, Sort.By.VoucherSeries?>
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.VoucherSeries? FilterBy { get; set; }


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
		public VoucherSeries Get(string id)
		{
			return BaseGet(id);
		}

		/// <summary>
		/// Updates a voucherSeries
		/// </summary>
		/// <param name="voucherSeries">The voucherSeries to update</param>
		/// <returns>The updated voucherSeries</returns>
		public VoucherSeries Update(VoucherSeries voucherSeries)
		{
			return BaseUpdate(voucherSeries, voucherSeries.Code.ToString());
		}

		/// <summary>
		/// Creates a new voucherSeries
		/// </summary>
		/// <param name="voucherSeries">The voucherSeries to create</param>
		/// <returns>The created voucherSeries</returns>
		public VoucherSeries Create(VoucherSeries voucherSeries)
		{
			return BaseCreate(voucherSeries);
		}

		/// <summary>
		/// Deletes a voucherSeries
		/// </summary>
		/// <param name="id">Identifier of the voucherSeries to delete</param>
		public void Delete(string id)
		{
			BaseDelete(id);
		}

		/// <summary>
		/// Gets a list of voucherSeriess
		/// </summary>
		/// <returns>A list of voucherSeriess</returns>
		public EntityCollection<VoucherSeriesSubset> Find()
		{
			return BaseFind();
		}
	}
}
