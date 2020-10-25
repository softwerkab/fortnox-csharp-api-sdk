using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
	/// <remarks/>
	public class VoucherFileConnectionConnector : EntityConnector<VoucherFileConnection, EntityCollection<VoucherFileConnection>, Sort.By.VoucherFileConnection?>, IVoucherFileConnectionConnector
	{
		public VoucherFileConnectionSearch Search { get; set; } = new VoucherFileConnectionSearch();


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
			return GetAsync(id).Result;
		}
		
		/// <summary>
		/// Creates a new voucherFileConnection
		/// </summary>
		/// <param name="voucherFileConnection">The voucherFileConnection to create</param>
		/// <returns>The created voucherFileConnection</returns>
		public VoucherFileConnection Create(VoucherFileConnection voucherFileConnection)
		{
			return CreateAsync(voucherFileConnection).Result;
		}

		/// <summary>
		/// Deletes a voucherFileConnection
		/// </summary>
		/// <param name="id">Identifier of the voucherFileConnection to delete</param>
		public void Delete(string id)
		{
			DeleteAsync(id).Wait();
		}

		/// <summary>
		/// Gets a list of voucherFileConnections
		/// </summary>
		/// <returns>A list of voucherFileConnections</returns>
		public EntityCollection<VoucherFileConnection> Find()
		{
			return FindAsync().Result;
		}

		public async Task<EntityCollection<VoucherFileConnection>> FindAsync()
		{
			return await BaseFind().ConfigureAwait(false);
		}
		public async Task DeleteAsync(string id)
		{
			await BaseDelete(id).ConfigureAwait(false);
		}
		public async Task<VoucherFileConnection> CreateAsync(VoucherFileConnection voucherFileConnection)
		{
			return await BaseCreate(voucherFileConnection).ConfigureAwait(false);
		}
		public async Task<VoucherFileConnection> GetAsync(string id)
		{
			return await BaseGet(id).ConfigureAwait(false);
		}
	}
}
