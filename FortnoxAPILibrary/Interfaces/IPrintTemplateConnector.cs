using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IPrintTemplateConnector : IEntityConnector
	{
		PrintTemplateSearch Search { get; set; }

		EntityCollection<PrintTemplate> Find();

		Task<EntityCollection<PrintTemplate>> FindAsync();
	}
}
