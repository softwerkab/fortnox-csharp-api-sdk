using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IContractAccrualConnector : IConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.ContractAccrual? SortBy { get; set; }
		Filter.ContractAccrual? FilterBy { get; set; }


		ContractAccrual Update(ContractAccrual contractAccrual);
		ContractAccrual Create(ContractAccrual contractAccrual);
		ContractAccrual Get(int? id);
		void Delete(int? id);
		EntityCollection<ContractAccrualSubset> Find();

		Task<ContractAccrual> UpdateAsync(ContractAccrual contractAccrual);
		Task<ContractAccrual> CreateAsync(ContractAccrual contractAccrual);
		Task<ContractAccrual> GetAsync(int? id);
		Task DeleteAsync(int? id);
		Task<EntityCollection<ContractAccrualSubset>> FindAsync();
	}
}
