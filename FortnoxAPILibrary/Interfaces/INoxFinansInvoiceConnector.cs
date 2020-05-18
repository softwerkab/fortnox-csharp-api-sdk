using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface INoxFinansInvoiceConnector : IConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.NoxFinansInvoice? SortBy { get; set; }
		Filter.NoxFinansInvoice? FilterBy { get; set; }

        EntityCollection<NoxFinansInvoiceSubset> Find();

        Task<EntityCollection<NoxFinansInvoiceSubset>> FindAsync();
	}
}
