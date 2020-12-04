using System.Threading.Tasks;
using Fortnox.SDK.Entities;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface ITrustedEmailSendersConnector : IEntityConnector
	{
        TrustedEmailSender Create(TrustedEmailSender trustedEmailSenders);
        void Delete(long? id);
        EmailSenders GetAll();

        Task<TrustedEmailSender> CreateAsync(TrustedEmailSender trustedEmailSenders);
        Task DeleteAsync(long? id);
        Task<EmailSenders> GetAllAsync();
	}
}
