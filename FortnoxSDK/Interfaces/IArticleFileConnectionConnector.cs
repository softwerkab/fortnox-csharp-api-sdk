using System;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface IArticleFileConnectionConnector : IEntityConnector
	{
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		ArticleFileConnection Create(ArticleFileConnection articleFileConnection);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		ArticleFileConnection Get(string id);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		void Delete(string id);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		EntityCollection<ArticleFileConnection> Find(ArticleFileConnectionSearch searchSettings);

		Task<ArticleFileConnection> CreateAsync(ArticleFileConnection articleFileConnection);
		Task<ArticleFileConnection> GetAsync(string id);
		Task DeleteAsync(string id);
		Task<EntityCollection<ArticleFileConnection>> FindAsync(ArticleFileConnectionSearch searchSettings);
	}
}
