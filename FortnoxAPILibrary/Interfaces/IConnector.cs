using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using FortnoxAPILibrary.Entities;

namespace FortnoxAPILibrary.Connectors
{
    public interface IBaseConnector
    {
        //Error Handling
        bool HasError { get; }
        ErrorInformation Error { get; }
    }

    public interface IConnector : IBaseConnector //TODO: Rename to IResourceConnector
    {
        // Credentials
        string AccessToken { get; set; }
        string ClientSecret { get; set; }
    }

    public interface IEntityConnector : IConnector
    {
        //BaseSearch Search { get; set; }
    }

    public interface ISearchable<TSearch> : IConnector where TSearch : BaseSearch
    {
        TSearch Search { get; set; }
        void Find<TSearchOptions>(TSearchOptions search) where TSearchOptions : BaseSearch;
    }

    public interface ISearchResult<out TEntity>
    {
        //TSearch SearchSettings { get; }
        IEnumerable<TEntity> GetPage(int page);
        IEnumerable<TEntity> GetAll();
    }
}
