using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IVoucherConnector : IEntityConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.Voucher? SortBy { get; set; }
		Filter.Voucher? FilterBy { get; set; }

        Voucher Create(Voucher voucher);
		Voucher Get(long? id, string seriesId, long? financialYearId);
        EntityCollection<VoucherSubset> Find();

        Task<Voucher> CreateAsync(Voucher voucher);
		Task<Voucher> GetAsync(long? id, string seriesId, long? financialYearId);
        Task<EntityCollection<VoucherSubset>> FindAsync();
	}
}
