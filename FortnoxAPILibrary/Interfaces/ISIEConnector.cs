using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace FortnoxAPILibrary.Connectors
{
    public interface ISIEConnector : IConnector
    {
        byte[] Get(SIEType type);
        Task<byte[]> GetAsync(SIEType type);
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
