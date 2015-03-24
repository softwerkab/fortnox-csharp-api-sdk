using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class VoucherConnector : FinancialYearBasedEntityConnector<Voucher, Vouchers, Sort.By.Voucher>
    {
        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        public string VoucherSeries { get; set; }

        /// <remarks/>
        public enum ReferenceType
        {
            /// <remarks/>
            INVOICE,
            /// <remarks/>
            INVOICEPAYMENT,
            /// <remarks/>
            SUPPLIERINVOICE,
            /// <remarks/>
            SUPPLIERINVOICEPAYMENT,
            /// <remarks/>
            MANUAL,
            /// <remarks/>
            CASHINVOICE
        }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [FilterProperty]
        public string CostCenter { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [FilterProperty]
        public string FromDate { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [FilterProperty]
        public string ToDate { get; set; }

        /// <remarks/>
        public VoucherConnector()
        {
            base.Resource = "vouchers";
        }

        /// <summary>
        /// Gets a voucher
        /// </summary>
        /// <param name="voucherSeries">The series of the voucher to get</param>
        /// <param name="voucherNumber">The number of the voucher to get</param>
        /// <returns>The found voucher</returns>
        public Voucher Get(string voucherSeries, string voucherNumber)
        {
            base.Resource = "vouchers";

            return base.BaseGet(voucherSeries, voucherNumber);
        }

        /// <summary>
        /// Create a new voucher
        /// </summary>
        /// <param name="voucher">The voucher to create</param>
        /// <returns>The created voucher</returns>
        public Voucher Create(Voucher voucher)
        {
            base.Resource = "vouchers";

            return base.BaseCreate(voucher);
        }

        /// <summary>
        /// Gets a list of vouchers
        /// </summary>
        /// <returns>A list of vouchers</returns>
        public Vouchers Find()
        {
            base.Resource += "/sublist/";

            if (!string.IsNullOrEmpty(this.VoucherSeries))
            {
                base.Resource += this.VoucherSeries;
            }

            return base.BaseFind();
        }
    }
}
