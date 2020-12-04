using Fortnox.SDK.Search;

namespace Fortnox.SDK.Interfaces
{
    public interface IBaseConnector
    {
        //Error Handling
        //bool HasError { get; }
        //ErrorInformation Error { get; }
    }

    public interface IConnector : IBaseConnector //TODO: Rename to IResourceConnector
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
