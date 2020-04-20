using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IVoucherFileConnectionConnector : IConnector
	{
        [SearchParameter("filter")]
		Filter.VoucherFileConnection? FilterBy { get; set; }


        [SearchParameter]
		string VoucherDescription { get; set; }

        [SearchParameter]
		string VoucherNumber { get; set; }

        [SearchParameter]
		string VoucherSeries { get; set; }

        VoucherFileConnection Create(VoucherFileConnection voucherFileConnection);

		VoucherFileConnection Get(string id);

		void Delete(string id);

		EntityCollection<VoucherFileConnection> Find();

	}
}
