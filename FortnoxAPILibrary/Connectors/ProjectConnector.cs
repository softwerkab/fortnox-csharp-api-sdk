using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class ProjectConnector : EntityConnector<Project, EntityCollection<ProjectSubset>>, IProjectConnector
	{
		public ProjectSearch Search { get; set; } = new ProjectSearch();

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
			return GetAsync(id).Result;
		}

		/// <summary>
		/// Updates a project
		/// </summary>
		/// <param name="project">The project to update</param>
		/// <returns>The updated project</returns>
		public Project Update(Project project)
		{
			return UpdateAsync(project).Result;
		}

		/// <summary>
		/// Creates a new project
		/// </summary>
		/// <param name="project">The project to create</param>
		/// <returns>The created project</returns>
		public Project Create(Project project)
		{
			return CreateAsync(project).Result;
		}

		/// <summary>
		/// Deletes a project
		/// </summary>
		/// <param name="id">Identifier of the project to delete</param>
		public void Delete(string id)
		{
			DeleteAsync(id).Wait();
		}

		/// <summary>
		/// Gets a list of projects
		/// </summary>
		/// <returns>A list of projects</returns>
		public EntityCollection<ProjectSubset> Find()
		{
			return FindAsync().Result;
		}

		public async Task<EntityCollection<ProjectSubset>> FindAsync()
		{
			return await BaseFind().ConfigureAwait(false);
		}
		public async Task DeleteAsync(string id)
		{
			await BaseDelete(id).ConfigureAwait(false);
		}
		public async Task<Project> CreateAsync(Project project)
		{
			return await BaseCreate(project).ConfigureAwait(false);
		}
		public async Task<Project> UpdateAsync(Project project)
		{
			return await BaseUpdate(project, project.ProjectNumber).ConfigureAwait(false);
		}
		public async Task<Project> GetAsync(string id)
		{
			return await BaseGet(id).ConfigureAwait(false);
		}
	}
}
