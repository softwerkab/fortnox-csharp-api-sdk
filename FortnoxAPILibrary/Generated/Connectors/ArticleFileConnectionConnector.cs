using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class ArticleFileConnectionConnector : EntityConnector<ArticleFileConnection, EntityCollection<ArticleFileConnectionSubset>, Sort.By.ArticleFileConnection?>
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.ArticleFileConnection? FilterBy { get; set; }


        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string ArticleNumber { get; set; }

		/// <remarks/>
		public ArticleFileConnectionConnector()
		{
			Resource = "articlefileconnections";
		}
		/// <summary>
		/// Gets a list of articleFileConnections
		/// </summary>
		/// <returns>A list of articleFileConnections</returns>
		public EntityCollection<ArticleFileConnectionSubset> Find()
		{
			return BaseFind();
		}
	}
}
