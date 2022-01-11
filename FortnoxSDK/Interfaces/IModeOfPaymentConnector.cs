using System;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces;

/// <remarks/>
public interface IModeOfPaymentConnector : IEntityConnector
{
    Task<ModeOfPayment> UpdateAsync(ModeOfPayment modeOfPayment);
    Task<ModeOfPayment> CreateAsync(ModeOfPayment modeOfPayment);
    Task<ModeOfPayment> GetAsync(string id);
    Task DeleteAsync(string id);
    Task<EntityCollection<ModeOfPayment>> FindAsync(ModeOfPaymentSearch searchSettings);
}