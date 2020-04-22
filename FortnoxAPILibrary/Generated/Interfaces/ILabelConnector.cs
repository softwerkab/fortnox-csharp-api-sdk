using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface ILabelConnector : IConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.Label? SortBy { get; set; }

        [SearchParameter("filter")]
		Filter.Label? FilterBy { get; set; }

		Label Update(Label label);

		Label Create(Label label);

		void Delete(int? id);

		EntityCollection<Label> Find();

	}
}
