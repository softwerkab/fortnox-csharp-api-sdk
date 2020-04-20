using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IArticleFileConnectionConnector : IConnector
	{
        [SearchParameter("filter")]
		Filter.ArticleFileConnection? FilterBy { get; set; }

        [SearchParameter]
		string ArticleNumber { get; set; }

		ArticleFileConnection Create(ArticleFileConnection articleFileConnection);

		ArticleFileConnection Get(string id);

		void Delete(string id);

		EntityCollection<ArticleFileConnection> Find();

	}
}
