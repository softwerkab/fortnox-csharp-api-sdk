using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class VoucherSeriesConnector : SearchableEntityConnector<VoucherSeries, VoucherSeriesSubset, VoucherSeriesSearch>, IVoucherSeriesConnector
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
		public VoucherSeries Get(string id)
		{
			return GetAsync(id).Result;
		}

		/// <summary>
		/// Updates a voucherSeries
		/// </summary>
		/// <param name="voucherSeries">The voucherSeries to update</param>
		/// <returns>The updated voucherSeries</returns>
		public VoucherSeries Update(VoucherSeries voucherSeries)
		{
			return UpdateAsync(voucherSeries).Result;
		}

		/// <summary>
		/// Creates a new voucherSeries
		/// </summary>
		/// <param name="voucherSeries">The voucherSeries to create</param>
		/// <returns>The created voucherSeries</returns>
		public VoucherSeries Create(VoucherSeries voucherSeries)
		{
			return CreateAsync(voucherSeries).Result;
		}

        /// <summary>
		/// Gets a list of voucherSeriess
		/// </summary>
		/// <returns>A list of voucherSeriess</returns>
		public EntityCollection<VoucherSeriesSubset> Find()
		{
			return FindAsync().Result;
		}

		public async Task<EntityCollection<VoucherSeriesSubset>> FindAsync()
		{
			return await BaseFind().ConfigureAwait(false);
		}
		public async Task<VoucherSeries> CreateAsync(VoucherSeries voucherSeries)
		{
			return await BaseCreate(voucherSeries).ConfigureAwait(false);
		}
		public async Task<VoucherSeries> UpdateAsync(VoucherSeries voucherSeries)
		{
			return await BaseUpdate(voucherSeries, voucherSeries.Code).ConfigureAwait(false);
		}
		public async Task<VoucherSeries> GetAsync(string id)
		{
			return await BaseGet(id).ConfigureAwait(false);
		}
	}
}
