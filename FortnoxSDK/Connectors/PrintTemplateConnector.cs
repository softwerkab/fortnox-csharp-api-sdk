using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;
using Fortnox.SDK.Utility;

namespace Fortnox.SDK.Connectors;

internal class PrintTemplateConnector : SearchableEntityConnector<PrintTemplate, PrintTemplate, PrintTemplateSearch>, IPrintTemplateConnector
{
    public PrintTemplateConnector()
    {
        Endpoint = Endpoints.PrintTemplates;
    }

    public EntityCollection<PrintTemplate> Find(PrintTemplateSearch searchSettings)
    {
        return FindAsync(searchSettings).GetResult();
    }

    public async Task<EntityCollection<PrintTemplate>> FindAsync(PrintTemplateSearch searchSettings)
    {
        return await BaseFind(searchSettings).ConfigureAwait(false);
    }
}