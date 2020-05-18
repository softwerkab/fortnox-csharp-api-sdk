using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IPrintTemplateConnector : IConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.PrintTemplate? SortBy { get; set; }
		Filter.PrintTemplate? FilterBy { get; set; }

		EntityCollection<PrintTemplate> Find();

		Task<EntityCollection<PrintTemplate>> FindAsync();
	}
}
