using System;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface ITrustedEmailSendersConnector : IEntityConnector
	{
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        TrustedEmailSender Create(TrustedEmailSender trustedEmailSenders);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        void Delete(long? id);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        EmailSenders GetAll();

        Task<TrustedEmailSender> CreateAsync(TrustedEmailSender trustedEmailSenders);
        Task DeleteAsync(long? id);
        Task<EmailSenders> GetAllAsync();
	}
}
