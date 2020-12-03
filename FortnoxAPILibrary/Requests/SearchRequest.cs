using System.Net.Http;

namespace FortnoxAPILibrary.Requests
{
    public class SearchRequest<TEntity> : BaseRequest
    {
        public SearchRequest()
        {
            Method = HttpMethod.Get;
        }
        public BaseSearch SearchSettings { get; set; }
    }
}
