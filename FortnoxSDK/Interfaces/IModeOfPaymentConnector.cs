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
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		ModeOfPayment Update(ModeOfPayment modeOfPayment);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		ModeOfPayment Create(ModeOfPayment modeOfPayment);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		ModeOfPayment Get(string id);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		void Delete(string id);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		EntityCollection<ModeOfPayment> Find(ModeOfPaymentSearch searchSettings);

		Task<ModeOfPayment> UpdateAsync(ModeOfPayment modeOfPayment);
		Task<ModeOfPayment> CreateAsync(ModeOfPayment modeOfPayment);
		Task<ModeOfPayment> GetAsync(string id);
		Task DeleteAsync(string id);
		Task<EntityCollection<ModeOfPayment>> FindAsync(ModeOfPaymentSearch searchSettings);
	}
}
