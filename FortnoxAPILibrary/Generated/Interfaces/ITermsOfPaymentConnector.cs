using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;
// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface ITermsOfPaymentConnector : IConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.TermsOfPayment? SortBy { get; set; }
		Filter.TermsOfPayment? FilterBy { get; set; }


		TermsOfPayment Update(TermsOfPayment termsOfPayment);
		TermsOfPayment Create(TermsOfPayment termsOfPayment);
		TermsOfPayment Get(string id);
		void Delete(string id);
		EntityCollection<TermsOfPayment> Find();
	}
}
