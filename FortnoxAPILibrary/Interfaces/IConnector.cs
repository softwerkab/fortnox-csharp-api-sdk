using System;
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
        //Base search params
        int? Limit { get; set; }
        DateTime? LastModified { get; set; }
        int? Page { get; set; }
        int? Offset { get; set; }
    }
}
