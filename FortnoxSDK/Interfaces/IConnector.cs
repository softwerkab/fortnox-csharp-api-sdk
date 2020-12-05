using Fortnox.SDK.Search;

namespace Fortnox.SDK.Interfaces
{
    public interface IConnector
    {
        // Credentials
        string AccessToken { get; set; }
        string ClientSecret { get; set; }
    }

    public interface IEntityConnector : IConnector
    {
    }

    public interface ISearchableEntityConnector<TSearchSettings> : IEntityConnector where TSearchSettings : BaseSearch
    {
    }
}
