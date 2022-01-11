using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;

namespace Fortnox.SDK.Connectors;

internal class PrintTemplateConnector : SearchableEntityConnector<PrintTemplate, PrintTemplate, PrintTemplateSearch>, IPrintTemplateConnector
{
    public PrintTemplateConnector()
    {
        Endpoint = Endpoints.PrintTemplates;
    }

    public async Task<EntityCollection<PrintTemplate>> FindAsync(PrintTemplateSearch searchSettings)
    {
        return await BaseFind(searchSettings).ConfigureAwait(false);
    }
}