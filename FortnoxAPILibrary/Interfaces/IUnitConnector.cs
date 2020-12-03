using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IUnitConnector : IEntityConnector
	{


		Unit Update(Unit unit);
		Unit Create(Unit unit);
		Unit Get(string id);
		void Delete(string id);
		EntityCollection<Unit> Find(UnitSearch searchSettings);

		Task<Unit> UpdateAsync(Unit unit);
		Task<Unit> CreateAsync(Unit unit);
		Task<Unit> GetAsync(string id);
		Task DeleteAsync(string id);
		Task<EntityCollection<Unit>> FindAsync(UnitSearch searchSettings);
	}
}
