using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IOfferConnector : IConnector
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
		Offer Get(int? id);
        EntityCollection<OfferSubset> Find();
		Offer CreateOrder(int? id);
		Offer Cancel(int? id);
		Offer Email(int? id);
        byte[] Print(int? id);
		Offer ExternalPrint(int? id);
		byte[] Preview(int? id);

		Task<Offer> UpdateAsync(Offer offer);
		Task<Offer> CreateAsync(Offer offer);
		Task<Offer> GetAsync(int? id);
        Task<EntityCollection<OfferSubset>> FindAsync();
	}
}
