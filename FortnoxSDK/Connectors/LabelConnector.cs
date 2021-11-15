using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;
using Fortnox.SDK.Utility;

namespace Fortnox.SDK.Connectors;

internal class LabelConnector : SearchableEntityConnector<Label, Label, LabelSearch>, ILabelConnector
{
    public LabelConnector()
    {
        Endpoint = Endpoints.Labels;
    }

    public Label Update(Label label)
    {
        return UpdateAsync(label).GetResult();
    }

    public Label Create(Label label)
    {
        return CreateAsync(label).GetResult();
    }

    public void Delete(long? id)
    {
        DeleteAsync(id).GetResult();
    }

    public EntityCollection<Label> Find(LabelSearch searchSettings)
    {
        return FindAsync(searchSettings).GetResult();
    }

    public async Task<EntityCollection<Label>> FindAsync(LabelSearch searchSettings)
    {
        return await BaseFind(searchSettings).ConfigureAwait(false);
    }

    public async Task DeleteAsync(long? id)
    {
        await BaseDelete(id.ToString()).ConfigureAwait(false);
    }

    public async Task<Label> CreateAsync(Label label)
    {
        return await BaseCreate(label).ConfigureAwait(false);
    }

    public async Task<Label> UpdateAsync(Label label)
    {
        return await BaseUpdate(label, label.Id.ToString()).ConfigureAwait(false);
    }
}