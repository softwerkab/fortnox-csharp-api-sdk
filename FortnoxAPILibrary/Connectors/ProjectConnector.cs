using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FortnoxAPILibrary.Entities;

namespace FortnoxAPILibrary.Connectors
{
	/// <remarks/>
	public class ProjectConnector : EntityConnector<Project, Projects, Sort.By.Project>
	{

		/// <remarks/>
		public enum Status
		{
			/// <remarks/>
			NOTSTARTED,
			/// <remarks/>
			ONGOING,
			/// <remarks/>
			COMPLETED
		}

		/// <summary>
		/// Use with Find() to limit the search result
		/// </summary>
        [FilterProperty]
		public string Description { get; set; }

		/// <summary>
		/// Use with Find() to limit the search result
        /// </summary>
        [FilterProperty]
		public string ProjectLeader { get; set; }

		/// <remarks/>
		public ProjectConnector()
		{
			base.Resource = "projects";
		}

		/// <summary>
		/// Gets a project based on project number
		/// </summary>
		/// <param name="projectNumber">The project number to find</param>
		/// <returns>The found project</returns>
		public Project Get(string projectNumber)
		{
			return base.BaseGet(projectNumber);
		}

		/// <summary>
		/// Updates a project
		/// </summary>
		/// <param name="project">The project to update</param>
		/// <returns>The updated project</returns>
		public Project Update(Project project)
		{
			return base.BaseUpdate(project, project.ProjectNumber.ToString());
		}

		/// <summary>
		/// Creates a new project
		/// </summary>
		/// <param name="project"> The project to Create</param>
		/// <returns>The created project</returns>
		public Project Create(Project project)
		{
			return base.BaseCreate(project);
		}

		/// <summary>
		/// Deletes a project
		/// </summary>
		/// <param name="projectNumber">The project number of the project to delete</param>
		/// <returns>If the project was deleted or not</returns>
		public void Delete(string projectNumber)
		{
			base.BaseDelete(projectNumber);
		}

		/// <summary>
		/// Gets at list of project, use the properties of ProjectConnector to limit the search
		/// </summary>
		/// <returns>A list of projects</returns>
		public Projects Find()
		{
			return base.BaseFind();
		}
	}
}
