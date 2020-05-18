using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IArticleFileConnectionConnector : IConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.ArticleFileConnection? SortBy { get; set; }
		Filter.ArticleFileConnection? FilterBy { get; set; }

		string ArticleNumber { get; set; }

		ArticleFileConnection Create(ArticleFileConnection articleFileConnection);
		ArticleFileConnection Get(string id);
		void Delete(string id);
		EntityCollection<ArticleFileConnection> Find();

		Task<ArticleFileConnection> CreateAsync(ArticleFileConnection articleFileConnection);
		Task<ArticleFileConnection> GetAsync(string id);
		Task DeleteAsync(string id);
		Task<EntityCollection<ArticleFileConnection>> FindAsync();
	}
}
