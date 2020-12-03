using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IAccountChartConnector : IEntityConnector
	{

		EntityCollection<AccountChart> Find(AccountChartSearch searchSettings);

		Task<EntityCollection<AccountChart>> FindAsync(AccountChartSearch searchSettings);
	}
}
