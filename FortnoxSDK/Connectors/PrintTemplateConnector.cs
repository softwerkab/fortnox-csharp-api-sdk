using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;
using Fortnox.SDK.Utility;

// ReSharper disable UnusedMember.Global

namespace Fortnox.SDK.Connectors;

/// <remarks/>
internal class PrintTemplateConnector : SearchableEntityConnector<PrintTemplate, PrintTemplate, PrintTemplateSearch>, IPrintTemplateConnector
{

    /// <remarks/>
    public PrintTemplateConnector()
    {
        Resource = "printtemplates";
    }

    /// <summary>
    /// Gets a list of printTemplates
    /// </summary>
    /// <returns>A list of printTemplates</returns>
    public EntityCollection<PrintTemplate> Find(PrintTemplateSearch searchSettings)
    {
        return FindAsync(searchSettings).GetResult();
    }

    public async Task<EntityCollection<PrintTemplate>> FindAsync(PrintTemplateSearch searchSettings)
    {
        return await BaseFind(searchSettings).ConfigureAwait(false);
    }
}