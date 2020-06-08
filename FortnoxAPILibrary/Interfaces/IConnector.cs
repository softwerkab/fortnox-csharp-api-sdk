
using System;
using FortnoxAPILibrary.Entities;
namespace FortnoxAPILibrary.Connectors
{
    public interface IConnector
    {
        // Credentials
        string AccessToken { get; set; }
        string ClientSecret { get; set; }
        //Error Handling
        bool HasError { get; }
        ErrorInformation Error { get; }
        //Base search params
        int? Limit { get; set; }
        DateTime? LastModified { get; set; }
        int? Page { get; set; }
        int? Offset { get; set; }

    }
}
