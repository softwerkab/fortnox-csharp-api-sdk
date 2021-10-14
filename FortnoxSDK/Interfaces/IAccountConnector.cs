using System;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface IAccountConnector : IEntityConnector
    {
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        Account Update(Account account, long? finYearID = null);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        Account Create(Account account, long? finYearID = null);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        Account Get(long? id, long? finYearID = null);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        void Delete(long? id, long? finYearID = null);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        EntityCollection<AccountSubset> Find(AccountSearch searchSettings);

        Task<Account> UpdateAsync(Account account, long? finYearID = null);
        Task<Account> CreateAsync(Account account, long? finYearID = null);
        Task<Account> GetAsync(long? id, long? finYearID = null);
        Task DeleteAsync(long? id, long? finYearID = null);
        Task<EntityCollection<AccountSubset>> FindAsync(AccountSearch searchSettings);
    }
}
