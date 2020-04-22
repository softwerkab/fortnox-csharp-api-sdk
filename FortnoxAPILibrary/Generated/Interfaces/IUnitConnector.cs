using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IUnitConnector : IConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.Unit? SortBy { get; set; }

        [SearchParameter("filter")]
		Filter.Unit? FilterBy { get; set; }

		Unit Update(Unit unit);

		Unit Create(Unit unit);

		Unit Get(string id);

		void Delete(string id);

		EntityCollection<Unit> Find();

	}
}
