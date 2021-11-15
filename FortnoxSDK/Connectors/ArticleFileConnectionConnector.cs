using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;
using Fortnox.SDK.Utility;

namespace Fortnox.SDK.Connectors;

internal class ArticleFileConnectionConnector : SearchableEntityConnector<ArticleFileConnection, ArticleFileConnection, ArticleFileConnectionSearch>, IArticleFileConnectionConnector
{
    public ArticleFileConnectionConnector()
    {
        Endpoint = Endpoints.ArticleFileConnections;
    }

    public ArticleFileConnection Get(string id)
    {
        return GetAsync(id).GetResult();
    }

    public ArticleFileConnection Create(ArticleFileConnection articleFileConnection)
    {
        return CreateAsync(articleFileConnection).GetResult();
    }

    public void Delete(string id)
    {
        DeleteAsync(id).GetResult();
    }

    public EntityCollection<ArticleFileConnection> Find(ArticleFileConnectionSearch searchSettings)
    {
        return FindAsync(searchSettings).GetResult();
    }

    public async Task<EntityCollection<ArticleFileConnection>> FindAsync(ArticleFileConnectionSearch searchSettings)
    {
        return await BaseFind(searchSettings).ConfigureAwait(false);
    }

    public async Task DeleteAsync(string id)
    {
        await BaseDelete(id).ConfigureAwait(false);
    }

    public async Task<ArticleFileConnection> CreateAsync(ArticleFileConnection articleFileConnection)
    {
        return await BaseCreate(articleFileConnection).ConfigureAwait(false);
    }

    public async Task<ArticleFileConnection> GetAsync(string id)
    {
        return await BaseGet(id).ConfigureAwait(false);
    }
}