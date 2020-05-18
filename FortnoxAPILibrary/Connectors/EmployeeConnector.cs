using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class EmployeeConnector : EntityConnector<Employee, EntityCollection<EmployeeSubset>, Sort.By.Employee?>, IEmployeeConnector
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.Employee? FilterBy { get; set; }

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
			return GetAsync(id).Result;
		}

		/// <summary>
		/// Updates a employee
		/// </summary>
		/// <param name="employee">The employee to update</param>
		/// <returns>The updated employee</returns>
		public Employee Update(Employee employee)
		{
			return UpdateAsync(employee).Result;
		}

		/// <summary>
		/// Creates a new employee
		/// </summary>
		/// <param name="employee">The employee to create</param>
		/// <returns>The created employee</returns>
		public Employee Create(Employee employee)
		{
			return CreateAsync(employee).Result;
		}

        /// <summary>
		/// Gets a list of employees
		/// </summary>
		/// <returns>A list of employees</returns>
		public EntityCollection<EmployeeSubset> Find()
		{
			return FindAsync().Result;
		}

		public async Task<EntityCollection<EmployeeSubset>> FindAsync()
		{
			return await BaseFind();
		}
		public async Task<Employee> CreateAsync(Employee employee)
		{
			return await BaseCreate(employee);
		}
		public async Task<Employee> UpdateAsync(Employee employee)
		{
			return await BaseUpdate(employee, employee.EmployeeId);
		}
		public async Task<Employee> GetAsync(string id)
		{
			return await BaseGet(id);
		}
	}
}
