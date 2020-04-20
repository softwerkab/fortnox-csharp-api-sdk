using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IPriceConnector : IConnector
	{
        [SearchParameter("filter")]
		Filter.Price? FilterBy { get; set; }

        [SearchParameter]
		string ArticleNumber { get; set; }

        [SearchParameter]
		string FromQuantity { get; set; }

		Price Update(Price price);

		Price Create(Price price);

		Price Get(string priceListCode, string articleNumber, decimal? fromQuantity = null);

		void Delete(string priceListCode, string articleNumber, decimal? fromQuantity = null);

		EntityCollection<PriceSubset> Find(string priceListId, string articleId = null);

	}
}
