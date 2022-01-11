using System.Threading.Tasks;
using Fortnox.SDK.Entities;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces;

/// <remarks/>
public interface ITrustedEmailSendersConnector : IEntityConnector
{
    Task<TrustedEmailSender> CreateAsync(TrustedEmailSender trustedEmailSenders);
    Task DeleteAsync(long? id);
    Task<EmailSenders> GetAllAsync();
}