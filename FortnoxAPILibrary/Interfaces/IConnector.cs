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
    }

    public interface IEntityConnector : IConnector
    {
        //Base search params
        public long? FinancialYearID { get; set; }
        public DateTime? FinancialYearDate { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        int? Page { get; set; }
        int? Offset { get; set; }
        int? Limit { get; set; }
    }
}
