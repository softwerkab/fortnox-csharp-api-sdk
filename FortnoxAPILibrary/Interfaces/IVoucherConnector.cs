using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IVoucherConnector : IConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.Voucher? SortBy { get; set; }
		Filter.Voucher? FilterBy { get; set; }

		string CostCenter { get; set; }

        Voucher Create(Voucher voucher);
		Voucher Get(int? id, string seriesId, int? financialYearId);
        EntityCollection<VoucherSubset> Find();

        Task<Voucher> CreateAsync(Voucher voucher);
		Task<Voucher> GetAsync(int? id, string seriesId, int? financialYearId);
        Task<EntityCollection<VoucherSubset>> FindAsync();
	}
}
