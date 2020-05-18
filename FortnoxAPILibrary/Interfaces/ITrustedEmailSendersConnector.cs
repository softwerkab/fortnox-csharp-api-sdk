using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface ITrustedEmailSendersConnector : IConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.TrustedEmailSenders? SortBy { get; set; }
		Filter.TrustedEmailSenders? FilterBy { get; set; }

        TrustedEmailSender Create(TrustedEmailSender trustedEmailSenders);
        void Delete(int? id);
        EmailSenders Find();

        Task<TrustedEmailSender> CreateAsync(TrustedEmailSender trustedEmailSenders);
        Task DeleteAsync(int? id);
        Task<EmailSenders> FindAsync();
	}
}
