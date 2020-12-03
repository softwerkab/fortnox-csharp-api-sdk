using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
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
