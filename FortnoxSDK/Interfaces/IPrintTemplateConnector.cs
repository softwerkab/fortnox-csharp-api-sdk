using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface IPrintTemplateConnector : IEntityConnector
	{

		EntityCollection<PrintTemplate> Find(PrintTemplateSearch searchSettings);

		Task<EntityCollection<PrintTemplate>> FindAsync(PrintTemplateSearch searchSettings);
	}
}
