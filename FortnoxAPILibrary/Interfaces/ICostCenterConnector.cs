using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface ICostCenterConnector : IEntityConnector
	{


		CostCenter Update(CostCenter costCenter);
		CostCenter Create(CostCenter costCenter);
		CostCenter Get(string id);
		void Delete(string id);
		EntityCollection<CostCenter> Find(CostCenterSearch searchSettings);

		Task<CostCenter> UpdateAsync(CostCenter costCenter);
		Task<CostCenter> CreateAsync(CostCenter costCenter);
		Task<CostCenter> GetAsync(string id);
		Task DeleteAsync(string id);
		Task<EntityCollection<CostCenter>> FindAsync(CostCenterSearch searchSettings);
	}
}
