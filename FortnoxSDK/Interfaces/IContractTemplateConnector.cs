using System;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces;

/// <remarks/>
public interface IContractTemplateConnector : IEntityConnector
{
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    ContractTemplate Update(ContractTemplate contractTemplate);
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    ContractTemplate Create(ContractTemplate contractTemplate);
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    ContractTemplate Get(string id);
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    EntityCollection<ContractTemplateSubset> Find(ContractTemplateSearch searchSettings);

    Task<ContractTemplate> UpdateAsync(ContractTemplate contractTemplate);
    Task<ContractTemplate> CreateAsync(ContractTemplate contractTemplate);
    Task<ContractTemplate> GetAsync(string id);
    Task<EntityCollection<ContractTemplateSubset>> FindAsync(ContractTemplateSearch searchSettings);
}