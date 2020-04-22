using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IFinancialYearConnector : IConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.FinancialYear? SortBy { get; set; }

        [SearchParameter("filter")]
		Filter.FinancialYear? FilterBy { get; set; }

        [SearchParameter]
		string Date { get; set; }

        FinancialYear Create(FinancialYear financialYear);

		FinancialYear Get(int? id);

        EntityCollection<FinancialYearSubset> Find();

	}
}
