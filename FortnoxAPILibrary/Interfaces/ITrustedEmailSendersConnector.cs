using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
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
