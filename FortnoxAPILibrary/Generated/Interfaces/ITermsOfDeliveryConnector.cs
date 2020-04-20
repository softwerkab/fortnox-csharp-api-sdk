using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface ITermsOfDeliveryConnector
	{
        [SearchParameter("filter")]
		Filter.TermsOfDelivery? FilterBy { get; set; }


        [SearchParameter]
		string Code { get; set; }
		TermsOfDelivery Update(TermsOfDelivery termsOfDelivery);

		TermsOfDelivery Create(TermsOfDelivery termsOfDelivery);

		TermsOfDelivery Get(string id);

		void Delete(string id);

		EntityCollection<TermsOfDelivery> Find();

	}
}
