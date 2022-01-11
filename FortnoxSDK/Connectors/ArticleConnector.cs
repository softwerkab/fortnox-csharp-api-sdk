using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;
using Fortnox.SDK.Utility;

namespace Fortnox.SDK.Connectors;

internal class ArticleConnector : SearchableEntityConnector<Article, ArticleSubset, ArticleSearch>, IArticleConnector
{
    public ArticleConnector()
    {
        Endpoint = Endpoints.Articles;
    }

    public async Task<EntityCollection<ArticleSubset>> FindAsync(ArticleSearch searchSettings)
    {
        return await BaseFind(searchSettings).ConfigureAwait(false);
    }

    public async Task DeleteAsync(string id)
    {
        await BaseDelete(id).ConfigureAwait(false);
    }

    public async Task<Article> CreateAsync(Article article)
    {
        return await BaseCreate(article).ConfigureAwait(false);
    }

    public async Task<Article> UpdateAsync(Article article)
    {
        return await BaseUpdate(article, article.ArticleNumber).ConfigureAwait(false);
    }

    public async Task<Article> GetAsync(string id)
    {
        return await BaseGet(id).ConfigureAwait(false);
    }
}