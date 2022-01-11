using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces;

/// <remarks/>
public interface IProjectConnector : IEntityConnector
{
    Task<Project> UpdateAsync(Project project);
    Task<Project> CreateAsync(Project project);
    Task<Project> GetAsync(string id);
    Task DeleteAsync(string id);
    Task<EntityCollection<ProjectSubset>> FindAsync(ProjectSearch searchSettings);
}