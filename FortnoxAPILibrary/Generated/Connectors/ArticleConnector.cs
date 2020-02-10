using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class ArticleConnector : EntityConnector<Article, EntityCollection<ArticleSubset>, Sort.By.Article?>
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.Article FilterBy { get; set; }


        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string ArticleNumber { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string Description { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string EAN { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string Manufacturer { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string ManufacturerArticleNumber { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string SupplierNumber { get; set; }

		/// <remarks/>
		public ArticleConnector()
		{
			Resource = "articles";
		}

		/// <summary>
		/// Find a article based on articlenumber
		/// </summary>
		/// <param name="articleNumber">The articlenumber to find</param>
		/// <returns>The found article</returns>
		public Article Get(string articleNumber)
		{
			return BaseGet(articleNumber);
		}

		/// <summary>
		/// Updates a article
		/// </summary>
		/// <param name="article">The article to update</param>
		/// <returns>The updated article</returns>
		public Article Update(Article article)
		{
			return BaseUpdate(article, article.ArticleNumber);
		}

		/// <summary>
		/// Create a new article
		/// </summary>
		/// <param name="article">The article to create</param>
		/// <returns>The created article</returns>
		public Article Create(Article article)
		{
			return BaseCreate(article);
		}

		/// <summary>
		/// Deletes a article
		/// </summary>
		/// <param name="articleNumber">The articlenumber to delete</param>
		public void Delete(string articleNumber)
		{
			BaseDelete(articleNumber);
		}

		/// <summary>
		/// Gets a list of articles
		/// </summary>
		/// <returns>A list of articles</returns>
		public EntityCollection<ArticleSubset> Find()
		{
			return BaseFind();
		}
	}
}
