using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces;

/// <remarks/>
public interface ITermsOfPaymentConnector : IEntityConnector
{
    Task<TermsOfPayment> UpdateAsync(TermsOfPayment termsOfPayment);
    Task<TermsOfPayment> CreateAsync(TermsOfPayment termsOfPayment);
    Task<TermsOfPayment> GetAsync(string id);
    Task DeleteAsync(string id);
    Task<EntityCollection<TermsOfPayment>> FindAsync(TermsOfPaymentSearch searchSettings);
}