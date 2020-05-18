using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IModeOfPaymentConnector : IConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.ModeOfPayment? SortBy { get; set; }
		Filter.ModeOfPayment? FilterBy { get; set; }

		string Code { get; set; }

		ModeOfPayment Update(ModeOfPayment modeOfPayment);
		ModeOfPayment Create(ModeOfPayment modeOfPayment);
		ModeOfPayment Get(string id);
		void Delete(string id);
		EntityCollection<ModeOfPayment> Find();

		Task<ModeOfPayment> UpdateAsync(ModeOfPayment modeOfPayment);
		Task<ModeOfPayment> CreateAsync(ModeOfPayment modeOfPayment);
		Task<ModeOfPayment> GetAsync(string id);
		Task DeleteAsync(string id);
		Task<EntityCollection<ModeOfPayment>> FindAsync();
	}
}
