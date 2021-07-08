using System.Net.Http;
using Fortnox.SDK.Search;

namespace Fortnox.SDK.Interfaces
{
    public interface IConnector
    {
        // Credentials
        string AccessToken { get; }
        string ClientSecret { get; }

        // Config
        HttpClient HttpClient { get; }
        bool UseRateLimiter { get; }
    }

    public interface IEntityConnector : IConnector
    {
    }

    public interface ISearchableEntityConnector<TSearchSettings> : IEntityConnector where TSearchSettings : BaseSearch
    {
    }
}
