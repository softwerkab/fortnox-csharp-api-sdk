using System;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface ITermsOfDeliveryConnector : IEntityConnector
    {
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        TermsOfDelivery Update(TermsOfDelivery termsOfDelivery);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        TermsOfDelivery Create(TermsOfDelivery termsOfDelivery);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        TermsOfDelivery Get(string id);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        void Delete(string id);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        EntityCollection<TermsOfDelivery> Find(TermsOfDeliverySearch searchSettings);

        Task<TermsOfDelivery> UpdateAsync(TermsOfDelivery termsOfDelivery);
        Task<TermsOfDelivery> CreateAsync(TermsOfDelivery termsOfDelivery);
        Task<TermsOfDelivery> GetAsync(string id);
        Task DeleteAsync(string id);
        Task<EntityCollection<TermsOfDelivery>> FindAsync(TermsOfDeliverySearch searchSettings);
    }
}
