using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface ISupplierConnector
	{
        [SearchParameter("filter")]
		Filter.Supplier? FilterBy { get; set; }


        [SearchParameter]
		string City { get; set; }

        [SearchParameter]
		string Email { get; set; }

        [SearchParameter]
		string Name { get; set; }

        [SearchParameter]
		string OrganisationNumber { get; set; }

        [SearchParameter]
		string Phone1 { get; set; }

        [SearchParameter]
		string Phone2 { get; set; }

        [SearchParameter]
		string SupplierNumber { get; set; }

        [SearchParameter]
		string ZipCode { get; set; }
		Supplier Update(Supplier supplier);

		Supplier Create(Supplier supplier);

		Supplier Get(string id);

		void Delete(string id);

		EntityCollection<SupplierSubset> Find();

	}
}
