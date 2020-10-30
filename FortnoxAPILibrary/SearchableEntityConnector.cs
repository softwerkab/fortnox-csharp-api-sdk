using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FortnoxAPILibrary.Entities;

namespace FortnoxAPILibrary
{
    public class SearchableEntityConnector<TEntity, TEntitySubset> : EntityConnector<TEntity> where TEntity : class
    {
        public BaseSearch PagingSettings { get; set; } //TODO: Temporary solution

        internal async Task<EntityCollection<TEntitySubset>> BaseFind(params string[] indices)
        {
            RequestInfo = new RequestInfo()
            {
                BaseUrl = BaseUrl,
                Resource = Resource,
                Indices = indices,
                Parameters = ParametersInjection ?? new Dictionary<string, string>(),
                SearchParameters = GetSearchParameters(),
                Method = HttpMethod.Get,
            };
            ParametersInjection = null;

            var result = await DoEntityRequest<EntityCollection<TEntitySubset>>().ConfigureAwait(false);
            return result;
        }

        protected Dictionary<string, string> GetSearchParameters()
        {
            var searchObjProperty = GetType().GetProperty("Search");
            var searchObj = (BaseSearch)searchObjProperty.GetValue(this);
            return searchObj.GetSearchParameters();
        }
    }
}