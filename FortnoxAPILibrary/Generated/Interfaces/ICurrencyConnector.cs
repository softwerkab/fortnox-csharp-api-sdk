using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface ICurrencyConnector
	{
        [SearchParameter("filter")]
		Filter.Currency? FilterBy { get; set; }

		Currency Update(Currency currency);

		Currency Create(Currency currency);

		Currency Get(string id);

		void Delete(string id);

		EntityCollection<Currency> Find();

	}
}
