using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface ITaxReductionConnector
	{
        [SearchParameter("filter")]
		Filter.TaxReduction? FilterBy { get; set; }


        [SearchParameter]
		string ReferenceNumber { get; set; }
		TaxReduction Update(TaxReduction taxReduction);

		TaxReduction Create(TaxReduction taxReduction);

		TaxReduction Get(string id);

		void Delete(string id);

		EntityCollection<TaxReductionSubset> Find();

	}
}
