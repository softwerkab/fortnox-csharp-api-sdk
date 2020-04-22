using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;
// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IVoucherFileConnectionConnector : IConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.VoucherFileConnection? SortBy { get; set; }
		Filter.VoucherFileConnection? FilterBy { get; set; }

		string VoucherDescription { get; set; }
		string VoucherNumber { get; set; }
		string VoucherSeries { get; set; }

        VoucherFileConnection Create(VoucherFileConnection voucherFileConnection);
		VoucherFileConnection Get(string id);
		void Delete(string id);
		EntityCollection<VoucherFileConnection> Find();
	}
}
