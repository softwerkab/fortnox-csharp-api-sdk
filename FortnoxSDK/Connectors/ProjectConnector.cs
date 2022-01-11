using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;

namespace Fortnox.SDK.Connectors;

internal class ProjectConnector : SearchableEntityConnector<Project, ProjectSubset, ProjectSearch>, IProjectConnector
{
    public ProjectConnector()
    {
        Endpoint = Endpoints.Projects;
    }

    public async Task<EntityCollection<ProjectSubset>> FindAsync(ProjectSearch searchSettings)
    {
        return await BaseFind(searchSettings).ConfigureAwait(false);
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