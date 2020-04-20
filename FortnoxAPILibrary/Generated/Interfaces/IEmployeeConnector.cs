using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IEmployeeConnector
	{
        [SearchParameter("filter")]
		Filter.Employee? FilterBy { get; set; }

		Employee Update(Employee employee);

		Employee Create(Employee employee);

		Employee Get(string id);

        EntityCollection<EmployeeSubset> Find();

	}
}
