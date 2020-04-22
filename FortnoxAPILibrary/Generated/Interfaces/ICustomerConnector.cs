using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface ICustomerConnector : IConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.Customer? SortBy { get; set; }

        [SearchParameter("filter")]
		Filter.Customer? FilterBy { get; set; }


        [SearchParameter]
		string City { get; set; }

        [SearchParameter]
		string CustomerNumber { get; set; }

        [SearchParameter]
		string Email { get; set; }

        [SearchParameter]
		string GLN { get; set; }

        [SearchParameter]
		string GLNDelivery { get; set; }

        [SearchParameter]
		string Name { get; set; }

        [SearchParameter]
		string OrganisationNumber { get; set; }

        [SearchParameter]
		string Phone1 { get; set; }

        [SearchParameter]
		string ZipCode { get; set; }
		Customer Update(Customer customer);

		Customer Create(Customer customer);

		Customer Get(string id);

		void Delete(string id);

		EntityCollection<CustomerSubset> Find();

	}
}
