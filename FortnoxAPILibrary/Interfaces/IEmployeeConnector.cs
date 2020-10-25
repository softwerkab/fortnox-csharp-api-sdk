using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IEmployeeConnector : IEntityConnector
	{
		EmployeeSearch Search { get; set; }


		Employee Update(Employee employee);
		Employee Create(Employee employee);
		Employee Get(string id);
        EntityCollection<EmployeeSubset> Find();

		Task<Employee> UpdateAsync(Employee employee);
		Task<Employee> CreateAsync(Employee employee);
		Task<Employee> GetAsync(string id);
        Task<EntityCollection<EmployeeSubset>> FindAsync();
	}
}
