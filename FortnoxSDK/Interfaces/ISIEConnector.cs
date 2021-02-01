using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Fortnox.SDK.Interfaces
{
    public interface ISIEConnector : IConnector
    {
        byte[] Get(SIEType type, long? finYearID = null);
        Task<byte[]> GetAsync(SIEType type, long? finYearID = null);
    }

    public enum SIEType
    {
        [EnumMember(Value = "1")]
        YearBalance,
        [EnumMember(Value = "2")]
        PeriodBalance,
        [EnumMember(Value = "3")]
        ObjectBalance,
        [EnumMember(Value = "4")]
        Transactions
    }
}
