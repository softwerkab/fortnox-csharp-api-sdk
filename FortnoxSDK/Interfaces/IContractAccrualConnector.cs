using System;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces;

/// <remarks/>
public interface IContractAccrualConnector : IEntityConnector
{
    Task<ContractAccrual> UpdateAsync(ContractAccrual contractAccrual);
    Task<ContractAccrual> CreateAsync(ContractAccrual contractAccrual);
    Task<ContractAccrual> GetAsync(long? id);
    Task DeleteAsync(long? id);
    Task<EntityCollection<ContractAccrualSubset>> FindAsync(ContractAccrualSearch searchSettings);
}