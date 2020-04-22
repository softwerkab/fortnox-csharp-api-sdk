using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface ISalaryTransactionConnector : IConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.SalaryTransaction? SortBy { get; set; }

        [SearchParameter("filter")]
		Filter.SalaryTransaction? FilterBy { get; set; }

		SalaryTransaction Update(SalaryTransaction salaryTransaction);

		SalaryTransaction Create(SalaryTransaction salaryTransaction);

		SalaryTransaction Get(int? id);

		void Delete(int? id);

		EntityCollection<SalaryTransactionSubset> Find();

	}
}
