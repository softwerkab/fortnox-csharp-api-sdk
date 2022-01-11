using System;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces;

/// <remarks/>
public interface IPredefinedAccountsConnector : IEntityConnector
{
    Task<PredefinedAccount> UpdateAsync(PredefinedAccount predefinedAccounts);
    Task<PredefinedAccount> GetAsync(string id);
    Task<EntityCollection<PredefinedAccount>> FindAsync(PredefinedAccountsSearch searchSettings);
}