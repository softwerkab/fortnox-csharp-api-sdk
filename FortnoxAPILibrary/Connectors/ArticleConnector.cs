using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class ArticleConnector : EntityConnector<Article, EntityCollection<ArticleSubset>, Sort.By.Article?>, IArticleConnector
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.Article? FilterBy { get; set; }

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
			return GetAsync(id).Result;
		}

		/// <summary>
		/// Updates a article
		/// </summary>
		/// <param name="article">The article to update</param>
		/// <returns>The updated article</returns>
		public Article Update(Article article)
		{
			return UpdateAsync(article).Result;
		}

		/// <summary>
		/// Creates a new article
		/// </summary>
		/// <param name="article">The article to create</param>
		/// <returns>The created article</returns>
		public Article Create(Article article)
		{
			return CreateAsync(article).Result;
		}

		/// <summary>
		/// Deletes a article
		/// </summary>
		/// <param name="id">Identifier of the article to delete</param>
		public void Delete(string id)
		{
			DeleteAsync(id).Wait();
		}

		/// <summary>
		/// Gets a list of articles
		/// </summary>
		/// <returns>A list of articles</returns>
		public EntityCollection<ArticleSubset> Find()
		{
			return FindAsync().Result;
		}

		public async Task<EntityCollection<ArticleSubset>> FindAsync()
		{
			return await BaseFind().ConfigureAwait(false);
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
}
