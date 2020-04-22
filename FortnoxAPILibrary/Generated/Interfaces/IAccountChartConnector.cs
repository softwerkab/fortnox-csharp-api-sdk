using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;
// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IAccountChartConnector : IConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.AccountChart? SortBy { get; set; }
		Filter.AccountChart? FilterBy { get; set; }

		EntityCollection<AccountChart> Find();
	}
}
