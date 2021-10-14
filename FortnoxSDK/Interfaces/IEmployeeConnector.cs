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
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        Employee Update(Employee employee);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        Employee Create(Employee employee);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        Employee Get(string id);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        EntityCollection<EmployeeSubset> Find(EmployeeSearch searchSettings);

        Task<Employee> UpdateAsync(Employee employee);
        Task<Employee> CreateAsync(Employee employee);
        Task<Employee> GetAsync(string id);
        Task<EntityCollection<EmployeeSubset>> FindAsync(EmployeeSearch searchSettings);
    }
}
