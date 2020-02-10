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
		/// Find a articleFileConnection based on id
		/// </summary>
		/// <param name="id">Identifier of the articleFileConnection to find</param>
		/// <returns>The found articleFileConnection</returns>
		public ArticleFileConnection Get(string id)
		{
			return BaseGet(id);
		}

		/// <summary>
		/// Updates a articleFileConnection
		/// </summary>
		/// <param name="articleFileConnection">The articleFileConnection to update</param>
		/// <returns>The updated articleFileConnection</returns>
		public ArticleFileConnection Update(ArticleFileConnection articleFileConnection)
		{
			return BaseUpdate(articleFileConnection, articleFileConnection.FileId.ToString());
		}

		/// <summary>
		/// Creates a new articleFileConnection
		/// </summary>
		/// <param name="articleFileConnection">The articleFileConnection to create</param>
		/// <returns>The created articleFileConnection</returns>
		public ArticleFileConnection Create(ArticleFileConnection articleFileConnection)
		{
			return BaseCreate(articleFileConnection);
		}

		/// <summary>
		/// Deletes a articleFileConnection
		/// </summary>
		/// <param name="id">Identifier of the articleFileConnection to delete</param>
		public void Delete(string id)
		{
			BaseDelete(id);
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
