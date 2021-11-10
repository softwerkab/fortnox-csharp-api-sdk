using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;
using Fortnox.SDK.Utility;

// ReSharper disable UnusedMember.Global

namespace Fortnox.SDK.Connectors;

/// <remarks/>
internal class ArticleConnector : SearchableEntityConnector<Article, ArticleSubset, ArticleSearch>, IArticleConnector
{

    /// <remarks/>
    public ArticleConnector()
    {
        Resource = "articles";
    }
    /// <summary>
    /// Find a article based on id
    /// </summary>
    /// <param name="id">Identifier of the article to find</param>
    /// <returns>The found article</returns>
    public Article Get(string id)
    {
        return GetAsync(id).GetResult();
    }

    /// <summary>
    /// Updates a article
    /// </summary>
    /// <param name="article">The article to update</param>
    /// <returns>The updated article</returns>
    public Article Update(Article article)
    {
        return UpdateAsync(article).GetResult();
    }

    /// <summary>
    /// Creates a new article
    /// </summary>
    /// <param name="article">The article to create</param>
    /// <returns>The created article</returns>
    public Article Create(Article article)
    {
        return CreateAsync(article).GetResult();
    }

    /// <summary>
    /// Deletes a article
    /// </summary>
    /// <param name="id">Identifier of the article to delete</param>
    public void Delete(string id)
    {
        DeleteAsync(id).GetResult();
    }

    /// <summary>
    /// Gets a list of articles
    /// </summary>
    /// <returns>A list of articles</returns>
    public EntityCollection<ArticleSubset> Find(ArticleSearch searchSettings)
    {
        return FindAsync(searchSettings).GetResult();
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