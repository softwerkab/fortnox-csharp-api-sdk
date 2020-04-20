using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IPrintTemplateConnector : IConnector
	{
        [SearchParameter("filter")]
		Filter.PrintTemplate? FilterBy { get; set; }
		EntityCollection<PrintTemplate> Find();

	}
}
