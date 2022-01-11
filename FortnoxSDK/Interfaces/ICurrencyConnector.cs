using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces;

/// <remarks/>
public interface ICurrencyConnector : IEntityConnector
{
    Task<Currency> UpdateAsync(Currency currency);
    Task<Currency> CreateAsync(Currency currency);
    Task<Currency> GetAsync(string id);
    Task DeleteAsync(string id);
    Task<EntityCollection<Currency>> FindAsync(CurrencySearch searchSettings);
}