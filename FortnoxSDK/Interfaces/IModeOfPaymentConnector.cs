using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface IModeOfPaymentConnector : IEntityConnector
	{

		ModeOfPayment Update(ModeOfPayment modeOfPayment);
		ModeOfPayment Create(ModeOfPayment modeOfPayment);
		ModeOfPayment Get(string id);
		void Delete(string id);
		EntityCollection<ModeOfPayment> Find(ModeOfPaymentSearch searchSettings);

		Task<ModeOfPayment> UpdateAsync(ModeOfPayment modeOfPayment);
		Task<ModeOfPayment> CreateAsync(ModeOfPayment modeOfPayment);
		Task<ModeOfPayment> GetAsync(string id);
		Task DeleteAsync(string id);
		Task<EntityCollection<ModeOfPayment>> FindAsync(ModeOfPaymentSearch searchSettings);
	}
}
