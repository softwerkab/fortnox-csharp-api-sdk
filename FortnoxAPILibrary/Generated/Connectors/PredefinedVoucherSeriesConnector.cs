using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class PredefinedVoucherSeriesConnector : EntityConnector<PredefinedVoucherSeries, EntityCollection<PredefinedVoucherSeriesSubset>, Sort.By.PredefinedVoucherSeries?>
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.PredefinedVoucherSeries? FilterBy { get; set; }


		/// <remarks/>
		public PredefinedVoucherSeriesConnector()
		{
			Resource = "predefinedvoucherseries";
		}

		/// <summary>
		/// Find a predefinedVoucherSeries based on id
		/// </summary>
		/// <param name="id">Identifier of the predefinedVoucherSeries to find</param>
		/// <returns>The found predefinedVoucherSeries</returns>
		public PredefinedVoucherSeries Get(string id)
		{
			return BaseGet(id);
		}

		/// <summary>
		/// Updates a predefinedVoucherSeries
		/// </summary>
		/// <param name="predefinedVoucherSeries">The predefinedVoucherSeries to update</param>
		/// <returns>The updated predefinedVoucherSeries</returns>
		public PredefinedVoucherSeries Update(PredefinedVoucherSeries predefinedVoucherSeries)
		{
			return BaseUpdate(predefinedVoucherSeries, predefinedVoucherSeries.Name.ToString());
		}

		/// <summary>
		/// Creates a new predefinedVoucherSeries
		/// </summary>
		/// <param name="predefinedVoucherSeries">The predefinedVoucherSeries to create</param>
		/// <returns>The created predefinedVoucherSeries</returns>
		public PredefinedVoucherSeries Create(PredefinedVoucherSeries predefinedVoucherSeries)
		{
			return BaseCreate(predefinedVoucherSeries);
		}

		/// <summary>
		/// Deletes a predefinedVoucherSeries
		/// </summary>
		/// <param name="id">Identifier of the predefinedVoucherSeries to delete</param>
		public void Delete(string id)
		{
			BaseDelete(id);
		}

		/// <summary>
		/// Gets a list of predefinedVoucherSeriess
		/// </summary>
		/// <returns>A list of predefinedVoucherSeriess</returns>
		public EntityCollection<PredefinedVoucherSeriesSubset> Find()
		{
			return BaseFind();
		}
	}
}
