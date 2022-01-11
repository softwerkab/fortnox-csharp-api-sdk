using System;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces;

/// <remarks/>
public interface IAccountConnector : IEntityConnector
{
    Task<Account> UpdateAsync(Account account, long? finYearID = null);
    Task<Account> CreateAsync(Account account, long? finYearID = null);
    Task<Account> GetAsync(long? id, long? finYearID = null);
    Task DeleteAsync(long? id, long? finYearID = null);
    Task<EntityCollection<AccountSubset>> FindAsync(AccountSearch searchSettings);
}