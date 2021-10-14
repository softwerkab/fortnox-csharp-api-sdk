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
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        Currency Update(Currency currency);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        Currency Create(Currency currency);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        Currency Get(string id);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        void Delete(string id);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        EntityCollection<Currency> Find(CurrencySearch searchSettings);

        Task<Currency> UpdateAsync(Currency currency);
        Task<Currency> CreateAsync(Currency currency);
        Task<Currency> GetAsync(string id);
        Task DeleteAsync(string id);
        Task<EntityCollection<Currency>> FindAsync(CurrencySearch searchSettings);
    }
}
