using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IArticleConnector : IConnector
	{
        [SearchParameter("filter")]
		Filter.Article? FilterBy { get; set; }


        [SearchParameter]
		string ArticleNumber { get; set; }

        [SearchParameter]
		string Description { get; set; }

        [SearchParameter]
		string EAN { get; set; }

        [SearchParameter]
		string Manufacturer { get; set; }

        [SearchParameter]
		string ManufacturerArticleNumber { get; set; }

        [SearchParameter]
		string SupplierNumber { get; set; }
		Article Update(Article article);

		Article Create(Article article);

		Article Get(string id);

		void Delete(string id);

		EntityCollection<ArticleSubset> Find();

	}
}
