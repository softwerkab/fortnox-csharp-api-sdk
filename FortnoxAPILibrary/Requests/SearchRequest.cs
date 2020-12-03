using System.Net.Http;

namespace FortnoxAPILibrary.Requests
{
    public class SearchRequest : BaseRequest
    {
        public SearchRequest()
        {
            Method = HttpMethod.Get;
        }
        public BaseSearch SearchSettings { get; set; }
    }
}
