using System;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces;

/// <remarks>
/// See https://apps.fortnox.se/apidocs#tag/ArticlesResource
/// </remarks>
public interface IArticleConnector : IEntityConnector
{
    Task<Article> UpdateAsync(Article article);
    Task<Article> CreateAsync(Article article);
    Task<Article> GetAsync(string id);
    Task DeleteAsync(string id);
    Task<EntityCollection<ArticleSubset>> FindAsync(ArticleSearch searchSettings);
}