using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface IAccountChartConnector : IEntityConnector
	{

		EntityCollection<AccountChart> Find(AccountChartSearch searchSettings);

		Task<EntityCollection<AccountChart>> FindAsync(AccountChartSearch searchSettings);
	}
}
