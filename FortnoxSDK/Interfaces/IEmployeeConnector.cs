using System;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces;

/// <remarks/>
public interface IEmployeeConnector : IEntityConnector
{
    Task<Employee> UpdateAsync(Employee employee);
    Task<Employee> CreateAsync(Employee employee);
    Task<Employee> GetAsync(string id);
    Task<EntityCollection<EmployeeSubset>> FindAsync(EmployeeSearch searchSettings);
}