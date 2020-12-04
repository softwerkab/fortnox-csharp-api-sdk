using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface IArticleConnector : IEntityConnector
	{

		Article Update(Article article);
		Article Create(Article article);
		Article Get(string id);
		void Delete(string id);
		EntityCollection<ArticleSubset> Find(ArticleSearch searchSettings);

		Task<Article> UpdateAsync(Article article);
		Task<Article> CreateAsync(Article article);
		Task<Article> GetAsync(string id);
		Task DeleteAsync(string id);
		Task<EntityCollection<ArticleSubset>> FindAsync(ArticleSearch searchSettings);
	}
}
