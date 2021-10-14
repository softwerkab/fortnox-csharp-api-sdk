using System;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface ITrustedEmailSendersConnector : IEntityConnector
	{
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
        TrustedEmailSender Create(TrustedEmailSender trustedEmailSenders);
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
        void Delete(long? id);
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
        EmailSenders GetAll();

        Task<TrustedEmailSender> CreateAsync(TrustedEmailSender trustedEmailSenders);
        Task DeleteAsync(long? id);
        Task<EmailSenders> GetAllAsync();
	}
}
