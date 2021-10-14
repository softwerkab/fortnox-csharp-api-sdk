using System;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface IArticleConnector : IEntityConnector
    {
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        Article Update(Article article);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        Article Create(Article article);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        Article Get(string id);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        void Delete(string id);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        EntityCollection<ArticleSubset> Find(ArticleSearch searchSettings);

        Task<Article> UpdateAsync(Article article);
        Task<Article> CreateAsync(Article article);
        Task<Article> GetAsync(string id);
        Task DeleteAsync(string id);
        Task<EntityCollection<ArticleSubset>> FindAsync(ArticleSearch searchSettings);
    }
}
