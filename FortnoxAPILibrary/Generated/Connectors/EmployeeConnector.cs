using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class EmployeeConnector : EntityConnector<Employee, EntityCollection<EmployeeSubset>, Sort.By.Employee?>
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.Employee FilterBy { get; set; }


		/// <remarks/>
		public EmployeeConnector()
		{
			Resource = "employees";
		}

		/// <summary>
		/// Find a employee based on employeenumber
		/// </summary>
		/// <param name="employeeNumber">The employeenumber to find</param>
		/// <returns>The found employee</returns>
		public Employee Get(string employeeNumber)
		{
			return BaseGet(employeeNumber);
		}

		/// <summary>
		/// Updates a employee
		/// </summary>
		/// <param name="employee">The employee to update</param>
		/// <returns>The updated employee</returns>
		public Employee Update(Employee employee)
		{
			return BaseUpdate(employee, employee.EmployeeNumber);
		}

		/// <summary>
		/// Create a new employee
		/// </summary>
		/// <param name="employee">The employee to create</param>
		/// <returns>The created employee</returns>
		public Employee Create(Employee employee)
		{
			return BaseCreate(employee);
		}

		/// <summary>
		/// Deletes a employee
		/// </summary>
		/// <param name="employeeNumber">The employeenumber to delete</param>
		public void Delete(string employeeNumber)
		{
			BaseDelete(employeeNumber);
		}

		/// <summary>
		/// Gets a list of employees
		/// </summary>
		/// <returns>A list of employees</returns>
		public EntityCollection<EmployeeSubset> Find()
		{
			return BaseFind();
		}
	}
}
