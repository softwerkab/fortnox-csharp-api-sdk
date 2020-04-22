using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IPrintTemplateConnector : IConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.PrintTemplate? SortBy { get; set; }

        [SearchParameter("filter")]
		Filter.PrintTemplate? FilterBy { get; set; }
		EntityCollection<PrintTemplate> Find();

	}
}
