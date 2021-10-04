using System;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface IOfferConnector : IEntityConnector
	{
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		Offer Update(Offer offer);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		Offer Create(Offer offer);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        Offer Get(long? id);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        EntityCollection<OfferSubset> Find(OfferSearch searchSettings);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        Offer CreateOrder(long? id);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        Offer Cancel(long? id);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        Offer Email(long? id);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        byte[] Print(long? id);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        Offer ExternalPrint(long? id);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
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
}
