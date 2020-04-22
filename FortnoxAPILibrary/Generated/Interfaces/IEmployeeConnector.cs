using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;
// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IEmployeeConnector : IConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.Employee? SortBy { get; set; }
		Filter.Employee? FilterBy { get; set; }


		Employee Update(Employee employee);
		Employee Create(Employee employee);
		Employee Get(string id);
        EntityCollection<EmployeeSubset> Find();
	}
}
