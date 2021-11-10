using System;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces;

/// <remarks/>
public interface IOfferConnector : IEntityConnector
{
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    Offer Update(Offer offer);
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    Offer Create(Offer offer);
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    Offer Get(long? id);
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    EntityCollection<OfferSubset> Find(OfferSearch searchSettings);
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    Offer CreateOrder(long? id);
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    Offer Cancel(long? id);
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    Offer Email(long? id);
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    byte[] Print(long? id);
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    Offer ExternalPrint(long? id);
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    byte[] Preview(long? id);

    Task<Offer> UpdateAsync(Offer offer);
    Task<Offer> CreateAsync(Offer offer);
    Task<Offer> GetAsync(long? id);
    Task<EntityCollection<OfferSubset>> FindAsync(OfferSearch searchSettings);
    Task<Offer> CreateOrderAsync(long? id);
    Task<Offer> CancelAsync(long? id);
    Task<Offer> EmailAsync(long? id);
    Task<byte[]> PrintAsync(long? id);
    Task<Offer> ExternalPrintAsync(long? id);
    Task<byte[]> PreviewAsync(long? id);
}