using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class ArticleFileConnectionConnector : EntityConnector<ArticleFileConnection, EntityCollection<ArticleFileConnection>, Sort.By.ArticleFileConnection?>, IArticleFileConnectionConnector
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
			return GetAsync(id).Result;
		}

		/// <summary>
		/// Creates a new articleFileConnection
		/// </summary>
		/// <param name="articleFileConnection">The articleFileConnection to create</param>
		/// <returns>The created articleFileConnection</returns>
		public ArticleFileConnection Create(ArticleFileConnection articleFileConnection)
		{
			return CreateAsync(articleFileConnection).Result;
		}

		/// <summary>
		/// Deletes a articleFileConnection
		/// </summary>
		/// <param name="id">Identifier of the articleFileConnection to delete</param>
		public void Delete(string id)
		{
			DeleteAsync(id).Wait();
		}

		/// <summary>
		/// Gets a list of articleFileConnections
		/// </summary>
		/// <returns>A list of articleFileConnections</returns>
		public EntityCollection<ArticleFileConnection> Find()
		{
			return FindAsync().Result;
		}

		public async Task<EntityCollection<ArticleFileConnection>> FindAsync()
		{
			return await BaseFind();
		}
		public async Task DeleteAsync(string id)
		{
			await BaseDelete(id);
		}
		public async Task<ArticleFileConnection> CreateAsync(ArticleFileConnection articleFileConnection)
		{
			return await BaseCreate(articleFileConnection);
		}
		public async Task<ArticleFileConnection> GetAsync(string id)
		{
			return await BaseGet(id);
		}
	}
}
