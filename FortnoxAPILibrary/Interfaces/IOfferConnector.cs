using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IOfferConnector : IEntityConnector
	{

		Offer Update(Offer offer);
		Offer Create(Offer offer);
		Offer Get(long? id);
        EntityCollection<OfferSubset> Find(OfferSearch searchSettings);
		Offer CreateOrder(long? id);
		Offer Cancel(long? id);
		Offer Email(long? id);
        byte[] Print(long? id);
		Offer ExternalPrint(long? id);
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
