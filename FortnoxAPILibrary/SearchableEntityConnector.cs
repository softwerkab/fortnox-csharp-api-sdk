using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FortnoxAPILibrary.Entities;

namespace FortnoxAPILibrary
{
    public class SearchableEntityConnector<TEntity, TEntitySubset, TSearchSettings> : EntityConnector<TEntity> 
        where TEntity : class 
        where TSearchSettings : BaseSearch, new()
    {
        public TSearchSettings Search { get; set; } = new TSearchSettings();

        internal async Task<EntityCollection<TEntitySubset>> BaseFind(params string[] indices)
        {
            var searchSettings = Search.Clone();
            if (searchSettings.Page == APIConstants.AllInOnePage)
                return await GetAllInOnePage(searchSettings, indices);
            else
                return await GetSinglePage(searchSettings, indices);
        }

        private async Task<EntityCollection<TEntitySubset>> GetAllInOnePage(BaseSearch searchSettings, string[] indices)
        {
            searchSettings.Limit = APIConstants.MaxLimit;
            searchSettings.Page = 1;

            var allEntities = new List<TEntitySubset>();
            while (true)
            {
                var result = await GetSinglePage(searchSettings, indices);
                if (HasError)
                    return null;
                allEntities.AddRange(result.Entities);
                if (result.CurrentPage >= result.TotalPages)
                    break;
                searchSettings.Page++;
            }

            var collection = new EntityCollection<TEntitySubset>()
            {
                Entities = allEntities,
                MetaInformation = new MetaInformation()
                {
                    TotalPages = allEntities.Count > 0 ? 1 : 0,
                    CurrentPage = 1,
                    TotalResources = allEntities.Count
                }
            };
            return collection;
        }

        private async Task<EntityCollection<TEntitySubset>> GetSinglePage(BaseSearch searchSettings, string[] indices)
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
    }
}