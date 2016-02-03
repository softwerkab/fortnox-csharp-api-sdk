using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FortnoxAPILibrary.Connectors
{

	/// <remarks/>
	public class PreDefinedVoucherSeriesConnector : FinancialYearBasedEntityConnector<PreDefinedVoucherSeries, PreDefinedVoucherSeriesCollection, Sort.By.PreDefinedVoucherSeries>
    {
		/// <remarks/>
		public PreDefinedVoucherSeriesConnector(string accessToken, string clientSecret) : base(accessToken, clientSecret)
        {
			base.Resource = "predefinedvoucherseries";
		}

		/// <remarks/>
		public enum PreDefinedVoucherSeriesName
		{
			/// <remarks/>
			ANL,
			/// <remarks/>
			CASHINVOICE,
			/// <remarks/>
			INVOICE,
			/// <remarks/>
			INVOICEACCRUAL,
			/// <remarks/>
			INVOICEPAYMENT,
			/// <remarks/>
			SALARY,
			/// <remarks/>
			SUPPLIERINVOICE,
			/// <remarks/>
			SUPPLIERINVOICEACCRUAL,
			/// <remarks/>
			SUPPLIERINVOICEPAYMENT,
            /// <remarks/>
            VAT
		}

		/// <summary>
		/// Finds a pre defined voucher series by name
		/// </summary>
		/// <param name="name">The name of the voucher series to find</param>
		/// <returns>The found voucher series</returns>
		public PreDefinedVoucherSeries Get(PreDefinedVoucherSeriesName name)
		{
			return base.BaseGet(name.ToString());
		}

		/// <summary>
		/// Updates a pre defined voucher series
		/// </summary>
		/// <param name="preDefinedVoucherSeries">The voucher series to update</param>
		/// <returns></returns>
		public PreDefinedVoucherSeries Update(PreDefinedVoucherSeries preDefinedVoucherSeries)
		{
			return base.BaseUpdate(preDefinedVoucherSeries, preDefinedVoucherSeries.Name.ToString());
		}


		/// <summary>
		/// Gets a list of pre defined voucher series
		/// </summary>
		/// <returns></returns>
		public PreDefinedVoucherSeriesCollection Find()
		{
			return base.BaseFind();
		}
	}
}
