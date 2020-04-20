using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IFinancialYearConnector
	{
        [SearchParameter("filter")]
		Filter.FinancialYear? FilterBy { get; set; }

        [SearchParameter]
		string Date { get; set; }

        FinancialYear Create(FinancialYear financialYear);

		FinancialYear Get(int? id);

        EntityCollection<FinancialYearSubset> Find();

	}
}
