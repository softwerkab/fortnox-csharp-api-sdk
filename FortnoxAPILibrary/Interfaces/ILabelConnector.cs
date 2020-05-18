using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface ILabelConnector : IConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.Label? SortBy { get; set; }
		Filter.Label? FilterBy { get; set; }


		Label Update(Label label);
		Label Create(Label label);
		void Delete(int? id);
		EntityCollection<Label> Find();

		Task<Label> UpdateAsync(Label label);
		Task<Label> CreateAsync(Label label);
		Task DeleteAsync(int? id);
		Task<EntityCollection<Label>> FindAsync();
	}
}
