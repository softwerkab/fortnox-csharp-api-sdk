using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface ILockedPeriodConnector : IEntityConnector
	{
        LockedPeriod Get();

        Task<LockedPeriod> GetAsync();
    }
}
