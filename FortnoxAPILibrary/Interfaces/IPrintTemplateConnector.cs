using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IPrintTemplateConnector : IEntityConnector
	{

		EntityCollection<PrintTemplate> Find(PrintTemplateSearch searchSettings);

		Task<EntityCollection<PrintTemplate>> FindAsync(PrintTemplateSearch searchSettings);
	}
}
