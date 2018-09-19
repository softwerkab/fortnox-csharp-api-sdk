using System.Collections.Generic;

namespace FortnoxAPILibrary.Connectors
{
    /// <inheritdoc />
    public interface IVoucherFileConnectionConnector : IEntityConnector<Sort.By.VoucherFileConnection>
    {
        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        string VoucherDescription { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        string VoucherNumber { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        string VoucherSeries { get; set; }

        /// <summary>
        /// Get a voucher file connection based on fileId
        /// </summary>
        /// <param name="fileId">The id of the file to find.</param>
        /// <returns>The found voucher file connection</returns>
        VoucherFileConnection Get(string fileId);

        /// <summary>
        /// Creates a new connection between a file and a voucher.
        /// </summary>
        /// <param name="voucherFileConnection">The voucher file connection to create</param>
        /// <returns>The created voucher file connection</returns>
        VoucherFileConnection Create(VoucherFileConnection voucherFileConnection);

        /// <summary>
        /// Deletes a connected file from a voucher
        /// </summary>
        /// <param name="fileId"></param>
        void Delete(string fileId);

        /// <summary>
        /// Gets a list of VoucherFile Connections
        /// </summary>
        /// <returns></returns>
        VoucherFileConnections Find();
    }

    public class VoucherFileConnectionConnector : EntityConnector<VoucherFileConnection, VoucherFileConnections, Sort.By.VoucherFileConnection>, IVoucherFileConnectionConnector
    {
		/// <summary>
		/// Use with Find() to limit the search result
		/// </summary>
        [FilterProperty]
		public string VoucherDescription { get; set; }

		/// <summary>
		/// Use with Find() to limit the search result
		/// </summary>
        [FilterProperty]
		public string VoucherNumber { get; set; }

		/// <summary>
		/// Use with Find() to limit the search result
		/// </summary>
        [FilterProperty]
		public string VoucherSeries { get; set; }

		/// <remarks/>
		public VoucherFileConnectionConnector()
		{
			base.Resource = "voucherfileconnections";
		}

		/// <summary>
		/// Get a voucher file connection based on fileId
		/// </summary>
		/// <param name="fileId">The id of the file to find.</param>
		/// <returns>The found voucher file connection</returns>
		public VoucherFileConnection Get(string fileId)
		{
			return base.BaseGet(fileId);
		}

		/// <summary>
		/// Creates a new connection between a file and a voucher.
		/// </summary>
		/// <param name="voucherFileConnection">The voucher file connection to create</param>
		/// <returns>The created voucher file connection</returns>
		public VoucherFileConnection Create(VoucherFileConnection voucherFileConnection)
		{
			return base.BaseCreate(voucherFileConnection);
		}

		/// <summary>
		/// Deletes a connected file from a voucher
		/// </summary>
		/// <param name="fileId"></param>
		public void Delete(string fileId)
		{
			base.BaseDelete(fileId);
		}

		/// <summary>
		/// Gets a list of VoucherFile Connections
		/// </summary>
		/// <returns></returns>
		public VoucherFileConnections Find()
		{
			return base.BaseFind();
		}
	}
}
