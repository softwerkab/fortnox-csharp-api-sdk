using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface ITermsOfDeliveryConnector : IEntityConnector
	{

		TermsOfDelivery Update(TermsOfDelivery termsOfDelivery);
		TermsOfDelivery Create(TermsOfDelivery termsOfDelivery);
		TermsOfDelivery Get(string id);
		void Delete(string id);
		EntityCollection<TermsOfDelivery> Find(TermsOfDeliverySearch searchSettings);

		Task<TermsOfDelivery> UpdateAsync(TermsOfDelivery termsOfDelivery);
		Task<TermsOfDelivery> CreateAsync(TermsOfDelivery termsOfDelivery);
		Task<TermsOfDelivery> GetAsync(string id);
		Task DeleteAsync(string id);
		Task<EntityCollection<TermsOfDelivery>> FindAsync(TermsOfDeliverySearch searchSettings);
	}
}
