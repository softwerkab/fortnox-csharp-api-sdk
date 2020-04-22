using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;
// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface ILockedPeriodConnector : IConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.LockedPeriod? SortBy { get; set; }

        LockedPeriod Get();
    }
}
