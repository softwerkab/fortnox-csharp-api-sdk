using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class ArticleConnector : FinancialYearBasedEntityConnector<Article, EntityCollection<ArticleSubset>, Sort.By.Article?>
	{
		/// <remarks/>
		[SearchParameter("filter")]
		public Filter.Article? FilterBy { get; set; }

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
		public string SupplierNumber { get; set; }

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
		public string Webshop { get; set; }
        
		/// <remarks/>
		public ArticleConnector()
		{
			Resource = "articles";
		}

		/// <summary>
		/// Gets an article based on articlenumber
		/// </summary>
		/// <param name="articleNumber">The articlenumber to find</param>
		/// <returns>The found article</returns>
		public Article Get(string articleNumber)
		{
			return BaseGet(articleNumber);
		}

		/// <summary>
		/// Updates an article
		/// </summary>
		/// <param name="article">The article to update</param>
		/// <returns>The updated article</returns>
		public Article Update(Article article)
		{
			return BaseUpdate(article, article.ArticleNumber);
		}

		/// <summary>
		/// Creates a new article
		/// </summary>
		/// <param name="article">The article to create</param>
		/// <returns>The created article</returns>
		public Article Create(Article article)
		{
			return BaseCreate(article);
		}

		/// <summary>
		/// Deletes an article
		/// </summary>
		/// <param name="articleNumber">The articlenumber of the article to delete</param>
		/// <returns>If the article was deleted or not</returns>
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
