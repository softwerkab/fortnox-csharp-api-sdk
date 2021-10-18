using System;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface IModeOfPaymentConnector : IEntityConnector
    {
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
        ModeOfPayment Update(ModeOfPayment modeOfPayment);
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
        ModeOfPayment Create(ModeOfPayment modeOfPayment);
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
        ModeOfPayment Get(string id);
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
        void Delete(string id);
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
        EntityCollection<ModeOfPayment> Find(ModeOfPaymentSearch searchSettings);

        Task<ModeOfPayment> UpdateAsync(ModeOfPayment modeOfPayment);
        Task<ModeOfPayment> CreateAsync(ModeOfPayment modeOfPayment);
        Task<ModeOfPayment> GetAsync(string id);
        Task DeleteAsync(string id);
        Task<EntityCollection<ModeOfPayment>> FindAsync(ModeOfPaymentSearch searchSettings);
    }
}
