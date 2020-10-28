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
        DateTime? LastModified { get; set; }
        public long? FinancialYearID { get; set; }
        public DateTime? FinancialYearDate { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        int? Page { get; set; }
        int? Offset { get; set; }
        int? Limit { get; set; }
    }
}
