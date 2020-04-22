using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Reused;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface ITrustedEmailSendersConnector : IConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.TrustedEmailSenders? SortBy { get; set; }

        [SearchParameter("filter")]
		Filter.TrustedEmailSenders? FilterBy { get; set; }

        TrustedEmailSender Create(TrustedEmailSender trustedEmailSenders);

        void Delete(int? id);

        EmailSenders Find();

	}
}
