using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface IEmployeeConnector : IEntityConnector
	{


		Employee Update(Employee employee);
		Employee Create(Employee employee);
		Employee Get(string id);
        EntityCollection<EmployeeSubset> Find(EmployeeSearch searchSettings);

		Task<Employee> UpdateAsync(Employee employee);
		Task<Employee> CreateAsync(Employee employee);
		Task<Employee> GetAsync(string id);
        Task<EntityCollection<EmployeeSubset>> FindAsync(EmployeeSearch searchSettings);
	}
}
