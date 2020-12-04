using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
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
