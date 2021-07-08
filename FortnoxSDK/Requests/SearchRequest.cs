using System.Net.Http;
using Fortnox.SDK.Search;

namespace Fortnox.SDK.Requests
{
    internal class SearchRequest<TEntity> : BaseRequest
    {
        public SearchRequest()
        {
            Method = HttpMethod.Get;
        }
        public BaseSearch SearchSettings { get; set; }
    }
}
