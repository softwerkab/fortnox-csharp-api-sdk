using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;
using Fortnox.SDK.Utility;

namespace Fortnox.SDK.Connectors;

internal class EmployeeConnector : SearchableEntityConnector<Employee, EmployeeSubset, EmployeeSearch>, IEmployeeConnector
{
    public EmployeeConnector()
    {
        Endpoint = Endpoints.Employees;
    }

    public Employee Get(string id)
    {
        return GetAsync(id).GetResult();
    }

    public Employee Update(Employee employee)
    {
        return UpdateAsync(employee).GetResult();
    }

    public Employee Create(Employee employee)
    {
        return CreateAsync(employee).GetResult();
    }

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