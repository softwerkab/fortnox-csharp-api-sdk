using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FortnoxAPILibrary.Entities;

namespace FortnoxAPILibrary.Connectors
{
	/// <remarks/>
	public class VoucherSeriesConnector : FinancialYearBasedEntityConnector<VoucherSeries, VoucherSeriesCollection, Sort.By.VoucherSeries>
	{
		/// <remarks/>
		public VoucherSeriesConnector()
		{
			base.Resource = "voucherseries";
		}

		/// <summary>
		/// Find a Voucher series by code
		/// </summary>
		/// <param name="code">The voucher series code to find</param>
		/// <returns>The found voucher series</returns>
		public VoucherSeries Get(string code)
		{
			return base.BaseGet(code);
		}

		/// <summary>
		/// Updates a vocuher series
		/// </summary>
		/// <param name="voucherSeries">The voucher series to update</param>
		/// <returns>The updated voucher series</returns>
		public VoucherSeries Update(VoucherSeries voucherSeries)
		{

			return base.BaseUpdate(voucherSeries, voucherSeries.Code);
		}

		/// <summary>
		/// Creates a new voucher series
		/// </summary>
		/// <param name="voucherseries">The voucher series to create</param>
		/// <returns>The created voucher series</returns>
		public VoucherSeries Create(VoucherSeries voucherseries)
		{
			return base.BaseCreate(voucherseries);
		}

		/// <summary>
		/// Gets a list of voucher series
		/// </summary>
		/// <returns>A list of voucher series</returns>
		public VoucherSeriesCollection Find()
		{
			return base.BaseFind();
		}
	}
}
