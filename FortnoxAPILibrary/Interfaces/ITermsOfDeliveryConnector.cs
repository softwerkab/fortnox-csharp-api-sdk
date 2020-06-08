using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface ITermsOfDeliveryConnector : IConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.TermsOfDelivery? SortBy { get; set; }
		Filter.TermsOfDelivery? FilterBy { get; set; }

		string Code { get; set; }

		TermsOfDelivery Update(TermsOfDelivery termsOfDelivery);
		TermsOfDelivery Create(TermsOfDelivery termsOfDelivery);
		TermsOfDelivery Get(string id);
		void Delete(string id);
		EntityCollection<TermsOfDelivery> Find();

		Task<TermsOfDelivery> UpdateAsync(TermsOfDelivery termsOfDelivery);
		Task<TermsOfDelivery> CreateAsync(TermsOfDelivery termsOfDelivery);
		Task<TermsOfDelivery> GetAsync(string id);
		Task DeleteAsync(string id);
		Task<EntityCollection<TermsOfDelivery>> FindAsync();
	}
}
