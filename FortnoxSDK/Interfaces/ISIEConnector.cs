using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Fortnox.SDK.Interfaces
{
    public interface ISIEConnector : IConnector
    {
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        byte[] Get(SIEType type, long? finYearID = null, SIEExportOptions exportOptions = null);

        Task<byte[]> GetAsync(SIEType type, long? finYearID = null, SIEExportOptions exportOptions = null);
    }

    public enum SIEType
    {
        /// <summary> SIE Type 1 </summary>
        [EnumMember(Value = "1")]
        YearBalance,
        /// <summary> SIE Type 2 </summary>
        [EnumMember(Value = "2")]
        PeriodBalance,
        /// <summary> SIE Type 3 </summary>
        [EnumMember(Value = "3")]
        ObjectBalance,
        /// <summary> SIE Type 4 </summary>
        [EnumMember(Value = "4")]
        Transactions
    }

    /// <summary>
    /// Export parameters to filter SIE content.
    /// NOTE: Parameters are not documented in API documentation, but expected behavior is similar to the export options in GUI.
    /// </summary>
    public class SIEExportOptions
    {
        /// <summary>
        /// Include unused accounts, cost centres and projects
        /// By default, the unused entities seems to be included. To exclude them, set this to false.
        /// </summary>
        public bool? ExportAll;

        public IList<VoucherSelection> Selection;

        public DateTime? FromDate;

        public DateTime? ToDate;
    }

    public class VoucherSelection
    {
        /// <summary>
        /// The code of the voucher series
        /// </summary>
        public string VoucherSeries { get; set; }
        public long? FromVoucherNumber { get; set; }
        public long? ToVoucherNumber { get; set; }
    }
}
