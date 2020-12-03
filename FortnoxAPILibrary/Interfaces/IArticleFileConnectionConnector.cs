using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IArticleFileConnectionConnector : IEntityConnector
	{

		ArticleFileConnection Create(ArticleFileConnection articleFileConnection);
		ArticleFileConnection Get(string id);
		void Delete(string id);
		EntityCollection<ArticleFileConnection> Find(ArticleFileConnectionSearch searchSettings);

		Task<ArticleFileConnection> CreateAsync(ArticleFileConnection articleFileConnection);
		Task<ArticleFileConnection> GetAsync(string id);
		Task DeleteAsync(string id);
		Task<EntityCollection<ArticleFileConnection>> FindAsync(ArticleFileConnectionSearch searchSettings);
	}
}
