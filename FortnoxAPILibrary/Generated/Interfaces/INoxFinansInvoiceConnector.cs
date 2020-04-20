using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface INoxFinansInvoiceConnector : IConnector
	{
        [SearchParameter("filter")]
		Filter.NoxFinansInvoice? FilterBy { get; set; }

        EntityCollection<NoxFinansInvoiceSubset> Find();

	}
}
