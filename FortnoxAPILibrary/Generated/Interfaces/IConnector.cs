using System;
using System.Collections.Generic;
using System.Text;
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
        [SearchParameter]
        int? Limit { get; set; }

        [SearchParameter]
        DateTime? LastModified { get; set; }

        [SearchParameter]
        int? Page { get; set; }

        [SearchParameter]
        int? Offset { get; set; }
    }
}
