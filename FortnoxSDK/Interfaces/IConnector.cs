using System.Net.Http;
using Fortnox.SDK.Authorization;
using Fortnox.SDK.Search;

namespace Fortnox.SDK.Interfaces;

public interface IConnector
{
    // Credentials
    FortnoxAuthorization Authorization { get; }

    // Config
    HttpClient HttpClient { get; }
    bool UseRateLimiter { get; }
    bool UseHttp2 { get; }
}

public interface IEntityConnector : IConnector
{
}

public interface ISearchableEntityConnector<TSearchSettings> : IEntityConnector where TSearchSettings : BaseSearch
{
}