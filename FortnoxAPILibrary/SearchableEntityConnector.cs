using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Requests;

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
            if (searchSettings.Limit == APIConstants.Unlimited)
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
            var request = new SearchRequest()
            {
                BaseUrl = BaseUrl,
                Resource = Resource,
                Indices = indices.ToList(),
                SearchSettings = searchSettings
            };

            return await SendAsync(request).ConfigureAwait(false);
        }

        private async Task<EntityCollection<TEntitySubset>> SendAsync(SearchRequest fortnoxRequest)
        {
            var searchParameters = fortnoxRequest.SearchSettings.GetSearchParameters();
            foreach (var parameter in searchParameters)
                fortnoxRequest.Parameters.Add(parameter.Key, parameter.Value);
            
            var responseData = await SendAsync((BaseRequest)fortnoxRequest).ConfigureAwait(false);
            var responseJson = Encoding.UTF8.GetString(responseData);

            return Serializer.Deserialize<EntityCollection<TEntitySubset>>(responseJson);
        }
    }
}