using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class ProjectConnector : EntityConnector<Project, EntityCollection<ProjectSubset>, Sort.By.Project?>, IProjectConnector
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.Project? FilterBy { get; set; }


		/// <remarks/>
		public ProjectConnector()
		{
			Resource = "projects";
		}

		/// <summary>
		/// Find a project based on id
		/// </summary>
		/// <param name="id">Identifier of the project to find</param>
		/// <returns>The found project</returns>
		public Project Get(string id)
		{
			return BaseGet(id.ToString());
		}

		/// <summary>
		/// Updates a project
		/// </summary>
		/// <param name="project">The project to update</param>
		/// <returns>The updated project</returns>
		public Project Update(Project project)
		{
			return BaseUpdate(project, project.ProjectNumber.ToString());
		}

		/// <summary>
		/// Creates a new project
		/// </summary>
		/// <param name="project">The project to create</param>
		/// <returns>The created project</returns>
		public Project Create(Project project)
		{
			return BaseCreate(project);
		}

		/// <summary>
		/// Deletes a project
		/// </summary>
		/// <param name="id">Identifier of the project to delete</param>
		public void Delete(string id)
		{
			BaseDelete(id.ToString());
		}

		/// <summary>
		/// Gets a list of projects
		/// </summary>
		/// <returns>A list of projects</returns>
		public EntityCollection<ProjectSubset> Find()
		{
			return BaseFind();
		}

		public async Task<EntityCollection<ProjectSubset>> FindAsync()
		{
			return await BaseFind();
		}
		public async Task DeleteAsync(string id)
		{
			await BaseDelete(id.ToString());
		}
		public async Task<Project> CreateAsync(Project project)
		{
			return await BaseCreate(project);
		}
		public async Task<Project> UpdateAsync(Project project)
		{
			return await BaseUpdate(project, project.ProjectNumber.ToString());
		}
		public async Task<Project> GetAsync(string id)
		{
			return await BaseGet(id.ToString());
		}
	}
}
