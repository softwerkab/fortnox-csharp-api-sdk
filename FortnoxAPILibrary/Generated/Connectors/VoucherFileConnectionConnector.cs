using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class VoucherFileConnectionConnector : EntityConnector<VoucherFileConnection, EntityCollection<VoucherFileConnectionSubset>, Sort.By.VoucherFileConnection?>
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.VoucherFileConnection? FilterBy { get; set; }


        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string VoucherDescription { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string VoucherNumber { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string VoucherSeries { get; set; }

		/// <remarks/>
		public VoucherFileConnectionConnector()
		{
			Resource = "voucherfileconnections";
		}
		/// <summary>
		/// Gets a list of voucherFileConnections
		/// </summary>
		/// <returns>A list of voucherFileConnections</returns>
		public EntityCollection<VoucherFileConnectionSubset> Find()
		{
			return BaseFind();
		}
	}
}
