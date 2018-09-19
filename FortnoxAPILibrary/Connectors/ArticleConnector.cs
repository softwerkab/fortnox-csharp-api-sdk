using System.Collections.Generic;

namespace FortnoxAPILibrary.Connectors
{
    public interface IArticleConnector : IEntityConnector<Sort.By.Article>
    {
        /// <remarks/>
        Filter.Article FilterBy { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        string ArticleNumber { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        string EAN { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        string SupplierNumber { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        string Manufacturer { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        string ManufacturerArticleNumber { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        string Webshop { get; set; }

        /// <summary>
        /// Gets an article based on articlenumber
        /// </summary>
        /// <param name="articleNumber">The articlenumber to find</param>
        /// <returns>The found article</returns>
        Article Get(string articleNumber);

        /// <summary>
        /// Updates an article
        /// </summary>
        /// <param name="article">The article to update</param>
        /// <returns>The updated article</returns>
        Article Update(Article article);

        /// <summary>
        /// Creates a new article
        /// </summary>
        /// <param name="article">The article to create</param>
        /// <returns>The created article</returns>
        Article Create(Article article);

        /// <summary>
        /// Deletes an article
        /// </summary>
        /// <param name="articleNumber">The articlenumber of the article to delete</param>
        /// <returns>If the article was deleted or not</returns>
        void Delete(string articleNumber);

        /// <summary>
        /// Gets a list of articles
        /// </summary>
        /// <returns>A list of articles</returns>
        Articles Find();
    }

    /// <remarks/>
	public class ArticleConnector : FinancialYearBasedEntityConnector<Article, Articles, Sort.By.Article>, IArticleConnector
    {
		private bool filterBySet = false;
		private Filter.Article filterBy;
		/// <remarks/>
		[FilterProperty("filter")]
		public Filter.Article FilterBy
		{
			get { return filterBy; }
			set
			{
				filterBy = value;
				filterBySet = true;
			}
		}

		/// <summary>
		/// Use with Find() to limit the search result
		/// </summary>
		[FilterProperty]
		public string ArticleNumber { get; set; }

		/// <summary>
		/// Use with Find() to limit the search result
		/// </summary>
		[FilterProperty]
		public string Description { get; set; }

		/// <summary>
		/// Use with Find() to limit the search result
		/// </summary>
		[FilterProperty]
		public string EAN { get; set; }

		/// <summary>
		/// Use with Find() to limit the search result
		/// </summary>
		[FilterProperty]
		public string SupplierNumber { get; set; }

		/// <summary>
		/// Use with Find() to limit the search result
		/// </summary>
		[FilterProperty]
		public string Manufacturer { get; set; }

		/// <summary>
		/// Use with Find() to limit the search result
		/// </summary>
		[FilterProperty]
		public string ManufacturerArticleNumber { get; set; }

		/// <summary>
		/// Use with Find() to limit the search result
		/// </summary>
		[FilterProperty]
		public string Webshop { get; set; }

		/// <remarks/>
		public enum ArticleType
		{
			/// <remarks/>
			STOCK,
			/// <remarks/>
			SERVICE
		}

		/// <remarks/>
		public ArticleConnector()
		{
			base.Resource = "articles";
		}

		/// <summary>
		/// Gets an article based on articlenumber
		/// </summary>
		/// <param name="articleNumber">The articlenumber to find</param>
		/// <returns>The found article</returns>
		public Article Get(string articleNumber)
		{
			return base.BaseGet(articleNumber);
		}

		/// <summary>
		/// Updates an article
		/// </summary>
		/// <param name="article">The article to update</param>
		/// <returns>The updated article</returns>
		public Article Update(Article article)
		{
			return base.BaseUpdate(article, article.ArticleNumber);
		}

		/// <summary>
		/// Creates a new article
		/// </summary>
		/// <param name="article">The article to create</param>
		/// <returns>The created article</returns>
		public Article Create(Article article)
		{
			return base.BaseCreate(article);
		}

		/// <summary>
		/// Deletes an article
		/// </summary>
		/// <param name="articleNumber">The articlenumber of the article to delete</param>
		/// <returns>If the article was deleted or not</returns>
		public void Delete(string articleNumber)
		{
			base.BaseDelete(articleNumber);
		}

		/// <summary>
		/// Gets a list of articles
		/// </summary>
		/// <returns>A list of articles</returns>
		public Articles Find()
		{
			return base.BaseFind();
		}
	}
}