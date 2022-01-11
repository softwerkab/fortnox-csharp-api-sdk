using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces;

/// <remarks/>
public interface IAccountChartConnector : IEntityConnector
{
    Task<EntityCollection<AccountChart>> FindAsync(AccountChartSearch searchSettings);
}