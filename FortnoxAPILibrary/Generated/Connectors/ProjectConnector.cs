using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class ProjectConnector : EntityConnector<Project, EntityCollection<ProjectSubset>, Sort.By.Project?>
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.Project FilterBy { get; set; }


		/// <remarks/>
		public ProjectConnector()
		{
			Resource = "projects";
		}

		/// <summary>
		/// Find a project based on projectnumber
		/// </summary>
		/// <param name="projectNumber">The projectnumber to find</param>
		/// <returns>The found project</returns>
		public Project Get(string projectNumber)
		{
			return BaseGet(projectNumber);
		}

		/// <summary>
		/// Updates a project
		/// </summary>
		/// <param name="project">The project to update</param>
		/// <returns>The updated project</returns>
		public Project Update(Project project)
		{
			return BaseUpdate(project, project.ProjectNumber);
		}

		/// <summary>
		/// Create a new project
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
		/// <param name="projectNumber">The projectnumber to delete</param>
		public void Delete(string projectNumber)
		{
			BaseDelete(projectNumber);
		}

		/// <summary>
		/// Gets a list of projects
		/// </summary>
		/// <returns>A list of projects</returns>
		public EntityCollection<ProjectSubset> Find()
		{
			return BaseFind();
		}
	}
}
