using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FortnoxAPILibrary.Connectors
{
    public interface IPreDefinedVoucherSeriesConnector : IFinancialYearBasedEntityConnector<PreDefinedVoucherSeries, PreDefinedVoucherSeriesCollection, Sort.By.PreDefinedVoucherSeries>
    {
        /// <summary>
        /// Finds a pre defined voucher series by name
        /// </summary>
        /// <param name="name">The name of the voucher series to find</param>
        /// <returns>The found voucher series</returns>
        PreDefinedVoucherSeries Get(PreDefinedVoucherSeriesConnector.PreDefinedVoucherSeriesName name);

        /// <summary>
        /// Updates a pre defined voucher series
        /// </summary>
        /// <param name="preDefinedVoucherSeries">The voucher series to update</param>
        /// <returns></returns>
        PreDefinedVoucherSeries Update(PreDefinedVoucherSeries preDefinedVoucherSeries);

        /// <summary>
        /// Gets a list of pre defined voucher series
        /// </summary>
        /// <returns></returns>
        PreDefinedVoucherSeriesCollection Find();
    }

    /// <remarks/>
	public class PreDefinedVoucherSeriesConnector : FinancialYearBasedEntityConnector<PreDefinedVoucherSeries, PreDefinedVoucherSeriesCollection, Sort.By.PreDefinedVoucherSeries>, IPreDefinedVoucherSeriesConnector
    {
		/// <remarks/>
		public PreDefinedVoucherSeriesConnector()
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
