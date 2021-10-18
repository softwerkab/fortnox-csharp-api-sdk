using System;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface IEmployeeConnector : IEntityConnector
    {
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
        Employee Update(Employee employee);
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
        Employee Create(Employee employee);
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
        Employee Get(string id);
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
        EntityCollection<EmployeeSubset> Find(EmployeeSearch searchSettings);

        Task<Employee> UpdateAsync(Employee employee);
        Task<Employee> CreateAsync(Employee employee);
        Task<Employee> GetAsync(string id);
        Task<EntityCollection<EmployeeSubset>> FindAsync(EmployeeSearch searchSettings);
    }
}
