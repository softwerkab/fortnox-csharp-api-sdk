using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IOfferConnector : IEntityConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.Offer? SortBy { get; set; }
		Filter.Offer? FilterBy { get; set; }

		string CostCenter { get; set; }
		string CustomerName { get; set; }
		string CustomerNumber { get; set; }
		string DocumentNumber { get; set; }
		string OfferDate { get; set; }
		string OurReference { get; set; }
		string Project { get; set; }
		string YourReference { get; set; }

		Offer Update(Offer offer);
		Offer Create(Offer offer);
		Offer Get(long? id);
        EntityCollection<OfferSubset> Find();
		Offer CreateOrder(long? id);
		Offer Cancel(long? id);
		Offer Email(long? id);
        byte[] Print(long? id);
		Offer ExternalPrint(long? id);
		byte[] Preview(long? id);

		Task<Offer> UpdateAsync(Offer offer);
		Task<Offer> CreateAsync(Offer offer);
		Task<Offer> GetAsync(long? id);
        Task<EntityCollection<OfferSubset>> FindAsync();
	}
}
