using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IArticleConnector : IConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.Article? SortBy { get; set; }
		Filter.Article? FilterBy { get; set; }

		string ArticleNumber { get; set; }
		string Description { get; set; }
		string EAN { get; set; }
		string Manufacturer { get; set; }
		string ManufacturerArticleNumber { get; set; }
		string SupplierNumber { get; set; }

		Article Update(Article article);
		Article Create(Article article);
		Article Get(string id);
		void Delete(string id);
		EntityCollection<ArticleSubset> Find();

		Task<Article> UpdateAsync(Article article);
		Task<Article> CreateAsync(Article article);
		Task<Article> GetAsync(string id);
		Task DeleteAsync(string id);
		Task<EntityCollection<ArticleSubset>> FindAsync();
	}
}
