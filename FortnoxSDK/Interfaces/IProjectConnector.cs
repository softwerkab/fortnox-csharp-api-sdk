using System;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface IProjectConnector : IEntityConnector
	{
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		Project Update(Project project);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		Project Create(Project project);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		Project Get(string id);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		void Delete(string id);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		EntityCollection<ProjectSubset> Find(ProjectSearch searchSettings);

		Task<Project> UpdateAsync(Project project);
		Task<Project> CreateAsync(Project project);
		Task<Project> GetAsync(string id);
		Task DeleteAsync(string id);
		Task<EntityCollection<ProjectSubset>> FindAsync(ProjectSearch searchSettings);
	}
}
