using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IContractAccrualConnector : IEntityConnector
	{
		ContractAccrualSearch Search { get; set; }


		ContractAccrual Update(ContractAccrual contractAccrual);
		ContractAccrual Create(ContractAccrual contractAccrual);
		ContractAccrual Get(long? id);
		void Delete(long? id);
		EntityCollection<ContractAccrualSubset> Find();

		Task<ContractAccrual> UpdateAsync(ContractAccrual contractAccrual);
		Task<ContractAccrual> CreateAsync(ContractAccrual contractAccrual);
		Task<ContractAccrual> GetAsync(long? id);
		Task DeleteAsync(long? id);
		Task<EntityCollection<ContractAccrualSubset>> FindAsync();
	}
}
