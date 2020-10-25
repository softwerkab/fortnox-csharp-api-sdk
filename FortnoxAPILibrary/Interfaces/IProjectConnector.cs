using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IProjectConnector : IEntityConnector
	{
		ProjectSearch Search { get; set; }

		Project Update(Project project);
		Project Create(Project project);
		Project Get(string id);
		void Delete(string id);
		EntityCollection<ProjectSubset> Find();

		Task<Project> UpdateAsync(Project project);
		Task<Project> CreateAsync(Project project);
		Task<Project> GetAsync(string id);
		Task DeleteAsync(string id);
		Task<EntityCollection<ProjectSubset>> FindAsync();
	}
}
