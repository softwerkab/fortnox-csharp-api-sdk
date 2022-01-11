using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces;

/// <remarks/>
public interface IOfferConnector : IEntityConnector
{
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