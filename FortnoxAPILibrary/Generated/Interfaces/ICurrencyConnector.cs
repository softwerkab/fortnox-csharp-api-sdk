using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface ICurrencyConnector : IConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.Currency? SortBy { get; set; }

        [SearchParameter("filter")]
		Filter.Currency? FilterBy { get; set; }

		Currency Update(Currency currency);

		Currency Create(Currency currency);

		Currency Get(string id);

		void Delete(string id);

		EntityCollection<Currency> Find();

	}
}
