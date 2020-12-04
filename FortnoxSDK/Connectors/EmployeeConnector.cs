using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;
using Fortnox.SDK.Utility;

// ReSharper disable UnusedMember.Global

namespace Fortnox.SDK.Connectors
{
    /// <remarks/>
    public class EmployeeConnector : SearchableEntityConnector<Employee, EmployeeSubset, EmployeeSearch>, IEmployeeConnector
	{

        /// <remarks/>
		public EmployeeConnector()
		{
			Resource = "employees";
		}

		/// <summary>
		/// Find a employee based on id
		/// </summary>
		/// <param name="id">Identifier of the employee to find</param>
		/// <returns>The found employee</returns>
		public Employee Get(string id)
		{
			return GetAsync(id).GetResult();
		}

		/// <summary>
		/// Updates a employee
		/// </summary>
		/// <param name="employee">The employee to update</param>
		/// <returns>The updated employee</returns>
		public Employee Update(Employee employee)
		{
			return UpdateAsync(employee).GetResult();
		}

		/// <summary>
		/// Creates a new employee
		/// </summary>
		/// <param name="employee">The employee to create</param>
		/// <returns>The created employee</returns>
		public Employee Create(Employee employee)
		{
			return CreateAsync(employee).GetResult();
		}

        /// <summary>
		/// Gets a list of employees
		/// </summary>
		/// <returns>A list of employees</returns>
		public EntityCollection<EmployeeSubset> Find(EmployeeSearch searchSettings)
		{
			return FindAsync(searchSettings).GetResult();
		}

		public async Task<EntityCollection<EmployeeSubset>> FindAsync(EmployeeSearch searchSettings)
		{
			return await BaseFind(searchSettings).ConfigureAwait(false);
		}
		public async Task<Employee> CreateAsync(Employee employee)
		{
			return await BaseCreate(employee).ConfigureAwait(false);
		}
		public async Task<Employee> UpdateAsync(Employee employee)
		{
			return await BaseUpdate(employee, employee.EmployeeId).ConfigureAwait(false);
		}
		public async Task<Employee> GetAsync(string id)
		{
			return await BaseGet(id).ConfigureAwait(false);
		}
	}
}
