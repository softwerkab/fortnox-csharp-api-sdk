using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IOfferConnector : IConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.Offer? SortBy { get; set; }

        [SearchParameter("filter")]
		Filter.Offer? FilterBy { get; set; }

        [SearchParameter]
		string CostCenter { get; set; }

        [SearchParameter]
		string CustomerName { get; set; }

        [SearchParameter]
		string CustomerNumber { get; set; }

        [SearchParameter]
		string DocumentNumber { get; set; }

        [SearchParameter]
		string OfferDate { get; set; }

        [SearchParameter]
		string OurReference { get; set; }

        [SearchParameter]
		string Project { get; set; }

        [SearchParameter]
		string YourReference { get; set; }

		Offer Update(Offer offer);

		Offer Create(Offer offer);

		Offer Get(int? id);

        EntityCollection<OfferSubset> Find();

		Offer CreateOrder(int? id);
		
		Offer Cancel(int? id);
		
		Offer Email(int? id);
		
		Offer Print(int? id);
		
		Offer ExternalPrint(int? id);
		
		Offer Preview(int? id);
	}
}
