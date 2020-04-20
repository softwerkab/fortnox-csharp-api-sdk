using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface INoxFinansInvoiceConnector
	{
        [SearchParameter("filter")]
		Filter.NoxFinansInvoice? FilterBy { get; set; }

        EntityCollection<NoxFinansInvoiceSubset> Find();

	}
}
