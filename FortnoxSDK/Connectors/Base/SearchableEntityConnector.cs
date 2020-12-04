using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Requests;
using Fortnox.SDK.Search;

namespace Fortnox.SDK.Connectors.Base
{
    public class SearchableEntityConnector<TEntity, TEntitySubset, TSearchSettings> : EntityConnector<TEntity> 
        where TEntity : class 
        where TSearchSettings : BaseSearch, new()
    {
        protected async Task<EntityCollection<TEntitySubset>> BaseFind(BaseSearch searchSettings)
        {
            var request = new SearchRequest<TEntitySubset>()
            {
                BaseUrl = BaseUrl,
                Resource = Resource,
                SearchSettings = searchSettings
            };

            return await SendAsync(request).ConfigureAwait(false);
        }
        
        protected async Task<EntityCollection<T>> SendAsync<T>(SearchRequest<T> request)
        {
            if (request.SearchSettings != null && request.SearchSettings.Limit == APIConstants.Unlimited)
                return await GetAllInOnePage(request).ConfigureAwait(false);
            else
                return await GetSinglePage(request).ConfigureAwait(false);
        }

        private async Task<EntityCollection<T>> GetAllInOnePage<T>(SearchRequest<T> request)
        {
            var page = 1;
            var allEntities = new List<T>();
            while (true)
            {
                var singlePageRequest = Clone(request);
                singlePageRequest.SearchSettings.Page = page;
                singlePageRequest.SearchSettings.Limit = APIConstants.MaxLimit;

                var result = await GetSinglePage(singlePageRequest).ConfigureAwait(false);
                allEntities.AddRange(result.Entities);

                if (result.CurrentPage >= result.TotalPages)
                    break;
                page++;
            }

            var collection = new EntityCollection<T>()
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
        
        private async Task<EntityCollection<T>> GetSinglePage<T>(SearchRequest<T> request)
        {
            if (request.SearchSettings != null)
            {
                var searchParameters = request.SearchSettings.GetSearchParameters();
                foreach (var parameter in searchParameters)
                    request.Parameters.Add(parameter.Key, parameter.Value);
            }

            var responseData = await SendAsync((BaseRequest)request).ConfigureAwait(false);
            var responseJson = Encoding.UTF8.GetString(responseData);

            return Serializer.Deserialize<EntityCollection<T>>(responseJson);
        }

        private static SearchRequest<T> Clone<T>(SearchRequest<T> request)
        {
            return new SearchRequest<T>()
            {
                BaseUrl = request.BaseUrl,
                Resource = request.Resource,
                Headers = request.Headers,
                Indices = request.Indices,
                Method = request.Method,
                Parameters = new Dictionary<string, string>(request.Parameters),
                SearchSettings = Clone(request.SearchSettings),
                Content = request.Content?.ToArray()
            };
        }

        private static T Clone<T>(T obj) where T : BaseSearch
        {
            var memberwiseClone = obj?.GetType().GetMethod("MemberwiseClone", BindingFlags.Instance | BindingFlags.NonPublic);
            return (T) memberwiseClone?.Invoke(obj, null);
        }
    }
}