using System;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces;

/// <remarks/>
public interface ITermsOfDeliveryConnector : IEntityConnector
{
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    TermsOfDelivery Update(TermsOfDelivery termsOfDelivery);
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    TermsOfDelivery Create(TermsOfDelivery termsOfDelivery);
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    TermsOfDelivery Get(string id);
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    void Delete(string id);
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    EntityCollection<TermsOfDelivery> Find(TermsOfDeliverySearch searchSettings);

    Task<TermsOfDelivery> UpdateAsync(TermsOfDelivery termsOfDelivery);
    Task<TermsOfDelivery> CreateAsync(TermsOfDelivery termsOfDelivery);
    Task<TermsOfDelivery> GetAsync(string id);
    Task DeleteAsync(string id);
    Task<EntityCollection<TermsOfDelivery>> FindAsync(TermsOfDeliverySearch searchSettings);
}