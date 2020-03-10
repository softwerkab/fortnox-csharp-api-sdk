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
		/// Find a voucherFileConnection based on id
		/// </summary>
		/// <param name="id">Identifier of the voucherFileConnection to find</param>
		/// <returns>The found voucherFileConnection</returns>
		public VoucherFileConnection Get(string id)
		{
			return BaseGet(id.ToString());
		}
		
		/// <summary>
		/// Creates a new voucherFileConnection
		/// </summary>
		/// <param name="voucherFileConnection">The voucherFileConnection to create</param>
		/// <returns>The created voucherFileConnection</returns>
		public VoucherFileConnection Create(VoucherFileConnection voucherFileConnection)
		{
			return BaseCreate(voucherFileConnection);
		}

		/// <summary>
		/// Deletes a voucherFileConnection
		/// </summary>
		/// <param name="id">Identifier of the voucherFileConnection to delete</param>
		public void Delete(string id)
		{
			BaseDelete(id.ToString());
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
