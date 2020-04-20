using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IProjectConnector : IConnector
	{
        [SearchParameter("filter")]
		Filter.Project? FilterBy { get; set; }

		Project Update(Project project);

		Project Create(Project project);

		Project Get(string id);

		void Delete(string id);

		EntityCollection<ProjectSubset> Find();

	}
}
