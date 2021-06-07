using System.Net.Http;
using Fortnox.SDK.Search;

namespace Fortnox.SDK.Interfaces
{
    public interface IConnector
    {
        // Credentials
        string AccessToken { get; set; }
        string ClientSecret { get; set; }

        // Config
        HttpClient HttpClient { get; set; }
        bool UseRateLimiter { get; set; }
    }

    public interface IEntityConnector : IConnector
    {
    }

    public interface ISearchableEntityConnector<TSearchSettings> : IEntityConnector where TSearchSettings : BaseSearch
    {
    }
}
