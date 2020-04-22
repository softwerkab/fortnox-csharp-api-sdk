using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface ICompanySettingsConnector : IConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.CompanySettings? SortBy { get; set; }

		CompanySettings Get();
	}
}
