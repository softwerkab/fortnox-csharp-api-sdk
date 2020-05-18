using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IUnitConnector : IConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.Unit? SortBy { get; set; }
		Filter.Unit? FilterBy { get; set; }


		Unit Update(Unit unit);
		Unit Create(Unit unit);
		Unit Get(string id);
		void Delete(string id);
		EntityCollection<Unit> Find();

		Task<Unit> UpdateAsync(Unit unit);
		Task<Unit> CreateAsync(Unit unit);
		Task<Unit> GetAsync(string id);
		Task DeleteAsync(string id);
		Task<EntityCollection<Unit>> FindAsync();
	}
}
