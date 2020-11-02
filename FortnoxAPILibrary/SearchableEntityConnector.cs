using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FortnoxAPILibrary.Entities;

namespace FortnoxAPILibrary
{
    public class SearchableEntityConnector<TEntity, TEntitySubset> : EntityConnector<TEntity> where TEntity : class
    {
        internal async Task<EntityCollection<TEntitySubset>> BaseFind(params string[] indices)
        {
            var search = GetSearchSettings().Clone();
            if (search.Page != APIConstants.AllInOnePage)
                return await BaseFindSpecificPage(search, indices);

            search.Limit = APIConstants.MaxLimit;
            search.Page = 1;

            var allEntities = new List<TEntitySubset>();
            while (true)
            {
                var result = await BaseFindSpecificPage(search, indices);
                if (HasError)
                    return null;
                allEntities.AddRange(result.Entities);
                if (result.CurrentPage >= result.TotalPages)
                    break;
                search.Page++;
            }

            return new EntityCollection<TEntitySubset>()
            {
                Entities = allEntities,
                MetaInformation = new MetaInformation()
                {
                    TotalPages = allEntities.Count > 0 ? 1 : 0,
                    CurrentPage = 1,
                    TotalResources = allEntities.Count
                }
            };
        }
        private async Task<EntityCollection<TEntitySubset>> BaseFindSpecificPage(BaseSearch searchSettings, params string[] indices)
        {
            RequestInfo = new RequestInfo()
            {
                BaseUrl = BaseUrl,
                Resource = Resource,
                Indices = indices,
                Parameters = ParametersInjection ?? new Dictionary<string, string>(),
                SearchParameters = searchSettings.GetSearchParameters(),
                Method = HttpMethod.Get,
            };
            ParametersInjection = null;

            var result = await DoEntityRequest<EntityCollection<TEntitySubset>>().ConfigureAwait(false);
            return result;
        }
        
        protected BaseSearch GetSearchSettings() => (BaseSearch) GetType().GetProperty("Search").GetValue(this);
    }
}