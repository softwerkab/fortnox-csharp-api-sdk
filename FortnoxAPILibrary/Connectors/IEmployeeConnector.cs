using System;
using FortnoxAPILibrary.Entities;

namespace FortnoxAPILibrary.Connectors
{
    /// <summary>
    /// Connector to employees endpoint
    /// </summary>
    public interface IEmployeeConnector : IEntityConnector<Sort.By.Employee>
    {
        /// <remarks/>
        Filter.Employee FilterBy { get; set; }

        /// <summary>
        /// Find an employee based on employeeId
        /// </summary>
        /// <param name="employeeId">The employeeId to find</param>
        /// <returns>The found employee</returns>
        Employee Get(string employeeId);

        /// <summary>
        /// Updates an employee
        /// </summary>
        /// <param name="employee">The employee to update</param>
        /// <returns>The updated employee</returns>
        Employee Update(Employee employee);

        /// <summary>
        /// Create a new employee
        /// </summary>
        /// <param name="employee">The employee to create</param>
        /// <returns>The created employee</returns>
        Employee Create(Employee employee);

        /// <summary>
        /// Gets a list of employees
        /// </summary>
        /// <returns>A list of employees</returns>
        Employees Find();
    }

    /// <summary>
    /// Connector to employees endpoint
    /// </summary>
    public class EmployeeConnector : EntityConnector<Employee, Employees, Sort.By.Employee>, IEmployeeConnector
    {
        /// <summary>
        /// Implementation of connector to employees endpoint
        /// </summary>
        public EmployeeConnector()
        {
            Resource = "employees";
        }

        /// <inheritdoc />
        public Filter.Employee FilterBy { get; set; }

        /// <inheritdoc />
        public Employee Get(string employeeId)
        {
            return BaseGet(employeeId);
        }

        /// <inheritdoc />
        public Employee Update(Employee employee)
        {
            if (string.IsNullOrEmpty(employee.EmployeeId))
                throw new ArgumentException("Employee must have an employee id to be able to update", nameof(employee.EmployeeId));

            return BaseUpdate(employee, employee.EmployeeId);
        }

        /// <inheritdoc />
        public Employee Create(Employee employee)
        {
            return BaseCreate(employee);
        }

        /// <inheritdoc />
        public Employees Find()
        {
            return BaseFind();
        }
    }
}