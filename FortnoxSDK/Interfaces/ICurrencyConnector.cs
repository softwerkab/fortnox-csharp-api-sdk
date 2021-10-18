using System;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface ICurrencyConnector : IEntityConnector
    {
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
        Currency Update(Currency currency);
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
        Currency Create(Currency currency);
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
        Currency Get(string id);
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
        void Delete(string id);
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
        EntityCollection<Currency> Find(CurrencySearch searchSettings);

        Task<Currency> UpdateAsync(Currency currency);
        Task<Currency> CreateAsync(Currency currency);
        Task<Currency> GetAsync(string id);
        Task DeleteAsync(string id);
        Task<EntityCollection<Currency>> FindAsync(CurrencySearch searchSettings);
    }
}
